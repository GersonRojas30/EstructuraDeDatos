using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoArbol
    {
        public Usuario Datos;  
        public NodoArbol Izquierda;  
        public NodoArbol Derecha;    

        public NodoArbol(Usuario datos)
        {
            Datos = datos;
            Izquierda = null;
            Derecha = null;
        }
    }
}
