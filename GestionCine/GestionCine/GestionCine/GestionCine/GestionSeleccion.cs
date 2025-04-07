using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public static class GestionSeleccion
    {
        private static ListaEnlazada listaSeleccionadas = new ListaEnlazada();

       
        public static ListaEnlazada ObtenerListaSeleccionadas()
        {
            return listaSeleccionadas;
        }

        
        public static void AgregarPelicula(Pelicula pelicula)
        {
            listaSeleccionadas.InsertarFinal(pelicula);
        }

        
        public static void LimpiarSeleccion()
        {
            listaSeleccionadas = new ListaEnlazada();
        }
    }
}
