using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Database.Models
{
    public class CityCrawl
    {
        [Key]
        public int CC_id { get; set; }
        //Collection over Virksomheder
        public ICollection<Virksomhed> Virksomhed { get; set; }
        //Collection over Bruger
        public ICollection<Bruger> Bruger { get; set; }
    }
}
