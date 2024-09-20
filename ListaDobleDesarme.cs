using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Creación de las operaciones que ejecutará la lista "ListaDobleDesarme"
    internal class ListaDobleDesarme
    {
        //Definir el nodo para la lista doble
        private Desarme listaDesarme;
        //Creamos un objeto para manipular la propiedad para el acceso al "contador1" de la clase "Program"
        public Program Contador3 = new Program();

        //Propiedad para acceso a la lista doble
        public Desarme ListaDesarme
        {
            get { return listaDesarme; } //Leer
            set { listaDesarme = value; } //Escribir
        }
        //Definir el constructor e inicializar la lista doble
        public ListaDobleDesarme()
        {
            listaDesarme = null;
        }
        //Método para insertar al final de la lista doble
        public void insertaAlFinalLD(int G6_codigoDesarme, int G6_operario, int G6_tiempoServicio)
        {
            //Hacer p que apunte al inicio de la lista doble
            Desarme p = listaDesarme;
            //Crear el nuevo nodo y asignarle los datos
            Desarme q = new Desarme(G6_codigoDesarme, G6_operario, G6_tiempoServicio);
            //Si la lista doble está vacia
            if (listaDesarme == null)
            {
                //"listaDesarme" apunte al nuevo nodo creado
                listaDesarme = q;
            }
            else
            {
                //Si la lista doble tiene elementeos recorrer la lista doble para ir al final
                while (p.Sgte != null)
                {
                    //Ir al sgte nodo de la lista doble
                    p = p.Sgte;
                }
                //Enlace sgte de "p" apunte al nuevo nodo creado
                p.Sgte = q;
                //Enlace anterior del nodo creado (q) apunte a "p"
                q.Ant = p;
            }
        }
        //Método para mostrar la lista "Desarme"
        public void mostrarListaDesarme()
        {
            int G6_total = 0;
            Console.Clear();
            Desarme q = listaDesarme; //Nodo actual
            Desarme p = listaDesarme; //Nodo actual

            //Encabezado
            Console.WriteLine("                ETAPA DE DESARME\n  Código Desarme      Operario      Tiempo Servicio");
            Console.WriteLine(" ---------------------------------------------------");

            //Si la lista no está vacía entonces la recorremos
            while (q != null)
            {
                G6_total += q.TiempoServicio; //Vamos guardando el total mientras se van agregando el valor de cada nodo
                //Escribimos el valor del nodo y lo volvemos a cadena para alinearlo con el encabezado
                Console.WriteLine($"       D-{q.CodigoDesarme.ToString().PadLeft(11, ' ')}", q.Operario.ToString().PadLeft(27, ' '), q.TiempoServicio.ToString().PadLeft(46, ' '));
                p.Ant = q;
                q = q.Sgte;
            }

            //Mostramos el total de minutos
            Console.WriteLine(" ---------------------------------------------------");
            Console.WriteLine("  TIEMPO TOTAL: " + G6_total.ToString().PadLeft(46, ' '));

            //Si la lista está vacía entonces escribimos un mensaje informando dicha situación
            if (listaDesarme == null)
            {
                Console.Write("\n La lista se encuentra vacía...");
                Console.ReadKey();
            }
        }
        //Función para actualizar los datos de la lista
        public void actualizarListaDesarme()
        {
            Desarme q = listaDesarme;
            Desarme p = listaDesarme;
            mostrarListaDesarme();
            int G6_codigoActualizar;
            int G6_nuevooperario;
            int G6_nuevotservicio;

            //Si la lista tiene elementos entonces buscamos el dato y lo actualizamos
            if (q != null)
            {
                Console.WriteLine("\n---------------------------------\n" +
                                  " 0. Volver\n" +
                                  "---------------------------------");
                Console.Write(" ¿Qué código desea actualizar?\n -> ");
                G6_codigoActualizar = int.Parse(Console.ReadLine());
                if (G6_codigoActualizar == 0) { return; } //Si colocamos "0" salimos de la función
                Console.Write("\n ¿Qué operario desea ponerle?\n -> ");
                G6_nuevooperario = int.Parse(Console.ReadLine());
                Console.Write("\n ¿Qué tiempo de servicio desea ponerle?\n -> ");
                G6_nuevotservicio = int.Parse(Console.ReadLine());

                while (q.CodigoDesarme != G6_codigoActualizar)
                {
                    p.Ant = q;
                    q = q.Sgte;
                }

                q.Operario = G6_nuevooperario;
                q.TiempoServicio = G6_nuevotservicio;
                Console.Write("\n Actualización exitosa...");
                Console.ReadKey();
            }
        }
        public void EliminarListaDesarme()
        {
            mostrarListaDesarme();

            //Creamos dos listas alternas (copias) a la lista original para recorrerlas sin afectar los datos de la lista verdadera
            Desarme q = listaDesarme;
            Desarme t = listaDesarme;
            int G6_codigoEliminar;

            //Si la lista tiene elementos entonces buscamos el dato y lo eliminamos
            if (q != null)
            {
                Console.WriteLine("\n---------------------------------\n" +
                                  " 0. Volver\n" +
                                  "---------------------------------");
                Console.Write(" ¿Qué código desea eliminar?\n -> ");
                G6_codigoEliminar = int.Parse(Console.ReadLine());
                if (G6_codigoEliminar == 0) { return; } //Si colocamos "0" salimos de la función

                while (q.CodigoDesarme != G6_codigoEliminar)
                {
                    t.Ant = q; //Guardamos el elemento de "q" en "t.Ant"
                    q = q.Sgte; //Pasamos al siguiente nodo de la lista
                }

                //Si el nodo que contiene el valor a eliminar es el primer elemento de la lista original, entonces pasamos
                //a la siguiente para eliminar la conexión y de esa forma eliminar su valor también
                if (q == listaDesarme) listaDesarme = listaDesarme.Sgte;
                //Si no, como hemos guardado el nodo anterior al actual (t.Ant) y el nodo actual (q)
                else
                {
                    t = q.Sgte; //Hacemos que el nodo anterior apunte al nodo posterior de nodo actual para omitir al nodo actual y así eliminarlo
                    t.Sgte = null;
                    q = null; //Eliminamos el nodo con el valor que se pretendía buscar para que no acumular "desechos"
                }

                Console.Write("\n El elemento se eliminó correctamente...");
                Contador3.Contador1 -= 1; //Disminuimos "1" al contador para no alterar el número del producto
                Console.ReadKey();
            }
        }
    }
}
