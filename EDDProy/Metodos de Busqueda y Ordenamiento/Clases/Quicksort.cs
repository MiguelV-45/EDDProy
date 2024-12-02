using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases
{
    public class Quicksort
    {
        // Método para realizar el Quicksort
        public List<string> Ordenar(int[] arr)
        {
            List<string> pasos = new List<string>();
            QuicksortRecursivo(arr, 0, arr.Length - 1, pasos);
            return pasos;
        }

        private void QuicksortRecursivo(int[] arr, int inicio, int fin, List<string> pasos)
        {
            if (inicio < fin)
            {
                int pivoteIndex = Particionar(arr, inicio, fin, pasos);
                QuicksortRecursivo(arr, inicio, pivoteIndex - 1, pasos);
                QuicksortRecursivo(arr, pivoteIndex + 1, fin, pasos);
            }
        }

        // Método para particionar el arreglo
        private int Particionar(int[] numeros, int bajo, int alto, List<string> pasos)
        {
            // Elegir el último elemento como pivote
            int pivote = numeros[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                // Si el elemento actual es menor o igual al pivote, se intercambia
                if (numeros[j] <= pivote)
                {
                    i++;
                    // Intercambiar elementos
                    int temp = numeros[i];
                    numeros[i] = numeros[j];
                    numeros[j] = temp;

                    // Mostrar el estado después de cada intercambio con la flecha
                    pasos.Add(string.Join(" → ", Array.ConvertAll(numeros, x => x.ToString())));
                }
            }

            // Colocar el pivote en su posición correcta
            int temp2 = numeros[i + 1];
            numeros[i + 1] = numeros[alto];
            numeros[alto] = temp2;

            // Mostrar el estado después de colocar el pivote con la flecha
            pasos.Add(string.Join(" → ", Array.ConvertAll(numeros, x => x.ToString())));

            return i + 1;
        }
    }
}
