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
        public NodoPrioridad ObtenerNodoFrente()
        {
            return frente;
        }

        public void AgregarPelicula(Pelicula pelicula, int prioridad)
        {
            NodoPrioridad nuevoNodo = new NodoPrioridad(pelicula, prioridad);

            if (frente == null || prioridad < frente.Prioridad)
            {
                nuevoNodo.Siguiente = frente;
                frente = nuevoNodo;
            }
            else
            {
                NodoPrioridad actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }
        public Pelicula ObtenerSiguiente()
        {
            if (frente == null) return null;

            Pelicula pelicula = frente.Pelicula;
            frente = frente.Siguiente;
            return pelicula;
        }
        public Pelicula VerSiguiente()
        {
            return frente?.Pelicula;
        }
        public bool EstaVacia()
        {
            return frente == null;
        }
        public void MostrarPeliculas()
        {
            NodoPrioridad actual = frente;
            while (actual != null)
            {
                Console.WriteLine("Película: " + actual.Pelicula.Nombre + ", Prioridad: " + actual.Prioridad);
                actual = actual.Siguiente;
            }
        }
        public void EliminarTodaLaColaPrioridad()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa cola de prioridad ya está vacía.");
                return;
            }
            while (frente != null)
            {
                NodoPrioridad nodoEliminado = frente;
                frente = frente.Siguiente; 
                nodoEliminado = null; 
            }

            Console.WriteLine("\nLa cola de prioridad ha sido eliminada exitosamente.");
        }
        public void Agregar(Pelicula pelicula, int prioridad)
        {
            NodoPrioridad nuevoNodo = new NodoPrioridad(pelicula, prioridad);

            if (frente == null || frente.Prioridad > prioridad)
            {
                nuevoNodo.Siguiente = frente;
                frente = nuevoNodo;
            }
            else
            {
                NodoPrioridad actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }
        public void OrdenarCola()
        {
            if (frente == null || frente.Siguiente == null)
                return;  
            bool ordenado;
            do
            {
                NodoPrioridad actual = frente;
                NodoPrioridad anterior = null;
                NodoPrioridad siguiente = frente.Siguiente;
                ordenado = true;

                while (siguiente != null)
                {
                    if (actual.Prioridad > siguiente.Prioridad)
                    {
                        if (anterior != null)
                            anterior.Siguiente = siguiente;

                        actual.Siguiente = siguiente.Siguiente;
                        siguiente.Siguiente = actual;
                        if (siguiente == frente)
                            frente = siguiente;

                        ordenado = false;
                    }

                    anterior = actual;
                    actual = siguiente;
                    siguiente = siguiente.Siguiente;
                }
            } while (!ordenado);
        }
    }
}