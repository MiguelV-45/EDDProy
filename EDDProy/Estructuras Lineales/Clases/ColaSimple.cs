using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_Lineales.Clases
{

    public class ColaSimple
    {

        private Nodo frente = null;  // Puntero al primer nodo de la cola
        private Nodo final = null;   // Puntero al último nodo de la cola

        // Método para agregar un elemento a la cola
        public void AgregarElemento(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento); // Crea un nuevo nodo con el valor ingresado

            if (frente == null) // Si la cola está vacía
            {
                frente = nuevoNodo; // El nuevo nodo será tanto el frente como el final
                final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo; // El último nodo apunta al nuevo nodo
                final = nuevoNodo; // Actualizamos el final para que sea el nuevo nodo
            }
        }

        // Método para eliminar el primer elemento de la cola
        public void EliminarElemento()
        {
            if (frente != null) // Verifica que la cola no esté vacía
            {
                frente = frente.Siguiente; // Mueve el frente al siguiente nodo

                if (frente == null)
                {
                    final = null; // Si la cola quedó vacía después de eliminar el primer elemento
                }
            }
        }

        // Método para eliminar un elemento específico de la cola
        public void EliminarElementoEspecifico(int elemento)
        {
            Nodo actual = frente;
            Nodo anterior = null;
            bool encontrado = false;

            while (actual != null)
            {
                if (actual.Dato == elemento)
                {
                    encontrado = true;
                    if (anterior == null)
                    {
                        frente = actual.Siguiente;
                        if (frente == null) final = null;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                        if (anterior.Siguiente == null) final = anterior;
                    }
                    break;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
        }

        // Método para vaciar todos los elementos de la cola
        public void VaciarCola()
        {
            frente = null;
            final = null;
        }

        // Método para buscar un elemento dentro de la cola
        public bool BuscarElemento(int elemento)
        {
            Nodo actual = frente;
            while (actual != null)
            {
                if (actual.Dato == elemento) return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        // Método para obtener los elementos actuales de la cola
        public string MostrarCola()
        {
            if (frente == null)
                return "Cola vacía.";

            Nodo actual = frente;
            var elementos = new System.Collections.Generic.List<string>();

            while (actual != null)
            {
                elementos.Add(actual.Dato.ToString());
                actual = actual.Siguiente;
            }

            return string.Join(", ", elementos);
        }
    }
}