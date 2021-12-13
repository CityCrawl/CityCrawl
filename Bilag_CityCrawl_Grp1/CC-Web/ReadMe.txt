Data for virksomheder, der indeholder profil oplysninger, addes automatisk til database, i entiteten Virksomheder, ved programkørsel. 

Alle profilsider pre-defineret kan tilgås uden om login ved siderne:

	/MainCC/Profil/bubbles@bubbles.dk
	/MainCC/Profil/jytte@hildsbeerbar.dk
	/MainCC/Profil/info@jazzitup.com
	/MainCC/Profil/wine@dine.com
	/MainCC/Profil/test@test.test

Ved programkørelse bliver de pre-defineret virksomheder blot seeded i Virksomheder, men ikke i AspNetUsers og derfor skal virksomhedsoplysningerne manuelt oprettes i denne tabel.
Dette gøres ved at oprette de pre-defineret virksomheder på hjemmesidens register.

Oplysninger for pre-defineret virksomheder:

Bubbles:
	Virksomhedsnavn = "Bubbles",
	CVR = "42356789",
	KontaktPerson = "Torben Jensen",
	Email = "bubbles@bubbles.dk",
	Password = "Bubbles1!",
	Beskrivelse = "Bubbles er byens fedeste champange bar placeret i hjertet af Aarhus"

Hildas Beer Bar:
	Virksomhedsnavn ="Hildas Beer Bar",
	CVR = "34127865",
	KontaktPerson = "Jytte Sørensen",
    	Email ="jytte@hildsbeerbar.dk",
	Password ="HildasBeer2!",
	Beskrivelse = "Boobies and Beers"

Jazz it up:
	Virksomhedsnavn ="Jazz it up",
	CVR = "56349865",
 	KontaktPerson ="Simone Nielsen",
	Email="info@jazzitup.com",
	Password = "Jazzitup3!",
	Beskrivelse = "Jazz op dit liv"

Wine & Dine:
	Virksomhedsnavn ="Wine & Dine",
	CVR = "67895432",
	KontaktPerson ="Lars Clausen",
	Email ="wine@dine.com",
 	Password ="Wine&dine4",
	Beskrivelse = "Drik dig fuld, så kan du ikke smage vores mad"

Test Virksomhed:
	Virksomhedsnavn = "Test Virksomhed",
	CVR = "TestCVR",
	KontaktPerson = "Test Person",
	Email = "test@test.test",
	Password = "Test123!",
	Beskrivelse = "Dette er en test af beskrivelse"
