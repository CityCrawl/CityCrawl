using CC_Web.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Bruger> brugere { get; set; }
        public DbSet<Pubcrawl> pubcrawls { set; get; }
        public DbSet<Virksomhed> virksomheder { get; set; }
    }
}
