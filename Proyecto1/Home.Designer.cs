namespace Proyecto1
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.figurasSencillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.complejasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figura6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figurasSencillasToolStripMenuItem,
            this.complejasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1069, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // figurasSencillasToolStripMenuItem
            // 
            this.figurasSencillasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figura1ToolStripMenuItem,
            this.figura2ToolStripMenuItem,
            this.figuToolStripMenuItem});
            this.figurasSencillasToolStripMenuItem.Name = "figurasSencillasToolStripMenuItem";
            this.figurasSencillasToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.figurasSencillasToolStripMenuItem.Text = "Figuras";
            // 
            // figura1ToolStripMenuItem
            // 
            this.figura1ToolStripMenuItem.Name = "figura1ToolStripMenuItem";
            this.figura1ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.figura1ToolStripMenuItem.Text = "Figura 1";
            this.figura1ToolStripMenuItem.Click += new System.EventHandler(this.figura1ToolStripMenuItem_Click);
            // 
            // figura2ToolStripMenuItem
            // 
            this.figura2ToolStripMenuItem.Name = "figura2ToolStripMenuItem";
            this.figura2ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.figura2ToolStripMenuItem.Text = "Figura 2";
            this.figura2ToolStripMenuItem.Click += new System.EventHandler(this.figura2ToolStripMenuItem_Click);
            // 
            // figuToolStripMenuItem
            // 
            this.figuToolStripMenuItem.Name = "figuToolStripMenuItem";
            this.figuToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.figuToolStripMenuItem.Text = "Figura 3";
            this.figuToolStripMenuItem.Click += new System.EventHandler(this.figuToolStripMenuItem_Click);
            // 
            // complejasToolStripMenuItem
            // 
            this.complejasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figura4ToolStripMenuItem,
            this.figura5ToolStripMenuItem,
            this.figura6ToolStripMenuItem});
            this.complejasToolStripMenuItem.Name = "complejasToolStripMenuItem";
            this.complejasToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.complejasToolStripMenuItem.Text = "Complejas";
            // 
            // figura4ToolStripMenuItem
            // 
            this.figura4ToolStripMenuItem.Name = "figura4ToolStripMenuItem";
            this.figura4ToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.figura4ToolStripMenuItem.Text = "Figura 4";
            this.figura4ToolStripMenuItem.Click += new System.EventHandler(this.figura4ToolStripMenuItem_Click);
            // 
            // figura5ToolStripMenuItem
            // 
            this.figura5ToolStripMenuItem.Name = "figura5ToolStripMenuItem";
            this.figura5ToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.figura5ToolStripMenuItem.Text = "Figura 5";
            this.figura5ToolStripMenuItem.Click += new System.EventHandler(this.figura5ToolStripMenuItem_Click);
            // 
            // figura6ToolStripMenuItem
            // 
            this.figura6ToolStripMenuItem.Name = "figura6ToolStripMenuItem";
            this.figura6ToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.figura6ToolStripMenuItem.Text = "Figura 6";
            this.figura6ToolStripMenuItem.Click += new System.EventHandler(this.figura6ToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "x";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem figurasSencillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem complejasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figura6ToolStripMenuItem;
    }
}

