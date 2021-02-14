using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RehberApi.Models.ORM.Context;
using RehberApi.Models.ORM.Entities;
using RehberApi.Models.VM;

namespace RehberApi.Controllers
{
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly DirectoryContext _directoryContext;

        public ContactInfoController(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }




        [Route("Contact/Add")]
        [HttpPost]
        public IActionResult Add([FromForm] ContactAddVM contactAdd)
        {
            if (ModelState.IsValid)
            {
                ContactInfo contactInfo = new ContactInfo();
                contactInfo.PersonID = contactAdd.personID;
                contactInfo.Phone = contactAdd.phone;
                contactInfo.EMail = contactAdd.eMail;
                contactInfo.Address = contactAdd.address;
                contactInfo.Content = contactAdd.content;

                _directoryContext.ContactInfos.Add(contactInfo);
                _directoryContext.SaveChanges();

                contactAdd.id = contactInfo.ID;
                return Ok(contactAdd);


            }

            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [Route("Contact/Delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] ContactDeleteVM contactDelete)

        {
            ContactInfo contactInfo = _directoryContext.ContactInfos.Find(contactDelete.id);

            if (contactInfo != null)
            {
                contactInfo.IsDeleted = true;
                _directoryContext.SaveChanges();

                return Ok(contactInfo);
            }

            else
            {
                return BadRequest("There is no any contact information has that id!");
            }
        }
       



    }
}
