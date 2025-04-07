using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class Arbol
    {
        public NodoArbol Raiz { get; private set; }

        public Arbol()
        {
            Raiz = null;
        }

        // Método para insertar el usuario en el árbol
        public void Insertar(Usuario usuario)
        {
            // Aquí siempre agregamos el nuevo nodo a la derecha
            if (Raiz == null)
            {
                Raiz = new NodoArbol(usuario);
            }
            else
            {
                NodoArbol actual = Raiz;
                while (actual.Derecha != null)
                {
                    actual = actual.Derecha;
                }
                actual.Derecha = new NodoArbol(usuario);
            }
        }

        // Método para mostrar el árbol con formato
        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS");
            Console.WriteLine("==============================");

            // Llamamos a la función recursiva para mostrar los usuarios
            MostrarArbolUsuarios(Raiz, "", false);
        }

        // Método recursivo para mostrar el árbol con formato
        private void MostrarArbolUsuarios(NodoArbol raiz, string prefijo, bool esDerecha)
        {
            if (raiz == null) return;

            // Si es un nodo a la derecha, imprimir con el símbolo `\` en una línea separada
            if (esDerecha)
            {
                Console.WriteLine(prefijo + "\\");
            }

            // Imprimir el nombre y el rol del usuario con una menor indentación
            Console.WriteLine(prefijo + raiz.Datos.NombreUsuario + " (" + raiz.Datos.Rol + ")");

            // Llamada recursiva para mostrar el siguiente nodo a la derecha, con un prefijo ajustado para alineación
            if (raiz.Derecha != null)
            {
                MostrarArbolUsuarios(raiz.Derecha, prefijo + "  ", true);
            }
        }
    }
}
