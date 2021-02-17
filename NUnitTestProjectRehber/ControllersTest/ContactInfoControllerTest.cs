using Confluent.Kafka;
using NUnit.Framework;
using RehberApi.Controllers;
using RehberApi.Models.ORM.Context;
using RehberApi.Models.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProjectRehber.ControllersTest
{
    class ContactInfoControllerTest
    {
        [Test]
        public void AddContactInfoTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();


            ContactInfoController infoController = new ContactInfoController(_directoryContext);

            ContactAddVM model = new ContactAddVM();
            model.personID = 1;
            var result = infoController.Add(model);

            Assert.IsNotNull(result);


        }

        [Test]
        public void DeleteInfoTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();

            ContactInfoController infoController = new ContactInfoController(_directoryContext);
            ContactDeleteVM model = new ContactDeleteVM();

            
            var data = infoController.Delete(model);

            Assert.IsNotNull(model);
            Assert.IsNotNull(data);

        }


    }
}
