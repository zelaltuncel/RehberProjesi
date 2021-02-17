using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.VM
{
    public class ContactAddVM
    {
       
        public int id { get; set; }

        [Required]
        public int personID { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string eMail { get; set; }

        [Required]
        public string address { get; set; }
        [Required]
        public string content { get; set; }

  
    }
}
