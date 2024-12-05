using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Busqueda.Clases
{
    public class BusquedaBinaria
    {
        private List<int> numeros;

        public BusquedaBinaria()
        {
            numeros = new List<int>();
        }

        // Método para agregar números a la lista
        public void AgregarNumero(int numero)
        {
            numeros.Add(numero);
            numeros.Sort(); // Ordenamos la lista automáticamente
        }

        // Método para obtener la lista de números
        public List<int> ObtenerNumeros()
        {
            return numeros;
        }

        // Método de búsqueda binaria
        public int BuscarNumero(int numeroBuscado)
        {
            int inicio = 0;
            int fin = numeros.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;

                if (numeros[medio] == numeroBuscado)
                {
                    return medio; // Retornamos la posición
                }
                else if (numeros[medio] < numeroBuscado)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }
            return -1; // Retornamos -1 si no se encuentra
        }

        // Método para limpiar la lista
        public void LimpiarLista()
        {
            numeros.Clear();
        }
    }
}
