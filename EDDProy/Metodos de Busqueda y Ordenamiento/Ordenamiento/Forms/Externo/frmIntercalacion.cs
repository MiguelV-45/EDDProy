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
    public partial class frmIntercalacion : Form
    {
        public frmIntercalacion()
        {
            InitializeComponent();
        }

        private void btnIntercalar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Selecciona el primer archivo",
                    Filter = "Archivos de texto (*.txt)|*.txt"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo1 = openFileDialog.FileName;

                    openFileDialog.Title = "Selecciona el segundo archivo";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string archivo2 = openFileDialog.FileName;

                        // Llamar a la intercalación y obtener el resultado como lista
                        Intercalacion intercalacion = new Intercalacion();
                        List<int> resultado = intercalacion.IntercalarEnLista(archivo1, archivo2);

                        // Mostrar el resultado en el ListBox
                        lstResultados.Items.Clear();
                        foreach (int numero in resultado)
                        {
                            lstResultados.Items.Add(numero);
                        }

                        MessageBox.Show("Intercalación completada. Resultados mostrados en el ListBox.", "Éxito");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error");
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
        }
    }
} 

