using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoPelicula
    {
        public Pelicula Datos { get; set; }
        public NodoPelicula Siguiente { get; set; }
        public NodoPelicula Anterior { get; set; }

        public NodoPelicula(Pelicula datos)
        {
            Datos = datos;
            Siguiente = null;
            Anterior = null;
        }
    }
}
