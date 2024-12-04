using EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Ordenamiento.Clases.Externo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Forms.Externo
{
    public partial class frmMezclaDirecta : Form
    {
        public frmMezclaDirecta()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Selecciona el archivo a ordenar",
                    Filter = "Archivos de texto (*.txt)|*.txt"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo = openFileDialog.FileName;

                    // Llamar al método de mezcla directa y obtener el resultado
                    MezclaDirecta mezclaDirecta = new MezclaDirecta();
                    List<int> resultado = mezclaDirecta.OrdenarPorMezclaDirecta(archivo);

                    // Mostrar el resultado en el ListBox
                    lstResultados.Items.Clear();
                    foreach (int numero in resultado)
                    {
                        lstResultados.Items.Add(numero);
                    }

                    MessageBox.Show("Ordenamiento completado. Resultados mostrados en el ListBox.", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
        }
    }
}
