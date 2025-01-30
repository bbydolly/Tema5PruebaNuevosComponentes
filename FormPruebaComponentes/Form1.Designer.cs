namespace FormPruebaComponentes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.etiquetaAviso1 = new Tema5PruebaNuevosComponentes.EtiquetaAviso();
            this.labelTextBox1 = new Tema5PruebaNuevosComponentes.LabelTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Change position";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Incrementar separación";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.Location = new System.Drawing.Point(43, 135);
            this.etiquetaAviso1.Marca = Tema5PruebaNuevosComponentes.EMarca.Cruz;
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(97, 15);
            this.etiquetaAviso1.TabIndex = 3;
            this.etiquetaAviso1.Text = "etiquetaAviso1";
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.Location = new System.Drawing.Point(28, 41);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Posicion = Tema5PruebaNuevosComponentes.LabelTextBox.EPosicion.IZQUIERDA;
            this.labelTextBox1.PswChr = 'u';
            this.labelTextBox1.Separacion = 0;
            this.labelTextBox1.Size = new System.Drawing.Size(135, 20);
            this.labelTextBox1.Subrayada = true;
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextLbl = "label1";
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.PosicionChanged += new System.EventHandler(this.labelTextBox1_PosicionChanged);
            this.labelTextBox1.TxtChange += new System.EventHandler(this.labelTextBox1_TxtChange_1);
            this.labelTextBox1.SeparacionChanged += new System.EventHandler(this.labelTextBox1_SeparacionChanged_1);
            this.labelTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.labelTextBox1_KeyPress);
            this.labelTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.labelTextBox1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etiquetaAviso1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTextBox1);
            this.Name = "Form1";
            this.Text = "Practica guiada Dibujo GDI y clase Control";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Tema5PruebaNuevosComponentes.LabelTextBox labelTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Tema5PruebaNuevosComponentes.EtiquetaAviso etiquetaAviso1;
    }
}

