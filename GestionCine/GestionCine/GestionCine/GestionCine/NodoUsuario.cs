using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoUsuario
    {
        public Usuario Datos { get; set; }
        public NodoUsuario Siguiente { get; set; }

        public NodoUsuario(Usuario datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }
}
