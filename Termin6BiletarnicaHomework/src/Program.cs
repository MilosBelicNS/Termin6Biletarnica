
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Termin6BiletarnicaHomework.src
{
    class Program
    {
        static void Main(string[] args)
        {


            UcitavanjePodataka.UcitajPodatke();

            Meni m = new Meni();
            m.DodajOpciju(PregledEntiteta.MeniPregled, "Pregled entiteta");
            m.DodajOpciju(UpravljanjeEntitetima.MeniRukovanje, "Rukovanje entitetima");
            m.Pokreni();
        }
    }
}
