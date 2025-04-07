using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ArbolPeliculasABB //Busqueda indexada de Peliculas ABB
    {
        private NodoPeliculaABB raiz;

        public ArbolPeliculasABB()
        {
            raiz = null;
        }

        public void AgregarPelicula(Pelicula pelicula)
        {
            raiz = AgregarRecursivo(raiz, pelicula);
        }

        private NodoPeliculaABB AgregarRecursivo(NodoPeliculaABB nodo, Pelicula pelicula)
        {
            if (nodo == null)
            {
                return new NodoPeliculaABB(pelicula);
            }

            if (String.Compare(pelicula.Nombre, nodo.Datos.Nombre) < 0)
            {
                nodo.Izquierda = AgregarRecursivo(nodo.Izquierda, pelicula);
            }
            else if (String.Compare(pelicula.Nombre, nodo.Datos.Nombre) > 0)
            {
                nodo.Derecha = AgregarRecursivo(nodo.Derecha, pelicula);
            }
            nodo.TamañoSubarbol = 1 + (nodo.Izquierda?.TamañoSubarbol ?? 0) + (nodo.Derecha?.TamañoSubarbol ?? 0);


            return nodo;
        }

        public Pelicula BuscarPelicula(string nombre)
        {
            return BuscarRecursivo(raiz, nombre);
        }

        private Pelicula BuscarRecursivo(NodoPeliculaABB nodo, string nombre)
        {
            if (nodo == null) return null;

            int comparacion = String.Compare(nombre, nodo.Datos.Nombre);
            if (comparacion == 0)
            {
                return nodo.Datos;
            }
            else if (comparacion < 0)
            {
                return BuscarRecursivo(nodo.Izquierda, nombre);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecha, nombre);
            }
        }
        public Pelicula BuscarPorIndice(int indice)
        {
            return BuscarPorIndiceRecursivo(raiz, indice);
        }

        private Pelicula BuscarPorIndiceRecursivo(NodoPeliculaABB nodo, int indice)
        {
            if (nodo == null) return null;

            int tamañoIzquierda = nodo.Izquierda?.TamañoSubarbol ?? 0;

            if (indice < tamañoIzquierda)
            {
                return BuscarPorIndiceRecursivo(nodo.Izquierda, indice);
            }
            else if (indice == tamañoIzquierda)
            {
                return nodo.Datos;
            }
            else
            {
                return BuscarPorIndiceRecursivo(nodo.Derecha, indice - tamañoIzquierda - 1);
            }
        }

    }
}
