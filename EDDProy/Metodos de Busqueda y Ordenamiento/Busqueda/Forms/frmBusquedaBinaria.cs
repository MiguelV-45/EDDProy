using EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Busqueda.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Busqueda.Forms
{
    public partial class frmBusquedaBinaria : Form
    {

        private BusquedaBinaria busqueda;

        public frmBusquedaBinaria()
        {
            InitializeComponent();
            busqueda = new BusquedaBinaria();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                busqueda.AgregarNumero(numero);
                ActualizarLista();
                txtNumero.Clear();
                txtNumero.Focus();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int numeroBuscado))
            {
                int posicion = busqueda.BuscarNumero(numeroBuscado);

                if (posicion != -1)
                {
                    MessageBox.Show($"Número encontrado en la posición: {posicion + 1}", "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Número no encontrado.", "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número válido para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda.LimpiarLista();
            ActualizarLista();
            txtNumero.Clear();
            txtBuscar.Clear();
            MessageBox.Show("Todos los campos han sido limpiados.", "Limpieza Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarLista()
        {
            listNumeros.Items.Clear();
            foreach (int numero in busqueda.ObtenerNumeros())
            {
                listNumeros.Items.Add(numero);
            }
        }
    }
}
