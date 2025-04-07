using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ListaBoletos
    {
        private NodoBoleto cabeza;

        public void Agregar(Boleto boleto)
        {
            NodoBoleto nuevoNodo = new NodoBoleto(boleto);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoBoleto actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public void Eliminar(Boleto boleto)
        {
            if (cabeza == null) return;

            if (cabeza.Datos.Equals(boleto))
            {
                cabeza = cabeza.Siguiente;
                return;
            }

            NodoBoleto actual = cabeza;
            while (actual.Siguiente != null && !actual.Siguiente.Datos.Equals(boleto))
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
        }
    }

    public class NodoBoleto
    {
        public Boleto Datos { get; set; }
        public NodoBoleto Siguiente { get; set; }

        public NodoBoleto(Boleto datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }

    public class PilaBoletos
    {
        public NodoBoleto tope;

        public void Agregar(Boleto boleto)
        {
            NodoBoleto nuevoNodo = new NodoBoleto(boleto);
            nuevoNodo.Siguiente = tope;
            tope = nuevoNodo;
        }

        public Boleto Eliminar()
        {
            if (tope == null) throw new InvalidOperationException("La pila está vacía.");
            Boleto datos = tope.Datos;
            tope = tope.Siguiente;
            return datos;
        }

        public bool EsVacia()
        {
            return tope == null;
        }
    }
}
