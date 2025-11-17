using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class frmGema : Form
    {
        private bool scaleModeActive = false;

        private CGema objGema = new CGema();
        private CTransformacion obTransformation = new CTransformacion();

        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;

        public frmGema()
        {
            InitializeComponent();
            this.picCanvas.MouseWheel += new MouseEventHandler(this.picCanvas_MouseWheel);
            this.KeyPreview = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!objGema.ReadData(txtSide))
                return;

            // (1) Resetear el estado de transformación
            obTransformation.Reset();

            // (2) Establecer el pivote en el centro del PictureBox
            obTransformation.Pivot = new PointF(0, 0);


            currentMode = TransformMode.None;
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;

            RedrawFigure();
        }

        private void RedrawFigure()
        {
            objGema.DibujarGema(picCanvas, obTransformation);
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            picCanvas.Focus();

            this.KeyDown += (s, ev) =>
            {
                const float paso = 10f;

                switch (ev.KeyCode)
                {
                    case Keys.Left:
                        obTransformation.Translate(-paso, 0);
                        objGema.DibujarGema(picCanvas, obTransformation);
                        break;

                    case Keys.Right:
                        obTransformation.Translate(paso, 0);
                        objGema.DibujarGema(picCanvas, obTransformation);
                        break;

                    case Keys.Up:
                        obTransformation.Translate(0, -paso);
                        objGema.DibujarGema(picCanvas, obTransformation);
                        break;

                    case Keys.Down:
                        obTransformation.Translate(0, paso);
                        objGema.DibujarGema(picCanvas, obTransformation);
                        break;
                }
            };

            MessageBox.Show("Usa las flechas del teclado para mover la figura.",
                "Modo Traslación Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRotarIzquierda_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(-5);
            RedrawFigure();
        }

        private void btnRotarDerecha_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(5);
            RedrawFigure();
        }

        private void picCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!scaleModeActive)
                return;   // ❌ No permitir escalar si no activó el botón Escalar

            if (e.Delta > 0)
                obTransformation.AdjustScale(1.1f);
            else if (e.Delta < 0)
                obTransformation.AdjustScale(1 / 1.1f);

            int newScrollValue = (int)(obTransformation.Scale * 100);
            if (newScrollValue < hScrollEscala.Minimum) newScrollValue = hScrollEscala.Minimum;
            if (newScrollValue > hScrollEscala.Maximum) newScrollValue = hScrollEscala.Maximum;

            obTransformation.SetScale(newScrollValue / 100.0f);
            hScrollEscala.Value = newScrollValue;

            RedrawFigure();
        }


        private void hScrollEscala_Scroll(object sender, EventArgs e)
        {
            float newScale = hScrollEscala.Value / 100.0f;
            obTransformation.SetScale(newScale);
            RedrawFigure();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            scaleModeActive = false;   // ❌ Desactivar modo escala

            obTransformation.Reset();
            currentMode = TransformMode.None;
            hScrollEscala.Value = 100;

            if (this.picCanvas != null)
            {
                this.picCanvas.Image?.Dispose();
                var bmp = new Bitmap(Math.Max(1, this.picCanvas.Width), Math.Max(1, this.picCanvas.Height));
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                this.picCanvas.Image = bmp;
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            objGema.CloseForm(this);
        }

        private void frmGema_Load(object sender, EventArgs e)
        {
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;
        }

        private void btnEscalar_Click(object sender, EventArgs e)
        {
            scaleModeActive = true;   // ✔ Activamos el modo escala
            picCanvas.Focus();

            MessageBox.Show("Usa el scroll del mouse o el pad",
                "Modo Escala Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
