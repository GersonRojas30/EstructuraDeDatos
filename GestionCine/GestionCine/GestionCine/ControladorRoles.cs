using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class ControladorRoles
    {
        
        public static bool VerificarCodigoTrabajador()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("Ingreso para el rol de Cajero");
            Console.WriteLine("====================================");

            string codigoIngresado = Operaciones.getTextoPantalla("Ingrese el código para acceder al rol de cajero: ");

           
            if (codigoIngresado.Equals("Cinemax", StringComparison.OrdinalIgnoreCase))
            {
                return true; 
            }
            else
            {
                Console.WriteLine("Código incorrecto. Regresando a la selección de roles.");
                Console.ReadKey();
                return false; 
            }
        }

      
        public static bool VerificarCodigoAdministrador()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("Ingreso para el rol de Administrador");
            Console.WriteLine("====================================");

            string codigoIngresado = Operaciones.getTextoPantalla("Ingrese el código para acceder al rol de administrador: ");

            
            if (codigoIngresado.Equals("Cinemax1239", StringComparison.OrdinalIgnoreCase))
            {
                return true; 
            }
            else
            {
                Console.WriteLine("Código incorrecto. Regresando a la selección de roles.");
                Console.ReadKey();
                return false;
            }
        }
    }
}
