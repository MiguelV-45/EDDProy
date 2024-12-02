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
    public partial class frmLCS : Form
    {
        private ListaCircularSimple lista = new ListaCircularSimple();

        public frmLCS()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDato.Text) || string.IsNullOrWhiteSpace(txtPosicion.Text))
            {
                MessageBox.Show("Por favor, ingresa un valor y una posición.");
                return;
            }

            int dato = int.Parse(txtDato.Text);
            int posicion = int.Parse(txtPosicion.Text);

            lista.Insertar(dato, posicion);
            MostrarLista();
            txtDato.Clear();
            txtPosicion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPosicion.Text))
            {
                MessageBox.Show("Por favor, ingresa una posición.");
                return;
            }

            int posicion = int.Parse(txtPosicion.Text);
            bool eliminado = lista.Eliminar(posicion);

            MessageBox.Show(eliminado ? "Elemento eliminado." : "No se encontró la posición.");
            MostrarLista();
            txtPosicion.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDato.Text))
            {
                MessageBox.Show("Por favor, ingresa un valor para buscar.");
                return;
            }

            int dato = int.Parse(txtDato.Text);
            bool encontrado = lista.Buscar(dato);

            MessageBox.Show(encontrado ? $"Elemento encontrado: {dato}" : "Elemento no encontrado.");
            txtDato.Clear();
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            lista.Vaciar();
            MessageBox.Show("La lista ha sido vaciada.");
            MostrarLista();
        }

        private void MostrarLista()
        {
            // Limpiar el contenido actual del Label
            lstLista.Text = string.Empty;

            // Obtener los elementos de la lista
            var elementos = lista.Mostrar();

            if (elementos.Count == 0)
            {
                lstLista.Text = "La lista está vacía.";
            }
            else
            {
                // Concatenar los elementos de la lista y mostrarlos en el Label
                lstLista.Text = string.Join(" -> ", elementos);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
