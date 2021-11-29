﻿using System;
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
        public string Foravn { get; set; }
        public string Efternavn { get; set; }
        public string Foedselsdag { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Forening key til BookPubcrawls
        public int BookdPubcrawlsId { get; set; }
        public BookedPubcrawls BookedPubcrawls { get; set; }
    }
}
