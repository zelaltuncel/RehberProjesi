using Microsoft.EntityFrameworkCore;
using RehberApi.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.ORM.Context
{
    public class DirectoryContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-52-209-134-160.eu-west-1.compute.amazonaws.com;Database=d7705ol87ec39c;UID=gnqixyghgfjlqb;PWD=1b32e48c911d1e4e14bcdd34a578cc312b0f4c120b9c2348e6581646e9740b15;SSL Mode= Require;TrustServerCertificate=True");
        }

        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Person> People { get; set; }


    }
}
