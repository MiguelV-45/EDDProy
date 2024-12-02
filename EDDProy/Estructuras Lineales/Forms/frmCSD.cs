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
    public partial class frmCSD : Form
    {
        private ColaSimple cola; // Instancia de la clase ColaSimple
        public frmCSD()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
            cola = new ColaSimple(); // Inicializa la cola
        }

        // Método para agregar un elemento a la cola
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtElemento.Text, out int elemento))
            {
                cola.AgregarElemento(elemento);
                MostrarCola();
                txtElemento.Clear();
            }
            else
            {
                MessageBox.Show("Ingresa un número válido.");
            }
        }

        // Método para eliminar el primer elemento de la cola
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cola.EliminarElemento();
            MostrarCola();
        }

        // Método para eliminar un elemento específico de la cola
        private void btnEliminarEspecifico_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtElemento.Text, out int elemento))
            {
                cola.EliminarElementoEspecifico(elemento);
                MostrarCola();
            }
            else
            {
                MessageBox.Show("Ingresa un número válido.");
            }
        }

        // Método para vaciar todos los elementos de la cola
        private void btnVaciar_Click(object sender, EventArgs e)
        {
            cola.VaciarCola();
            MostrarCola();
        }

        // Método para buscar un elemento dentro de la cola
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtElemento.Text, out int elemento))
            {
                bool encontrado = cola.BuscarElemento(elemento);
                MessageBox.Show(encontrado ? "Elemento encontrado." : "Elemento no encontrado.");
            }
            else
            {
                MessageBox.Show("Ingresa un número válido.");
            }
        }

        // Método para mostrar los elementos de la cola en el Label
        private void MostrarCola()
        {
            lblCola.Text = cola.MostrarCola();
        }

        // Método para regresar al menú principal
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
    }
}
