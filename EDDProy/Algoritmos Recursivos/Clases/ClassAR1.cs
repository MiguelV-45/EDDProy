using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR1
    {
        public long operaciones { get; private set; } = 0; // Contador para las operaciones realizadas

        // Función recursiva para calcular el factorial y contar las operaciones
        public int Factorial(int n)
        {
            operaciones++; // Cada llamada a la función cuenta como una operación
            if (n == 0) return 1; // Caso base
            return n * Factorial(n - 1); // Caso recursivo
        }

        // Método para medir el tiempo de ejecución y calcular el factorial
        public double CalcularFactorial(int numero, out int resultado)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Iniciar el cronómetro

            operaciones = 0; // Reiniciar el contador de operaciones
            resultado = Factorial(numero); // Calcular el factorial

            stopwatch.Stop(); // Detener el cronómetro
            return stopwatch.Elapsed.TotalSeconds; // Retornar el tiempo de ejecución en segundos
        }

        // Método para ejecutar el cálculo con validación del input
        public bool EjecutarCalculo(string numeroTexto, out int resultado, out double tiempo, out long totalOperaciones)
        {
            resultado = 0;
            tiempo = 0;
            totalOperaciones = 0;

            try
            {
                // Validar que el número ingresado sea un entero positivo
                int numero;
                if (!int.TryParse(numeroTexto, out numero) || numero < 0)
                {
                    MessageBox.Show("Por favor, ingresa un número entero válido.");
                    return false;
                }

                // Calcular el factorial y el tiempo de ejecución
                tiempo = CalcularFactorial(numero, out resultado);
                totalOperaciones = operaciones;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
