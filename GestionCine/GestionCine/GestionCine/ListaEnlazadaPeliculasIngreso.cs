using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ListaEnlazadaPeliculasIngreso
    {
        public NodoPrioridad cabeza;

        public ListaEnlazadaPeliculasIngreso()
        {
            cabeza = null;
        }
        public void AgregarPelicula(Pelicula pelicula, int prioridad)
        {
            NodoPrioridad nuevoNodo = new NodoPrioridad(pelicula, prioridad);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoPrioridad actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }
        public void MostrarPeliculasEnOrdenDeIngreso()
        {
            Console.Clear();
            Console.WriteLine("======================================================================");
            Console.WriteLine("Registro de Película en Orden de Ingreso");
            Console.WriteLine("======================================================================");

            if (cabeza == null)
            {
                Console.WriteLine("\nNo hay películas registradas.");
            }
            else
            {
                Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}", "Nombre", "Horario", "Precio", "Prioridad");
                Console.WriteLine("---------------------------------------------------------------------");

                NodoPrioridad actual = cabeza;
                while (actual != null)
                {
                    Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}",
                                      actual.Pelicula.Nombre,
                                      actual.Pelicula.Horario,
                                      actual.Pelicula.Precio.ToString("C"),
                                      actual.Prioridad);
                    actual = actual.Siguiente;
                }
            }

            Console.WriteLine("======================================================================");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}