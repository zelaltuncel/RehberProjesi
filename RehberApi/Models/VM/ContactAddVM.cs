using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.VM
{
    public class ContactAddVM
    {
        public int id { get; set; }
        public int personID { get; set; }
        public string phone { get; set; }
        public string eMail { get; set; }
        public string address { get; set; }
        public string content { get; set; }

  
    }
}
