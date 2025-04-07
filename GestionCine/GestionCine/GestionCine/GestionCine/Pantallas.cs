using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    public class Pantallas
    {

        private static ListaUsuarios listaUsuarios = new ListaUsuarios();
        private static ListaEnlazada listaPeliculas = new ListaEnlazada();
        private static ListaSeleccionadas listaPeliculasSeleccionadas = new ListaSeleccionadas();
        private static ListaEnlazada peliculasSeleccionadas = new ListaEnlazada();

        public static int PantallaPrincipal()
        {

            while (true)
            {
                string texto = "=====================\n" +
                               "CINE MAX\n" +
                               "=====================\n" +
                               "1: Rol de cliente\n" +
                               "2: Rol de trabajador\n" +
                               "3: Rol de administrador\n" +
                               "4: Salir\n" +
                               "=====================";
                Console.Clear();
                Console.WriteLine(texto);
                int opcion = Operaciones.getEntero("Ingrese su rol: ", texto);


                switch (opcion)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("Bienvenido, cliente.");
                        Console.WriteLine("====================================");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        return opcion;

                    case 2:

                        Console.Clear();
                        if (ControladorRoles.VerificarCodigoTrabajador())
                        {
                            Console.WriteLine("Bienvenido, trabajador.");
                            Console.WriteLine("====================================");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            return opcion;
                        }
                        break;

                    case 3:

                        Console.Clear();
                        if (ControladorRoles.VerificarCodigoAdministrador())
                        {
                            Console.WriteLine("Bienvenido, administrador.");
                            Console.WriteLine("====================================");
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            return opcion;
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }


        public static void MenuRolCliente()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Cliente\n" +
                                  "=====================\n" +
                                  "1: Registro Cliente\n" +
                                  "2: Selección de Peliculas\n" +
                                  "3: Seleccion de productos\n" +
                                  "4: Validar Pagos\n" +
                                  "5: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        MenuClienteOpciones();
                        break;
                    case 2:
                        ListarPeliculas();
                        break;
                    case 3:
                        SeleccionProductos();
                        break;
                    case 4:
                        ValidarPago();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 6);
        }


        public static void MenuClienteOpciones()
        {
            while (true)
            {
                Console.Clear();
                string texto = "=====================\n" +
                               "Registro Cliente\n" +
                               "=====================\n" +
                               "1: Crear cuenta\n" +
                               "2: Iniciar sesión\n" +
                               "3: Actualizar cuenta\n" +
                               "4: Eliminar cuenta\n" +
                               "5: Volver al menú de Clientes\n" +
                               "=====================";
                Console.WriteLine(texto);

                int opcion = Operaciones.getEntero("Seleccione una opción: ", texto);

                switch (opcion)
                {
                    case 1:
                        RegistrarUsuario();
                        break;
                    case 2:
                        IniciarSesionUsuario();
                        break;
                    case 3:
                        ActualizarUsuario();
                        break;
                    case 4:
                        EliminarUsuario();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public static void RegistrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese el nombre del usuario: ");
            if (string.IsNullOrWhiteSpace(nombreUsuario) || listaUsuarios.BuscarUsuario(nombreUsuario) != null)
            {
                Console.WriteLine("El nombre del usuario no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese la contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }


            string rol = "cliente";
            listaUsuarios.InsertarFinal(new Usuario(nombreUsuario, contraseña, rol));
            Console.WriteLine("================================");
            Console.WriteLine("Usuario registrado con éxito.");
            Console.ReadKey();
        }


        public static void IniciarSesionUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Usuario)\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese su nombre de usuario: ");
            Usuario usuario = listaUsuarios.BuscarUsuario(nombreUsuario);

            if (usuario != null)
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (usuario.Contraseña == contraseña)
                {
                    Console.WriteLine("Inicio de sesión exitoso.");
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("El usuario no existe.");
            }
            Console.WriteLine("================================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }


        public static void ActualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Actualizar Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese el nombre del usuario a actualizar: ");
            Usuario usuario = listaUsuarios.BuscarUsuario(nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("El usuario no existe.");
                Console.ReadKey();
                return;
            }

            string nuevaContraseña = Operaciones.getTextoPantalla("Ingrese la nueva contraseña: ");
            if (string.IsNullOrWhiteSpace(nuevaContraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }


            bool actualizado = listaUsuarios.ActualizarContraseña(nombreUsuario, nuevaContraseña);
            if (actualizado)
            {
                Console.WriteLine("================================");
                Console.WriteLine("Contraseña actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("No se pudo actualizar la contraseña.");
            }

            Console.ReadKey();
        }


        public static void EliminarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese el nombre del usuario a eliminar: ");
            Usuario usuario = listaUsuarios.BuscarUsuario(nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("El usuario no existe.");
                Console.ReadKey();
                return;
            }


            bool eliminado = listaUsuarios.EliminarUsuario(nombreUsuario);
            if (eliminado)
            {
                Console.WriteLine("Usuario eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("No se pudo eliminar el usuario.");
            }

            Console.ReadKey();
        }


        public static void SeleccionProductos()
        {

            if (GestionTienda.gestionProductos.IsEmpty())
            {
                Console.WriteLine("No hay productos disponibles en la tienda. Por favor, agregue productos primero.");
                Console.ReadKey();
                return;
            }


            Console.Clear();
            Console.WriteLine("Selecciona un producto:");
            Console.WriteLine("================================");


            NodoProductos actual = GestionTienda.gestionProductos.frente;
            int index = 1;
            while (actual != null)
            {

                Console.WriteLine(index + ": " + actual.producto.Nombre + " - Precio: " + actual.producto.Precio + " - Stock disponible: " + actual.producto.Stock);
                actual = actual.sgte;
                index++;
            }
            Console.WriteLine("================================");

            int seleccion = Operaciones.getEntero("Seleccione un producto: ", "Selección inválida. Intente nuevamente.");
            if (seleccion <= 0 || seleccion > index - 1)
            {
                Console.WriteLine("Selección inválida. Regresando al menú.");
                Console.ReadKey();
                return;
            }


            actual = GestionTienda.gestionProductos.frente;
            for (int i = 1; i < seleccion; i++)
            {
                actual = actual.sgte;
            }


            if (actual.producto.Stock > 0)
            {

                actual.producto.Stock--;


                GestionTienda.productosSeleccionados.Enqueue(new Productos(actual.producto.Nombre, actual.producto.Precio, 1));
                Console.WriteLine("================================");
                Console.WriteLine("Has seleccionado " + actual.producto.Nombre + ". ¡Gracias por tu compra!");
            }
            else
            {
                Console.WriteLine("Lo siento, este producto está agotado.");
            }


            Console.WriteLine("================================");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }


        public static void ListarPeliculas()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Listado de Películas\n" +
                              "================================");


            if (listaPeliculas.Contar() > 0)
            {
                listaPeliculas.MostrarPeliculas();

                Console.WriteLine("\nSeleccione el número de la película que desea ver o 0 para volver al menú:");


                int opcion = -1;
                while (opcion < 0 || opcion > listaPeliculas.Contar())
                {
                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > listaPeliculas.Contar())
                    {
                        Console.WriteLine("Opción no válida, intente de nuevo:");
                    }
                }

                if (opcion == 0)
                {
                    return;
                }


                Pelicula peliculaSeleccionada = listaPeliculas.ObtenerPorIndice(opcion);
                Console.Clear();
                Console.WriteLine("Has seleccionado: \n" +
                                  "Nombre: " + peliculaSeleccionada.Nombre + "\n" +
                                  "Horario: " + peliculaSeleccionada.Horario + "\n" +
                                  "Precio: " + peliculaSeleccionada.Precio.ToString("C"));


                SeleccionarSede(peliculaSeleccionada);
            }
            else
            {
                Console.WriteLine("No hay películas registradas.");
                Console.ReadKey();
            }
        }


        public static void SeleccionarSede(Pelicula peliculaSeleccionada)
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Seleccione la Sede\n" +
                              "================================");


            int contador = 1;
            NodoSede actual = GestionSedes.gestionSedes.pila;

            if (actual == null)
            {
                Console.WriteLine("No hay sedes registradas.");
                return;
            }

            while (actual != null)
            {
                Console.WriteLine($"{contador}: {actual.sede}");
                actual = actual.sgte;
                contador++;
            }


            int sedeSeleccionada = Operaciones.getEntero("Seleccione una sede: ", "Opción no válida.");
            while (sedeSeleccionada < 1 || sedeSeleccionada > GestionSedes.gestionSedes.Contar())
            {
                Console.WriteLine("Opción no válida. Intente de nuevo:");
                sedeSeleccionada = Operaciones.getEntero("Seleccione una sede: ", "Opción no válida.");
            }


            string sede = GestionSedes.gestionSedes.ObtenerPorIndice(sedeSeleccionada - 1);


            SeleccionarSala(peliculaSeleccionada, sede);
        }


        public static void SeleccionarSala(Pelicula peliculaSeleccionada, string sede)
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Seleccione la Sala\n" +
                              "================================");


            string[] salas = { "Sala 1", "Sala 2", "Sala 3" };
            for (int i = 0; i < salas.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {salas[i]}");
            }


            int salaSeleccionada = Operaciones.getEntero("Seleccione una sala: ", "Opción no válida.");
            while (salaSeleccionada < 1 || salaSeleccionada > salas.Length)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo:");
                salaSeleccionada = Operaciones.getEntero("Seleccione una sala: ", "Opción no válida.");
            }

            string sala = salas[salaSeleccionada - 1];


            SeleccionarAsiento(peliculaSeleccionada.Nombre, peliculaSeleccionada.Horario, sede, sala);
        }

        public static void SeleccionarAsiento(string pelicula, string horario, string sede, string sala)
        {
            Console.Clear();
            Console.WriteLine($"Selecciona tu asiento para la película {pelicula} a las {horario} en {sede}, {sala}\n");
            Console.WriteLine("================================\n" +
                              "Asientos disponibles:\n" +
                              "================================");


            string[] asientos = new string[]
            {
                  "A1", "A2", "A3", "A4", "A5",
                  "B1", "B2", "B3", "B4", "B5",
                  "C1", "C2", "C3", "C4", "C5",
                  "D1", "D2", "D3", "D4", "D5"
            };


            for (int i = 0; i < asientos.Length; i++)
            {

                if (GestionAsientos.AsientoReservado(asientos[i], sala))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write((i + 1) + ": " + asientos[i] + "\t");

                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }


            Console.ForegroundColor = ConsoleColor.Cyan;


            int asientoSeleccionado = -1;
            while (asientoSeleccionado < 1 || asientoSeleccionado > asientos.Length || GestionAsientos.AsientoReservado(asientos[asientoSeleccionado - 1], sala))
            {
                Console.Write("\nIngrese el número del asiento que desea: ");
                if (!int.TryParse(Console.ReadLine(), out asientoSeleccionado) || asientoSeleccionado < 1 || asientoSeleccionado > asientos.Length)
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                }
                else if (GestionAsientos.AsientoReservado(asientos[asientoSeleccionado - 1], sala))
                {
                    Console.WriteLine("El asiento ya está reservado. Elija otro asiento.");
                }
            }


            GestionAsientos.ReservarAsiento(asientos[asientoSeleccionado - 1], sala);

            Console.Clear();
            Console.WriteLine("===============================\n" +
                              "Sede: " + sede + "\n" +
                              "Sala: " + sala + "\n" +
                              "Asiento seleccionado: " + asientos[asientoSeleccionado - 1] + "\n" +
                              "Película: " + pelicula + "\n" +
                              "Horario: " + horario + "\n" +
                              "===============================\n" +
                              "Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }


        public static void ValidarPago()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Confirmación de Pedido\n" +
                              "================================");

            decimal totalPedido = 0;


            Console.WriteLine("Películas seleccionadas:");
            ListaEnlazada MostrarSeleccionadas = GestionSeleccion.ObtenerListaSeleccionadas();

            if (listaPeliculas.cabeza == null)
            {
                Console.WriteLine("No ha seleccionado ninguna película.");
            }
            else
            {
                NodoPelicula peliculaActual = listaPeliculas.cabeza;
                do
                {
                    Console.WriteLine("- " + peliculaActual.Datos.Nombre + " - Horario: " + peliculaActual.Datos.Horario + " - Precio: S/." + peliculaActual.Datos.Precio.ToString("F2"));
                    totalPedido += peliculaActual.Datos.Precio;
                    peliculaActual = peliculaActual.Siguiente;
                } while (peliculaActual != listaPeliculas.cabeza);
            }


            Console.WriteLine("\nProductos seleccionados de la tienda:");
            if (GestionTienda.productosSeleccionados.IsEmpty())
            {
                Console.WriteLine("No ha seleccionado ningún producto.");
            }
            else
            {
                NodoProductos productoActual = GestionTienda.productosSeleccionados.frente;
                while (productoActual != null)
                {
                    Console.WriteLine("- " + productoActual.producto.Nombre + " - Precio: S/." + productoActual.producto.Precio.ToString("F2") + " - Cantidad: 1");
                    totalPedido += productoActual.producto.Precio;
                    productoActual = productoActual.sgte;
                }
            }


            Console.WriteLine("\nTotal del pedido: S/." + totalPedido.ToString("F2"));
            Console.WriteLine("\n¿Desea confirmar el pedido? (Escriba 'si' o 'no')");

            string confirmacion = Console.ReadLine()?.ToLower();

            if (confirmacion == "si")
            {

                GuardarPago(totalPedido);

                Console.WriteLine("¡Pedido confirmado con éxito!");
            }
            else
            {
                Console.WriteLine("El pedido ha sido cancelado. No se realizaron cambios.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }


        public static void GuardarPago(decimal totalPedido)
        {

            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine("================================");
            Console.WriteLine("Información del Pago");
            Console.WriteLine("================================");
            Console.WriteLine("Fecha: " + fechaHora);
            Console.WriteLine("Total: S/." + totalPedido);
            Console.WriteLine("================================");
        }


        public static void MenuRolTrabajador()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Trabajador\n" +
                                  "=====================\n" +
                                  "1: Registro Trabajador\n" +
                                  "2: Selección de Productos y Experiencias\n" +
                                  "3: Seleccion de productos\n" +
                                  "4: validar pagos\n" +
                                  "5: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        MenuTrabajadorOpciones();
                        break;
                    case 2:
                        ListarPeliculas();
                        break;
                    case 3:
                        SeleccionProductos();
                        break;
                    case 4:
                        ValidarPago();
                        break;
                    case 5:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }


        public static void MenuTrabajadorOpciones()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Registro Trabajador\n" +
                                  "=====================\n" +
                                  "1: Crear cuenta\n" +
                                  "2: Iniciar sesión\n" +
                                  "3: Actualizar cuenta\n" +
                                  "4: Eliminar cuenta\n" +
                                  "5: Volver al menú de Trabajador\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        RegistrarTrabajador();
                        break;
                    case 2:
                        IniciarSesionTrabajador();
                        break;
                    case 3:
                        ActualizarTrabajador();
                        break;
                    case 4:
                        EliminarTrabajador();
                        break;
                    case 5:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }


        public static void RegistrarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese el nombre del trabajador: ");
            if (string.IsNullOrWhiteSpace(nombreTrabajador) || listaUsuarios.BuscarUsuario(nombreTrabajador) != null)
            {
                Console.WriteLine("El nombre del trabajador no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese la contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }


            string rol = "trabajador";
            listaUsuarios.InsertarFinal(new Usuario(nombreTrabajador, contraseña, rol));
            Console.WriteLine("================================");
            Console.WriteLine("Trabajador registrado con éxito.");
            Console.ReadKey();
        }


        public static void IniciarSesionTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Trabajador)\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese su nombre de trabajador: ");
            Usuario trabajador = listaUsuarios.BuscarUsuario(nombreTrabajador);

            if (trabajador != null)
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (trabajador.Contraseña == contraseña)
                {
                    Console.WriteLine("================================");
                    Console.WriteLine("Inicio de sesión exitoso.");
                }
                else
                {
                    Console.WriteLine("================================");
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }


        public static void ActualizarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Actualizar Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese su nombre de trabajador: ");
            Usuario trabajador = listaUsuarios.BuscarUsuario(nombreTrabajador);

            if (trabajador != null)
            {
                string nuevaContraseña = Operaciones.getTextoPantalla("Ingrese la nueva contraseña: ");
                if (string.IsNullOrWhiteSpace(nuevaContraseña))
                {
                    Console.WriteLine("La contraseña no puede estar vacía.");
                    Console.ReadKey();
                    return;
                }


                trabajador.Contraseña = nuevaContraseña;
                Console.WriteLine("================================");
                Console.WriteLine("Cuenta de trabajador actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.ReadKey();
        }


        public static void EliminarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese el nombre del trabajador: ");
            Usuario trabajador = listaUsuarios.BuscarUsuario(nombreTrabajador);

            if (trabajador != null)
            {

                listaUsuarios.EliminarUsuario(nombreTrabajador);
                Console.WriteLine("================================");
                Console.WriteLine("Trabajador eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.ReadKey();
        }


        public static void MenuRolAdminFun()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Administrador\n" +
                                  "=====================\n" +
                                  "1: Registrar Administradores\n" +
                                  "2: Iniciar Sesión\n" +
                                  "3: Listar Usuarios\n" +
                                  "4: Gestión Cinematográfica\n" +
                                  "5: Gestión de Sedes\n" +
                                  "6: Gestión de Tienda\n" +
                                  "7: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        RegistrarAdministracion();
                        break;
                    case 2:
                        IniciarSesionAdmin();
                        break;
                    case 3:
                        MostrarUsuariosConPrioridad();
                        break;
                    case 4:
                        GestionCinematografica.GestionCine();
                        break;
                    case 5:
                        GestionSedes.MostrarMenu();
                        break;
                    case 6:
                        GestionTienda.GestionarTienda();
                        break;
                    case 0:
                        break;


                }
            } while (opcion != 7);
        }


        public static void RegistrarAdministracion()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Administrador\n" +
                              "================================");

            string nombreAdmin = Operaciones.getTextoPantalla("Ingrese el nombre del administrador: ");
            if (string.IsNullOrWhiteSpace(nombreAdmin) || listaUsuarios.BuscarUsuario(nombreAdmin) != null)
            {
                Console.WriteLine("El nombre del administrador no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese la contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }


            string rol = "administrador";
            listaUsuarios.InsertarFinal(new Usuario(nombreAdmin, contraseña, rol));
            Console.WriteLine("==============================");
            Console.WriteLine("Administrador registrado con éxito.");
            Console.ReadKey();
        }


        public static void IniciarSesionAdmin()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Administrador)\n" +
                              "================================");

            string nombreAdmin = Operaciones.getTextoPantalla("Ingrese su nombre de administrador: ");
            Usuario usuario = listaUsuarios.BuscarUsuario(nombreAdmin);

            if (usuario != null)
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (usuario.Contraseña == contraseña)
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine("Inicio de sesión exitoso.");

                }
                else
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("El administrador no existe.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        public static void MostrarUsuariosConPrioridad()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Listar usuarios\n" +
                                  "=====================\n" +
                                  "1: Listar Usuarios\n" +
                                  "2: Listar Según el Cliente\n" +
                                  "3: Listar Según el Administrador\n" +
                                  "4: Regresar al menú anterior\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        MostrarUsuarios();
                        break;
                    case 2:
                        ListarCliente();
                        break;
                    case 3:
                        ListarAdministrador();
                        break;
                    case 4:
                        return; // Regresar al menú anterior
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4);
        }


        public static void MostrarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS REGISTRADOS");
            Console.WriteLine("==============================");


            Console.WriteLine("CLIENTES:");
            bool hayClientes = false;
            NodoUsuario actual = listaUsuarios.cabeza;

            while (actual != null)
            {
                if (actual.Datos.Rol == "cliente")
                {
                    Console.WriteLine($"- {actual.Datos.NombreUsuario}");
                    hayClientes = true;
                }
                actual = actual.Siguiente;
            }
            if (!hayClientes)
            {
                Console.WriteLine("No hay clientes registrados.");
            }


            Console.WriteLine("\nTRABAJADORES:");
            bool hayTrabajadores = false;
            actual = listaUsuarios.cabeza;

            while (actual != null)
            {
                if (actual.Datos.Rol == "trabajador")
                {
                    Console.WriteLine($"- {actual.Datos.NombreUsuario}");
                    hayTrabajadores = true;
                }
                actual = actual.Siguiente;
            }
            if (!hayTrabajadores)
            {
                Console.WriteLine("No hay trabajadores registrados.");
            }


            Console.WriteLine("\nADMINISTRADORES:");
            bool hayAdministradores = false;
            actual = listaUsuarios.cabeza;

            while (actual != null)
            {
                if (actual.Datos.Rol == "administrador")
                {
                    Console.WriteLine($"- {actual.Datos.NombreUsuario}");
                    hayAdministradores = true;
                }
                actual = actual.Siguiente;
            }
            if (!hayAdministradores)
            {
                Console.WriteLine("No hay administradores registrados.");
            }

            Console.WriteLine("==============================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }
        public static void ListarCliente()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS (Prioridad Cliente)");
            Console.WriteLine("==============================");

            // Crear un árbol para almacenar los usuarios
            Arbol arbolUsuarios = new Arbol();

            // Recorrer la lista de usuarios (suponemos que la lista de usuarios se llama listaUsuarios)
            NodoUsuario actual = listaUsuarios.cabeza;

            // Primero insertamos los clientes
            while (actual != null)
            {
                if (actual.Datos.Rol == "cliente")
                {
                    arbolUsuarios.Insertar(actual.Datos);  // Insertamos en el árbol
                }
                actual = actual.Siguiente;
            }

            // Luego insertamos los trabajadores
            actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Datos.Rol == "trabajador")
                {
                    arbolUsuarios.Insertar(actual.Datos);
                }
                actual = actual.Siguiente;
            }

            // Finalmente insertamos los administradores
            actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Datos.Rol == "administrador")
                {
                    arbolUsuarios.Insertar(actual.Datos);
                }
                actual = actual.Siguiente;
            }

            // Mostrar el árbol de usuarios
            arbolUsuarios.Mostrar();

            Console.WriteLine("==============================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        public static void ListarAdministrador()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS (Prioridad Administrador)");
            Console.WriteLine("==============================");

            // Crear un árbol para almacenar los usuarios
            Arbol arbolUsuarios = new Arbol();

            // Insertar primero los administradores
            NodoUsuario actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Datos.Rol == "administrador")
                {
                    arbolUsuarios.Insertar(actual.Datos);  // Insertamos en el árbol
                }
                actual = actual.Siguiente;
            }

            // Luego insertamos los trabajadores
            actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Datos.Rol == "trabajador")
                {
                    arbolUsuarios.Insertar(actual.Datos);
                }
                actual = actual.Siguiente;
            }

            // Finalmente insertamos los clientes
            actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Datos.Rol == "cliente")
                {
                    arbolUsuarios.Insertar(actual.Datos);
                }
                actual = actual.Siguiente;
            }

            // Mostrar el árbol de usuarios
            arbolUsuarios.Mostrar();

            Console.WriteLine("==============================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        public static class GestionCinematografica
        {
            private static ColaPrioridad colaPrioridad = new ColaPrioridad();

            public static void GestionCine()
            {
                int opcion;

                do
                {
                    Console.Clear();
                    Console.WriteLine("=====================\n" +
                                      "Gestión de Películas\n" +
                                      "=====================\n" +
                                      "1: Agregar película\n" +
                                      "2: Actualizar película\n" +
                                      "3: Eliminar película\n" +
                                      "4: Películas Registradas\n" +
                                      "5: Regresar al menú de administrador\n");

                    opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                    switch (opcion)
                    {
                        case 1:
                            AgregarPelicula();
                            break;
                        case 2:
                            ActualizarPelicula();
                            break;
                        case 3:
                            EliminarPelicula();
                            break;
                        case 4:
                            MostrarPeliculasConPrioridad();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcion != 5);
            }



            public static void AgregarPelicula()
            {
                Console.Clear();
                Console.WriteLine("================================\n" +
                                  "Agregar Película\n" +
                                  "================================");

                string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película: ");
                if (string.IsNullOrWhiteSpace(nombrePelicula) || listaPeliculas.BuscarPelicula(nombrePelicula) != null)
                {
                    Console.WriteLine("El nombre de la película no es válido o ya existe.");
                    Console.ReadKey();
                    return;
                }

                string horario = Operaciones.getTextoPantalla("Ingrese el horario de la película: ");
                if (string.IsNullOrWhiteSpace(horario))
                {
                    Console.WriteLine("El horario no puede estar vacío.");
                    Console.ReadKey();
                    return;
                }

                decimal precio = Operaciones.getDecimal("Ingrese el precio de la película: ");
                int prioridad = Operaciones.getEntero("Ingrese la prioridad de la película (número entero): ", "Prioridad no válida. Intente nuevamente.");

                Pelicula nuevaPelicula = new Pelicula(nombrePelicula, horario, precio);

                listaPeliculas.InsertarFinal(nuevaPelicula);
                colaPrioridad.AgregarPelicula(nuevaPelicula, prioridad);

                Console.WriteLine("================================");
                Console.WriteLine("Película agregada con éxito.");
                Console.ReadKey();
            }

            public static void MostrarPeliculasConPrioridad()
            {
                int opcion;

                do
                {
                    Console.Clear();
                    Console.WriteLine("=====================\n" +
                                      "Peliculas Registradas\n" +
                                      "=====================\n" +
                                      "1: Listar peliculas \n" +
                                      "2: Listar cola prioridad\n" +
                                      "3: Eliminar cola prioridad\n" +
                                      "4: Combinación de películas\n" +
                                      "5: Regresar a la gestión de películas\n");

                    opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                    switch (opcion)
                    {
                        case 1:
                            PeliculasRegistradas();
                            break;
                        case 2:
                            PeliculaColaPrioridad();
                            break;
                        case 3:
                            EliminarTodaLaCola();
                            break;
                        case 4:
                            //CombinacionPeliculas();
                            break;
                        case 5:
                            return; // Regresar al menú anterior
                        default:
                            Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcion != 5);
            }
            public static void PeliculaColaPrioridad()
            {
                Console.Clear();
                Console.WriteLine("======================================================================");
                Console.WriteLine("       Películas en Cola de Prioridad     ");
                Console.WriteLine("======================================================================");

                if (colaPrioridad.EstaVacia())
                {
                    Console.WriteLine("\nNo hay películas en la cola de prioridad.");
                }
                else
                {
                    // Ordenamos la cola de nodos en su lugar (in-place)
                    OrdenarCola();

                    // Imprimimos las películas ordenadas
                    NodoPrioridad actual = colaPrioridad.ObtenerNodoFrente();
                    Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}", "Nombre", "Horario", "Precio", "Prioridad");
                    Console.WriteLine("---------------------------------------------------------------------");

                    while (actual != null)
                    {
                        Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}",
                                          actual.Pelicula.Nombre,
                                          actual.Pelicula.Horario,
                                          actual.Pelicula.Precio.ToString("C"),
                                          actual.Prioridad);
                        actual = actual.Siguiente;
                    }
                }

                Console.WriteLine("======================================================================");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

            public static void PeliculasRegistradas()
            {
                Console.Clear();
                Console.WriteLine("======================================================================");
                Console.WriteLine("       Películas Registradas Sin Orden     ");
                Console.WriteLine("======================================================================");

                if (colaPrioridad.EstaVacia())
                {
                    Console.WriteLine("\nNo hay películas registradas.");
                }
                else
                {
                    // Mostrar la cola en el orden de ingreso sin ordenar
                    NodoPrioridad actual = colaPrioridad.ObtenerNodoFrente();
                    Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}", "Nombre", "Horario", "Precio", "Prioridad");
                    Console.WriteLine("---------------------------------------------------------------------");

                    while (actual != null)
                    {
                        Console.WriteLine("{0,-25} | {1,-15} | {2,-10} | {3,-10}",
                                          actual.Pelicula.Nombre,
                                          actual.Pelicula.Horario,
                                          actual.Pelicula.Precio.ToString("C"),
                                          actual.Prioridad);
                        actual = actual.Siguiente;
                    }
                }

                Console.WriteLine("======================================================================");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

            private static void OrdenarCola()
            {
                if (colaPrioridad.EstaVacia() || colaPrioridad.ObtenerNodoFrente().Siguiente == null)
                {
                    return; // Si la cola está vacía o tiene solo un elemento, no hay nada que ordenar
                }

                // Usamos un algoritmo de ordenación por selección
                NodoPrioridad anterior = null;
                NodoPrioridad actual = colaPrioridad.ObtenerNodoFrente();
                NodoPrioridad siguiente = null;

                while (actual != null)
                {
                    siguiente = actual.Siguiente;
                    while (siguiente != null)
                    {
                        // Comparamos los nodos actual y siguiente
                        bool intercambiar = false;

                        // Ordenamos por prioridad primero
                        if (actual.Prioridad > siguiente.Prioridad)
                        {
                            intercambiar = true;
                        }
                        else if (actual.Prioridad == siguiente.Prioridad)
                        {
                            // Si la prioridad es la misma, comparamos por precio
                            if (actual.Pelicula.Precio > siguiente.Pelicula.Precio)
                            {
                                intercambiar = true;
                            }
                            else if (actual.Pelicula.Precio == siguiente.Pelicula.Precio)
                            {
                                // Si el precio es el mismo, comparamos por horario
                                if (String.Compare(actual.Pelicula.Horario, siguiente.Pelicula.Horario) > 0)
                                {
                                    intercambiar = true;
                                }
                            }
                        }

                        // Si se debe intercambiar, cambiamos los enlaces de los nodos
                        if (intercambiar)
                        {
                            // Intercambiamos las referencias de los nodos
                            NodoPrioridad temp = actual.Siguiente;
                            actual.Siguiente = siguiente.Siguiente;
                            siguiente.Siguiente = temp;

                            // Si el nodo anterior existe, actualizamos su enlace
                            if (anterior != null)
                            {
                                anterior.Siguiente = siguiente;
                            }

                            // Si el nodo siguiente es el primero, actualizamos la cabeza
                            if (actual == colaPrioridad.ObtenerNodoFrente())
                            {
                                colaPrioridad.ObtenerNodoFrente().Siguiente = actual;
                            }

                            // Realizamos un cambio de referencia para seguir comparando
                            temp = actual;
                            actual = siguiente;
                            siguiente = temp;
                        }
                        siguiente = siguiente.Siguiente;
                    }
                    actual = actual.Siguiente;
                }
            }
            public static void EliminarTodaLaCola()
            {
                // Solicitar confirmación del usuario
                Console.Clear();
                Console.WriteLine("¿Está seguro de que desea eliminar toda la cola de prioridad? (S/N)");

                // Leer la respuesta del usuario
                string respuesta = Console.ReadLine().Trim().ToUpper();

                if (respuesta == "S") // Si el usuario confirma con "S"
                {
                    // Verificamos si la cola está vacía
                    if (colaPrioridad.EstaVacia())
                    {
                        Console.WriteLine("La cola de prioridad ya está vacía.");
                    }
                    else
                    {
                        // Recorremos la cola y eliminamos todos los nodos
                        NodoPrioridad actual = colaPrioridad.ObtenerNodoFrente();

                        while (actual != null)
                        {
                            NodoPrioridad siguiente = actual.Siguiente;
                            actual.Siguiente = null;  // Limpiamos la referencia al siguiente nodo
                            actual = siguiente;       // Pasamos al siguiente nodo
                        }

                        // Después de limpiar todos los nodos, la cola se considera vacía
                        colaPrioridad = new ColaPrioridad();  // Reiniciamos la cola de prioridad
                        Console.WriteLine("Cola de prioridad eliminada correctamente.");
                    }
                }
                else if (respuesta == "N") // Si el usuario responde con "N"
                {
                    Console.WriteLine("No se ha eliminado la cola de prioridad. Presione cualquier tecla para regresar al menú.");
                }
                else
                {
                    // Si la respuesta no es válida
                    Console.WriteLine("Respuesta no válida. Presione cualquier tecla para regresar al menú.");
                }

                // Esperamos que el usuario presione una tecla antes de regresar al menú
                Console.ReadKey();
            }


            public static void SeleccionarPelicula()
            {
                Console.Clear();
                Console.WriteLine("================================\n" +
                                  "Seleccionar Película\n" +
                                  "================================");


                listaPeliculas.MostrarPeliculas();

                Console.WriteLine("\nSeleccione el número de la película que desea seleccionar o 0 para volver al menú:");
                int opcion = Operaciones.getEntero("Ingrese su opción: ", "Opción no válida. Intente nuevamente.");

                if (opcion == 0)
                    return;


                Pelicula peliculaSeleccionada = listaPeliculas.ObtenerPorIndice(opcion);

                if (peliculaSeleccionada != null)
                {
                    peliculasSeleccionadas.InsertarFinal(peliculaSeleccionada);
                    Console.WriteLine("Película seleccionada con éxito.");
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }

                Console.ReadKey();
            }


            public static void ActualizarPelicula()
            {
                Console.Clear();
                Console.WriteLine("================================\n" +
                                  "Actualizar Película\n" +
                                  "================================");

                string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película a actualizar: ");


                Pelicula peliculaActualizar = listaPeliculas.BuscarPelicula(nombrePelicula);

                if (peliculaActualizar == null)
                {
                    Console.WriteLine("La película no existe.");
                    Console.ReadKey();
                    return;
                }

                string nuevoHorario = Operaciones.getTextoPantalla("Ingrese el nuevo horario de la película: ");
                decimal nuevoPrecio = Operaciones.getDecimal("Ingrese el nuevo precio de la película: ");


                peliculaActualizar.Horario = nuevoHorario;
                peliculaActualizar.Precio = nuevoPrecio;
                Console.WriteLine("================================");
                Console.WriteLine("Película actualizada con éxito.");
                Console.ReadKey();
            }


            public static void EliminarPelicula()
            {
                Console.Clear();
                Console.WriteLine("================================\n" +
                                  "Eliminar Película\n" +
                                  "================================");

                string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película a eliminar: ");


                Pelicula peliculaEliminar = listaPeliculas.BuscarPelicula(nombrePelicula);

                if (peliculaEliminar != null)
                {

                    listaPeliculas.EliminarPelicula(peliculaEliminar);
                    Console.WriteLine("Película eliminada con éxito.");
                }
                else
                {
                    Console.WriteLine("La película no existe.");
                }

                Console.ReadKey();
            }

        }
        public static class GestionSedes
        {
            public static PilaSedes gestionSedes = new PilaSedes();


            public static void MostrarMenu()
            {
                int opcion;
                do
                {
                    Console.Clear();
                    Console.WriteLine("=====================\n" +
                                      "Gestión de Sedes\n" +
                                      "=====================\n" +
                                      "1: Agregar Sede\n" +
                                      "2: Editar Sede\n" +
                                      "3: Eliminar Sede\n" +
                                      "4: Listar Sedes\n" +
                                      "5: Regresar al menú anterior\n");

                    opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                    switch (opcion)
                    {
                        case 1:
                            AgregarSede();
                            break;

                        case 2:
                            EditarSede();
                            break;

                        case 3:
                            EliminarSede();
                            break;

                        case 4:
                            ListarSedes(true);
                            break;

                        case 5:
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }

                } while (opcion != 5);
            }


            public static void AgregarSede()
            {
                Console.Clear();
                Console.WriteLine("Agregar una nueva sede:");
                Console.Write("Ingrese el nombre de la nueva sede: ");
                string nuevaSede = Console.ReadLine();
                Console.Write("Ingrese la prioridad de la sede (número): ");
                int prioridad = Convert.ToInt32(Console.ReadLine());

                // Agregar la sede con prioridad
                gestionSedes.push(nuevaSede, prioridad);
                Console.WriteLine("Sede agregada exitosamente.");
            }



            public static void ListarSedes(bool mostrarMensajeDeRegreso = false)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("SEDES REGISTRADAS");
                Console.WriteLine("==============================");

                if (gestionSedes.pila == null)
                {
                    Console.WriteLine("No hay sedes registradas.");
                }
                else
                {
                    NodoSede actual = gestionSedes.pila;
                    int contador = 1;
                    while (actual != null)
                    {
                        Console.WriteLine($"{contador}: {actual.sede} - Prioridad: {actual.prioridad}");
                        actual = actual.sgte;
                        contador++;
                    }
                }

                if (mostrarMensajeDeRegreso)
                {
                    Console.WriteLine("\nPresione cualquier tecla para regresar a la gestión de cines...");
                    Console.ReadKey();
                }
            }



            public static void EditarSede()
            {
                Console.Clear();
                Console.WriteLine("EDITAR SEDE");
                ListarSedes(false);

                Console.Write("Seleccione el número de la sede que desea editar: ");
                int numeroSede = Convert.ToInt32(Console.ReadLine());

                NodoSede actual = gestionSedes.pila;
                int contador = 1;
                bool sedeEncontrada = false;

                while (actual != null)
                {
                    if (contador == numeroSede)
                    {
                        Console.Write("Ingrese el nuevo nombre para la sede: ");
                        string nuevaSede = Console.ReadLine();
                        Console.Write("Ingrese la nueva prioridad para la sede: ");
                        int nuevaPrioridad = Convert.ToInt32(Console.ReadLine());

                        actual.sede = nuevaSede;
                        actual.prioridad = nuevaPrioridad;
                        sedeEncontrada = true;
                        Console.WriteLine("Sede actualizada: " + nuevaSede);
                        break;
                    }
                    actual = actual.sgte;
                    contador++;
                }

                if (!sedeEncontrada)
                {
                    Console.WriteLine("Sede no encontrada.");
                }

                Console.WriteLine("\nPresione cualquier tecla para regresar a la gestión de cines...");
            }



            public static void EliminarSede()
            {
                Console.Clear();
                Console.WriteLine("ELIMINAR SEDE");
                ListarSedes(false);

                Console.Write("Seleccione el número de la sede que desea eliminar: ");
                int numeroSede = Convert.ToInt32(Console.ReadLine());

                NodoSede actual = gestionSedes.pila;
                NodoSede anterior = null;
                int contador = 1;
                bool sedeEncontrada = false;

                while (actual != null)
                {
                    if (contador == numeroSede)
                    {
                        sedeEncontrada = true;
                        if (anterior != null)
                        {
                            anterior.sgte = actual.sgte;
                        }
                        else
                        {
                            gestionSedes.pila = actual.sgte;
                        }
                        Console.WriteLine("Sede eliminada: " + actual.sede);
                        break;
                    }
                    anterior = actual;
                    actual = actual.sgte;
                    contador++;
                }

                if (!sedeEncontrada)
                {
                    Console.WriteLine("Sede no encontrada.");
                }

                Console.WriteLine("\nPresione cualquier tecla para regresar a la gestión de cines...");
            }
        }

        public static class GestionTienda
        {
            public static ColaProductos gestionProductos = new ColaProductos();
            public static ColaProductos productosSeleccionados = new ColaProductos();

            static GestionTienda()
            {
                gestionProductos.Enqueue(new Productos("Popcorn Grande", 15m, 30));
                gestionProductos.Enqueue(new Productos("Popcorn Mediano", 10m, 30));
                gestionProductos.Enqueue(new Productos("Popcorn Pequeño", 5m, 30));
                gestionProductos.Enqueue(new Productos("Gaseosa Grande", 9m, 30));
                gestionProductos.Enqueue(new Productos("Gaseosa Mediana", 3m, 30));
                gestionProductos.Enqueue(new Productos("Gaseosa Pequeña", 6m, 30));
                gestionProductos.Enqueue(new Productos("Chocolate", 3.50m, 30));
                gestionProductos.Enqueue(new Productos("Galletas", 2.50m, 30));
            }


            public static void GestionarTienda()
            {
                int opcion;
                do
                {
                    Console.Clear();
                    Console.WriteLine("=====================\n" +
                                      "Gestión de Tienda\n" +
                                      "=====================\n" +
                                      "1: Agregar producto\n" +
                                      "2: Actualizar producto/precio/stock\n" +
                                      "3: Eliminar producto\n" +
                                      "4: Ver stock\n" +
                                      "5: Regresar al menú de administrador\n");

                    opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                    switch (opcion)
                    {
                        case 1:
                            AgregarProducto();
                            break;
                        case 2:
                            ActualizarProducto();
                            break;
                        case 3:
                            EliminarProducto();
                            break;
                        case 4:
                            ListarProductos();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcion != 5);
            }


            public static void AgregarProducto()
            {
                Console.Clear();
                Console.WriteLine("Agregar un nuevo producto:");
                Console.Write("Ingrese el nombre del producto: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese el precio del producto: ");
                decimal precio = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Ingrese el stock del producto: ");
                int stock = Convert.ToInt32(Console.ReadLine());

                gestionProductos.Enqueue(new Productos(nombre, precio, stock));
                Console.WriteLine("Producto agregado exitosamente.");
                Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
                Console.ReadKey();
            }


            public static void ListarProductos()
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("PRODUCTOS EN STOCK");
                Console.WriteLine("==============================");

                if (gestionProductos.IsEmpty())
                {
                    Console.WriteLine("No hay productos en stock.");
                }
                else
                {
                    NodoProductos actual = gestionProductos.frente;
                    int contador = 1;
                    while (actual != null)
                    {
                        Console.WriteLine($"{contador}: {actual.producto.Nombre} - Precio: S/.{actual.producto.Precio} - Stock: {actual.producto.Stock}");
                        actual = actual.sgte;
                        contador++;
                    }
                }

                Console.WriteLine("");
                Console.ReadKey();
            }


            public static void ActualizarProducto()
            {
                Console.Clear();
                Console.WriteLine("ACTUALIZAR PRODUCTO");
                ListarProductos();

                Console.Write("Seleccione el número del producto que desea actualizar: ");
                int numeroProducto = Convert.ToInt32(Console.ReadLine());

                NodoProductos actual = gestionProductos.frente;
                int contador = 1;
                bool productoEncontrado = false;

                while (actual != null)
                {
                    if (contador == numeroProducto)
                    {
                        Console.Write("Ingrese el nuevo nombre del producto (deje en blanco para no cambiar): ");
                        string nuevoNombre = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoNombre)) actual.producto.Nombre = nuevoNombre;
                        Console.Write("Ingrese el nuevo precio del producto (deje en blanco para no cambiar): ");
                        string nuevoPrecioInput = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoPrecioInput)) actual.producto.Precio = Convert.ToDecimal(nuevoPrecioInput);

                        Console.Write("Ingrese el nuevo stock del producto (deje en blanco para no cambiar): ");
                        string nuevoStockInput = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoStockInput)) actual.producto.Stock = Convert.ToInt32(nuevoStockInput);

                        productoEncontrado = true;
                        Console.WriteLine("Producto actualizado exitosamente.");
                        break;
                    }
                    actual = actual.sgte;
                    contador++;
                }

                if (!productoEncontrado)
                {
                    Console.WriteLine("Producto no encontrado.");
                }

                Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
                Console.ReadKey();
            }


            public static void EliminarProducto()
            {
                Console.Clear();
                Console.WriteLine("ELIMINAR PRODUCTO");
                ListarProductos();

                Console.Write("Seleccione el número del producto que desea eliminar: ");
                int numeroProducto = Convert.ToInt32(Console.ReadLine());

                NodoProductos actual = gestionProductos.frente;
                NodoProductos anterior = null;
                int contador = 1;
                bool productoEncontrado = false;

                while (actual != null)
                {
                    if (contador == numeroProducto)
                    {
                        productoEncontrado = true;
                        if (anterior != null)
                        {
                            anterior.sgte = actual.sgte;
                        }
                        else
                        {
                            gestionProductos.frente = actual.sgte;
                        }
                        Console.WriteLine("Producto eliminado: " + actual.producto.Nombre);
                        break;
                    }
                    anterior = actual;
                    actual = actual.sgte;
                    contador++;
                }

                if (!productoEncontrado)
                {
                    Console.WriteLine("Producto no encontrado.");
                }

                Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
                Console.ReadKey();
            }
        }
    }

}