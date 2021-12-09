using CC_Web.Controllers;
using CC_Web.Data;
using CC_Web.Models.Data;
using NUnit.Framework;

namespace CC_Web.Test
{
    public class Tests
    {

        private readonly ApplicationDbContext _context;
        MainCCController uut;

        [SetUp]
        public void Setup()
        {
            var uut = new MainCCController(_context);
        }

        [Test]
        public void Test1()
        {

            var vuser = new Virksomhed { CVR = "12345678", Virksomhedsnavn = "BarTest", Email = "bar@bartest.dk", Password = "1234", KontaktPerson = "Jan Test", Beskrivelse = "Dette er en bar der er lavet til at teste øl!"};

            _context.Add(vuser);
            _context.SaveChangesAsync();

            var testProfil = uut.Profil("bar@bartest.dk");



            Assert.IsTrue(testProfil.IsCompletedSuccessfully);

        }
    }
}