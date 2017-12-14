using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISPIS_LAB.Models
{
    public class Report
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public string Corrections { get; set; }
        public Incident Incident { get; set; }
    }
}
