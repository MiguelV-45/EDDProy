using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_No_Lineales
{
    public class ArbolBusqueda
    {
        // Nodo raíz del árbol de búsqueda
        NodoBinario Raiz;

        // Variables para almacenar las representaciones del árbol y recorridos
        public String strArbol;
        public String strRecorrido;

        // Constructor para inicializar el árbol vacío
        public ArbolBusqueda()
        {
            Raiz = null;        // El árbol comienza sin nodos
            strArbol = "";      // Cadena vacía para la representación visual del árbol
            strRecorrido = "";  // Cadena vacía para el recorrido del árbol
        }

        // Método para verificar si el árbol está vacío
        public Boolean EstaVacio()
        {
            return Raiz == null; // Retorna verdadero si no hay nodos en el árbol
        }

        // Método para obtener la raíz del árbol
        public NodoBinario RegresaRaiz()
        {
            return Raiz;
        }

        // Método recursivo para insertar un nodo en el árbol de búsqueda
        public void InsertaNodo(int Dato, ref NodoBinario Nodo)
        {
            // Caso base: si el nodo actual es null, insertamos aquí el nuevo nodo
            if (Nodo == null)
            {
                Nodo = new NodoBinario(Dato); // Se crea un nuevo nodo con el dato
                if (Raiz == null)             // Si es el primer nodo, lo establecemos como raíz
                    Raiz = Nodo;
            }
            // Si el dato es menor, lo insertamos en el subárbol izquierdo
            else if (Dato < Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Izq);

            // Si el dato es mayor, lo insertamos en el subárbol derecho
            else if (Dato > Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Der);
        }

        // Método para mostrar el árbol en una representación visual acostada
        public void MuestraArbolAcostado(int nivel, NodoBinario nodo)
        {
            if (nodo == null)
                return;

            // Llamada recursiva al subárbol derecho, aumentando el nivel de profundidad
            MuestraArbolAcostado(nivel + 1, nodo.Der);

            // Genera sangría basada en el nivel actual para visualización
            for (int i = 0; i < nivel; i++)
                strArbol += "      ";

            strArbol += nodo.Dato.ToString() + "\r\n"; // Añade el valor del nodo y salto de línea

            // Llamada recursiva al subárbol izquierdo
            MuestraArbolAcostado(nivel + 1, nodo.Izq);
        }

        // Método para generar el árbol en formato Graphviz
        public String ToDot(NodoBinario nodo)
        {
            StringBuilder b = new StringBuilder();
            if (nodo.Izq != null)
            {
                b.AppendFormat("{0}->{1} [side=L] {2} ", nodo.Dato.ToString(), nodo.Izq.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Izq)); // Llama recursivamente para el subárbol izquierdo
            }

            if (nodo.Der != null)
            {
                b.AppendFormat("{0}->{1} [side=R] {2} ", nodo.Dato.ToString(), nodo.Der.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Der)); // Llama recursivamente para el subárbol derecho
            }
            return b.ToString();
        }

        // Método para recorrer el árbol en preorden
        public void PreOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            strRecorrido += nodo.Dato + ", "; // Procesa el nodo actual
            PreOrden(nodo.Izq);               // Llama recursivamente al subárbol izquierdo
            PreOrden(nodo.Der);               // Llama recursivamente al subárbol derecho
        }

        // Método para recorrer el árbol en inorden
        public void InOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            InOrden(nodo.Izq);               // Llama recursivamente al subárbol izquierdo
            strRecorrido += nodo.Dato + ", "; // Procesa el nodo actual
            InOrden(nodo.Der);               // Llama recursivamente al subárbol derecho
        }

        // Método para recorrer el árbol en postorden
        public void PostOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            PostOrden(nodo.Izq);             // Llama recursivamente al subárbol izquierdo
            PostOrden(nodo.Der);             // Llama recursivamente al subárbol derecho
            strRecorrido += nodo.Dato + ", "; // Procesa el nodo actual
        }

        // Método para buscar un valor en el árbol binario
        public bool Busqueda(int valor, NodoBinario nodo)
        {
            // Caso base: si el nodo es null, el valor no está en el árbol.
            if (nodo == null)
                return false;

            // Si el valor actual del nodo es igual al valor buscado, retornamos verdadero.
            if (nodo.Dato == valor)
                return true;

            // Si el valor es menor que el dato actual, buscar en el subárbol izquierdo
            if (valor < nodo.Dato)
                return Busqueda(valor, nodo.Izq);

            // Si el valor es mayor que el dato actual, buscar en el subárbol derecho
            return Busqueda(valor, nodo.Der);
        }
    }
}
