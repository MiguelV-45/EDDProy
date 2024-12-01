using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_Lineales.Clases
{
    public class NodoDoble
    {
        public int dato;  // El valor que almacena el nodo.
        public NodoDoble sig;  // Referencia al siguiente nodo en la lista.
        public NodoDoble prev; // Referencia al nodo anterior en la lista.

        // Constructor que inicializa el nodo con un valor dado.
        public NodoDoble(int dato)
        {
            this.dato = dato;
            this.sig = null;
            this.prev = null;
        }
    }
}
