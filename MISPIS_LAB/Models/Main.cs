using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISPIS_LAB.Models
{
    public class Main
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int AuditorID { get; set; }
        public int AuthorID { get; set; }
        public Auditor Auditor { get; set; }
        public Incident Incident { get; set; }
        public Author Author { get; set; }
    }
}
