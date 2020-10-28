using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework.src.Model
{
    class MuzickiDogadjaj : Dogadjaj
    {
        public string Izvodjac { get; set; }
        public string Zanr { get; set; }


        public MuzickiDogadjaj(int id, string naziv, string vreme, string mesto, string izvodjac, string zanr):base(id, naziv, vreme, mesto)
        {
            this.Izvodjac = izvodjac;
            this.Zanr = zanr;
        }

        public override string ToString()
        {
            string stringPretka = base.ToString();
            string ukupanString = stringPretka + ", Izvodjac: " + Izvodjac + ", Zanr: " + Zanr;
            return ukupanString;
        }
    }
}
