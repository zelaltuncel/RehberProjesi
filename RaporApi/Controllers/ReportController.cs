using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using RaporApi.Models.ORM.Context;

namespace RaporApi.Controllers
{
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportContext _reportContext;
        private ConsumerConfig _config;

        public ReportController(ReportContext reportContext, ConsumerConfig config)
        {
            _reportContext = reportContext;
            this._config = config;
        }


        [Route("Getpeople")]
        [HttpGet]
        public IActionResult GetPeop() 
        {
            using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
            {
                consumer.Subscribe("temp-topic-to");
                while (true)
                {
                    var cr = consumer.Consume();
                    var msg = cr.Message.Value;
                    


                    return Ok(msg);
                }
            }
        }


    }
}
