using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RehberApi.Models.ORM.Context;

namespace RehberApi.Controllers
{

    [ApiController]
    public class ProducerController : PersonController
    {


        private ProducerConfig _config;

        public ProducerController(ProducerConfig config, DirectoryContext directoryContext) : base(directoryContext)
        {
            this._config = config;

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
                return Ok(peop);
            }

        }

       
    } 
}
