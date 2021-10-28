using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Database.Models
{
    public class Bruger
    {
        [Key]
        public int BrugerId { get; set; }
        public string Navn { get; set; }
        [MaxLength(30)]
        public string Efternavn { get; set; }
        [MaxLength(30)]
        public string Foedselsdag { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }

    }
}
