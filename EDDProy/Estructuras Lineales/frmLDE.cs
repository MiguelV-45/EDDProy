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
    public partial class frmLDE : Form
    {
        private ListaDobleEncadenada lista = new ListaDobleEncadenada();
        public frmLDE()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDato.Text, out int dato) && int.TryParse(txtPosicion.Text, out int posicion))
            {
                lista.Insertar(posicion, dato);
                lblLista.Text = lista.MostrarLista();
            }
            else
            {
                MessageBox.Show("Por favor ingresa un número válido en el campo de dato y posición.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPosicion.Text, out int posicion))
            {
                int? eliminado = lista.Eliminar(posicion);
                if (eliminado != null)
                {
                    MessageBox.Show($"Elemento eliminado: {eliminado}");
                    lblLista.Text = lista.MostrarLista();
                }
                else
                {
                    MessageBox.Show("No se encontró el elemento.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa una posición válida.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtPosicion.Text, out int dato))
            {
                int posicion = lista.Buscar(dato);
                if (posicion != -1)
                {
                    MessageBox.Show($"Elemento encontrado en la posición: {posicion}.");
                }
                else
                {
                    MessageBox.Show("Elemento no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa un número válido en el campo de búsqueda.");
            }
        }

        private void btnVaciar_Click(object sender, EventArgs e)
        {
            lista.VaciarLista();
            lblLista.Text = "Lista vacía";
            MessageBox.Show("Lista vaciada correctamente.");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Close();
        }
    }
}
