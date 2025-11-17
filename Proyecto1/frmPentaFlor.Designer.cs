namespace Proyecto1
{
    partial class frmPentaFlor
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
            this.grbGafico = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grbEntrada = new System.Windows.Forms.GroupBox();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.grbEscala = new System.Windows.Forms.GroupBox();
            this.hScrollEscala = new System.Windows.Forms.TrackBar();
            this.grbRotacion = new System.Windows.Forms.GroupBox();
            this.btnRotarIzquierda = new System.Windows.Forms.Button();
            this.btnRotarDerecha = new System.Windows.Forms.Button();
            this.grbTraslacion = new System.Windows.Forms.GroupBox();
            this.btnEscalar = new System.Windows.Forms.Button();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.grbSalida = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grbGafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbEntrada.SuspendLayout();
            this.grbEscala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).BeginInit();
            this.grbRotacion.SuspendLayout();
            this.grbTraslacion.SuspendLayout();
            this.grbSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGafico
            // 
            this.grbGafico.Controls.Add(this.picCanvas);
            this.grbGafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbGafico.Location = new System.Drawing.Point(413, 107);
            this.grbGafico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbGafico.Name = "grbGafico";
            this.grbGafico.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbGafico.Size = new System.Drawing.Size(685, 574);
            this.grbGafico.TabIndex = 37;
            this.grbGafico.TabStop = false;
            this.grbGafico.Text = "Figura";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(7, 26);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(671, 539);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // grbEntrada
            // 
            this.grbEntrada.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbEntrada.Controls.Add(this.txtSide);
            this.grbEntrada.Controls.Add(this.lblLado);
            this.grbEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbEntrada.Location = new System.Drawing.Point(413, 18);
            this.grbEntrada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbEntrada.Name = "grbEntrada";
            this.grbEntrada.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbEntrada.Size = new System.Drawing.Size(265, 78);
            this.grbEntrada.TabIndex = 35;
            this.grbEntrada.TabStop = false;
            this.grbEntrada.Text = "Control de Entrada";
            // 
            // txtSide
            // 
            this.txtSide.Location = new System.Drawing.Point(117, 32);
            this.txtSide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(132, 26);
            this.txtSide.TabIndex = 1;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(26, 34);
            this.lblLado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(46, 20);
            this.lblLado.TabIndex = 0;
            this.lblLado.Text = "Lado";
            // 
            // grbEscala
            // 
            this.grbEscala.Controls.Add(this.hScrollEscala);
            this.grbEscala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbEscala.Location = new System.Drawing.Point(44, 589);
            this.grbEscala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbEscala.Name = "grbEscala";
            this.grbEscala.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbEscala.Size = new System.Drawing.Size(340, 116);
            this.grbEscala.TabIndex = 40;
            this.grbEscala.TabStop = false;
            this.grbEscala.UseWaitCursor = true;
            // 
            // hScrollEscala
            // 
            this.hScrollEscala.Enabled = false;
            this.hScrollEscala.Location = new System.Drawing.Point(13, 42);
            this.hScrollEscala.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hScrollEscala.Name = "hScrollEscala";
            this.hScrollEscala.Size = new System.Drawing.Size(309, 56);
            this.hScrollEscala.TabIndex = 1;
            this.hScrollEscala.UseWaitCursor = true;
            this.hScrollEscala.Visible = false;
            // 
            // grbRotacion
            // 
            this.grbRotacion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbRotacion.Controls.Add(this.btnRotarIzquierda);
            this.grbRotacion.Controls.Add(this.btnRotarDerecha);
            this.grbRotacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbRotacion.Location = new System.Drawing.Point(44, 282);
            this.grbRotacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbRotacion.Name = "grbRotacion";
            this.grbRotacion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbRotacion.Size = new System.Drawing.Size(341, 118);
            this.grbRotacion.TabIndex = 39;
            this.grbRotacion.TabStop = false;
            this.grbRotacion.Text = "Control de Rotación";
            // 
            // btnRotarIzquierda
            // 
            this.btnRotarIzquierda.Location = new System.Drawing.Point(29, 38);
            this.btnRotarIzquierda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRotarIzquierda.Name = "btnRotarIzquierda";
            this.btnRotarIzquierda.Size = new System.Drawing.Size(121, 56);
            this.btnRotarIzquierda.TabIndex = 2;
            this.btnRotarIzquierda.Text = "Rotar Izquierda";
            this.btnRotarIzquierda.UseVisualStyleBackColor = true;
            this.btnRotarIzquierda.Click += new System.EventHandler(this.btnRotarIzquierda_Click);
            // 
            // btnRotarDerecha
            // 
            this.btnRotarDerecha.Location = new System.Drawing.Point(177, 38);
            this.btnRotarDerecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRotarDerecha.Name = "btnRotarDerecha";
            this.btnRotarDerecha.Size = new System.Drawing.Size(120, 56);
            this.btnRotarDerecha.TabIndex = 1;
            this.btnRotarDerecha.Text = "Rotar derecha";
            this.btnRotarDerecha.UseVisualStyleBackColor = true;
            this.btnRotarDerecha.Click += new System.EventHandler(this.btnRotarDerecha_Click);
            // 
            // grbTraslacion
            // 
            this.grbTraslacion.BackColor = System.Drawing.SystemColors.GrayText;
            this.grbTraslacion.Controls.Add(this.btnEscalar);
            this.grbTraslacion.Controls.Add(this.btnTrasladar);
            this.grbTraslacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbTraslacion.Location = new System.Drawing.Point(44, 146);
            this.grbTraslacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbTraslacion.Name = "grbTraslacion";
            this.grbTraslacion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbTraslacion.Size = new System.Drawing.Size(339, 94);
            this.grbTraslacion.TabIndex = 38;
            this.grbTraslacion.TabStop = false;
            this.grbTraslacion.Text = "Control Traslación y Escala";
            // 
            // btnEscalar
            // 
            this.btnEscalar.Location = new System.Drawing.Point(198, 37);
            this.btnEscalar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEscalar.Name = "btnEscalar";
            this.btnEscalar.Size = new System.Drawing.Size(115, 36);
            this.btnEscalar.TabIndex = 1;
            this.btnEscalar.Text = "Escalar";
            this.btnEscalar.UseVisualStyleBackColor = true;
            this.btnEscalar.Click += new System.EventHandler(this.btnEscalar_Click);
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(12, 37);
            this.btnTrasladar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(115, 36);
            this.btnTrasladar.TabIndex = 0;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // grbSalida
            // 
            this.grbSalida.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grbSalida.Controls.Add(this.btnSalir);
            this.grbSalida.Controls.Add(this.btnResetear);
            this.grbSalida.Controls.Add(this.btnGraficar);
            this.grbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbSalida.Location = new System.Drawing.Point(708, 18);
            this.grbSalida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbSalida.Name = "grbSalida";
            this.grbSalida.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbSalida.Size = new System.Drawing.Size(341, 82);
            this.grbSalida.TabIndex = 36;
            this.grbSalida.TabStop = false;
            this.grbSalida.Text = "Control de Salida";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(234, 32);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 33);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(123, 33);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(106, 34);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Borrar";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(12, 34);
            this.btnGraficar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(101, 34);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 43);
            this.label1.TabIndex = 34;
            this.label1.Text = "Pentagono Flor";
            
            // 
            // frmPentaFlor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 718);
            this.Controls.Add(this.grbGafico);
            this.Controls.Add(this.grbEntrada);
            this.Controls.Add(this.grbEscala);
            this.Controls.Add(this.grbRotacion);
            this.Controls.Add(this.grbTraslacion);
            this.Controls.Add(this.grbSalida);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPentaFlor";
            this.Text = "frmPentaEstrella";
            this.grbGafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbEntrada.ResumeLayout(false);
            this.grbEntrada.PerformLayout();
            this.grbEscala.ResumeLayout(false);
            this.grbEscala.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).EndInit();
            this.grbRotacion.ResumeLayout(false);
            this.grbTraslacion.ResumeLayout(false);
            this.grbSalida.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGafico;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grbEntrada;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.GroupBox grbEscala;
        private System.Windows.Forms.TrackBar hScrollEscala;
        private System.Windows.Forms.GroupBox grbRotacion;
        private System.Windows.Forms.Button btnRotarIzquierda;
        private System.Windows.Forms.Button btnRotarDerecha;
        private System.Windows.Forms.GroupBox grbTraslacion;
        private System.Windows.Forms.Button btnEscalar;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.GroupBox grbSalida;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label label1;
    }
}