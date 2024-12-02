using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDDemo.Algoritmos_Recursivos.Clases;
using EDDemo.Estructuras_Lineales;
using EDDemo.Estructuras_No_Lineales;
using EDDemo.Metodos_de_Busqueda_y_Ordenamiento;
using EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Forms;

namespace EDDemo
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        //************************************** Estructura no lineal ***************************//
        private void arbolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArboles mArboles = new frmArboles();
            mArboles.MdiParent = this;
            mArboles.Show();
        }

        //***************** Algoritmos Recursivos ***************************//
        private void factorialDe1NumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR1 frm1 = new AR1(); // Crea una nueva instancia del formulario "AR1"
            frm1.Show(); // Muestra el formulario "AR1"
            frm1.MdiParent = this;
        }

        private void calculoDeUnExponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR2 frm2 = new AR2();// Crea una nueva instancia del formulario "AR2"
            frm2.Show();// Muestra el formulario "AR2"
            frm2.MdiParent = this;
        }

        private void sumarArreglosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR3 frm3 = new AR3();// Crea una nueva instancia del formulario "AR3"
            frm3.Show();// Muestra el formulario "AR3"
            frm3.MdiParent = this;
        }

        private void fibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR4 frm4 = new AR4();// Crea una nueva instancia del formulario "AR4"
            frm4.Show();// Muestra el formulario "AR4"
            frm4.MdiParent = this;
        }

        private void busquedaBinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR5 frm5 = new AR5();// Crea una nueva instancia del formulario "AR5"
            frm5.Show();// Muestra el formulario "AR5"
            frm5.MdiParent = this;
        }

        private void torreDeHanoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR6 frm6 = new AR6();// Crea una nueva instancia del formulario "AR6"
            frm6.Show();// Muestra el formulario "AR6"
            frm6.MdiParent = this;
        }
        //***************************** Estructura Lineal *************************************************//
        private void estaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPE frm1 = new frmPE();// Crea una nueva instancia del formulario 
            frm1.Show();// Muestra el formulario 
            frm1.MdiParent = this;
        }

        private void dinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPD frm2 = new frmPD();// Crea una nueva instancia del formulario 
            frm2.Show();// Muestra el formulario 
            frm2.MdiParent = this;
        }

        private void simpleEstaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCSE frm3 = new frmCSE();// Crea una nueva instancia del formulario 
            frm3.Show();// Muestra el formulario 
            frm3.MdiParent = this;
        }

        private void simpleDinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCSD frm4 = new frmCSD();// Crea una nueva instancia del formulario 
            frm4.Show();// Muestra el formulario 
            frm4.MdiParent = this;
        }

        private void simplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLS frm5 = new frmLS();// Crea una nueva instancia del formulario 
            frm5.Show();// Muestra el formulario 
            frm5.MdiParent = this;
        }

        private void doblementeEncadenadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDE frm6 = new frmLDE();// Crea una nueva instancia del formulario 
            frm6.Show();// Muestra el formulario 
            frm6.MdiParent = this;
        }

        private void circularesSimplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLCS frm7 = new frmLCS();// Crea una nueva instancia del formulario 
            frm7.Show();// Muestra el formulario 
            frm7.MdiParent = this;
        }

        private void burbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBurbuja frm = new frmBurbuja();
            frm.Show();
            frm.MdiParent = this;
        }

        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuicksort frm = new frmQuicksort();
            frm.Show();
            frm.MdiParent = this;
        }
    }
}
