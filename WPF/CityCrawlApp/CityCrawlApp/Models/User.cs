using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCrawlApp.Models
{
    public class User
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Foedselsdag { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Pubcrawl> Pubcrawls { get; set; } = new List<Pubcrawl>();

    }
}
