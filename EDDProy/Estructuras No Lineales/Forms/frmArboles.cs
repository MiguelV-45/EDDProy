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
            // Verifica si el árbol no es nulo antes de intentar limpiar
            if (miRaiz != null)
            {
                miArbol.LimpiarArbol(miRaiz); // Método recursivo para liberar nodos
                miRaiz = null; // Ahora puedes liberar la raíz
            }

            // Si tu árbol es una estructura propia, como una clase, asegúrate de liberar todo.
            miArbol = null;

            // Limpia los campos visuales
            txtArbol.Text = "";
            txtDato.Text = "";
            lblRecorridoPreOrden.Text = "";
            lblRecorridoInOrden.Text = "";
            lblRecorridoPostOrden.Text = "";
            lblRecorridoNiveles.Text = "";
            lblAltura.Text = "";
            lblCantidadHojas.Text = "";
            lblCantidadNodos.Text = "";
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


        //Boton para eliminar el nodo Predecesor que se elija
        private void btnEliminarPredecesor_Click(object sender, EventArgs e)
        {
            int valor;
            // Validación del valor ingresado en txtDato
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Buscar el nodo con el valor proporcionado
            miRaiz = miArbol.RegresaRaiz();
            NodoBinario nodoBuscado = miArbol.BuscarNodo(miRaiz, valor);

            // Verificar que el nodo exista
            if (nodoBuscado == null)
            {
                MessageBox.Show($"El valor {valor} no existe en el árbol.");
                return;
            }

            // Obtener el predecesor del nodo encontrado
            NodoBinario predecesor = miArbol.ObtenerPredecesor(nodoBuscado);

            // Si no existe un predecesor, muestra un mensaje de error
            if (predecesor == null)
            {
                MessageBox.Show($"El nodo {valor} no tiene predecesor.");
                return;
            }

            // Eliminar el nodo predecesor
            miRaiz = miArbol.EliminarNodo(miRaiz, predecesor.Dato);

            // Mostrar el árbol actualizado
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
        }

        //Boton para eliminar el sucesor del nodo que se elija
        private void btnEliminarSucesor_Click(object sender, EventArgs e)
        {
            // Validación del valor ingresado en txtDato
            int valor;
            if (!int.TryParse(txtDato.Text, out valor))
            {
                MessageBox.Show("Por favor, introduce un valor válido.");
                return;
            }

            // Buscar el nodo con el valor proporcionado
            NodoBinario nodoBuscado = miArbol.BuscarNodo(miRaiz, valor);

            // Verificar que el nodo exista
            if (nodoBuscado == null)
            {
                MessageBox.Show($"El valor {valor} no existe en el árbol.");
                return;
            }

            // Obtener el sucesor del nodo encontrado
            NodoBinario sucesor = miArbol.ObtenerSucesor(nodoBuscado);

            // Si no existe un sucesor, muestra un mensaje de error
            if (sucesor == null)
            {
                MessageBox.Show($"El nodo {valor} no tiene sucesor.");
                return;
            }

            // Eliminar el nodo sucesor
            miRaiz = miArbol.EliminarNodo(miRaiz, sucesor.Dato);

            // Mostrar el árbol actualizado
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;
        }

        //Boton para recorrer los nodos por amplitud
        private void btnRecorrerPorNiveles_Click(object sender, EventArgs e)
        {
            NodoBinario miRaiz = miArbol.RegresaRaiz(); // Obtener la raíz del árbol
            miArbol.strRecorrido = ""; // Limpiar el recorrido anterior

            if (miRaiz == null)
            {
                lblRecorridoNiveles.Text = "El árbol está vacío.";
                return;
            }

            miArbol.RecorrerPorNivelesRecursivo(miRaiz); // Realizar el recorrido por niveles recursivamente
            lblRecorridoNiveles.Text = miArbol.strRecorrido; // Mostrar el recorrido en el Label
        }

        // boton para contar la altura del arbol
        private void btnAltura_Click(object sender, EventArgs e)
        {
            NodoBinario miRaiz = miArbol.RegresaRaiz(); // Obtener la raíz del árbol

            if (miRaiz == null)
            {
                lblAltura.Text = "El árbol está vacío.";
                return;
            }

            int altura = miArbol.Altura(miRaiz); // Obtener la altura del árbol
            lblAltura.Text = "" + altura;
        }

        // boton para contar las hojas cuando se presiona el botón
        private void btnContarHojas_Click(object sender, EventArgs e)
        {
            // Llamamos al método ContarHojas y le pasamos la raíz del árbol.
            int cantidadHojas = miArbol.ContarHojas(miRaiz);

            // Mostramos la cantidad de hojas en el label.
            lblCantidadHojas.Text = "" +  cantidadHojas;
        }

        // boton para contar los nodos del árbol
        private void btnContarNodos_Click(object sender, EventArgs e)
        {
            NodoBinario miRaiz = miArbol.RegresaRaiz(); // Obtener la raíz del árbol

            // Llamamos al método para contar los nodos
            int cantidadNodos = miArbol.ContarNodos(miRaiz);

            // Mostramos el resultado en el Label
            lblCantidadNodos.Text = "" + cantidadNodos;
        }

        // boton para ver si el arbol esta completo
        private void btnVerificarCompleto_Click(object sender, EventArgs e)
        {
            NodoBinario miRaiz = miArbol.RegresaRaiz(); // Obtener la raíz del árbol
            bool esCompleto = miArbol.EsCompleto(miRaiz); // Verificar si el árbol es completo

            // Mostrar el resultado en el label
            lblResultadoCompleto.Text = esCompleto ? "El árbol es completo" : "El árbol no es completo";
        }

        // boton para verificar si el arbol esta lleno
        private void btnVerificarLleno_Click(object sender, EventArgs e)
        {
            NodoBinario miRaiz = miArbol.RegresaRaiz(); // Obtener la raíz del árbol
            bool esLleno = miArbol.EsLleno(miRaiz); // Verificar si el árbol es lleno

            // Mostrar el resultado en el label
            lblResultadoLleno.Text = esLleno ? "El árbol es lleno" : "El árbol no es lleno";
        }
    }
}