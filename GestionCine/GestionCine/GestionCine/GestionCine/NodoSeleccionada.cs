using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoSeleccionada
    {
        public Pelicula Datos { get; set; }
        public NodoSeleccionada Siguiente { get; set; }

        public NodoSeleccionada(Pelicula datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }
}
