using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoProducto
    {
        public Producto Datos { get; set; }
        public NodoProducto Siguiente { get; set; }
        public NodoProducto Anterior { get; set; }

        public NodoProducto(Producto datos)
        {
            Datos = datos;
            Siguiente = null;
            Anterior = null;
        }
    }
}
