using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RaporApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var config = new ConsumerConfig
            //{
            //    GroupId = "gid-consumers",
            //    BootstrapServers = "localhost:9092"
            //};
            //using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            //{
            //    consumer.Subscribe("temp-topic-to");
            //    while (true)
            //    {
            //        var cr = consumer.Consume();
            //        Console.WriteLine(cr.Message.Value);

            //    }
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
