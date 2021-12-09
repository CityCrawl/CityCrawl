using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CC_Web.Models.Data
{
    public class Pubcrawl
    {
        [Key]
        public int PubcrawlId { get; set; }
        public string PakkeNavn { get; set; }
        public DateTime MoedeTid { get; set; }
        public string MoedeSted { get; set; }
        //Many to many relationship to Bruger
        public ICollection<Bruger> Brugere { get; set; }
        //Many to many relationship to Virksomhed
        public ICollection<Virksomhed> Virksomheder { get; set; }
    }
}
