using GestionCine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionCine
{
    public class ColaPrioridad
    {
        private NodoPrioridad frente;

        public ColaPrioridad()
        {
            frente = null;
        }

        // Método para obtener el nodo frente sin modificar la cola
        public NodoPrioridad ObtenerNodoFrente()
        {
            return frente;
        }

        // Método para agregar una película con prioridad
        public void AgregarPelicula(Pelicula pelicula, int prioridad)
        {
            NodoPrioridad nuevoNodo = new NodoPrioridad(pelicula, prioridad);

            // Insertar al inicio si la cola está vacía o si el nuevo nodo tiene mayor prioridad
            if (frente == null || prioridad < frente.Prioridad)
            {
                nuevoNodo.Siguiente = frente;
                frente = nuevoNodo;
            }
            else
            {
                // Buscar la posición correcta en la cola según la prioridad
                NodoPrioridad actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }

        // Método para obtener y eliminar la siguiente película con la prioridad más alta
        public Pelicula ObtenerSiguiente()
        {
            if (frente == null) return null;

            Pelicula pelicula = frente.Pelicula;
            frente = frente.Siguiente;
            return pelicula;
        }

        // Método para ver la siguiente película en la cola sin eliminarla
        public Pelicula VerSiguiente()
        {
            return frente?.Pelicula;
        }

        // Método para verificar si la cola está vacía
        public bool EstaVacia()
        {
            return frente == null;
        }

        // Método para mostrar todas las películas en la cola de prioridad
        public void MostrarPeliculas()
        {
            NodoPrioridad actual = frente;
            while (actual != null)
            {
                Console.WriteLine("Película: " + actual.Pelicula.Nombre + ", Prioridad: " + actual.Prioridad);
                actual = actual.Siguiente;
            }
        }


        // Método para eliminar toda la cola de prioridad
        public void EliminarTodaLaColaPrioridad()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa cola de prioridad ya está vacía.");
                return;
            }

            // Eliminar todos los nodos de la cola
            while (frente != null)
            {
                NodoPrioridad nodoEliminado = frente;
                frente = frente.Siguiente; // Mover el frente al siguiente nodo
                nodoEliminado = null; // Eliminar referencia al nodo (garbage collector lo limpiará)
            }

            Console.WriteLine("\nLa cola de prioridad ha sido eliminada exitosamente.");
        }
    }
}