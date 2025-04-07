using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class Boleto
    {
        public string Pelicula { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Boleto(string pelicula, int cantidad, decimal precio)
        {
            Pelicula = pelicula;
            Cantidad = cantidad;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Película: {Pelicula}, Cantidad: {Cantidad}, Precio Total: {Precio:S/.}";
        }
    }
}
