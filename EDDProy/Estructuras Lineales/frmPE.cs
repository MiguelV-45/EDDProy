using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo
{
    public partial class frmPE : Form
    {
        private Pilas pila; // Instancia de la pila.

        public frmPE()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSize.Text, out int maxSize) && maxSize > 0)
            {
                pila = new Pilas(maxSize); // Inicializa la pila con el tamaño indicado.
                MessageBox.Show($"Tamaño de la pila: {maxSize}");
            }
            else
            {
                MessageBox.Show("Introduce un número válido.");
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int valor))
            {
                try
                {
                    pila.Push(valor); // Agrega un elemento a la pila.
                    ActualizarPila();
                    textBox1.Clear();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Introduce un número válido.");
            }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                pila.Pop(); // Elimina el último elemento.
                ActualizarPila();
                MessageBox.Show("Elemento del tope eliminado.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            try
            {
                int top = pila.Top(); // Obtiene el elemento del tope.
                MessageBox.Show($"El elemento en el tope es: {top}");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pila.VaciarLista(); // Vacía la pila.
            ActualizarPila();
            MessageBox.Show("Pila vaciada.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int valor))
            {
                Nodo actual = pila.ObtenerInicio();
                bool encontrado = false;

                while (actual != null)
                {
                    if (actual.Dato == valor)
                    {
                        encontrado = true;
                        MessageBox.Show($"Elemento {valor} encontrado.");
                        break;
                    }
                    actual = actual.Siguiente;
                }

                if (!encontrado) MessageBox.Show("Elemento no encontrado.");
            }
            else
            {
                MessageBox.Show("Introduce un número válido.");
            }
        }

        private void ActualizarPila()
        {
            listBox1.Items.Clear(); // Limpia el ListBox.
            Nodo actual = pila.ObtenerInicio();

            while (actual != null)
            {
                listBox1.Items.Add(actual.Dato); // Muestra los elementos en el ListBox.
                actual = actual.Siguiente;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
    }
}
