using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases.Interno
{
    internal class RadixSort
    {
        public List<int> Ordenar(List<int> lista, List<string> pasos)
        {
            int max = ObtenerMaximo(lista); // Obtenemos el valor máximo de la lista
            int exp = 1; // Empezamos desde el dígito menos significativo (unidad)

            // Realizamos el ordenamiento por dígitos
            while (max / exp > 0)
            {
                ListaPorDigito(lista, exp, pasos);
                exp *= 10; // Aumentamos el exponente para el siguiente dígito
            }

            return lista; // Devuelve la lista ordenada
        }

        // Función para obtener el valor máximo de la lista
        private int ObtenerMaximo(List<int> lista)
        {
            int max = lista[0];
            foreach (int num in lista)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        // Función para realizar el conteo por el dígito actual (exp)
        private void ListaPorDigito(List<int> lista, int exp, List<string> pasos)
        {
            List<int> salida = new List<int>(new int[lista.Count]);
            int[] conteo = new int[10]; // Array para contar las ocurrencias de cada dígito

            // Contar las ocurrencias del dígito actual
            foreach (int num in lista)
            {
                int digito = (num / exp) % 10;
                conteo[digito]++;
            }

            // Acumular las posiciones
            for (int i = 1; i < conteo.Length; i++)
            {
                conteo[i] += conteo[i - 1];
            }

            // Colocar los números en la salida ordenada
            for (int i = lista.Count - 1; i >= 0; i--)
            {
                int num = lista[i];
                int digito = (num / exp) % 10;
                salida[conteo[digito] - 1] = num;
                conteo[digito]--;
            }

            // Copiar la salida en la lista original
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i] = salida[i];
            }

            // Guardar el paso en el proceso
            pasos.Add(string.Join(" -> ", lista));
        }
    }
}
