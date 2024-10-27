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
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Obtenemos el nodo raíz del árbol
            miRaiz = miArbol.RegresaRaiz();

            // Verificar si el valor ya existe en el árbol
            if (miArbol.Busqueda(valor, miRaiz))
            {
                MessageBox.Show($"El valor {valor} ya existe en el árbol. No se permiten duplicados.");
                txtDato.Text = "";
                return;
            }

            // Insertar el nodo ya que no es duplicado
            miArbol.strArbol = "";
            miArbol.InsertaNodo(valor, ref miRaiz);
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
            txtDato.Text = "";


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
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
            String graphVizString;

            miRaiz = miArbol.RegresaRaiz();
            if (miRaiz == null)
            {
                MessageBox.Show("El arbol esta vacio");
                return;
            }

            StringBuilder b = new StringBuilder();
            b.Append("digraph G { node [shape=\"circle\"]; " + Environment.NewLine);
            b.Append(miArbol.ToDot(miRaiz));
            b.Append("}");
            graphVizString = b.ToString();

            //graphVizString = @" digraph g{ label=""Graph""; labelloc=top;labeljust=left;}";
            //graphVizString = @"digraph Arbol{Raiz->60; 60->40. 60->90; 40->34; 40->50;}";
            Bitmap bm = FileDotEngine.Run(graphVizString);


            frmGrafica graf = new frmGrafica();
            graf.ActualizaGrafica(bm);
            graf.MdiParent = this.MdiParent;
            graf.Show();
        }


        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            //Recorrido en PreOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPreOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPreOrden.Text = "";
            miArbol.PreOrden(miRaiz);

            lblRecorridoPreOrden.Text = miArbol.strRecorrido;


            //Recorrido en InOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoInOrden.Text = "";
            miArbol.InOrden(miRaiz);
            lblRecorridoInOrden.Text = miArbol.strRecorrido;


            //Recorrido en PostOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPostOrden.Text = "";
            miArbol.PostOrden(miRaiz);
            lblRecorridoPostOrden.Text = miArbol.strRecorrido;
        }

        private void btnCrearArbol_Click(object sender, EventArgs e)
        {
            // Limpiamos el árbol anterior
            miArbol = new ArbolBusqueda();
            miRaiz = null;
            txtArbol.Text = "";
            txtDato.Text = "";
            miArbol.strArbol = "";

            Random rnd = new Random();
            for (int nNodos = 1; nNodos <= txtNodos.Value; nNodos++)
            {
                int dato = rnd.Next(1, 100);

                // Verificar si el valor ya existe en el árbol
                if (!miArbol.Busqueda(dato, miRaiz))
                {
                    // Insertar el nodo si no es duplicado
                    miArbol.InsertaNodo(dato, ref miRaiz);
                }
            }

            // Leer árbol completo y mostrarlo en caja de texto
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int valor;
            // Tomar el valor de txtDato y verificar si es un número válido
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Obtenemos el nodo raíz del árbol y buscamos el valor
            miRaiz = miArbol.RegresaRaiz();
            bool encontrado = miArbol.Busqueda(valor, miRaiz);

            // Mostrar mensaje basado en el resultado de la búsqueda
            if (encontrado)
                MessageBox.Show($"El valor {valor} SÍ se encuentra en el árbol.");
            else
                MessageBox.Show($"El valor {valor} NO se encuentra en el árbol.");

            // Limpiar el campo de texto después de buscar
            txtDato.Text = "";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
    }
}