# WebShop-raupjc

Ovaj projekt napravljen je u sklopu vještine Razvoj aplikacija u programskom jeziku C# u akademskoj godini 2017./2018.
Tema projekta je webshop koji prodaje opremu za pikado. Pregledavanje ponude i dodavanje artikala u košaricu moguće su i bez prijave.
Za zaključenje ili dodatno mijenjanje košarice potrebno se prijaviti na stranicu (moguće preko lokalnog profila ili preko Facebooka).



Napomene

Uz obične korisnike koji se mogu registrirati na stranicu ili prijaviti preko Facebooka, postoji i jedan "superuser".
Njegovo ime je "Admin", a lozinka "T0p_secret_lozinka" (oboje bez navodnika, lozinka ima znamenku nula, ne slovo o).
Admin može vidjeti cjelokupnu listu artikala, dodavati nove, uređivati ili brisati postojeće (s tim da se mora uzeti u obzir da, ako je neki korisnik naručio određeni artikl, njega nije moguće izbrisati jer postoji u narudžbi).
Ako Admin pokuša izbrisati artikl koji se nalazi u narudžbi, brisanje se ne izvrši te se ispiše prikladna poruka.
Također je moguće dodati slike koje se koriste za nove artikle.
Osim toga, Admin ima pregled završenih neposlanih narudžbi (tko je naručio, što je naručio, kamo to treba stići).
On tada može izabrati koja narudžba se treba poslati kupcu.


Za ispravljanje

Da bi ste pokrenuli projekt nakon downloada koda potrebno je podesiti vlasitu bazu podataka prema modelima projekta koji se nalaze u mapi "Models".
(Ili alternativno, moguće je u appsettings.Development.json zakomentirati jedan connection string, odkomentirati drugi i tako se spojiti direktno na Azure bazu podataka ako se želi projekt testirati lokalno.
Naravno, ovo je samo brzi način ako se ne misli mijenjati ništa tijekom testiranja, ne onaj koji treba koristiti)





Autor

Tomislav Gregurić (0036499029)
