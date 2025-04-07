using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Stocks { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, string stock, decimal precio)
        {
            Nombre = nombre;
            Stocks = stock;
            Precio = precio;
        }
    }
}
