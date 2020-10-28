using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin6BiletarnicaHomework.src.Model;

namespace Termin6BiletarnicaHomework.src
{
  static  class Podaci
    {


        /* 
         * Ova datoteka nam sluzi za promenljive u kojima ce se cuvati podaci.
         * Sve druge operacije u programu koje rade sa podacima ce koristiti ove promenljive.
         * Cela klasa moze da bude staticka, posto sadrzi samo staticka polja, a svakako ne
         * zelimo da pravimo instance ove klase, niti da je nasledjujemo.*/

        public static List<Dogadjaj> listaDogadjaja = new List<Dogadjaj>();
        
        public static List<Ulaznica> listaUlaznica = new List<Ulaznica>();
        public static List<Osoba> listaOsoba = new List<Osoba>();
    }
}
