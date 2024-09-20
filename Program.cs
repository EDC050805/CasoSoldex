using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    internal class Program
    {
        //Instanciamos las listas para poder usar sus funciones
        public static ListaSimpleEnsamblaje ListEns = new ListaSimpleEnsamblaje();
        public static PilaArribo PilaA = new PilaArribo(20);
        public static ListaDobleDesarme ListDes = new ListaDobleDesarme();
        public static int contador = 0;
        public static int contador1 = 0;
        public int Contador { get => contador; set => contador = value; } //Propiedad de acceso de otras clases al contador
        public int Contador1 { get => contador; set => contador = value; } //Propiedad de acceso de otras clases al contador1
        static void Main(string[] args)
        {
            int G6_opc = 0;

            //Según la opción que se obtendrá en el menú se darán distintos casos
            do
            {
                G6_opc = Menu("", 1);
                switch (G6_opc)
                {
                    case 1: //Va al menú de "Arribo"
                        do
                        {
                            G6_opc = Menu("Arribo", 2);
                            switch (G6_opc)
                            {
                                case 1: //Guarda datos
                                    Arribo Producto = new Arribo(); //Formamos un objeto para guardar los datos a ingresar
                                    Encabezado3erN("Arribo");
                                    Console.Write(" Ingrese el tiempo en minutos a agregar: ");
                                    Producto.G6_minuto = int.Parse(Console.ReadLine());
                                    if (Producto.G6_minuto == 0) { break; } //Si colocamos "0" salimos del menú
                                    contador+=1;
                                    Producto.G6_nroproducto = contador; //El número del producto va aumentando en "1" cada vez que agregan los minutos de llegada
                                    PilaA.Push(Producto); //Pasamos el objeto (nodo) para que pueda agregar sus atributos al arreglo
                                    break;

                                case 2: //Mostrar datos
                                    PilaA.MostrarPila();

                                    //Si la pila tiene valores entonces se pulsa cualquier tecla para salir
                                    if (PilaA.top != 0)
                                    {
                                        Console.Write(" ---------------------------------------\n Pulse cualquier tecla para regresar...");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3: //Actualizar datos
                                    PilaA.ActualizarPila();
                                    break;

                                case 4: //Eliminar datos
                                    PilaA.Pop();
                                    break;
                            }
                        } while (G6_opc != 5);
                        break;

                    case 2: //Va al menú de "Desarme"
                        do
                        {
                            G6_opc = Menu("Desarme", 2);
                            switch (G6_opc)
                            {
                                case 1: //Guarda un dato
                                    Encabezado3erN("Desarme");
                                    Console.Write(" Ingrese el operario a agregar: ");
                                    int operario = int.Parse(Console.ReadLine());
                                    if (operario == 0) { break; } //Si colocamos "0" salimos del menú
                                    Console.Write("\n Ingrese el tiempo de servicio a agregar: ");
                                    int tiemServ = int.Parse(Console.ReadLine());
                                    contador1 += 1;
                                    ListDes.insertaAlFinalLD(contador1, operario, tiemServ);
                                    break;

                                case 2: //Mostrar datos
                                    ListDes.mostrarListaDesarme();

                                    //Si la lista tiene valores entonces se pulsa cualquier tecla para salir
                                    if (ListEns.ListaEnsamblaje != null)
                                    {
                                        Console.Write(" ---------------------------------------\n Pulse cualquier tecla para regresar...");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3: //Actualizar datos
                                    ListEns.ActualizarMinEnsamblaje();
                                    break;

                                case 4: //Eliminar datos
                                    ListEns.EliminarMinEnsamblaje();
                                    break;
                            }
                        } while (G6_opc != 5);
                break;

                    case 3: //Va al menú de "Revisión y Reparación"
                        G6_opc = Menu("Revisión y Reparación", 2);
                        break;

                    case 4: //Va al menú de "Ensamblaje"
                        do
                        {
                            G6_opc = Menu("Ensamblaje", 2);
                            switch (G6_opc)
                            {
                                case 1: //Guarda un dato
                                    Encabezado3erN("Ensamblaje");
                                    Console.Write(" Ingrese el tiempo en minutos a agregar: ");
                                    int minutos = int.Parse(Console.ReadLine());
                                    if (minutos == 0) { break; } //Si colocamos "0" salimos del menú
                                    ListEns.RegistrarMinEnsamblaje(minutos);
                                    break;

                                case 2: //Mostrar datos
                                    ListEns.MostrarMinEnsamblaje();

                                    //Si la lista tiene valores entonces se pulsa cualquier tecla para salir
                                    if (ListEns.ListaEnsamblaje != null)
                                    {
                                        Console.Write(" ---------------------------------------\n Pulse cualquier tecla para regresar...");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3: //Actualizar datos
                                    ListEns.ActualizarMinEnsamblaje();
                                    break;

                                case 4: //Eliminar datos
                                    ListEns.EliminarMinEnsamblaje();
                                    break;
                            }
                        } while (G6_opc != 5);
                        break;

                    case 5: //Reporte
                        break;

                    case 6:
                        break;
                }
            } while (G6_opc != 6);
        }

        //Función para mostrar los menús
        public static int Menu(string titulo, int tipo)
        {
            //Primer nivel de menú
            if (tipo == 1)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------\n"+
                              "  Sistema de Producción - Soldex\n"+
                              "-----------------------------------\n"+
                              " 1. Etapa de Arribo\n"+
                              " 2. Etapa de Desarme\n"+
                              " 3. Etapa de Revisión y Reparación\n"+
                              " 4. Etapa de Ensamblaje\n"+
                              " 5. Reporte\n"+
                              " 6. Salir\n"+
                              "-----------------------------------");
                Console.Write(" Ingrese una opción: ");
                return int.Parse(Console.ReadLine());
            }

            //Segundo nivel de menú
            else
            {
                Console.Clear();
                Console.WriteLine("----------------------------------\n"+
                                  "  Sistema de Producción - Soldex\n"+
                                  "----------------------------------\n"+
                                  $" Etapa de {titulo}\n" +
                                  "----------------------------------\n" +
                                  " 1. Ingresar datos\n"+
                                  " 2. Mostrar datos\n"+
                                  " 3. Actualizar datos\n"+
                                  " 4. Eliminar datos\n"+
                                  " 5. Volver\n"+
                                  "----------------------------------");
                Console.Write(" Ingrese una opción: ");
                return int.Parse(Console.ReadLine());
            }
        }

        //Función para mostrar el encabezado del tercer nivel de menú
        public static void Encabezado3erN(string titulo)
        {
                Console.Clear();
                Console.WriteLine("----------------------------------------------\n"+
                                 $" Etapa de {titulo}\n"+
                                  "----------------------------------------------\n" +
                                  " 0. Volver\n"+
                                  "----------------------------------------------");
        }
    }
}
