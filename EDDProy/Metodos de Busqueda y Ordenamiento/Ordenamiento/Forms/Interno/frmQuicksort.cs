using EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Forms
{
    public partial class frmQuicksort : Form
    {
        private Quicksort quicksort = new Quicksort();
        public frmQuicksort()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeros.Text))
            {
                MessageBox.Show("Por favor, ingresa una serie de números separados por comas.");
                return;
            }

            try
            {
                // Convertir la entrada en un arreglo de números
                int[] numeros = txtNumeros.Text.Split(',')
                                              .Select(x => int.Parse(x.Trim()))
                                              .ToArray();

                // Ordenar y obtener los pasos
                List<string> pasos = quicksort.Ordenar(numeros);

                // Mostrar pasos en el ListBox
                lstProceso.Items.Clear();
                foreach (string paso in pasos)
                {
                    lstProceso.Items.Add(paso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumeros.Clear();
            lstProceso.Items.Clear();
        }
    }
}
