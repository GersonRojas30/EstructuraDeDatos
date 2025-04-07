using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    internal class NodoPeliculaABB
    {
        public Pelicula Datos { get; set; }
        public NodoPeliculaABB Izquierda { get; set; }
        public NodoPeliculaABB Derecha { get; set; }
        public int TamañoSubarbol { get; set; }

        public NodoPeliculaABB(Pelicula datos)
        {
            Datos = datos;
            Izquierda = null;
            Derecha = null;
            TamañoSubarbol = 1; 
        }
    }
}
