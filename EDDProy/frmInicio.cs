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
using EDDemo.Estructuras_No_Lineales;

namespace EDDemo
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPilas mPilas = new frmPilas();
            mPilas.MdiParent = this;
            mPilas.Show();
        }

        private void estructurasLinealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
            AR3 frm3 = new AR3();// Crea una nueva instancia del formulario "AR2"
            frm3.Show();// Muestra el formulario "AR2"
            frm3.MdiParent = this;
        }

        private void fibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR4 frm4 = new AR4();// Crea una nueva instancia del formulario "AR2"
            frm4.Show();// Muestra el formulario "AR2"
            frm4.MdiParent = this;
        }

        private void busquedaBinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR5 frm5 = new AR5();// Crea una nueva instancia del formulario "AR2"
            frm5.Show();// Muestra el formulario "AR2"
            frm5.MdiParent = this;
        }

        private void torreDeHanoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AR6 frm6 = new AR6();// Crea una nueva instancia del formulario "AR2"
            frm6.Show();// Muestra el formulario "AR2"
            frm6.MdiParent = this;
        }

        //******************************************************************************//


    }
}
