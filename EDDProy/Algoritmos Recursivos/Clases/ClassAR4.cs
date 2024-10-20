using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR4
    {
        // Método recursivo para calcular el número de Fibonacci
        public int Fibonacci(int n, ref long operaciones)
        {
            operaciones++; // Contar cada llamada recursiva

            if (n < 0) throw new ArgumentException("El número debe ser no negativo.");
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fibonacci(n - 1, ref operaciones) + Fibonacci(n - 2, ref operaciones);
        }

        // Método para medir el tiempo de ejecución del cálculo de Fibonacci
        public double MedirTiempoEjecucion(int n, ref long operaciones, out int resultado)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Inicia el cronómetro

            resultado = Fibonacci(n, ref operaciones); // Calcula el número de Fibonacci

            stopwatch.Stop(); // Detiene el cronómetro
            return stopwatch.Elapsed.TotalSeconds; // Retorna el tiempo de ejecución en segundos
        }

        // Método para ejecutar todo el cálculo y validar el input
        public bool EjecutarCalculo(string entrada, TextBox txbResultado, TextBox txbTiempo, TextBox txbComplejidad)
        {
            int n;
            if (!int.TryParse(entrada, out n) || n < 0)
            {
                MessageBox.Show("Por favor, ingresa un número entero no negativo.");
                return false;
            }

            long operaciones = 0; // Contador de operaciones
            int total; // Resultado del cálculo de Fibonacci

            double tiempo = MedirTiempoEjecucion(n, ref operaciones, out total); // Medir tiempo y obtener resultado

            // Mostrar los resultados en los TextBoxes
            txbResultado.Text = total.ToString();
            txbTiempo.Text = $"{tiempo} segundos";
            txbComplejidad.Text = $"{operaciones} operaciones";

            return true;
        }
    }
}
