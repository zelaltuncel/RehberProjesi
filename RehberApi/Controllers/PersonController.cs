using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RehberApi.Models.ORM.Context;
using RehberApi.Models.ORM.Entities;
using RehberApi.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DirectoryContext _directoryContext;

       
        private ProducerConfig _config;

        public PersonController(ProducerConfig config, DirectoryContext directoryContext)
        {
            this._config = config;
            _directoryContext = directoryContext;

        }

        [Route("People")]
        public List<PersonListVM> GetPeople()
        {
            List<PersonListVM> people = _directoryContext.People.Where(q => q.IsDeleted == false).Select(q => new PersonListVM()
            {
                id = q.ID,
                name = q.Name,
                surName = q.SurName,
                company = q.Company
            }).ToList();

            return people;

        }

        [Route("Person/Detail/{id}")]
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            Person person = _directoryContext.People.Find(id);

            if (person != null)
            {
                PersonDetailVM persondetail = _directoryContext.People.Where(q => q.IsDeleted == false).Select(x => new PersonDetailVM()
                {
                    id = x.ID,
                    name = x.Name,
                    surName = x.SurName,
                    company = x.Company,
                    contacts = _directoryContext.ContactInfos.Where(q => q.IsDeleted == false && q.PersonID == id).Select(q => new ContactDetailVM() 
                    {
                        phone = q.Phone,
                        email = q.EMail,
                        address = q.Address,
                        content = q.Content
                    }).ToList()
                }).FirstOrDefault(q => q.id == id);

                return Ok(persondetail);

            }
            else
            {
                return BadRequest("There is no any person has that id!");

            }


        }


        [Route("Person/Add")]
        [HttpPost]

        public IActionResult Add([FromForm] PersonAddVM personAdd)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = personAdd.name;
                person.SurName = personAdd.surName;
                person.Company = personAdd.company;

                _directoryContext.People.Add(person);
                _directoryContext.SaveChanges();

                personAdd.id = person.ID;

                return Ok(personAdd);

            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }


        [Route("Person/Delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] PersonDeleteVM personDelete)
        {
            Person person = _directoryContext.People.Find(personDelete.id);

            if (person != null)
            {
                person.IsDeleted = true;
                _directoryContext.SaveChanges();

                return Ok(person);
            }
            else
            {
                return BadRequest("There is no any person has that id!");
            }
        }

  
        [HttpPost("send")]
        public async Task<IActionResult> Get(string topic)
        {
            var peop = GetPeople();
            string serializedPeople = JsonConvert.SerializeObject(peop);

            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedPeople });
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok(true);
            }

        }
    }
}