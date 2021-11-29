using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class BookedPubcrawls
    {
        [Key]
        public int BookedPubcrawlsId { get; set; }
        // Indeholder liste over bruger id'er 
        public List<Bruger> Bruger { get; set; }
        public int CityCrawlId { get; set; }
        public CityCrawl CC { get; set; }

    }
}
