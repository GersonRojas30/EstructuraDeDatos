using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    // Clase NodoArbol para el árbol
    public class NodoArbol
    {
        public Usuario Datos;  // Los datos del usuario (nombre y rol)
        public NodoArbol Izquierda;  // Subárbol izquierdo (trabajadores)
        public NodoArbol Derecha;    // Subárbol derecho (clientes)

        public NodoArbol(Usuario datos)
        {
            Datos = datos;
            Izquierda = null;
            Derecha = null;
        }
    }
}
