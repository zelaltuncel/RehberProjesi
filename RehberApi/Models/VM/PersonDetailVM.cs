using RehberApi.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.VM
{
    public class PersonDetailVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string company { get; set; }

        public List<ContactDetailVM> contacts { get; set; }
    }
}
