using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR5
    {
        // Método recursivo para la búsqueda binaria
        public int BusquedaBinaria(int[] arr, int low, int high, int target, ref long operaciones)
        {
            operaciones++; // Contar cada operación recursiva

            // Caso base: si low es mayor que high, el elemento no está en el arreglo
            if (low > high) return -1;

            // Encontrar el punto medio
            int mid = (low + high) / 2;

            // Si encontramos el elemento
            if (arr[mid] == target) return mid;

            // Si el elemento a buscar es menor que el elemento en la mitad
            if (target < arr[mid])
                return BusquedaBinaria(arr, low, mid - 1, target, ref operaciones); // Buscar en la mitad izquierda
            else
                return BusquedaBinaria(arr, mid + 1, high, target, ref operaciones); // Buscar en la mitad derecha
        }

        // Método para medir el tiempo de ejecución y realizar la búsqueda
        public double MedirTiempoEjecucion(int[] arreglo, int numeroBuscado, ref long operaciones, out int resultado)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Iniciar el cronómetro

            resultado = BusquedaBinaria(arreglo, 0, arreglo.Length - 1, numeroBuscado, ref operaciones); // Ejecutar la búsqueda

            stopwatch.Stop(); // Detener el cronómetro
            return stopwatch.Elapsed.TotalSeconds; // Retornar el tiempo de ejecución en segundos
        }

        // Método para ejecutar la búsqueda binaria con validación del input
        public bool EjecutarCalculo(string arregloTexto, string numeroTexto, TextBox txbResultado, TextBox txbTiempo, TextBox txbComplejidad)
        {
            try
            {
                // Dividir el arreglo ingresado por el usuario
                string[] numerosTexto = arregloTexto.Split(',');
                int[] arreglo = numerosTexto.Select(int.Parse).ToArray(); // Convertir el string en un arreglo de enteros
                arreglo = arreglo.OrderBy(x => x).ToArray(); // Ordenar el arreglo

                // Obtener el número a buscar
                int numeroBuscado;
                if (!int.TryParse(numeroTexto, out numeroBuscado))
                {
                    MessageBox.Show("Por favor, ingresa un número válido.");
                    return false;
                }

                // Contador de operaciones
                long operaciones = 0;
                int resultado; // Resultado de la búsqueda

                // Medir tiempo y realizar la búsqueda binaria
                double tiempo = MedirTiempoEjecucion(arreglo, numeroBuscado, ref operaciones, out resultado);

                // Mostrar el resultado de la búsqueda
                if (resultado != -1)
                {
                    txbResultado.Text = $"Número encontrado en el índice {resultado}";
                }
                else
                {
                    txbResultado.Text = "Número no encontrado.";
                }

                // Mostrar el tiempo de ejecución y la cantidad de operaciones
                txbTiempo.Text = $"Tiempo: {tiempo} segundos";
                txbComplejidad.Text = $"Operaciones: {operaciones}";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} , utilice el separador por comas ','");
                return false;
            }
        }
    }
}

