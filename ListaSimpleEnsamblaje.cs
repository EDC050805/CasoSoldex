using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Creación de las operaciones que ejecutará la lista "ListaSimpleEnsamblaje"
    internal class ListaSimpleEnsamblaje
    {
        public Ensamblaje ListaEnsamblaje;

        //Creamos la lista por un constructor
        public ListaSimpleEnsamblaje()
        {
            ListaEnsamblaje = null;
        }

        //Función para registrar los minutos en la lista
        public void RegistrarMinEnsamblaje(int min)
        {
            Ensamblaje q = new Ensamblaje(min); //Nodo a agregar
            Ensamblaje t = ListaEnsamblaje; //Nodo actual

            //Si la lista está vacía, lo agregamos
            if (ListaEnsamblaje == null)
            {
                ListaEnsamblaje = q;
            } 
            //Si no, recorremos la lista y guardamos el nuevo nodo al final
            else
            {
                while (t.sgte != null)
                {
                    t = t.sgte;
                }
                t.sgte = q;
            }
        }

        //Función para mostrar los minutos de la lista
        public void MostrarMinEnsamblaje()
        {
            int G6_total = 0;
            Console.Clear();
            Ensamblaje q = ListaEnsamblaje; //Nodo actual
            Console.WriteLine("            ETAPA ENSAMBLAJE\n          Tiempo de Ensamblaje");
            Console.WriteLine("          --------------------");

            //Si la lista no está vacía entonces la recorremos
            while (q != null)
            {
                G6_total += q.G6_minutos; //Vamos guardando el total mientras se van agregando el valor de cada nodo
                //Escribimos el valor del nodo y lo volvemos a cadena para alinearlo con el encabezado
                Console.WriteLine(q.G6_minutos.ToString().PadLeft(21,' '));
                q = q.sgte;
            }

            //Mostramos el total de minutos
            Console.WriteLine(" ------------------------------");
            Console.WriteLine(" Total de minutos: " + G6_total);

            //Si la lista está vacía entonces escribimos un mensaje informando dicha situación
            if (ListaEnsamblaje == null)
            {
                Console.Write("\n La lista se encuentra vacía...");
                Console.ReadKey();
            }
        }

        //Función para actualizar los minutos de la lista
        public void ActualizarMinEnsamblaje()
        {
            Ensamblaje q = ListaEnsamblaje;
            MostrarMinEnsamblaje();
            int G6_datoActualizar;
            int G6_nuevodato;

            //Si la lista tiene elementos entonces buscamos el dato y lo actualizamos
            if (q != null)
            {
                Console.WriteLine("\n---------------------------------\n" +
                                  " 0. Volver\n" +
                                  "---------------------------------");
                Console.Write(" ¿Qué dato desea actualizar?\n -> ");
                G6_datoActualizar = int.Parse(Console.ReadLine());
                if (G6_datoActualizar == 0) { return; } //Si colocamos "0" salimos de la función
                Console.Write("\n ¿Qué valor desea ponerle?\n -> ");
                G6_nuevodato = int.Parse(Console.ReadLine());

                while (q.G6_minutos != G6_datoActualizar)
                {
                    q = q.sgte;
                }

                q.G6_minutos = G6_nuevodato;
                Console.Write("\n Actualización exitosa...");
                Console.ReadKey();
            }
        }

        //Función para eliminar los minutos de la lista
        public void EliminarMinEnsamblaje()
        {
            MostrarMinEnsamblaje();

            //Creamos dos listas alternas (copias) a la lista original para recorrerlas sin afectar los datos de la lista verdadera
            //Explicación: como las listas enlazadas simples solo avanzan hacia adelante, si nos vamos para adelante en la lista original,
            //perdemos el valor anterior ya que no se puede ir hacia atrás. Por ello, la lista original siempre estará en el primer nodo de la lista
            Ensamblaje q = ListaEnsamblaje;
            Ensamblaje t = ListaEnsamblaje;
            int G6_datoEliminar;

            //Si la lista tiene elementos entonces buscamos el dato y lo eliminamos
            if (q != null)
            {
                Console.WriteLine("\n---------------------------------\n" +
                                  " 0. Volver\n" +
                                  "---------------------------------");
                Console.Write(" ¿Qué dato desea eliminar?\n -> ");
                G6_datoEliminar = int.Parse(Console.ReadLine());
                if (G6_datoEliminar == 0) { return; } //Si colocamos "0" salimos de la función

                while (q.G6_minutos != G6_datoEliminar)
                {
                    t = q; //Guardamos el elemento de "q" en "t"
                    q = q.sgte; //Pasamos al siguiente nodo de la lista
                }

                //Si el nodo que contiene el valor a eliminar es el primer elemento de la lista original, entonces pasamos
                //a la siguiente para eliminar la conexión y de esa forma eliminar su valor también
                if (q == ListaEnsamblaje) ListaEnsamblaje = ListaEnsamblaje.sgte;
                //Si no, como hemos guardado el nodo anterior al actual (t) y el nodo actual (q)
                else
                {
                    t.sgte = q.sgte; //Hacemos que el nodo anterior apunte al nodo posterior de nodo actual para omitir al nodo actual y así eliminarlo
                    q = null; //Eliminamos el nodo con el valor que se pretendía buscar para que no acumular "desechos"
                }

                Console.Write("\n El elemento se eliminó correctamente...");
                Console.ReadKey();
            }
        }
    }
}
