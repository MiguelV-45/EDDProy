using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_No_Lineales
{
    public class NodoBinario
    {
        public int Dato;
        public NodoBinario Izq;
        public NodoBinario Der;
        public Nodo Raiz;

        public NodoBinario(int dato)
        {
            Dato = dato;
            Izq = null;
            Der = null;
            // CAMBIO 2
        }
    }
}
