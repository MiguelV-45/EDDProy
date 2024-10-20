using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR2
    {
        public class CalcularPotencia
        {
            public long Operaciones { get; private set; } = 0;

            // Método para calcular la potencia recursivamente
            public double Calcular(double baseNumero, int exponente)
            {
                Operaciones = 0; // Reinicia el conteo de operaciones
                return Potencia(baseNumero, exponente);
            }

            // Función recursiva para calcular la potencia
            private double Potencia(double x, int n)
            {
                Operaciones++; // Cada llamada recursiva cuenta como una operación

                if (n == 0) return 1; // Caso base: cualquier número elevado a la potencia 0 es 1

                if (n > 0) return x * Potencia(x, n - 1); // Exponente positivo

                return 1 / Potencia(x, -n); // Exponente negativo
            }

            // Método para medir el tiempo de ejecución
            public double MedirTiempoEjecucion(double baseNumero, int exponente, out double resultado)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); // Inicia el cronómetro

                resultado = Calcular(baseNumero, exponente); // Calcula la potencia

                stopwatch.Stop(); // Detiene el cronómetro
                return stopwatch.Elapsed.TotalSeconds; // Retorna el tiempo en segundos
            }
        }
    }
}
