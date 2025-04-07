using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ListaUsuarios
    {
        public NodoUsuario cabeza;

        public ListaUsuarios()
        {
            cabeza = null;
        }

       
        public void InsertarInicio(Usuario usuario)
        {
            NodoUsuario nuevoNodo = new NodoUsuario(usuario);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
        }

        
        public void InsertarFinal(Usuario usuario)
        {
            NodoUsuario nuevoNodo = new NodoUsuario(usuario);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoUsuario actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

       
        public Usuario BuscarUsuario(string nombreUsuario)
        {
            NodoUsuario actual = cabeza;
            while (actual != null)
            {
                if (actual.Datos.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Datos;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        
        public bool ActualizarContraseña(string nombreUsuario, string nuevaContraseña)
        {
            Usuario usuario = BuscarUsuario(nombreUsuario);
            if (usuario != null)
            {
                usuario.Contraseña = nuevaContraseña;
                return true;
            }
            return false;
        }

        
        public bool EliminarUsuario(string nombreUsuario)
        {
            if (cabeza == null)
                return false;

            if (cabeza.Datos.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            NodoUsuario actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Datos.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        
        public void MostrarUsuarios()
        {
            if (EstaVacia())
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            NodoUsuario actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"- {actual.Datos.NombreUsuario}");
                actual = actual.Siguiente;
            }
        }

       
        public bool EstaVacia()
        {
            return cabeza == null;
        }
    }
}
