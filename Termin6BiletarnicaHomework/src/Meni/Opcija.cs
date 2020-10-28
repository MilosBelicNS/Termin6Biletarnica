using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework
{

    public delegate void FunkcijaOpcije();
    class Opcija
    {
        /* Delegat koji sluzi za metodu koja treba biti izvrsena kada se ova opcija odabere */
       


        /* Svaka opcija sadrzi opisni tekst, i metodu koja treba da se izvrsi kada ova opcija bude odabrana */

        public string Tekst { get; set; }
        public FunkcijaOpcije Funkcija { get; set; }

        public Opcija( FunkcijaOpcije funkcija, string tekst)
        {
            Funkcija = funkcija;
            Tekst = tekst;

        }

    }
}
