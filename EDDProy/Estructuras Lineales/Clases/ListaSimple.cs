using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_Lineales.Clases
{
    public class ListaSimple
    {
        public Nodo cabeza; // Apunta al primer nodo de la lista.

        // Agrega un nuevo nodo al final de la lista.
        public void Agregar(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor); // Aquí se pasa el valor al constructor de Nodo
            if (cabeza == null)
            {
                cabeza = nuevoNodo; // Si la lista está vacía, el nuevo nodo es la cabeza
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; // Avanza hasta el último nodo
                }
                actual.Siguiente = nuevoNodo; // Agrega el nuevo nodo al final de la lista
            }
        }


        // Elimina el primer nodo que contiene el dato especificado.
        public void Eliminar(int dato)
        {
            if (cabeza == null) return; // Si la lista está vacía, no hay nada que eliminar.

            if (cabeza.Dato == dato) // Si el nodo a eliminar es la cabeza.
            {
                cabeza = cabeza.Siguiente; // Mueve la cabeza al siguiente nodo.
                return;
            }

            Nodo actual = cabeza; // Comienza desde la cabeza.
            while (actual.Siguiente != null && actual.Siguiente.Dato != dato)
            {
                actual = actual.Siguiente; // Busca el nodo a eliminar.
            }

            if (actual.Siguiente != null) // Si el nodo existe.
            {
                actual.Siguiente = actual.Siguiente.Siguiente; // Elimina el nodo ajustando los punteros.
            }
        }

        // Busca un dato en la lista y devuelve true si lo encuentra.
        public bool Buscar(int dato)
        {
            Nodo actual = cabeza; // Comienza desde la cabeza.
            while (actual != null)
            {
                if (actual.Dato == dato) return true; // Si encuentra el dato, devuelve true.
                actual = actual.Siguiente; // Avanza al siguiente nodo.
            }
            return false; // Devuelve false si no encuentra el dato.
        }

        // Vacía la lista estableciendo la cabeza como null.
        public void Vaciar()
        {
            cabeza = null; // La lista queda vacía.
        }

        // Muestra los datos de la lista en un Label.
        public void Mostrar(System.Windows.Forms.Label label)
        {
            if (label == null)
            {
                MessageBox.Show("El label no está inicializado.");
                return;
            }

            label.Text = ""; // Limpia el texto del Label.

            if (cabeza == null)
            {
                label.Text = "La lista está vacía."; // Si la lista está vacía, muestra un mensaje.
                return;
            }

            Nodo actual = cabeza; // Comienza desde la cabeza.

            // Recorre la lista e imprime cada dato.
            while (actual != null)
            {
                label.Text += actual.Dato + " "; // Agrega cada dato al Label.
                actual = actual.Siguiente; // Avanza al siguiente nodo.
            }
        }
    }
}
