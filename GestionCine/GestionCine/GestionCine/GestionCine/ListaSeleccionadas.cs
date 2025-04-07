using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ListaSeleccionadas
    {
        public NodoSeleccionada cabeza;

        public ListaSeleccionadas()
        {
            cabeza = null;
        }

       
        public void InsertarFinal(Pelicula pelicula)
        {
            NodoSeleccionada nuevoNodo = new NodoSeleccionada(pelicula);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoSeleccionada actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

       
        public bool EliminarEnIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return false;

            if (indice == 1)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            NodoSeleccionada actual = cabeza;
            for (int i = 1; i < indice - 1; i++)
            {
                if (actual.Siguiente == null)
                    return false;
                actual = actual.Siguiente;
            }

            if (actual.Siguiente == null)
                return false;

            actual.Siguiente = actual.Siguiente.Siguiente;
            return true;
        }

        
        public int Contar()
        {
            int contador = 0;
            NodoSeleccionada actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

      
        public Pelicula ObtenerPorIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return null;

            NodoSeleccionada actual = cabeza;
            int contador = 1;
            while (actual != null)
            {
                if (contador == indice)
                {
                    return actual.Datos;
                }
                actual = actual.Siguiente;
                contador++;
            }
            return null;
        }

        
        public void MostrarSeleccionadas()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay películas seleccionadas.");
                return;
            }

            NodoSeleccionada actual = cabeza;
            int contador = 1;
            while (actual != null)
            {
                Console.WriteLine($"{contador}. Nombre: {actual.Datos.Nombre}, Horario: {actual.Datos.Horario}, Precio: {actual.Datos.Precio:C}");
                actual = actual.Siguiente;
                contador++;
            }
        }

        
        public bool EstaVacia()
        {
            return cabeza == null;
        }
    }
}
