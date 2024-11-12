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
        public void InsertaNodo(int valor, ref NodoBinario Nodo)
        {
            // Caso base: si el nodo actual es null, insertamos aquí el nuevo nodo
            if (Nodo == null)
            {
                Nodo = new NodoBinario(valor); // Se crea un nuevo nodo con el dato
                if (Raiz == null)             // Si es el primer nodo, lo establecemos como raíz
                    Raiz = Nodo;
            }
            // Si el dato es menor, lo insertamos en el subárbol izquierdo
            else if (valor < Nodo.Dato)
                InsertaNodo(valor, ref Nodo.Izq);

            // Si el dato es mayor, lo insertamos en el subárbol derecho
            else if (valor > Nodo.Dato)
                InsertaNodo(valor, ref Nodo.Der);
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

        //---------------------------------------------------------------------------------//

        public NodoBinario ObtenerPredecesor(NodoBinario nodo)
        {
            NodoBinario actual = nodo.Izq;
            while (actual != null && actual.Der != null)
            {
                actual = actual.Der;
            }
            return actual;
        }

        public NodoBinario EliminarNodo(NodoBinario raiz, int valor)
        {
            if (raiz == null)
                return raiz;

            // Si el valor a eliminar es menor, sigue buscando en el subárbol izquierdo
            if (valor < raiz.Dato)
                raiz.Izq = EliminarNodo(raiz.Izq, valor);
            // Si el valor a eliminar es mayor, sigue buscando en el subárbol derecho
            else if (valor > raiz.Dato)
                raiz.Der = EliminarNodo(raiz.Der, valor);
            else
            {
                // Caso 1: El nodo tiene un solo hijo o ninguno
                if (raiz.Izq == null)
                    return raiz.Der;
                else if (raiz.Der == null)
                    return raiz.Izq;

                // Caso 2: El nodo tiene dos hijos
                // Encontramos el predecesor
                NodoBinario predecesor = ObtenerPredecesor(raiz);
                raiz.Dato = predecesor.Dato;  // Copiamos el valor del predecesor al nodo actual
                raiz.Izq = EliminarNodo(raiz.Izq, predecesor.Dato);  // Eliminamos el predecesor
            }

            return raiz;
        }

        public NodoBinario BuscarNodo(NodoBinario raiz, int valor)
        {
            // Si el árbol está vacío o encontramos el nodo con el valor buscado, retornamos el nodo.
            if (raiz == null || raiz.Dato == valor)
                return raiz;

            // Si el valor es menor, buscamos en el subárbol izquierdo.
            if (valor < raiz.Dato)
                return BuscarNodo(raiz.Izq, valor);

            // Si el valor es mayor, buscamos en el subárbol derecho.
            return BuscarNodo(raiz.Der, valor);
        }
        //---------------------------------------------------------------------//

        public NodoBinario ObtenerSucesor(NodoBinario nodo)
        {
            NodoBinario actual = nodo.Der;
            while (actual != null && actual.Izq != null)
            {
                actual = actual.Izq;  // El sucesor es el valor más a la izquierda del subárbol derecho
            }
            return actual;
        }

        public NodoBinario EliminarNodo2(NodoBinario raiz, int valor)
        {
            if (raiz == null)
                return raiz;

            // Si el valor a eliminar es menor, sigue buscando en el subárbol izquierdo
            if (valor < raiz.Dato)
                raiz.Izq = EliminarNodo(raiz.Izq, valor);
            // Si el valor a eliminar es mayor, sigue buscando en el subárbol derecho
            else if (valor > raiz.Dato)
                raiz.Der = EliminarNodo(raiz.Der, valor);
            else
            {
                // Caso 1: El nodo tiene un solo hijo o ninguno
                if (raiz.Izq == null)
                    return raiz.Der;
                else if (raiz.Der == null)
                    return raiz.Izq;

                // Caso 2: El nodo tiene dos hijos
                // Encontramos el sucesor
                NodoBinario sucesor = ObtenerSucesor(raiz);
                raiz.Dato = sucesor.Dato;  // Copiamos el valor del sucesor al nodo actual
                raiz.Der = EliminarNodo(raiz.Der, sucesor.Dato);  // Eliminamos el sucesor
            }

            return raiz;
        }

        //------------------------------------------------------------------------------------------------//

        // Método para obtener la altura del árbol
        public int Altura(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;

            int alturaIzq = Altura(nodo.Izq);
            int alturaDer = Altura(nodo.Der);

            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        //-------------------------------------------------------------------------------------------------//

        // Método principal para recorrer el árbol por niveles de forma recursiva
        public void RecorrerPorNivelesRecursivo(NodoBinario raiz)
        {
            // Limpiar el recorrido anterior
            strRecorrido = "";

            if (raiz == null)
                return;

            // Implementación de una cola manual usando una lista
            List<NodoBinario> colaAuxiliar = new List<NodoBinario>();
            colaAuxiliar.Add(raiz); // Agregar la raíz al inicio de la lista

            // Mientras la cola no esté vacía, procesamos los nodos
            while (colaAuxiliar.Count > 0)
            {
                // Tomamos el primer nodo de la lista como si fuera Dequeue
                NodoBinario nodoActual = colaAuxiliar[0];
                colaAuxiliar.RemoveAt(0); // Eliminamos el primer nodo de la lista

                strRecorrido += nodoActual.Dato + ", "; // Agregamos el dato al recorrido

                // Si el nodo tiene hijo izquierdo, lo agregamos al final de la lista (cola)
                if (nodoActual.Izq != null)
                    colaAuxiliar.Add(nodoActual.Izq);

                // Si el nodo tiene hijo derecho, lo agregamos al final de la lista (cola)
                if (nodoActual.Der != null)
                    colaAuxiliar.Add(nodoActual.Der);
            }
        }

        //-------------------------------------------------------------------//

        // Método recursivo para contar las hojas del árbol
        public int ContarHojas(NodoBinario nodo)
        {
            // Si el nodo es nulo, no hay hojas
            if (nodo == null)
            {
                return 0;
            }

            // Si un nodo no tiene hijos, es una hoja
            if (nodo.Izq == null && nodo.Der == null)
            {
                return 1;
            }

            // Si tiene hijos, contar las hojas de los subárboles
            return ContarHojas(nodo.Izq) + ContarHojas(nodo.Der);
        }

        //-----------------------------------------------------------------------//

        // Método para contar los nodos del árbol
        public int ContarNodos(NodoBinario nodo)
        {
            // Si el nodo es null, no hay nodo que contar
            if (nodo == null)
                return 0;

            // Contamos el nodo actual y los nodos en sus subárboles izquierdo y derecho
            return 1 + ContarNodos(nodo.Izq) + ContarNodos(nodo.Der);
        }

        //------------------------------------------------------------------------//

        public bool EsCompleto(NodoBinario nodo)
        {
            if (nodo == null)
                return true; // Un árbol vacío es completo

            // Implementación de cola manual con una lista
            List<NodoBinario> colaAuxiliar = new List<NodoBinario>();
            colaAuxiliar.Add(nodo); // Agregar la raíz al inicio de la "cola"
            int index = 0; // Índice para simular el frente de la cola

            bool nodoNoLleno = false; // Bandera para indicar si encontramos un nodo no lleno

            while (index < colaAuxiliar.Count)
            {
                NodoBinario nodoActual = colaAuxiliar[index];
                index++; // Avanzar el índice para simular un "Dequeue"

                // Revisar el hijo izquierdo
                if (nodoActual.Izq != null)
                {
                    if (nodoNoLleno)
                        return false; // Si ya vimos un nodo no lleno, el árbol no es completo

                    colaAuxiliar.Add(nodoActual.Izq); // Agregar el hijo izquierdo al "final de la cola"
                }
                else
                {
                    nodoNoLleno = true; // Activar bandera si el nodo izquierdo está ausente
                }

                // Revisar el hijo derecho
                if (nodoActual.Der != null)
                {
                    if (nodoNoLleno)
                        return false; // Si ya vimos un nodo no lleno, el árbol no es completo

                    colaAuxiliar.Add(nodoActual.Der); // Agregar el hijo derecho al "final de la cola"
                }
                else
                {
                    nodoNoLleno = true; // Activar bandera si el nodo derecho está ausente
                }
            }

            return true; // Si pasamos todas las revisiones, el árbol es completo
        }

        //---------------------------------------------------------------------------------//

        // Método para verificar si el árbol es binario lleno
        public bool EsLleno(NodoBinario nodo)
        {
            // Si el nodo es nulo, el árbol es lleno
            if (nodo == null)
                return true;

            // Si el nodo es una hoja, también se considera lleno
            if (nodo.Izq == null && nodo.Der == null)
                return true;

            // Si el nodo tiene ambos hijos, revisar recursivamente los hijos
            if (nodo.Izq != null && nodo.Der != null)
                return EsLleno(nodo.Izq) && EsLleno(nodo.Der);

            // Si el nodo tiene solo un hijo, el árbol no es lleno
            return false;
        }

        //--------------------------------------------//

        // Método recursivo para liberar los nodos del árbol
        public void LimpiarArbol(NodoBinario nodo)
        {
            if (nodo != null)
            {
                // Llamada recursiva para los nodos hijos
                LimpiarArbol(nodo.Izq);
                LimpiarArbol(nodo.Der);

                nodo = null; // Elimina la referencia al nodo
            }
        }
    }
}
