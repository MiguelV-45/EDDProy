using EDDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;


//sing GraphVizWrapper;
//using GraphVizWrapper.Queries;
//using GraphVizWrapper.Commands;

//using csdot;
//using csdot.Attributes.DataTypes;

namespace EDDemo.Estructuras_No_Lineales
{
    public partial class frmArboles : Form
    {
        // Declaración del árbol de búsqueda y su nodo raíz.
        ArbolBusqueda miArbol;
        NodoBinario miRaiz;

        public frmArboles()
        {
            InitializeComponent();
            miArbol = new ArbolBusqueda();
            miRaiz = null;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int valor;
            // Validación del valor introducido en txtDato.
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Obtenemos el nodo raíz del árbol.
            miRaiz = miArbol.RegresaRaiz();

            // Verificamos si el valor ya existe en el árbol para evitar duplicados.
            if (miArbol.Busqueda(valor, miRaiz))
            {
                MessageBox.Show($"El valor {valor} ya existe en el árbol. No se permiten duplicados.");
                txtDato.Text = "";
                return;
            }

            // Insertamos el nodo en el árbol y actualizamos la representación visual.
            miArbol.strArbol = "";
            miArbol.InsertaNodo(valor, ref miRaiz);
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
            txtDato.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Reinicia el árbol y limpia los campos visuales.
            miArbol = null;
            miRaiz = null;
            miArbol = new ArbolBusqueda();
            txtArbol.Text = "";
            txtDato.Text = "";
            lblRecorridoPreOrden.Text = "";
            lblRecorridoInOrden.Text = "";
            lblRecorridoPostOrden.Text = "";
        }

        private void btnGrafica_Click(object sender, EventArgs e)
        {
            // Generación de la cadena en formato GraphViz para graficar el árbol.
            String graphVizString;

            miRaiz = miArbol.RegresaRaiz();
            if (miRaiz == null)
            {
                MessageBox.Show("El árbol está vacío.");
                return;
            }

            // Construcción de la representación en GraphViz.
            StringBuilder b = new StringBuilder();
            b.Append("digraph G { node [shape=\"circle\"]; " + Environment.NewLine);
            b.Append(miArbol.ToDot(miRaiz));
            b.Append("}");
            graphVizString = b.ToString();

            Bitmap bm = FileDotEngine.Run(graphVizString);

            // Muestra la gráfica en un formulario aparte.
            frmGrafica graf = new frmGrafica();
            graf.ActualizaGrafica(bm);
            graf.MdiParent = this.MdiParent;
            graf.Show();
        }

        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            // Obtenemos el nodo raíz y realizamos recorrido en PreOrden.
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPreOrden.Text = "El árbol está vacío.";
                return;
            }
            lblRecorridoPreOrden.Text = "";
            miArbol.PreOrden(miRaiz);
            lblRecorridoPreOrden.Text = miArbol.strRecorrido;

            // Realizamos recorrido en InOrden.
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El árbol está vacío.";
                return;
            }
            lblRecorridoInOrden.Text = "";
            miArbol.InOrden(miRaiz);
            lblRecorridoInOrden.Text = miArbol.strRecorrido;

            // Realizamos recorrido en PostOrden.
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El árbol está vacío.";
                return;
            }
            lblRecorridoPostOrden.Text = "";
            miArbol.PostOrden(miRaiz);
            lblRecorridoPostOrden.Text = miArbol.strRecorrido;
        }

        private void btnCrearArbol_Click(object sender, EventArgs e)
        {
            // Limpia el árbol actual y genera uno nuevo con valores aleatorios.
            miArbol = new ArbolBusqueda();
            miRaiz = null;
            txtArbol.Text = "";
            txtDato.Text = "";
            miArbol.strArbol = "";

            Random rnd = new Random();
            for (int nNodos = 1; nNodos <= txtNodos.Value; nNodos++)
            {
                int dato = rnd.Next(1, 100);

                // Verificamos si el valor es único antes de insertarlo.
                if (!miArbol.Busqueda(dato, miRaiz))
                {
                    miArbol.InsertaNodo(dato, ref miRaiz);
                }
            }

            // Mostramos la estructura del árbol generado en la caja de texto.
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int valor;
            // Validación del valor introducido.
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Realizamos la búsqueda del valor en el árbol.
            miRaiz = miArbol.RegresaRaiz();
            bool encontrado = miArbol.Busqueda(valor, miRaiz);

            // Mostramos un mensaje indicando si el valor fue encontrado o no.
            if (encontrado)
                MessageBox.Show($"El valor {valor} SÍ se encuentra en el árbol.");
            else
                MessageBox.Show($"El valor {valor} NO se encuentra en el árbol.");

            // Limpiamos el campo de texto después de la búsqueda.
            txtDato.Text = "";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual.
            this.Close();
        }
    }
}