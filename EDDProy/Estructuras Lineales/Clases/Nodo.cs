using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo
{
    public class Nodo
    {
        public int Dato { get; set; } // Dato almacenado en el nodo.
        public Nodo Siguiente { get; set; } // Referencia al siguiente nodo.

        public Nodo(int dato)
        {
            this.Dato = dato; // Inicializa el dato.
            this.Siguiente = null; // Inicializa el siguiente nodo como null.
        }
    }
}
