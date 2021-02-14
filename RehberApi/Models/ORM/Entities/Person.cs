using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.ORM.Entities
{
    public class Person : Base
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }

        public List<ContactInfo> Contacts { get; set; }



    }
}
