using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ListaEnlazada
    {
        public NodoPelicula cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        
        public void InsertarInicio(Pelicula pelicula)
        {
            NodoPelicula nuevoNodo = new NodoPelicula(pelicula);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cabeza.Siguiente = cabeza;
                cabeza.Anterior = cabeza;
            }
            else
            {
                NodoPelicula ultimo = cabeza.Anterior;
                nuevoNodo.Siguiente = cabeza;
                nuevoNodo.Anterior = ultimo;
                cabeza.Anterior = nuevoNodo;
                ultimo.Siguiente = nuevoNodo;
                cabeza = nuevoNodo;
            }
        }

        
        public void InsertarFinal(Pelicula pelicula)
        {
            if (cabeza == null)
            {
                InsertarInicio(pelicula);
                return;
            }

            NodoPelicula nuevoNodo = new NodoPelicula(pelicula);
            NodoPelicula ultimo = cabeza.Anterior;

            nuevoNodo.Siguiente = cabeza;
            nuevoNodo.Anterior = ultimo;
            ultimo.Siguiente = nuevoNodo;
            cabeza.Anterior = nuevoNodo;
        }

       
        public void EliminarEnIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return;

            NodoPelicula actual = cabeza;
            int contador = 1;

            do
            {
                if (contador == indice)
                {
                    if (actual.Siguiente == actual) 
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

        
        public int Contar()
        {
            if (cabeza == null)
                return 0;

            int contador = 0;
            NodoPelicula actual = cabeza;

            do
            {
                contador++;
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return contador;
        }

        
        public Pelicula ObtenerPorIndice(int indice)
        {
            if (cabeza == null || indice < 1)
                return null;

            NodoPelicula actual = cabeza;
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

        
        public void MostrarPeliculas()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay películas registradas.");
                return;
            }

            NodoPelicula actual = cabeza;
            int contador = 1;
            do
            {
                Console.WriteLine($"{contador}. Nombre: {actual.Datos.Nombre}, Horario: {actual.Datos.Horario}, Precio: {actual.Datos.Precio:C}");
                actual = actual.Siguiente;
                contador++;
            } while (actual != cabeza);
        }

        
        public Pelicula BuscarPelicula(string nombrePelicula)
        {
            if (cabeza == null)
                return null;

            NodoPelicula actual = cabeza;
            do
            {
                if (actual.Datos.Nombre.Equals(nombrePelicula, StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Datos;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return null;
        }

       
        public bool ActualizarPelicula(string nombrePelicula, string nuevoHorario, decimal nuevoPrecio)
        {
            Pelicula pelicula = BuscarPelicula(nombrePelicula);
            if (pelicula != null)
            {
                pelicula.Horario = nuevoHorario;
                pelicula.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }

       
        public void EliminarPelicula(Pelicula pelicula)
        {
            if (cabeza == null) 
                return;

            NodoPelicula actual = cabeza;

            
            do
            {
                if (actual.Datos == pelicula) 
                {
                    if (actual.Siguiente == actual) 
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
                    return;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);
        }

    }

}

