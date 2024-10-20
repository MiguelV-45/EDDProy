using EDDemo.Algoritmos_Recursivos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo
{
    public partial class AR1 : Form
    {
        private ClassAR1 _calculator;

        // Constructor del formulario
        public AR1()
        {
            InitializeComponent();
            _calculator = new ClassAR1(); // Instancia de la clase ClassAR1
        }

        // Evento del botón "Regresar" para regresar al menú
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        // Evento del botón "Calcular" para ejecutar el cálculo del factorial
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string numeroTexto = txbNumero.Text; // Capturar el número ingresado
            int resultado;
            double tiempo;
            long totalOperaciones;

            // Ejecutar el cálculo y mostrar los resultados
            if (_calculator.EjecutarCalculo(numeroTexto, out resultado, out tiempo, out totalOperaciones))
            {
                txbResultado.Text = resultado.ToString(); // Mostrar el resultado del factorial
                txbTiempo.Text = tiempo.ToString() + " segundos"; // Mostrar el tiempo de ejecución
                txbOperaciones.Text = totalOperaciones.ToString(); // Mostrar el número de operaciones
            }
        }

        // Evento del botón "Borrar" para limpiar los campos
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txbNumero.Clear();
            txbResultado.Clear();
            txbTiempo.Clear();
            txbOperaciones.Clear();
        }
    }
}
