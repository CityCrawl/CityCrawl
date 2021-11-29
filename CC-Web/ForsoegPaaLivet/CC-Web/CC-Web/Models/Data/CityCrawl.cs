using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class CityCrawl
    {
        [Key]
        public int CityCrawlID { get; set; }
        public List<BookedPubcrawls> BookingList { get; set; }
        //Collection over Virksomheder, FK
        public List<Virksomhed> Virksomhed { get; set; }

    }
}
