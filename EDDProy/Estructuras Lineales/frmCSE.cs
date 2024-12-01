using EDDemo.Estructuras_Lineales.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_Lineales
{
    public partial class frmCSE : Form
    {
        private ColaSimpleEstatica cola;

        public frmCSE()
        {
            InitializeComponent();
            cola = new ColaSimpleEstatica(5); // Tamaño inicial de la cola
            ActualizarCola();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtElemento.Text == "")
            {
                MessageBox.Show("Por favor ingrese un elemento.");
                return;
            }

            try
            {
                int elemento = Convert.ToInt32(txtElemento.Text);
                cola.AgregarElemento(elemento);
                ActualizarCola();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }

        private void btnEstablecerTamaño_Click(object sender, EventArgs e)
        {
            if (txtTamaño.Text == "")
            {
                MessageBox.Show("Por favor ingrese el tamaño de la cola.");
                return;
            }

            try
            {
                int nuevoTamaño = Convert.ToInt32(txtTamaño.Text);
                cola.EstablecerTamaño(nuevoTamaño);
                MessageBox.Show($"Tamaño de la cola establecido a {nuevoTamaño}");
                ActualizarCola();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un tamaño válido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cola.EliminarElemento();
                ActualizarCola();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            cola.VaciarCola();
            ActualizarCola();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtElemento.Text == "")
            {
                MessageBox.Show("Por favor ingrese un elemento para buscar.");
                return;
            }

            try
            {
                int elemento = Convert.ToInt32(txtElemento.Text);
                bool encontrado = cola.BuscarElemento(elemento);
                if (encontrado)
                    MessageBox.Show("Elemento encontrado en la cola.");
                else
                    MessageBox.Show("Elemento no encontrado.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarCola()
        {
            if (cola.EstaVacia())
            {
                lblCola.Text = "Cola vacía.";
            }
            else
            {
                int[] elementos = cola.ObtenerElementos();
                lblCola.Text = "Cola: " + string.Join(", ", elementos);
            }
        }
    }
}
