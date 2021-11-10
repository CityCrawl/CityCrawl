using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class Virksomhed
    {
        public int VirksomhedID { get; set; }
        public int CVR { get; set; }
        public string Virksomhedsnavn { get; set; }
        public string KontaktPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
