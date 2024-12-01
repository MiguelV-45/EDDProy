using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_Lineales.Clases
{
    public class ListaDobleEncadenada
    {
        private NodoDoble inicio = null;  // Apunta al primer nodo de la lista.
        private NodoDoble fin = null;     // Apunta al último nodo de la lista.

        // Método para insertar un nuevo nodo en una posición específica.
        public void Insertar(int posicion, int dato)
        {
            NodoDoble nuevo = new NodoDoble(dato);

            if (inicio == null && fin == null)
            {
                inicio = nuevo;
                fin = nuevo;
                return;
            }

            if (posicion == 0 || posicion == 1)
            {
                nuevo.sig = inicio;
                inicio.prev = nuevo;
                inicio = nuevo;
                return;
            }

            NodoDoble aux = inicio;
            int pos = 1;

            while (pos < posicion && aux != null)
            {
                aux = aux.sig;
                pos++;
            }

            if (aux != null)
            {
                nuevo.sig = aux;
                nuevo.prev = aux.prev;
                aux.prev.sig = nuevo;
                aux.prev = nuevo;
            }
            else
            {
                fin.sig = nuevo;
                nuevo.prev = fin;
                fin = nuevo;
            }
        }

        // Método para eliminar un nodo en una posición específica.
        public int? Eliminar(int posicion)
        {
            if (inicio == null && fin == null)
            {
                return null;
            }

            NodoDoble aux = inicio;
            int pos = 1;

            while (pos < posicion && aux != null)
            {
                aux = aux.sig;
                pos++;
            }

            if (aux != null)
            {
                if (aux == fin)
                {
                    fin = aux.prev;
                    if (fin != null) fin.sig = null;
                }
                else if (aux == inicio)
                {
                    inicio = aux.sig;
                    if (inicio != null) inicio.prev = null;
                }
                else
                {
                    aux.prev.sig = aux.sig;
                    if (aux.sig != null) aux.sig.prev = aux.prev;
                }

                int datoEliminado = aux.dato;
                aux = null;
                return datoEliminado;
            }
            return null;
        }

        // Método para buscar un número en la lista.
        public int Buscar(int dato)
        {
            NodoDoble aux = inicio;
            int pos = 0;

            while (aux != null)
            {
                if (aux.dato == dato)
                {
                    return pos;
                }
                aux = aux.sig;
                pos++;
            }
            return -1;
        }

        // Método para mostrar los elementos de la lista.
        public string MostrarLista()
        {
            NodoDoble aux = inicio;
            string lista = "";

            while (aux != null)
            {
                lista += aux.dato + " ";
                aux = aux.sig;
            }

            return lista == "" ? "Lista vacía." : lista;
        }

        // Método para vaciar la lista.
        public void VaciarLista()
        {
            inicio = null;
            fin = null;
        }
    }
}

