using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework.src.Model
{
    class Dogadjaj
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Vreme { get; set; }
        public string Mesto { get; set; }

        public Dogadjaj(int id, string naziv, string vreme, string mesto)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Vreme = vreme;
            this.Mesto = mesto;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Naziv: {1}, Vreme: {2}, Mesto: {3}", Id, Naziv, Vreme, Mesto);
        }
    }
}
