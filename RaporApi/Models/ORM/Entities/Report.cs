using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaporApi.Models.ORM.Entities
{
    public class Report
    {
        public int ID { get; set; }

        public DateTime AddDate = DateTime.Now;

        private bool _status = false;
        public bool ReportStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }



    }
}
