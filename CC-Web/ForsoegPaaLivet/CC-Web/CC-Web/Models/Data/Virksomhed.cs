using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.Data
{
    public class Virksomhed
    {
        [Key]
        public int VirksomhedID { get; set; }
        public string CVR { get; set; }
        public string Virksomhedsnavn { get; set; }
        public string KontaktPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Forening key til CityCrawl
        public int CityCrawlId { get; set; }
        public CityCrawl CC { get; set; }
    }
}
