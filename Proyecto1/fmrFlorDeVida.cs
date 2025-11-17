using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class frmFlorDeVida : Form
    {
        private bool scaleModeActive = false;

        private CFlorDeVida objFlor = new CFlorDeVida();
        private CTransformacion obTransformation = new CTransformacion();

        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;

        public frmFlorDeVida()
        {
            InitializeComponent();
            this.picCanvas.MouseWheel += new MouseEventHandler(this.picCanvas_MouseWheel);
            this.KeyPreview = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!objFlor.ReadData(txtSide))
                return;
            // (1) Resetear el estado
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
            // Delegamos el dibujo al objeto y le pasamos la transformación actual
            objFlor.DibujarFlorDeVida(picCanvas, obTransformation);
        }

        private void btnTrasladar_Click_1(object sender, EventArgs e)
        {
            // Activar modo de traslado
            this.KeyPreview = true; // Asegura que el formulario capture las teclas antes que los controles
            picCanvas.Focus();      // Pone el foco en el canvas (necesario para recibir eventos de teclado)

            // Manejador del evento KeyDown
            this.KeyDown += (s, ev) =>
            {
                const float paso = 10f; // cantidad de movimiento en píxeles

                switch (ev.KeyCode)
                {
                    case Keys.Left:
                        obTransformation.Translate(-paso, 0);
                        objFlor.DibujarFlorDeVida(picCanvas, obTransformation);
                        break;

                    case Keys.Right:
                        obTransformation.Translate(paso, 0);
                        objFlor.DibujarFlorDeVida(picCanvas, obTransformation);
                        break;

                    case Keys.Up:
                        obTransformation.Translate(0, -paso);
                        objFlor.DibujarFlorDeVida(picCanvas, obTransformation);
                        break;

                    case Keys.Down:
                        obTransformation.Translate(0, paso);
                        objFlor.DibujarFlorDeVida(picCanvas, obTransformation);
                        break;
                }
            };

            MessageBox.Show("Usa las flechas del teclado para mover la figura.", "Modo Traslación Activo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                return; // ⛔ NO escalar si el modo no está activo

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
            txtSide.Text = string.Empty;
            obTransformation.Reset();
            currentMode = TransformMode.None;

            scaleModeActive = false;  // ⛔ Desactivar modo escala

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
            objFlor.InitializeData(txtSide, picCanvas);
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            objFlor.CloseForm(this);
        }

        private void FrmFlorDeVida_Load(object sender, EventArgs e)
        {
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;
        }

        private void btnEscalar_Click(object sender, EventArgs e)
        {
            scaleModeActive = true;  // ✔ Activar modo escalar
            picCanvas.Focus();

            MessageBox.Show("Usa el scroll del mouse o el pad",
                "Modo Escala Activo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
