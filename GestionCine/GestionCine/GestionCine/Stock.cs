using GestionCine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class Stock
    {
        public NodoProducto cabeza;

        public Stock()
        {
            cabeza = null;
        }

        // Método para insertar un producto al final de la lista
        public void InsertarFinal(Producto pelicula)
        {
            NodoProducto nuevoNodo = new NodoProducto(pelicula);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoProducto actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        // Método para buscar un producto en la lista
        public Producto BuscarProducto(string nombreProducto)
        {
            NodoProducto actual = cabeza;
            while (actual != null)
            {
                if (actual.Datos.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Datos; // Retorna el producto encontrado
                }
                actual = actual.Siguiente;
            }
            return null; // Retorna null si no se encuentra el producto
        }
    }
}
