using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo
{
    public class Pilas : Listas
    {
        public int MaxSize { get; private set; } // Tamaño máximo de la pila.

        public Pilas(int maxSize) : base()
        {
            MaxSize = maxSize; // Inicializa el tamaño máximo.
        }

        public Pilas()
        {
            Inicio = null; // Al inicio, la pila está vacía
        }

        public bool EstaLlena() => Tamaño >= MaxSize; // Verifica si la pila está llena.

        public void Push(int dato)
        {
            if (EstaLlena()) throw new InvalidOperationException("La pila está llena.");
            InsertarAlInicio(dato); // Inserta un nodo al inicio.
        }

        public void PushPD(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);  // Creamos un nuevo nodo
            nuevoNodo.Siguiente = Inicio;      // El siguiente del nuevo nodo es el actual inicio
            Inicio = nuevoNodo;                // El nuevo nodo se convierte en el nuevo inicio
        }

        public int Pop()
        {
            if (EstaVacia()) throw new InvalidOperationException("La pila está vacía.");
            return EliminarAlInicio(); // Elimina el nodo del inicio.
        }

        public int Top()
        {
            if (EstaVacia()) throw new InvalidOperationException("La pila está vacía.");
            return Inicio.Dato; // Retorna el dato del nodo inicial (tope).
        }
    }
}

