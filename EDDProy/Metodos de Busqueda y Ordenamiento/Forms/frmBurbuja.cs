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

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento
{
    public partial class frmBurbuja : Form
    {
        private Burbuja burbuja; // Instancia de la clase Burbuja

        public frmBurbuja()
        {
            InitializeComponent();
            burbuja = new Burbuja(lstProceso); // Pasamos el ListBox a la clase
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            // Limpiar el ListBox antes de comenzar
            lstProceso.Items.Clear();

            // Leer los números del TextBox
            string entrada = txtNumeros.Text;
            if (string.IsNullOrWhiteSpace(entrada))
            {
                MessageBox.Show("Por favor, ingresa los números separados por comas.", "Error");
                return;
            }

            // Convertir los números ingresados en un arreglo de enteros
            int[] numeros;
            try
            {
                numeros = entrada.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                MessageBox.Show("Por favor, ingresa un formato válido. Ejemplo: 5,3,8,1", "Error");
                return;
            }

            // Llamar al método de ordenación burbuja
            burbuja.OrdenarBurbuja(numeros);

            // Mostrar el arreglo ordenado final
            lstProceso.Items.Add("Arreglo ordenado: " + string.Join(", ", numeros));

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar el TextBox y el ListBox
            txtNumeros.Clear();
            lstProceso.Items.Clear();
        }
    }
}
