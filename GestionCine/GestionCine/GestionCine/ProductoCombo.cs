using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    //Combinacion ABB y Lista enlazada
    public class ProductoCombo
    {
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public ProductoCombo Siguiente { get; set; }

        public ProductoCombo(string nombreProducto, decimal precioProducto)
        {
            NombreProducto = nombreProducto;
            PrecioProducto = precioProducto;
            Siguiente = null;
        }
    }
    public class NodoCombo
    {
        public string NombreCombo { get; set; }
        public decimal PrecioTotal { get; set; }
        public ProductoCombo ListaProductos { get; set; }
        public NodoCombo Izquierdo { get; set; }
        public NodoCombo Derecho { get; set; }

        public NodoCombo(string nombreCombo, decimal precioTotal)
        {
            NombreCombo = nombreCombo;
            PrecioTotal = precioTotal;
            ListaProductos = null;
            Izquierdo = null;
            Derecho = null;
        }
        public void AgregarProducto(string nombreProducto, decimal precioProducto)
        {
            ProductoCombo nuevoProducto = new ProductoCombo(nombreProducto, precioProducto);
            if (ListaProductos == null)
            {
                ListaProductos = nuevoProducto;
            }
            else
            {
                ProductoCombo actual = ListaProductos;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoProducto;
            }
            PrecioTotal += precioProducto; 
        }
    }
    public class ArbolCombos
    {
        public NodoCombo raiz;

        public ArbolCombos()
        {
            raiz = null;
        }

        public void AgregarCombo(string nombreCombo, decimal precioInicial)
        {
            NodoCombo nuevoCombo = new NodoCombo(nombreCombo, precioInicial);
            raiz = AgregarRecursivo(raiz, nuevoCombo);
        }

        public NodoCombo AgregarRecursivo(NodoCombo nodo, NodoCombo nuevoCombo)
        {
            if (nodo == null)
            {
                return nuevoCombo;
            }

            if (nuevoCombo.NombreCombo.CompareTo(nodo.NombreCombo) < 0)
            {
                nodo.Izquierdo = AgregarRecursivo(nodo.Izquierdo, nuevoCombo);
            }
            else
            {
                nodo.Derecho = AgregarRecursivo(nodo.Derecho, nuevoCombo);
            }
            return nodo;
        }

        public void AgregarProductoACombo(string nombreCombo, string nombreProducto, decimal precioProducto)
        {
            NodoCombo nodoCombo = BuscarCombo(raiz, nombreCombo);
            if (nodoCombo != null)
            {
                nodoCombo.AgregarProducto(nombreProducto, precioProducto);
            }
        }
        private NodoCombo BuscarCombo(NodoCombo nodo, string nombreCombo)
        {
            if (nodo == null) return null;

            int comparacion = nombreCombo.CompareTo(nodo.NombreCombo);
            if (comparacion == 0) return nodo;
            if (comparacion < 0) return BuscarCombo(nodo.Izquierdo, nombreCombo);

            return BuscarCombo(nodo.Derecho, nombreCombo);
        }
        public void MostrarCombos()
        {
            MostrarRecursivo(raiz);
        }
        private void MostrarRecursivo(NodoCombo nodo)
        {
            if (nodo == null) return;

            MostrarRecursivo(nodo.Izquierdo);
            Console.WriteLine($"Combo: {nodo.NombreCombo}, Precio Total: {nodo.PrecioTotal}");

            ProductoCombo producto = nodo.ListaProductos;
            while (producto != null)
            {
                Console.WriteLine($"   Producto: {producto.NombreProducto}, Precio: {producto.PrecioProducto}");
                producto = producto.Siguiente;
            }

            MostrarRecursivo(nodo.Derecho);
        }
    }
}
