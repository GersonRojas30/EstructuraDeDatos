using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    internal class ListaDobleCircularProducto
    {
        public NodoProducto cabeza;

        public ListaDobleCircularProducto()
        {
            cabeza = null;
        }

        // Insertar al inicio
        public void InsertarInicio(Producto producto)
        {
            NodoProducto nuevoNodo = new NodoProducto(producto);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cabeza.Siguiente = cabeza;
                cabeza.Anterior = cabeza;
            }
            else
            {
                NodoProducto ultimo = cabeza.Anterior;
                nuevoNodo.Siguiente = cabeza;
                nuevoNodo.Anterior = ultimo;
                cabeza.Anterior = nuevoNodo;
                ultimo.Siguiente = nuevoNodo;
                cabeza = nuevoNodo;
            }
        }

        // Insertar al final
        public void InsertarFinal(Producto producto)
        {
            if (cabeza == null)
            {
                InsertarInicio(producto);
                return;
            }

            NodoProducto nuevoNodo = new NodoProducto(producto);
            NodoProducto ultimo = cabeza.Anterior;

            nuevoNodo.Siguiente = cabeza;
            nuevoNodo.Anterior = ultimo;
            ultimo.Siguiente = nuevoNodo;
            cabeza.Anterior = nuevoNodo;
        }

        // Eliminar un nodo por índice (1-based)
        public void EliminarEnIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return;

            NodoProducto actual = cabeza;
            int contador = 1;

            do
            {
                if (contador == indice)
                {
                    if (actual.Siguiente == actual) // Solo un nodo
                    {
                        cabeza = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                        if (actual == cabeza)
                        {
                            cabeza = actual.Siguiente;
                        }
                    }
                    break;
                }
                actual = actual.Siguiente;
                contador++;
            } while (actual != cabeza);
        }

        // Obtener la cantidad de nodos en la lista
        public int Contar()
        {
            if (cabeza == null)
                return 0;

            int contador = 0;
            NodoProducto actual = cabeza;

            do
            {
                contador++;
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return contador;
        }

        // Obtener un producto por índice (1-based)
        public Producto ObtenerPorIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return null;

            NodoProducto actual = cabeza;
            int contador = 1;

            do
            {
                if (contador == indice)
                {
                    return actual.Datos;
                }
                actual = actual.Siguiente;
                contador++;
            } while (actual != cabeza);

            return null;
        }

        // Mostrar todos los productos
        public void MostrarProductos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            NodoProducto actual = cabeza;
            int contador = 1;
            do
            {
                Console.WriteLine($"{contador}. Nombre: {actual.Datos.Nombre}, Stock: {actual.Datos.Stocks}, Precio: {actual.Datos.Precio:C}");
                actual = actual.Siguiente;
                contador++;
            } while (actual != cabeza);
        }

        // Buscar un producto por nombre
        public Producto BuscarProducto(string nombreProd)
        {
            if (cabeza == null)
                return null;

            NodoProducto actual = cabeza;
            do
            {
                if (actual.Datos.Nombre.Equals(nombreProd, StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Datos;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return null;
        }

        // Actualizar un producto por nombre
        public bool ActualizarProducto(string nombreProducto, string nuevoStock, decimal nuevoPrecio)
        {
            Producto producto = BuscarProducto(nombreProducto);
            if (producto != null)
            {
                producto.Stocks = nuevoStock;
                producto.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }

        // Eliminar Producto
        public void EliminarProducto(Producto producto)
        {
            if (cabeza == null) // Si la lista está vacía
                return;

            NodoProducto actual = cabeza;

            // Recorre la lista para encontrar el producto
            do
            {
                if (actual.Datos == producto) // Si encontramos el producto
                {
                    if (actual.Siguiente == actual) // Solo hay un nodo en la lista
                    {
                        cabeza = null; // Vaciamos la lista
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;

                        if (actual == cabeza) // Si es la cabeza, movemos la cabeza al siguiente nodo
                        {
                            cabeza = actual.Siguiente;
                        }
                    }
                    return; // Salimos después de eliminar
                }
                actual = actual.Siguiente; // Continuamos con el siguiente nodo
            } while (actual != cabeza);
        }
    }
}
