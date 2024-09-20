using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Creación de las operaciones que ejecutará la pila "PilaArribo"
    internal class PilaArribo
    {
        private int Max; // Tamaño de la pila
        public int top; // Cantidad de elementos almacenados en la pila
        Arribo[] arribo; // Arreglo de nodos "Arribo"
        public Program Contador2 = new Program(); //Creamos un objeto para manipular la propiedad para el acceso al contador de la clase "Program"

        // Constructor para inicializar la pila
        public PilaArribo(int tamaño)
        {
            Max = tamaño; // Define el tamaño de la pila
            top = 0; // Inicializa la pila vacía
            arribo = new Arribo[Max]; // Creación del arreglo para la pila
        }

        // Método para agregar un elemento a la pila (Push)
        public void Push(Arribo Nodo)
        {
            //Si la pila no está llena, guardamos el nodo
            if (top != Max)
            {
                //Creamos el espacio para el nuevo nodo de la pila (instanciamos)
                arribo[top] = new Arribo();
                arribo[top] = Nodo; // Insertar el elemento en la pila
                top++; // Incrementar el contador de elementos
                Console.Write("\n Los datos se registraron correctamente...");
                Console.ReadKey();
            }
            else
            {
                Console.Write(" La pila está llena..."); //No se pudo ingresar los elementos
                Console.ReadKey();
            }
        }

        // Método para eliminar el último elemento insertado en la pila (Pop)
        public void Pop()
        {
            MostrarPila();
            //Si la pila no está vacía procedemos a eliminar el elemento
            if (top != 0)
            {
                arribo[top] = null; //Elimina el nodo de la pila
                top--; // Decrementa la cantidad de nodos en la pila
                Console.Write("\n El elemento se eliminó correctamente...");
                Contador2.Contador -= 1; //Disminuimos "1" al contador para no alterar el número del producto
                Console.ReadKey(); //Mantenemos la consola abierta hasta que apretemos una tecla (pausa)
            }

        }

        //Función para mostrar los datos de la pila
        public void MostrarPila()
        {
            Arribo Producto; //Creamos un nodo "Producto" para guardar el número de producto de la pila
            int total = 0; //Declaramos la variable "total" para hallar la cantidad de minutos de llegada totales

            Console.Clear(); //Limpiamos la consola
            //Hacemos el encabezado
            Console.WriteLine("        ETAPA DE ARRIBO        " +
                              "\n    Nro.Producto    Minutos" +
                              "\n ----------------------------- ");

            //Utilizamos un "for" para recorrer toda la pila mostrando el número de producto y los minutos de llegada
            for (int contador = 0; contador <= top - 1; contador++)
            {
                Producto = arribo[contador]; //Guardamos cada nodo en el nodo que actúa como almacén
                //Escribimos el número de producto y los minutos de llegada
                Console.WriteLine(Producto.G6_nroproducto.ToString().PadLeft(11,' ') + Producto.G6_minuto.ToString().PadLeft(13, ' '));
                total += Producto.G6_minuto; //Vamos sumando los minutos para llegar a la cantidad total de llegada al final
            }

            Console.WriteLine($"\n -----------------------------\n    TIEMPO TOTAL      {total}"); //Mostramos el total de minutos de llegada

            if (top == 0)
            {
                Console.Write("\n La lista se encuentra vacía...");
                Console.ReadKey();
            }
        }

        //Función para actualizar los datos de la pila
        public void ActualizarPila()
        {
            MostrarPila();
            Arribo Producto; //Creamos un nodo para guardar el nodo con la coincidencia
            int G6_productoActualizar; //Declaramos la variable en donde se guardará el dato de a actualizar
            int G6_nuevodato; //Variable para guardar dato nuevo

            //Si la pila tiene elementos entonces buscamos el dato y lo actualizamos
            if (top != 0)
            {
                Console.WriteLine("\n---------------------------------\n" +
                                  " 0. Volver\n"+
                                  "---------------------------------");
                Console.Write(" ¿Qué producto desea actualizar?\n -> ");
                G6_productoActualizar = int.Parse(Console.ReadLine());
                if (G6_productoActualizar == 0) { return; } //Si colocamos "0" salimos de la función
                Console.Write("\n ¿Qué cantidad de minutos desea ponerle?\n -> ");
                G6_nuevodato = int.Parse(Console.ReadLine());

                //Recorremos la pila con un "for"
                for (int contador = 0; contador <= top - 1; contador++)
                {
                    Producto = arribo[contador]; //Guardamos cada nodo en el nodo que actúa como almacén

                    //Si se encuentra el número de producto a actualizar entonces actualizamos
                    if (Producto.G6_nroproducto == G6_productoActualizar)
                    {
                        Producto.G6_minuto = G6_nuevodato; //Se guarda el nuevo dato en el objeto
                        arribo[contador] = Producto; //Actualizamos el arreglo de nodos con el objeto
                    }
                }

                Console.Write("\n Actualización exitosa...");
                Console.ReadKey();
            }
        }
    }
}
