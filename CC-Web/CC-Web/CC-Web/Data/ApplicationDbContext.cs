using CC_Web.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CC_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext( )
        {
            
        }
        //public ApplicationDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=aspnet-CC_Web-2787FD87-B001-4F8C-A176-A8F5A5B9553E;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Bruger> brugere { get; set; }
        public DbSet<CityCrawl> cityCrawls { set; get; }
        public DbSet<Virksomhed> virksomheder { get; set; }
    }
}
