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
                    Password = "Bubbles1!",
                    Beskrivelse = "Bubbles er byens fedeste champange bar placeret i hjertet af Aarhus"
                },
                //Seed Hildas Beer Bar
                new Virksomhed
                {
                    Virksomhedsnavn ="Hildas Beer Bar",
                    CVR = "34127865",
                    KontaktPerson = "Jytte Sørensen",
                    Email = "jytte@hildasbeerbar.dk",
                    Password ="HildasBeer2!",
                    Beskrivelse = "Boobies and Beers"
                },
                //Seed Jaxx it up
                new Virksomhed
                {
                    Virksomhedsnavn ="Jazz it up",
                    CVR = "56349865",
                    KontaktPerson ="Simone Nielsen",
                    Email="info@jazzitup.com",
                    Password = "Jazzitup3!",
                    Beskrivelse = "Jazz op dit liv"
                },
                //Seed Wine Dine
                new Virksomhed
                {
                    Virksomhedsnavn ="Wine & Dine",
                    CVR = "67895432",
                    KontaktPerson ="Lars Clausen",
                    Email ="wine@dine.com",
                    Password ="Wine&dine4",
                    Beskrivelse = "Drik dig fuld, så kan du ikke smage vores mad"
                },
                new Virksomhed
                {
                    Virksomhedsnavn = "Test Virksomhed",
                    CVR = "TestCVR",
                    KontaktPerson = "Test Person",
                    Email = "test@test.test",
                    Password = "Test123!",
                    Beskrivelse = "Dette er en test af beskrivelse"
                }
                );
            context.SaveChanges();
        }
    }
}
