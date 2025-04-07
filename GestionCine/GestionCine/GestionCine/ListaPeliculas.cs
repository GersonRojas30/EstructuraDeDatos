using GestionCine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListaPeliculas
{
    public NodoPelicula cabeza;

    public ListaPeliculas()
    {
        cabeza = null;
    }

  
    public void InsertarFinal(Pelicula pelicula)
    {
        NodoPelicula nuevoNodo = new NodoPelicula(pelicula);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoPelicula actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }


    public Pelicula BuscarPelicula(string nombrePelicula)
    {
        NodoPelicula actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.Nombre.Equals(nombrePelicula, StringComparison.OrdinalIgnoreCase))
            {
                return actual.Datos;
            }
            actual = actual.Siguiente;
        }
        return null; 
    }
}