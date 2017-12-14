using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISPIS_LAB.Models
{
    public class Incident
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }

    }
}
