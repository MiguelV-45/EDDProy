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
    public partial class AR4 : Form
    {
        private ClassAR4 _calculator;
        public AR4()
        {
            InitializeComponent();
            _calculator = new ClassAR4(); // Instancia de la clase ClassAR4
        }

        // Evento del botón regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        // Evento del botón Calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string entrada = txbNumero.Text; // Captura la entrada del TextBox
            _calculator.EjecutarCalculo(entrada, txbResultado, txbTiempo, txbComplejidad); // Llama al método de cálculo
        }

        // Evento del botón Borrar
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Limpiar los TextBoxes
            txbNumero.Clear();
            txbResultado.Clear();
            txbTiempo.Clear();
            txbComplejidad.Clear();
        }
    }
}
