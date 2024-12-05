using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Busqueda.Clases
{
    public class FuncionesHash
    {
        // Creamos la tabla hash
        private Hashtable hashTable;

        public FuncionesHash()
        {
            // Inicializamos la tabla hash
            hashTable = new Hashtable();
        }

        // Método para buscar un elemento en la tabla hash por clave
        public string BuscarElemento(int clave)
        {
            if (hashTable.ContainsKey(clave))
            {
                return "Elemento encontrado: " + hashTable[clave];
            }
            else
            {
                return "Elemento no encontrado.";
            }
        }

        // Método para agregar un elemento en la tabla hash
        public void AgregarElemento(int clave, string valor)
        {
            if (!hashTable.ContainsKey(clave))
            {
                hashTable.Add(clave, valor);
            }
            else
            {
                // Si la clave ya existe, actualizamos el valor
                hashTable[clave] = valor;
            }
        }

        // Método para obtener todos los elementos como string para mostrar en ListBox
        public string[] ObtenerElementos()
        {
            // Creamos una lista para almacenar las claves como strings
            List<string> elementos = new List<string>();

            // Recorrimos las claves y las convertimos a string
            foreach (var clave in hashTable.Keys)
            {
                elementos.Add(clave.ToString());
            }

            // Convertimos la lista de strings en un arreglo
            return elementos.ToArray();
        }

        // Método para limpiar la tabla hash
        public void LimpiarTabla()
        {
            hashTable.Clear(); // Limpiamos la tabla hash
        }
    }
}
