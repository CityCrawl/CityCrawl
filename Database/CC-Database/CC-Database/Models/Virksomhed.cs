using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Database.Models
{
    public class Virksomhed
    {
        [Key]
        public int VirksomhedId { get; set; }
        [MaxLength(8)]
        public string CVR { get; set; }
        [MaxLength(30)]
        public string Virksomhedsnavn { get; set; }
        [MaxLength(30)]
        public string KontaktPerson { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }


    }
}
