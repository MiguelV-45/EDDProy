using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_Lineales.Clases
{
    // Clase que maneja la lista circular simple
    public class ListaCircularSimple
    {
        private Nodo inicio = null;
        private Nodo fin = null;

        // Método para insertar un nodo en la lista
        public void Insertar(int dato, int posicion)
        {
            Nodo nuevo = new Nodo(dato);// Crear el nuevo nodo con el dato

            // Si la lista está vacía
            if (inicio == null)
            {
                inicio = nuevo;
                fin = nuevo;
                fin.Siguiente = inicio;
            }
            else if (posicion == 0 || posicion == 1)
            {
                nuevo.Siguiente = inicio;
                inicio = nuevo;
                fin.Siguiente = inicio;
            }
            else
            {
                Nodo aux = inicio;
                Nodo previo = null;
                int pos = 1;

                while (pos < posicion && aux.Siguiente!= inicio)
                {
                    previo = aux;
                    aux = aux.Siguiente;
                    pos++;
                }

                if (pos == posicion)
                {
                    nuevo.Siguiente = aux;
                    if (previo != null)
                    {
                        previo.Siguiente = nuevo;
                    }
                }
                else if (aux.Siguiente == inicio)
                {
                    fin.Siguiente = nuevo;
                    fin = nuevo;
                    fin.Siguiente = inicio;
                }
            }
        }

        // Método para eliminar un nodo en una posición específica
        public bool Eliminar(int posicion)
        {
            if (inicio == null) return false;

            Nodo aux = inicio;
            Nodo previo = null;
            int pos = 1;

            while (pos < posicion && aux.Siguiente != inicio)
            {
                previo = aux;
                aux = aux.Siguiente;
                pos++;
            }

            if (aux != null && pos == posicion)
            {
                if (aux == inicio)
                {
                    if (inicio == fin)
                    {
                        inicio = null;
                        fin = null;
                    }
                    else
                    {
                        inicio = inicio.Siguiente;
                        fin.Siguiente = inicio;
                    }
                }
                else if (aux == fin)
                {
                    fin = previo;
                    fin.Siguiente = inicio;
                }
                else
                {
                    previo.Siguiente = aux.Siguiente;
                }

                return true;
            }

            return false;
        }

        // Método para buscar un valor en la lista
        public bool Buscar(int dato)
        {
            if (inicio == null) return false;

            Nodo aux = inicio;
            do
            {
                if (aux.Dato == dato)
                    return true;
                aux = aux.Siguiente;
            } while (aux != inicio);

            return false;
        }

        // Método para vaciar la lista
        public void Vaciar()
        {
            inicio = null;
            fin = null;
        }

        // Método para mostrar los elementos de la lista
        public List<int> Mostrar()
        {
            List<int> elementos = new List<int>();

            if (inicio == null) return elementos;

            Nodo aux = inicio;
            do
            {
                elementos.Add(aux.Dato);
                aux = aux.Siguiente;
            } while (aux != inicio);

            return elementos;
        }
    }
}
