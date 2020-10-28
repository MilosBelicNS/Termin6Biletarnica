using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin6BiletarnicaHomework.src.Model;
using static Termin6BiletarnicaHomework.src.Model.Ulaznica;

namespace Termin6BiletarnicaHomework.src
{
    static class UcitavanjePodataka
    {

        /*
         * U ovu datoteku smo stavili sav kod koji se odnosi na ucitavanje podataka
         * iz datoteka.
         */

        private static void UcitajOsobe(string imeFajla)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(imeFajla);

            string linija;
            while (true)
            {
                //pokusavamo da ocitamo sledecu liniju teksta iz datoteke
                linija = file.ReadLine();

                if (linija == null)
                {
                    break;
                }


                /* Razdvajamo ocitanu liniju na delove */
                string[] deloviLinije = linija.Split(',');




                /* Interpretiramo delove linije kao ime, prezime i jmbg osobe */
                string ime = deloviLinije[0];
                string prezime = deloviLinije[1];

                string jmbg = deloviLinije[2];
                

                /* Koristeci ocitane podatke o osobi, kreiramo novi objekat */
                Osoba novaOsoba = new Osoba(ime, prezime, jmbg);

                /* Ubacujemo novonastali objekat u staticku listu u kojoj cuvamo sve Osobe */
                Podaci.listaOsoba.Add(novaOsoba);
            }
        }


