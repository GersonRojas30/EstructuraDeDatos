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
            push("San Juan de Lurigancho", 1);
            push("Los Olivos", 2);
            push("Villa El Salvador", 3);
            push("Comas", 4);
        }

        public void push(string sede, int prioridad)
        {
            NodoSede nuevaSede = new NodoSede(sede, prioridad);
            nuevaSede.sgte = pila;
            pila = nuevaSede;
        }
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
                    Console.WriteLine($"- {actual.sede} (Prioridad: {actual.prioridad})"); 
                    actual = actual.sgte;
                }
            }
        }
    }
}
