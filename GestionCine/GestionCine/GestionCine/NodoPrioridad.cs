using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoPrioridad
    {
        public Pelicula Pelicula { get; set; }
        public int Prioridad { get; set; }
        public NodoPrioridad Siguiente { get; set; }

        public NodoPrioridad(Pelicula pelicula, int prioridad)
        {
            Pelicula = pelicula;
            Prioridad = prioridad;
            Siguiente = null;
        }
    }
}
