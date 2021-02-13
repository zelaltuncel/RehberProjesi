using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberApi.Models.ORM.Entities
{
    public class Base
    {
        public int ID { get; set; }

        public DateTime AddDate = DateTime.Now;

        public DateTime UpdateDate = DateTime.Now;

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
            }
        }
    }
}
