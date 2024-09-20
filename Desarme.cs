using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Creación del nodo "Desarme"
    internal class Desarme
    {
        //Datos del nodo de la lista doble
        private int G6_operario;
        private int G6_tiempoServicio;
        private int G6_codigoDesarme;
        private Desarme sgte; //Enlace sgte. del nodo de la lista doble
        private Desarme ant; //Enlace anterior del nodo de la lista doble

        //Definir propiedades
        //Propiedades para el acceso a los datos "Operario", "CodigoDesarme" y "TiempoServicio" del nodo
        public int Operario
        {
            get { return G6_operario; } //Leer el dato del nodo
            set { G6_operario = value; } //Escribir el dato del nodo
        }
        public int CodigoDesarme
        {
            get { return G6_codigoDesarme; } //Leer el dato del nodo
            set { G6_codigoDesarme = value; } //Escribir el dato del nodo
        }
        public int TiempoServicio
        {
            get { return G6_tiempoServicio; } //Leer el dato del nodo
            set { G6_tiempoServicio = value; } //Escribir el dato del nodo
        }
        //Propiedad para acceso al enlace siguiente del nodo
        public Desarme Sgte
        {
            get { return sgte; } //Leer el enlace sgte
            set { sgte = value; } //Escribir el enlace sgte
        }
        //Propiedad para acceso al enlace anterior del nodo
        public Desarme Ant
        {
            get { return ant; } //Leer el enlace anterior del nodo
            set { ant = value; } //Escribir el enlace anterior del nodo
        }

        //Definir el constructor
        public Desarme(int codigoDesarme, int operario, int tiempoServicio)
        {
            G6_operario = operario; //Asignar dato al nodo cuando se crea
            G6_codigoDesarme = codigoDesarme; //Asignar dato al nodo cuando se crea
            G6_tiempoServicio = tiempoServicio; //Asignar dato al nodo cuando se crea
            //Al momento de crearse el nodo, "anterior" y "siguiente" apuntan a null
            Ant = null;
            Sgte = null;
        }
    }
}