        public static void UcitajMuzickeDogadjaje(string imeFajla)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(imeFajla);
            string linija;
            while (true)
            {
                linija = file.ReadLine();

                if (linija == null)
                {
                    break;
                }

                /* Razdvajamo ocitanu liniju na delove */
                string[] deloviLinije = linija.Split(',');

                /* Interpretiramo delove linije kao ime, prezime i jmbg osobe */

                /* ID nam je celobrojni tip. Moramo prvo proveriti da li je moguca konverzija iz tekstualnog u celobrojni. */
                int id;

                /* Ukoliko konverzija nije uspela, preskocicemo ovaj red u datoteci - prelazimo na sledeci */
                if (!int.TryParse(deloviLinije[0], out id))
                {
                    continue;
                }

                string naziv = deloviLinije[1];
                string vreme = deloviLinije[2];
                string mesto = deloviLinije[3];
                string izvodjac = deloviLinije[4];
                string zanr = deloviLinije[5];

                MuzickiDogadjaj muzickiDogadjaj = new MuzickiDogadjaj(id, naziv, vreme, mesto, izvodjac, zanr);
                Podaci.listaDogadjaja.Add(muzickiDogadjaj);
            }

        }


        public static void UcitajSportskeDogadjaje(string imeFajla)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(imeFajla);
            string linija;
            while (true)
            {
                linija = file.ReadLine();

                if (linija == null)
                {
                    break;
                }

                /* Razdvajamo ocitanu liniju na delove */
                string[] deloviLinije = linija.Split(',');

                /* Interpretiramo delove linije kao ime, prezime i jmbg osobe */

                /* ID nam je celobrojni tip. Moramo prvo proveriti da li je moguca konverzija iz tekstualnog u celobrojni. */
                int id;

                /* Ukoliko konverzija nije uspela, preskocicemo ovaj red u datoteci - prelazimo na sledeci */
                if (!int.TryParse(deloviLinije[0], out id))
                {
                    continue;
                }

                string naziv = deloviLinije[1];
                string vreme = deloviLinije[2];
                string mesto = deloviLinije[3];
                string vrstaSporta = deloviLinije[4];


                SportskiDogadjaj noviSportDogadjaj = new SportskiDogadjaj(id, naziv, vreme, mesto, vrstaSporta);
                Podaci.listaDogadjaja.Add(noviSportDogadjaj);
            }

        }



        public static void UcitajUlaznice(string imeFajla)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(imeFajla);
            string linija;
            while (true)
            {
                linija = file.ReadLine();

                if (linija == null)
                {
                    break;
                }

                /* Razdvajamo ocitanu liniju na delove */
                string[] deloviLinije = linija.Split(',');

                /* Interpretiramo delove linije kao ime, prezime i jmbg osobe */

                /* ID nam je celobrojni tip. Moramo prvo proveriti da li je moguca konverzija iz tekstualnog u celobrojni. */
                int id;

                /* Ukoliko konverzija nije uspela, preskocicemo ovaj red u datoteci - prelazimo na sledeci */
                if (!int.TryParse(deloviLinije[0], out id))
                {
                    continue;
                }

                double cena;
                if(!double.TryParse(deloviLinije[1], out cena))
                {
                    continue;
                }

                /* Tip ulaznice je u programu enumeracija, a u datoteci jedan karakter koji bi trebalo da bude ili "O" ili "V".
                 * Moramo sada proveriti koji se karakter nalazi u datoteci, i napraviti odgovarajucu instancu enumeracije. */
                string tipUlazniceString = deloviLinije[2];
                TipUlaznice tip;
                if (tipUlazniceString == "O")
                {
                    tip = TipUlaznice.OBICNA;
                }
                else if (tipUlazniceString == "V")
                {
                    tip = TipUlaznice.VIP;
                }
                else
                {
                    continue;
                }

                /* Ulaznica i dogadjaj su vezani jednosmernom asocijacijom - Svaka ulaznica bi trebalo da zna za dogadjaj za koji je namenjena. U C# kodu smo to realizovali ubacivanjem reference na dogadjaj u klasu Ulaznica. U datoteci je veza realizovana tako sto svaka ulaznica u sebi ima zapisan id dogadjaja za koji je namenjena.
                 * 
                 * Nama nije cilj da u objektu ulaznice stoji "int id" dogadjaja, vec referenca na postojeci objekat odgovarajuceg dogadjaja.
                 * 
                 * Zbog toga nam je zadatak da ocitamo id dogadjaja iz datoteke, potom pronadjemo odgovarajuci dogadjaj iz staticke liste u kojoj cuvamo sve dogadjaje, i njegovu referencu smestimo u novi objekat ulaznice koji pravimo na kraju ove metode */

                int idDogadjaja;
                if(!int.TryParse(deloviLinije[3],out idDogadjaja))
                {
                    continue;
                }

                Dogadjaj dogadjaj = UpravljanjeEntitetima.PronadjiDogadjajPoId(idDogadjaja);

                string jmbgOsobe = deloviLinije[4];
               
                Osoba osoba = UpravljanjeEntitetima.PronadjiOsobuPoJmbg(jmbgOsobe);

                Ulaznica ulaznica = new Ulaznica(id, cena, tip, dogadjaj, osoba);

                Podaci.listaUlaznica.Add(ulaznica);
            }

        }


        public static void UcitajPodatke()
        {
            /*
             * Imena datoteka smo zadali ovde. Struktura naseg projekta je takva da je 
             * izvrsna datoteka (.exe) u direktorijumu bin\\Debug. Zbog toga, da bismo
             * dosli do direktorijuma 'data' u kome se nalaze nasi podaci, moramo prvo
             * da se 'popnemo' dva nivoa iznad u odnosu na direktorijum izvrsne datoteke.
             * Dupla tacka (..) predstavlja penjanje u roditeljski direktorijum.
             * 
             * Ovo je uradjeno radi jednostavnosti programa. Naravno, bolje je parametrizovati
             * direktorijume i imena samih datoteka, pa ih spajati metodom Path.Combine()
             */

            UcitajOsobe("..\\..\\data\\osobe.csv");
            UcitajMuzickeDogadjaje("..\\..\\data\\muzicki.csv");
            UcitajSportskeDogadjaje("..\\..\\data\\sportski.csv");
            UcitajUlaznice("..\\..\\data\\ulaznice.csv");
        }
    }
}
