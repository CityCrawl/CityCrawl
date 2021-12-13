using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class Bruger
    {
        [Key]
        public int BrugerID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Foedselsdag { get; set; }
        public string Email { get; set; }
        public string PwHash { get; set; }
        //Many to many relationship to Pubcrawl
        public ICollection<Pubcrawl> Pubcrawls { get; set; }
        //indsæt liste af pubcrawls entiteten

    }
}
