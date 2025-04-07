using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class GestionAsientos
    {
        
        private static bool[,] asientosSalas = new bool[3, 20]; 

      
        public static bool AsientoReservado(string asiento, string sala)
        {
            int indiceSala = ObtenerIndiceSala(sala);
            int indiceAsiento = ObtenerIndiceAsiento(asiento);

           
            if (asientosSalas[indiceSala, indiceAsiento])
            {
                return true;
            }

           
            return false;
        }

        
        public static void ReservarAsiento(string asiento, string sala)
        {
            int indiceSala = ObtenerIndiceSala(sala);
            int indiceAsiento = ObtenerIndiceAsiento(asiento);

            
            asientosSalas[indiceSala, indiceAsiento] = true;
        }

        
        private static int ObtenerIndiceSala(string sala)
        {
            switch (sala)
            {
                case "Sala 1":
                    return 0;
                case "Sala 2":
                    return 1;
                case "Sala 3":
                    return 2;
                default:
                    throw new ArgumentException("Sala no válida.");
            }
        }

        
        private static int ObtenerIndiceAsiento(string asiento)
        {
            
            char fila = asiento[0]; 
            int columna = int.Parse(asiento[1].ToString()); 

         
            int indiceFila = fila - 'A';

            
            int indiceColumna = columna - 1;

            
            return (indiceFila * 5) + indiceColumna;
        }
    }
}
