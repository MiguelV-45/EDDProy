using EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases.Interno;
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
    public partial class frmRadixSort : Form
    {
        public frmRadixSort()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            txtNumeros.Clear();
            lstProceso.Items.Clear();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> numeros = new List<int>();
                List<string> pasos = new List<string>();  // Lista para guardar los pasos intermedios
                string[] input = txtNumeros.Text.Split(',');

                // Agregar números a la lista
                foreach (string s in input)
                {
                    if (int.TryParse(s.Trim(), out int num))
                    {
                        numeros.Add(num);
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingresa números válidos separados por comas.");
                        return;
                    }
                }

                // Crear una instancia de RadixSort
                RadixSort radixSort = new RadixSort();

                // Ordenar la lista y obtener la lista ordenada
                List<int> listaOrdenada = radixSort.Ordenar(numeros, pasos);

                // Limpiar el ListBox antes de mostrar los pasos
                lstProceso.Items.Clear();

                // Mostrar los pasos intermedios solo cuando haya cambios
                foreach (var paso in pasos)
                {
                    lstProceso.Items.Add(paso);  // Mostrar cada paso del ordenamiento
                }

                // Mostrar la lista ordenada final
                lstProceso.Items.Add("Lista ordenada final: " + string.Join(" -> ", listaOrdenada));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
