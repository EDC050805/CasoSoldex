using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Colocamos los atributos del nodo "Arribo"
    internal class Arribo
    {
        public int G6_nroproducto; //Número del producto ingresado
        public int G6_minuto; //Tiempo en que llegó en minutos

        //Propiedad para acceso al número del producto
        public int  NroProducto
        {
            get {  return G6_nroproducto; } //Leer el número del producto
            set { G6_nroproducto = value; } //Escribir el número del producto
        }
        //Propiedad para acceso al tiempo de llegada en minutos
        public int  TiempoLlegada
        {
            get {  return G6_minuto; } //Leer el tiempo de llegada
            set { G6_minuto = value; } //Escribir el tiempo de llegada
        }

    }
}
