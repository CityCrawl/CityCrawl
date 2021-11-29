using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class CityCrawl
    {
        public int CityCrawlID { get; set; }
        public string Begivenhed { get; set; }
        public string Sted { get; set; }
        public string Dato { get; set; }
        //Collection over Virksomheder, FK
        public List<Virksomhed> Virksomhed { get; set; }
        ////Collection over Bruger, FK
        public List<Bruger> Bruger { get; set; }
    }
}
