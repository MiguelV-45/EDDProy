using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Algoritmos_Recursivos.Clases
{
    internal class ClassAR6
    {
        public long operaciones { get; private set; } = 0; // Variable para contar las operaciones

        // Método recursivo para resolver la Torre de Hanoi
        public void TorreDeHanoi(int n, char origen, char auxiliar, char destino, ListBox lbResultado)
        {
            // Si solo hay un disco, lo movemos directamente de la torre origen a la torre destino
            if (n == 1)
            {
                lbResultado.Items.Add($"Mover disco 1 de {origen} a {destino}");
                operaciones++; // Contar operación
            }
            else
            {
                // Mover los n-1 discos de la torre origen a la torre auxiliar
                TorreDeHanoi(n - 1, origen, destino, auxiliar, lbResultado);

                // Mover el disco n de la torre origen a la torre destino
                lbResultado.Items.Add($"Mover disco {n} de {origen} a {destino}");
                operaciones++; // Contar operación

                // Mover los n-1 discos de la torre auxiliar a la torre destino
                TorreDeHanoi(n - 1, auxiliar, origen, destino, lbResultado);
            }
        }

        // Método para medir el tiempo de ejecución y resolver la Torre de Hanoi
        public double MedirTiempoEjecucion(int n, ListBox lbResultado)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Iniciar el cronómetro

            operaciones = 0; // Reiniciar el contador de operaciones
            TorreDeHanoi(n, 'A', 'B', 'C', lbResultado); // Resolver la Torre de Hanoi

            stopwatch.Stop(); // Detener el cronómetro
            return stopwatch.Elapsed.TotalSeconds; // Retornar el tiempo de ejecución en segundos
        }

        // Método para ejecutar el cálculo con validación del input
        public bool EjecutarCalculo(string discosTexto, ListBox lbResultado, TextBox txbTiempo, TextBox txbComplejidad)
        {
            try
            {
                // Validar el número de discos ingresado
                int n;
                if (!int.TryParse(discosTexto, out n) || n <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un número válido de discos (entero positivo).");
                    return false;
                }

                // Limpiar el ListBox de resultado para mostrar los nuevos movimientos
                lbResultado.Items.Clear();

                // Medir tiempo y resolver la Torre de Hanoi
                double tiempo = MedirTiempoEjecucion(n, lbResultado);

                // Mostrar el tiempo de ejecución y la cantidad de operaciones realizadas
                txbTiempo.Text = tiempo.ToString() + " segundos";
                txbComplejidad.Text = operaciones.ToString();

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
