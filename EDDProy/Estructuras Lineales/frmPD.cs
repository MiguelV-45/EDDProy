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
    public partial class frmPD : Form
    {
        public Pilas pila;

        public frmPD()
        {
            InitializeComponent();
            pila = new Pilas();
        }

        // Botón para apilar un valor
        private void btnPush_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int valor))
            {
                try
                {
                    pila.PushPD(valor);
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

        // Botón para desapilar un valor
        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = pila.Pop();
                ActualizarPila();
                MessageBox.Show($"Elemento {valor} desapilado.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Botón para mostrar el valor en el tope de la pila
        private void btnTop_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = pila.Top();
                MessageBox.Show($"El elemento en el tope es: {valor}");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Botón para limpiar la pila
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pila = new Pilas(pila.MaxSize);  // Reinicia la pila con el mismo tamaño
            ActualizarPila();
            MessageBox.Show("Pila vaciada.");
        }

        // Actualiza el ListBox con el estado actual de la pila
        private void ActualizarPila()
        {
            listBox1.Items.Clear();
            Nodo nodoActual = pila.Inicio;
            while (nodoActual != null)
            {
                listBox1.Items.Add(nodoActual.Dato);
                nodoActual = nodoActual.Siguiente;
            }
        }

        // Regresa al menú principal
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
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
    }
}
