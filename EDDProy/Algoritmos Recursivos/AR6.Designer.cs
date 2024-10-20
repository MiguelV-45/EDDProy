namespace EDDemo
{
    partial class AR6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbComplejidad = new System.Windows.Forms.TextBox();
            this.txbTiempo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbResultado = new System.Windows.Forms.ListBox();
            this.txbDiscos = new System.Windows.Forms.TextBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbComplejidad
            // 
            this.txbComplejidad.Location = new System.Drawing.Point(379, 324);
            this.txbComplejidad.Name = "txbComplejidad";
            this.txbComplejidad.Size = new System.Drawing.Size(129, 22);
            this.txbComplejidad.TabIndex = 24;
            // 
            // txbTiempo
            // 
            this.txbTiempo.Location = new System.Drawing.Point(379, 295);
            this.txbTiempo.Name = "txbTiempo";
            this.txbTiempo.Size = new System.Drawing.Size(129, 22);
            this.txbTiempo.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Complejidad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tiempo de Ejecucion :";
            // 
            // lbResultado
            // 
            this.lbResultado.FormattingEnabled = true;
            this.lbResultado.ItemHeight = 16;
            this.lbResultado.Location = new System.Drawing.Point(379, 119);
            this.lbResultado.Name = "lbResultado";
            this.lbResultado.Size = new System.Drawing.Size(243, 148);
            this.lbResultado.TabIndex = 20;
            // 
            // txbDiscos
            // 
            this.txbDiscos.Location = new System.Drawing.Point(379, 78);
            this.txbDiscos.Name = "txbDiscos";
            this.txbDiscos.Size = new System.Drawing.Size(129, 22);
            this.txbDiscos.TabIndex = 19;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(403, 378);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 18;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(272, 378);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 17;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Resultado :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ingresa numero de discos :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Torre de Hanoi";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegresar.Location = new System.Drawing.Point(681, 13);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(107, 29);
            this.btnRegresar.TabIndex = 13;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // AR6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbComplejidad);
            this.Controls.Add(this.txbTiempo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbResultado);
            this.Controls.Add(this.txbDiscos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegresar);
            this.Name = "AR6";
            this.Text = "AR6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbComplejidad;
        private System.Windows.Forms.TextBox txbTiempo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbResultado;
        private System.Windows.Forms.TextBox txbDiscos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegresar;
    }
}