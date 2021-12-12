using CC_Web.Controllers;
using CC_Web.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CC_Web.Test
{
    [TestFixture]
    public class Tests : DbContext
    {

        private ApplicationDbContext _context;
        private MainCCController _uut;

        [SetUp]
        public void Init()
        {
            var connectionstring = "Server=(localdb)\\mssqllocaldb;Database=CC-database;Trusted_Connection=True;MultipleActiveResultSets=true";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            _context = new ApplicationDbContext(optionsBuilder.Options);
            
            _uut = new MainCCController(_context);

        }

        [Test]
        public async Task Test_Of_Profil()
        {

            var model = await _uut.Profil("test@test.test") as ViewResult;

            var virksomhed = await _context.virksomheder
                .FirstOrDefaultAsync(m => m.Email == "test@test.test");

            Assert.That(model.Model == virksomhed);

        }

        [Test]
        public void Test_Of_Welcome()
        {

            var model = _uut.Welcome() as ViewResult;

            Assert.AreEqual("Welcome", model.ViewName);


        }
    }
}