using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class Virksomhed
    {
        public int VirksomhedID { get; set; }
        public string CVR { get; set; }
        public string Virksomhedsnavn { get; set; }
        public string KontaktPerson { get; set; }

        //forening key til CityCrawl
        public int CityCrawlId { get; set; }
        public CityCrawl CC { get; set; }
    }
}
