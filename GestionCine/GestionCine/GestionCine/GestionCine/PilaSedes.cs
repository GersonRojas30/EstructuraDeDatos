using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GestionCine
{
    public class PilaSedes
    {
        public NodoSede pila;

        public PilaSedes()
        {
            pila = null;

            // Agregamos sedes con su prioridad
            push("San Juan de Lurigancho", 1);
            push("Los Olivos", 2);
            push("Villa El Salvador", 3);
            push("Comas", 4);
        }

        // Método para agregar una sede con prioridad
        public void push(string sede, int prioridad)
        {
            NodoSede nuevaSede = new NodoSede(sede, prioridad); // Ahora usamos el constructor con prioridad
            nuevaSede.sgte = pila;
            pila = nuevaSede;
        }

        // Método para eliminar la sede más reciente (LIFO)
        public string pop()
        {
            if (pila == null)
            {
                Console.WriteLine("La pila está vacía.");
                return null;
            }
            else
            {
                string sedeEliminada = pila.sede;
                pila = pila.sgte;
                return sedeEliminada;
            }
        }

        // Método para verificar si una sede existe
        public bool SedeExiste(string nombreSede)
        {
            NodoSede actual = pila;
            while (actual != null)
            {
                if (actual.sede.Equals(nombreSede, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                actual = actual.sgte;
            }
            return false;
        }

        // Método para contar el número de sedes
        public int Contar()
        {
            int contador = 0;
            NodoSede actual = pila;
            while (actual != null)
            {
                contador++;
                actual = actual.sgte;
            }
            return contador;
        }

        // Método para obtener la sede en una posición específica (por índice)
        public string ObtenerPorIndice(int index)
        {
            NodoSede actual = pila;
            for (int i = 0; i < index; i++)
            {
                if (actual == null) throw new ArgumentOutOfRangeException("Índice fuera de rango.");
                actual = actual.sgte;
            }
            return actual.sede;
        }

        // Método para mostrar las sedes con sus prioridades
        public void muestraPila()
        {
            if (pila == null)
            {
                Console.WriteLine("No hay sedes registradas.");
            }
            else
            {
                Console.WriteLine("Sedes registradas (de más reciente a más antigua):");
                NodoSede actual = pila;
                while (actual != null)
                {
                    Console.WriteLine($"- {actual.sede} (Prioridad: {actual.prioridad})"); // Muestra la prioridad
                    actual = actual.sgte;
                }
            }
        }
    }
}
