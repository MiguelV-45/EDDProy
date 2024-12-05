using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Busqueda.Clases
{
    public class BusquedaSecuencial
    {
        // Lista para almacenar los números
        private List<int> numeros;

        public BusquedaSecuencial()
        {
            numeros = new List<int>();
        }

        // Método para agregar un número a la lista
        public void AgregarNumero(int numero)
        {
            numeros.Add(numero);
        }

        // Método para obtener todos los números en la lista
        public List<int> ObtenerNumeros()
        {
            return numeros;
        }

        // Método de búsqueda secuencial
        public int BuscarNumero(int valor)
        {
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] == valor)
                {
                    return i; // Retorna la posición
                }
            }
            return -1; // No encontrado
        }
    }
}
