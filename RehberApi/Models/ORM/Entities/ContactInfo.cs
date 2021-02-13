using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.ORM.Entities
{
    public class ContactInfo : Base
    {
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }

        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }
    }
}
