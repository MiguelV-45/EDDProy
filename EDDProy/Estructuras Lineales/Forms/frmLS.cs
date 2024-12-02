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
    public partial class frmLS : Form
    {
        // Instancia de la lista simplemente enlazada.
        ListaSimple lista = new ListaSimple();

        // Constructor del formulario.
        public frmLS()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        // Maneja el evento de clic en el botón Regresar.
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Maneja el evento de clic en el botón Agregar.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDato.Text, out int valor)) // Intenta convertir el texto a un número.
            {
                lista.Agregar(valor); // Agrega el valor a la lista.
                lista.Mostrar(labelLista); // Muestra la lista actualizada en el Label.
                txtDato.Clear(); // Limpia el campo de texto.
            }
            else
            {
                MessageBox.Show("Ingrese un número válido."); // Mensaje de error.
            }
        }

        // Maneja el evento de clic en el botón Eliminar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Si el TextBox está vacío, elimina el primer nodo (top de la lista).
            if (string.IsNullOrWhiteSpace(txtDato.Text))
            {
                if (lista.cabeza != null) // Verifica si la lista no está vacía.
                {
                    lista.Eliminar(lista.cabeza.Dato); // Elimina el primer nodo.
                    lista.Mostrar(labelLista); // Muestra la lista actualizada en el Label.
                }
            }
            else
            {
                // Si hay un número en el TextBox, elimina ese número específico.
                if (int.TryParse(txtDato.Text, out int valor))
                {
                    lista.Eliminar(valor); // Elimina el valor de la lista.
                    lista.Mostrar(labelLista); // Muestra la lista actualizada en el Label.
                    txtDato.Clear(); // Limpia el campo de texto.
                }
                else
                {
                    MessageBox.Show("Ingrese un número válido."); // Mensaje de error.
                }
            }
        }

        // Maneja el evento de clic en el botón Buscar.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDato.Text, out int valor)) // Intenta convertir el texto a un número.
            {
                string mensaje = lista.Buscar(valor) ? "Número encontrado." : "Número no encontrado."; // Busca el número y asigna el mensaje.
                MessageBox.Show(mensaje); // Muestra el resultado de la búsqueda.
                txtDato.Clear(); // Limpia el campo de texto.
            }
            else
            {
                MessageBox.Show("Ingrese un número válido."); // Mensaje de error.
            }
        }

        // Maneja el evento de clic en el botón Vaciar.
        private void btnVaciar_Click(object sender, EventArgs e)
        {
            lista.Vaciar(); // Vacía la lista.
            lista.Mostrar(labelLista); // Muestra la lista actualizada en el Label.
        }
    }
}

