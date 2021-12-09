using CC_Web.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC_Web.Data
{
    public static class SeedData
    {
        //Seed'er de fire virksomheder som brugeren kan vælge i
        //pubcrawl pakkerne i CC-App
        internal static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if(!context.virksomheder.Any())
            {
                SeedVirksomhed(context);
            }
        }

        static void SeedVirksomhed(ApplicationDbContext context)
        {
            context.virksomheder.AddRange(
                //Seed bubbles
                new Virksomhed
                {
                    Virksomhedsnavn = "Bubbles",
                    CVR = "42356789",
                    KontaktPerson = "Torben Jensen",
                    Email = "bubbles@bubbles.dk",
                    Password = "Bubbles1!"
                },
                //Seed Hildas Beer Bar
                new Virksomhed
                {
                    Virksomhedsnavn ="Hildas Beer Bar",
                    CVR = "34127865",
                    KontaktPerson = "Jytte Sørensen",
                    Email ="jytte@hildsbeerbar.dfk",
                    Password ="HildasBeer2!"
                },
                //Seed Jaxx it up
                new Virksomhed
                {
                    Virksomhedsnavn ="Jazz it up",
                    CVR = "56349865",
                    KontaktPerson ="Simone Nielsen",
                    Email="info@jazzitup.com",
                    Password = "Jazzitup3!"
                },
                //Seed Wine Dine
                new Virksomhed
                {
                    Virksomhedsnavn ="Wine & Dine",
                    CVR = "67895432",
                    KontaktPerson ="Lars Clausen",
                    Email ="wine@dine.com",
                    Password ="Wine&dine4"
                }
                );
            context.SaveChanges();
        }
    }
}
