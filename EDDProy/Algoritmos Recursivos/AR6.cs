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
    public partial class AR6 : Form
    {
        private ClassAR6 _calculator;
        public AR6()
        {
            InitializeComponent();
            _calculator = new ClassAR6(); // Instancia de la clase ClassAR6
        }

        // Evento del botón "Regresar" para regresar al menú
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        // Evento del botón "Calcular" para ejecutar el algoritmo de la Torre de Hanoi
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string discosTexto = txbDiscos.Text; // Capturar el número de discos ingresado

            _calculator.EjecutarCalculo(discosTexto, lbResultado, txbTiempo, txbComplejidad); // Ejecutar el cálculo
        }

        // Evento del botón "Borrar" para limpiar los campos
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txbDiscos.Clear();
            lbResultado.Items.Clear();
            txbTiempo.Clear();
            txbComplejidad.Clear();
        }
    }
}
