using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.VM
{
    public class PersonAddVM
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surName { get; set; }
        [Required]
        public string company { get; set; }
    }
}
