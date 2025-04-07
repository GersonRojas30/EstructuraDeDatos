using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ColaProductos
    {
        public NodoProductos frente; 
        public NodoProductos final; 

        public void Enqueue(Productos producto) 
        {
            NodoProductos nuevoNodo = new NodoProductos(producto); 
            if (final != null)
            {
                final.sgte = nuevoNodo;
            }
            final = nuevoNodo;
            if (frente == null)
            {
                frente = nuevoNodo;
            }
        }

        public void Dequeue()
        {
            if (frente != null)
            {
                frente = frente.sgte;
                if (frente == null)
                {
                    final = null;
                }
            }
        }

        public bool IsEmpty()
        {
            return frente == null;
        }
    }
}
