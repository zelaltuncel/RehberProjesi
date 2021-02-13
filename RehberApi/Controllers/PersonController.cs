using Microsoft.AspNetCore.Mvc;
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

        public PersonController(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
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

        
    }
}
