using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class Bruger
    {
        public int BrugerID { get; set; }
        public string Foravn { get; set; }
        public string Efternavn { get; set; }
        public string Foedselsdag { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
