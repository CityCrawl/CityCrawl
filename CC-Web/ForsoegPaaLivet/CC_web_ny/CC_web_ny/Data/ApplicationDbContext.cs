using CC_Web.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC_web_ny.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CityCrawl> CityCrawl { get; set; }
        public DbSet<Virksomhed> Virksomheder { get; set; }
        public DbSet<Bruger> Brugere { get; set; }

    }
}
