using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public static class GestionSeleccion
    {
        private static ListaDoble listaSeleccionadas = new ListaDoble();

       
        public static ListaDoble ObtenerListaSeleccionadas()
        {
            return listaSeleccionadas;
        }

        
        public static void AgregarPelicula(Pelicula pelicula)
        {
            listaSeleccionadas.InsertarFinal(pelicula);
        }

        
        public static void LimpiarSeleccion()
        {
            listaSeleccionadas = new ListaDoble();
        }
    }
}
