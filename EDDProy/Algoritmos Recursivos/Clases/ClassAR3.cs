using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR3
    {
        public long Operaciones { get; private set; } = 0;

        // Método para sumar los elementos de un arreglo recursivamente
        public int CalcularSuma(int[] arreglo)
        {
            Operaciones = 0; // Reiniciar el conteo de operaciones
            return SumarElementos(arreglo, 0); // Iniciar la recursión desde el índice 0
        }

        // Función recursiva para sumar los elementos del arreglo
        private int SumarElementos(int[] arr, int index)
        {
            Operaciones++; // Cada llamada recursiva cuenta como una operación

            if (index == arr.Length) return 0; // Caso base: cuando se alcanza el final del arreglo

            return arr[index] + SumarElementos(arr, index + 1); // Caso recursivo
        }

        // Método para medir el tiempo de ejecución de la suma
        public double MedirTiempoEjecucion(int[] arreglo, out int suma)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Inicia el cronómetro

            suma = CalcularSuma(arreglo); // Calcula la suma de los elementos

            stopwatch.Stop(); // Detiene el cronómetro
            return stopwatch.Elapsed.TotalSeconds; // Retorna el tiempo de ejecución en segundos
        }

        // Método para ejecutar todo el cálculo, incluyendo la validación del arreglo de entrada
        public bool EjecutarCalculo(string entrada, TextBox txbResultado, TextBox txbTiempo, TextBox txbComplejidad)
        {
            string[] numerosTexto = entrada.Split(','); // Divide la entrada en un array de strings
            int[] numeros = new int[numerosTexto.Length]; // Array para almacenar los números convertidos

            try
            {
                for (int i = 0; i < numerosTexto.Length; i++)
                {
                    numeros[i] = int.Parse(numerosTexto[i]); // Parsear cada número
                }
            }
            catch
            {
                MessageBox.Show("Por favor, ingresa un arreglo válido de números separados por comas.");
                return false;
            }

            // Calcular la suma y el tiempo de ejecución
            int suma;
            double tiempo = MedirTiempoEjecucion(numeros, out suma);

            // Mostrar los resultados en los TextBoxes correspondientes
            txbResultado.Text = suma.ToString();
            txbTiempo.Text = tiempo.ToString() + " segundos";
            txbComplejidad.Text = Operaciones.ToString();

            return true;
        }
    }
}
