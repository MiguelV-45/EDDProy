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
    public partial class frmBusquedaHashing : Form
    {
        // Instancia de la clase FuncionesHash
        private FuncionesHash funcionesHash;

        public frmBusquedaHashing()
        {
            InitializeComponent();
            // Inicializamos el manejador de la tabla hash
            funcionesHash = new FuncionesHash();
        }

       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiamos los TextBox de clave y valor
            txtClave.Clear();
            txtValor.Clear();

            // Limpiamos el ListBox
            listResultados.Items.Clear();

            // Limpiamos la tabla hash (diccionario)
            funcionesHash.LimpiarTabla();

            // Mostramos un mensaje indicando que todo ha sido limpiado
            MessageBox.Show("Todos los campos y elementos han sido limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int clave;
            string valor = txtValor.Text;

            bool isNumeric = int.TryParse(txtClave.Text, out clave);

            if (isNumeric && !string.IsNullOrEmpty(valor))
            {
                // Agregamos el nuevo elemento
                funcionesHash.AgregarElemento(clave, valor);

                // Actualizamos el ListBox con todos los elementos de la tabla hash
                ActualizarListBox();

                // Mostramos un mensaje de éxito en un MessageBox
                MessageBox.Show("Elemento agregado/actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Mostramos un mensaje de error si no se ingresaron datos válidos
                MessageBox.Show("Por favor ingresa una clave válida y un valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int clave;
            bool isNumeric = int.TryParse(txtClave.Text, out clave);

            if (isNumeric)
            {
                // Llamamos al método BuscarElemento de FuncionesHash
                string resultado = funcionesHash.BuscarElemento(clave);

                // Mostramos el resultado en un MessageBox
                MessageBox.Show(resultado, "Resultado de la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor ingresa un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListBox()
        {
            listResultados.Items.Clear(); // Limpiamos el ListBox antes de agregar los nuevos elementos

            // Obtenemos todos los elementos de la tabla hash y los mostramos en el ListBox
            string[] elementos = funcionesHash.ObtenerElementos();
            foreach (var clave in elementos)
            {
                listResultados.Items.Add(clave + " - " + funcionesHash.BuscarElemento(int.Parse(clave)));
            }
        }
    }
}
