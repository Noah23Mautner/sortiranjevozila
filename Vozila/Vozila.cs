using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozila
{
    internal class Vozila
    {
        public string Marka { get; set; } // Public getter i setter
        public string Model { get; set; } // Public getter i setter
        public int GodinaProizvodmje { get; set; } // Public getter i setter
        public int Kilometraza { get; set; } // Public getter i setter

        public Vozila(string marka, string model, int godinaProizvodmje, int kIlometraza)
        {
            Marka = marka;
            Model = model;
            GodinaProizvodmje = godinaProizvodmje;
            Kilometraza = kIlometraza;
        }

        public override string ToString()
        {
            return $"{Marka} {Model}, Godina: {GodinaProizvodmje}, Kilometraža: {Kilometraza} km";
            
        }
    }
}
