using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void OpenChild<T>() where T : Form, new()
        {
            var existing = this.MdiChildren.OfType<T>().FirstOrDefault();
            if (existing != null)
            {
                if (existing.WindowState == FormWindowState.Minimized)
                    existing.WindowState = FormWindowState.Normal;
                existing.BringToFront();
                existing.Activate();
            }
            else
            {
                var child = new T
                {
                    MdiParent = this
                };
                child.Show();
            }
        }

        private void figuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<frmGema>();
        }

        private void figura1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<fmrPoligonoEstrellado>();
        }

        private void figura4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<FrmEstrellaGeometrica>();
        }

        private void figura6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<frmFlorDeVida>();
        }

        private void figura5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<frmHexFlor>();
        }

        private void figura2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild<frmPentaFlor>();
        }
    }
}
