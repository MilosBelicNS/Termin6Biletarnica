using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin6BiletarnicaHomework.src.Model
{
    class Ulaznica
    {
        public enum TipUlaznice { OBICNA, VIP};  



        public int Id { get; set; }
        public double Cena { get; set; }
        public TipUlaznice Tip { get; set; }
        public Dogadjaj TipDogadjaja { get; set; }
        public Osoba Osoba { get; set; }


        public Ulaznica(int id, double cena, TipUlaznice tipUlaznice, Dogadjaj tipDogadjaja, Osoba osoba)
        {
            this.Id = id;
            this.Cena = cena;
            Tip = tipUlaznice;
            this.TipDogadjaja = tipDogadjaja;
            this.Osoba = osoba;

        }

        public override string ToString()
        {

            string tipString;
            if (Tip == TipUlaznice.OBICNA)
            {
                tipString = "Obicna";
            }
            else
            {
                tipString = "VIP";
            }
            return string.Format("Ulaznica ID: {0} \n Cena: {1} rsd \n Tip: {2} \n Dogadjaj: {3} \n Kupila osoba: {4}",
                Id, Cena, tipString, TipDogadjaja, Osoba );
        }
    }
}
