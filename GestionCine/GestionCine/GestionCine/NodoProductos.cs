using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class NodoProductos
    {
        public Productos producto; 
        public NodoProductos sgte;

        public NodoProductos(Productos producto) 
        {
            this.producto = producto; 
            this.sgte = null;
        }
    }   
}   
