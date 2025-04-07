using System;

namespace GestionCine
{
    public class Arbol
    {
        public NodoArbol Raiz { get; private set; }

        public Arbol()
        {
            Raiz = null;
        }

        // Método para insertar un nodo en el árbol de acuerdo con el nombre de usuario
        public void Insertar(Usuario usuario)
        {
            if (Raiz == null)
            {
                Raiz = new NodoArbol(usuario);
            }
            else
            {
                InsertarPorRol(Raiz, usuario);  // Inserta por rol en lugar de por solo nombre
            }
        }

        private void InsertarPorRol(NodoArbol nodo, Usuario usuario)
        {
            // Se usa la prioridad del rol
            int prioridadNodo = ObtenerPrioridad(nodo.Datos.Rol);  // Obtener la prioridad de rol del nodo actual
            int prioridadUsuario = ObtenerPrioridad(usuario.Rol);  // Obtener la prioridad de rol del usuario

            if (prioridadUsuario < prioridadNodo)
            {
                // Insertar a la izquierda si el rol del usuario tiene mayor prioridad
                if (nodo.Izquierda == null)
                {
                    nodo.Izquierda = new NodoArbol(usuario);
                }
                else
                {
                    InsertarPorRol(nodo.Izquierda, usuario);
                }
            }
            else
            {
                // Insertar a la derecha si el rol del usuario tiene menor o igual prioridad
                if (nodo.Derecha == null)
                {
                    nodo.Derecha = new NodoArbol(usuario);
                }
                else
                {
                    InsertarPorRol(nodo.Derecha, usuario);
                }
            }
        }

        // Método que asigna la prioridad a cada rol
        private int ObtenerPrioridad(string rol)
        {
            switch (rol.ToLower())
            {
                case "cliente": return 1;  // Prioridad más alta para clientes
                case "trabajador": return 2;  // Luego los trabajadores
                case "administrador": return 3;  // Y por último los administradores
                default: return int.MaxValue;  // En caso de rol desconocido
            }
        }

        // Método para mostrar el árbol de forma jerárquica (de izquierda a derecha)
        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS EN ÁRBOL");
            Console.WriteLine("==============================");
            MostrarArbolUsuarios(Raiz, 0);  // Llama al método de visualización
        }

        // Método recursivo para mostrar el árbol con indentación (de izquierda a derecha)
        private void MostrarArbolUsuarios(NodoArbol raiz, int cont)
        {
            if (raiz == null) return;

            // Primero, recursión hacia la izquierda (se imprimen primero los nodos de la izquierda)
            if (raiz.Izquierda != null)
            {
                MostrarArbolUsuarios(raiz.Izquierda, cont + 1);
            }

            // Imprime el nodo actual con indentación
            for (int i = 0; i < cont; i++)
            {
                Console.Write("   "); // Espacios para cada nivel de profundidad
            }
            Console.WriteLine(raiz.Datos.NombreUsuario + " (" + raiz.Datos.Rol + ")");

            // Luego, recursión hacia la derecha (luego se imprimen los nodos de la derecha)
            if (raiz.Derecha != null)
            {
                MostrarArbolUsuarios(raiz.Derecha, cont + 1);
            }
        }

        public void PreOrdenSecuenciaPorRol(NodoArbol nodo)
        {
            if (nodo == null) return;

            // Primero, imprimimos los clientes
            if (nodo.Datos.Rol == "cliente")
            {
                Console.Write(nodo.Datos.NombreUsuario + " | ");
            }

            // Luego, los trabajadores
            PreOrdenSecuenciaPorRol(nodo.Izquierda);  // Recursión hacia la izquierda
            if (nodo.Datos.Rol == "trabajador")
            {
                Console.Write(nodo.Datos.NombreUsuario + " | ");
            }

            // Finalmente, los administradores
            PreOrdenSecuenciaPorRol(nodo.Derecha);  // Recursión hacia la derecha
            if (nodo.Datos.Rol == "administrador")
            {
                Console.Write(nodo.Datos.NombreUsuario + " | ");
            }
        }

        public void MostrarSecuencia()
        {
            Console.WriteLine("Secuencia");
            PreOrdenSecuenciaPorRol(Raiz); // Genera la secuencia de preorden por rol
            Console.WriteLine("\n");
        }

        // Recorrido en PreOrden
        public void PreOrden(NodoArbol nodo)
        {
            if (nodo == null) return;

            Console.Write(nodo.Datos.NombreUsuario + " (" + nodo.Datos.Rol + ") - ");
            PreOrden(nodo.Izquierda);
            PreOrden(nodo.Derecha);
        }

        // Recorrido en InOrden
        public void InOrden(NodoArbol nodo)
        {
            if (nodo == null) return;

            InOrden(nodo.Izquierda);
            Console.Write(nodo.Datos.NombreUsuario + " (" + nodo.Datos.Rol + ") - ");
            InOrden(nodo.Derecha);
        }

        // Recorrido en PostOrden
        public void PostOrden(NodoArbol nodo)
        {
            if (nodo == null) return;

            PostOrden(nodo.Izquierda);
            PostOrden(nodo.Derecha);
            Console.Write(nodo.Datos.NombreUsuario + " (" + nodo.Datos.Rol + ") - ");
        }
    }
}