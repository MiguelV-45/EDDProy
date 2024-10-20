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
    public partial class AR5 : Form
    {
        private ClassAR5 _calculator;
        public AR5()
        {
            InitializeComponent();
            _calculator = new ClassAR5(); // Instancia de la clase ClassAR5
        }

        // Evento del botón "Regresar" para regresar al menú
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        // Evento del botón "Calcular" para ejecutar la búsqueda binaria
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string arregloTexto = txbArreglo.Text; // Capturar el arreglo ingresado
            string numeroTexto = txbNumero.Text; // Capturar el número a buscar

            _calculator.EjecutarCalculo(arregloTexto, numeroTexto, txbResultado, txbTiempo, txbComplejidad); // Ejecutar el cálculo
        }

        // Evento del botón "Borrar" para limpiar los campos
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txbArreglo.Clear();
            txbNumero.Clear();
            txbResultado.Clear();
            txbTiempo.Clear();
            txbComplejidad.Clear();
        }
    }
}
