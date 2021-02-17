using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RehberApi.Controllers;
using RehberApi.Models.ORM.Context;
using RehberApi.Models.VM;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NUnitTestProjectRehber.ControllersTest
{
    class PersonControllerTests
    {

        [Test]

        public void GetpeopleListTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            PersonController personController = new PersonController(_config, _directoryContext );

            var result = personController.GetPeople();

            if (result != null)
            {
                Assert.IsTrue(result.Count > 0);
            }

        }

        [Test]
        public void GetDetailTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            PersonController personController = new PersonController(_config, _directoryContext);

            var result = personController.GetDetail(2);

            Assert.IsNotNull(result);
 
        }

        [Test]
        public void AddPersonTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            PersonController personController = new PersonController(_config, _directoryContext);
            PersonAddVM model = new PersonAddVM();

            var result = personController.Add(model);

            Assert.IsNotNull(result);

        }


        [Test]
        public void DeletePersonTest()
        {
            DirectoryContext _directoryContext = new DirectoryContext();
            ProducerConfig _config = new ProducerConfig();
            PersonController personController = new PersonController(_config, _directoryContext);
            PersonDeleteVM model = new PersonDeleteVM();

            var data = personController.Delete(model);
    

            Assert.IsNotNull(model);
            Assert.IsNotNull(data);
        
          
        }





    }
}
