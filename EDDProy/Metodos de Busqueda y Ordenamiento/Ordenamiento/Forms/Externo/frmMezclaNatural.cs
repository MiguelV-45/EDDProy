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
    public partial class frmMezclaNatural : Form
    {
        public frmMezclaNatural()
        {
            InitializeComponent();
        }

        public void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir un cuadro de diálogo para seleccionar el archivo
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Selecciona el archivo a ordenar",
                    Filter = "Archivos de texto (*.txt)|*.txt"
                };

                // Selección del archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo = openFileDialog.FileName;

                    // Limpiar el ListBox y mostrar mensaje de progreso
                    lstResultados.Items.Clear();
                    lstResultados.Items.Add("Leyendo archivo...");

                    // Ejecutar el proceso de mezcla natural de manera asincrónica
                    MezclaNatural mezclaNatural = new MezclaNatural();
                    List<int> resultado = await Task.Run(() => mezclaNatural.OrdenarPorMezclaNatural(archivo));

                    // Si el archivo está vacío o no se procesó correctamente
                    if (resultado.Count == 0)
                    {
                        lstResultados.Items.Add("El archivo está vacío o no se pudo procesar.");
                        return;
                    }

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

        public void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstResultados.Items.Clear();
        }
    }
}
