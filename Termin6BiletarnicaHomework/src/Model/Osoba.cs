using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework.src.Model
{
    class Osoba
    {
       
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }

        public Osoba(string ime, string prezime, string jmbg)
        {
            
            this.Ime = ime;
            this.Prezime = prezime;
            this.JMBG = jmbg;
        }

        public override string ToString()
        {
            return string.Format("Osoba: {0} {1}, JMBG: {2}", Ime, Prezime, JMBG);
        }
    }
}
