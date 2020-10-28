using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework.src.Model
{
    class SportskiDogadjaj : Dogadjaj

    {
        public string VrstaSporta { get; set; }



        public SportskiDogadjaj(int id, string naziv, string vreme, string mesto, string vrstaSporta) : base(id, naziv, vreme, mesto)
        {
            this.VrstaSporta = vrstaSporta;
            

        }

        public override string ToString()
        {
            string stringPretka = base.ToString();
            string ukupanString = stringPretka + ", Vrsta sporta: " + VrstaSporta;
            return ukupanString;
        }
 } }
