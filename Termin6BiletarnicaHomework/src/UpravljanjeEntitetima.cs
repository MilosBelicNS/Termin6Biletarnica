using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin6BiletarnicaHomework.src.Model;
using static Termin6BiletarnicaHomework.src.Model.Ulaznica;

namespace Termin6BiletarnicaHomework.src
{
    static class UpravljanjeEntitetima


    /*
    * U ovu datoteku smo stavili sve funkcionalnosti koje se odnose na rukovanje
    * entitetima, ukljucujuci i sam meni za rukovanje entitetima. Liste u kojima
    * se nalaze podaci kojima rukujemo se ne nalaze u ovoj datoteci, vec u datoteci
    * Program.cs. U ovoj datoteci ima najvise koda, i to koda koji je dosta
    * repetitivan. Funkcije u ovoj datoteci bi se mogle reorganizovati i 
    * 'pametnije' napisati, ali nam to u ovom trenutku nije cilj posto bi
    * bile manje razumljive pocetnicima.
    */
    {
        public static int GenerisiNoviIdDogadjaja()
        {
            int najveciId = -1;
            foreach (Dogadjaj d in Podaci.listaDogadjaja)
            {
                if (d.Id > najveciId)
                {
                    najveciId = d.Id;
                }

            }
            return najveciId + 1;
        }

        public static int GenerisiNoviIdUlaznice()
        {
            int najveciId = -1;
            foreach (Ulaznica u in Podaci.listaUlaznica)
            {
                if (u.Id > najveciId)
                {
                    najveciId = u.Id;
                }
            }
            return najveciId + 1;
        }



        private static void DodavanjeOsoba()
        {
            Console.WriteLine("Unesite ime osobe: ");
            string imeO = Console.ReadLine();
            Console.WriteLine("Unesite prezime osobe: ");
            string prezimeO = Console.ReadLine();
            Console.WriteLine("Unesite ime osobe: ");
            var jmbgO = Convert.ToString(Console.ReadLine());

            Osoba novaOsoba = new Osoba(imeO, prezimeO, jmbgO);
            Podaci.listaOsoba.Add(novaOsoba);


        }
        private static void DodavanjeDogadjaja()
        {

            Dogadjaj noviDogadjaj;

            int id = GenerisiNoviIdDogadjaja();



            Console.WriteLine("Unesite naziv dogadjaja: ");
            string nazivDog = Console.ReadLine();
            Console.WriteLine("Unesite vreme dogadjaja: ");
            string vremeDog = Console.ReadLine();
            Console.WriteLine("Unesite mesto dogadjaja: ");
            string mestoDog = Console.ReadLine();

            Console.WriteLine("Unesite tip dogadjaja, M za muzicki ili S za sportski: ");
            string tipDog = Console.ReadLine();


            if (tipDog == "M")
            {
                Console.WriteLine("Unesite izvodjaca: ");
                string izvodjacDog = Console.ReadLine();
                Console.WriteLine("Unesite zanr: ");
                string zanrDog = Console.ReadLine();

                noviDogadjaj = new MuzickiDogadjaj(id, nazivDog, vremeDog, mestoDog, izvodjacDog, zanrDog);

            }
            else
            {
                Console.WriteLine("Unesite vrstu sporta: ");
                string vrstaSpDog = Console.ReadLine();
                noviDogadjaj = new SportskiDogadjaj(id, nazivDog, vremeDog, mestoDog, vrstaSpDog);
            }

            Podaci.listaDogadjaja.Add(noviDogadjaj);

        }

        public static void DodavanjeUlaznica()
        {
            Console.WriteLine("Unesite cenu ulaznice: ");
            double cena = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Unesite tip ulaznice: O ili V");
            string unosTipa = Console.ReadLine();
            TipUlaznice tip;
            if(unosTipa == "V")
            {
                tip = TipUlaznice.VIP;
            }
            else
            {
                tip = TipUlaznice.OBICNA;
            }

            Console.WriteLine("Unesite id dogadjaja: ");
            string idDogadjajaString = Console.ReadLine();
            int idDogadjaja = int.Parse(idDogadjajaString);
            Dogadjaj noviDogadjaj = PronadjiDogadjajPoId(idDogadjaja);
            Console.WriteLine("Unesite jmbg osobe: ");
            string jmbgString = Console.ReadLine();
         
            Osoba novaOsoba = PronadjiOsobuPoJmbg(jmbgString);
            int id = GenerisiNoviIdUlaznice();
            Ulaznica novaUlaznica = new Ulaznica(id, cena, tip, noviDogadjaj, novaOsoba);
            Podaci.listaUlaznica.Add(novaUlaznica);
        }

        public static void BrisanjeOsoba()
        {
            Console.WriteLine("Unesite JMBG osobe koju cete obrisati iz sistema: ");
            string jmbgString = Console.ReadLine();
            
            Osoba o = PronadjiOsobuPoJmbg(jmbgString);
            Podaci.listaOsoba.Remove(o);
        }

        public static void BrisanjeDogadjaja()
        {
            Console.WriteLine("Unesite id dogadjaja koji cete izbrisati iz sistema: ");
            string idString = Console.ReadLine();
            int id = int.Parse(idString);
            Dogadjaj d = PronadjiDogadjajPoId(id);
            Podaci.listaDogadjaja.Remove(d);
        }

        public static void BrisanjeUlaznica()
        {
            Console.WriteLine("Unesite id ulaznice koju cete obrisati: ");
            string idString = Console.ReadLine();
            int id = int.Parse(idString);
            Ulaznica u = PronadjiUlaznicuPoId(id);
            Podaci.listaUlaznica.Remove(u);
        }




        public static Ulaznica PronadjiUlaznicuPoId(int id)
        {
            foreach(Ulaznica u in Podaci.listaUlaznica)
            {
                if(u.Id == id)
                {
                    return u;
                }

            }
            return null;
        }

        public static Osoba PronadjiOsobuPoJmbg(string jmbg)
        {
            foreach(Osoba o in Podaci.listaOsoba)
            {
                if(o.JMBG == jmbg)
                {
                    return o;
                }
            }
            return null;
        }

        public static Dogadjaj PronadjiDogadjajPoId(int id)
        {
            foreach(Dogadjaj d in Podaci.listaDogadjaja)
            {
                if(d.Id == id)
                {
                    return d;
                }
            }
            return null;
        }


        public static void MeniRukovanje()
        {
            Meni m = new Meni();
            m.DodajOpciju(DodavanjeOsoba, "Dodavanje nove osobe");
            m.DodajOpciju(DodavanjeDogadjaja, "Dodavanje novog dogadjaja");
            m.DodajOpciju(DodavanjeUlaznica, "Dodavanje nove ulaznice");
            m.DodajOpciju(BrisanjeOsoba, "Brisanje osobe");
            m.DodajOpciju(BrisanjeDogadjaja, "Brisanje dogadjaja");
            m.DodajOpciju(BrisanjeUlaznica, "Brisanje ulaznica");

            m.Pokreni();
        }

    }
}
