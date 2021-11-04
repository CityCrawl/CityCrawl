using CC_Database.data;
using CC_Database.Models;
using System;

namespace CC_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();
            var bruger1 = new Bruger();
            var virksomhed1 = new Virksomhed();

            //dummy data
            bruger1.BrugerId = 1;
            bruger1.Navn = "Jytte";
            bruger1.Efternavn = "Hansen";
            bruger1.Foedselsdag = "12-01-1981";
            bruger1.Email = "jytte@hansen.dk";
            bruger1.Password = "minkatersoed";

            virksomhed1.VirksomhedId = 1;
            virksomhed1.CVR = "23564789";
            virksomhed1.Virksomhedsnavn = "Hildas Beerbar";
            virksomhed1.KontaktPerson = "Emil Frederiksen";
            virksomhed1.Email = "hildasbeerbar@skaal.dk";
            virksomhed1.Password = "partyhardy";

            //pt kan jeg ikke køre programmet
            context.Add(bruger1);
            context.Add(virksomhed1);
            context.SaveChanges();
        }
        
    }
}
