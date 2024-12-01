using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo
{
   public class Listas
    {
        public Nodo Inicio; // Nodo que indica el inicio de la lista.
        public int Tamaño; // Tamaño actual de la lista.

        public Listas()
        {
            Inicio = null; // Inicializa la lista como vacía.
            Tamaño = 0; // Tamaño de la lista en 0.
        }

        public int GetTamaño() => Tamaño; // Retorna el tamaño actual de la lista.

        public bool EstaVacia() => Inicio == null; // Verifica si la lista está vacía.

        public void InsertarAlInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato); // Crea un nuevo nodo.
            nuevo.Siguiente = Inicio; // Apunta al nodo que era el inicio.
            Inicio = nuevo; // Actualiza el inicio al nuevo nodo.
            Tamaño++; // Incrementa el tamaño de la lista.
        }

        public int EliminarAlInicio()
        {
            if (EstaVacia()) throw new InvalidOperationException("La lista está vacía."); // Manejo de error.
            int dato = Inicio.Dato; // Obtiene el dato del nodo inicial.
            Inicio = Inicio.Siguiente; // Elimina el nodo inicial.
            Tamaño--; // Reduce el tamaño.
            return dato; // Retorna el dato eliminado.
        }

        public void VaciarLista()
        {
            Inicio = null; // Elimina todos los nodos.
            Tamaño = 0; // Reinicia el tamaño.
        }

        public Nodo ObtenerInicio() => Inicio; // Retorna el nodo inicial.


        public override string ToString()
        {
            Nodo actual = Inicio;
            string resultado = "Inicio -> ";
            while (actual != null)
            {
                resultado += $"{actual.Dato} -> ";
                actual = actual.Siguiente;
            }
            return resultado + "null";
        }
    }
}

