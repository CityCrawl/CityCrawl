using CC_Web.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Models.CC_DbContext
{
    public class CC_DbContext : DbContext
    {
        public CC_DbContext(DbContextOptions<CC_DbContext> options) : base(options) { }

        public DbSet<Bruger> brugere { get; set; }
        public DbSet<CityCrawl> cityCrawls { set; get; }
        public DbSet<Virksomhed> virksomheder { get; set; }

    }
}
