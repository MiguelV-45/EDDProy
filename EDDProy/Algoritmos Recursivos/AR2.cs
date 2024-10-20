using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EDDemo.Algoritmos_Recursivos.Clases.ClassAR2;

namespace EDDemo
{
    public partial class AR2 : Form
    {
        private CalcularPotencia _calculator;
        public AR2()
        {
            InitializeComponent();
            _calculator = new CalcularPotencia(); // Instancia de CalcularPotencia
        }


        // Evento del botón regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        // Evento del botón Calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double baseNumero;
            int exponente;

            // Validar que los valores ingresados sean válidos
            if (double.TryParse(txbNumero.Text, out baseNumero) && int.TryParse(txbPotencia.Text, out exponente))
            {
                double resultado;
                // Calcula el tiempo de ejecución y el resultado
                double tiempo = _calculator.MedirTiempoEjecucion(baseNumero, exponente, out resultado);

                // Muestra los resultados en los TextBoxes correspondientes
                txbResultado.Text = resultado.ToString();
                txbTiempo.Text = tiempo.ToString() + " segundos";
                txbComplejidad.Text = _calculator.Operaciones.ToString();
            }
            else
            {
                // Muestra un mensaje de error si los datos ingresados no son válidos
                MessageBox.Show("Por favor, ingresa un número y un exponente válidos.");
            }
        }

        // Evento del botón Borrar
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Limpia los TextBoxes
            txbNumero.Clear();
            txbPotencia.Clear();
            txbResultado.Clear();
            txbTiempo.Clear();
            txbComplejidad.Clear();
        }
    }
}
