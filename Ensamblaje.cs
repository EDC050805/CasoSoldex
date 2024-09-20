using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoSoldex
{
    //Creación del nodo "Ensamblaje"
    internal class Ensamblaje
    {
        public int G6_minutos;
        public Ensamblaje sgte;

        //Guardamos los datos del nodo por un constructor
        public Ensamblaje (int minutos)
        {
            this.G6_minutos = minutos;
            sgte = null;
        }

        //Permitimos que las variables puedan manipularse también en otras clases sin necesaidad de llamar a su clase (instanciarlos)
        public int Minutos { get => G6_minutos; set => G6_minutos = value; }
        public Ensamblaje Sgte
        {
            get { return sgte; }
            set { sgte = value; }
        }
    }
}
