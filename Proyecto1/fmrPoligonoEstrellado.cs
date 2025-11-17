using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class fmrPoligonoEstrellado : Form
    {
        private bool scaleModeActive = false;

        private CPoligonoEs objPoligono = new CPoligonoEs();
        private CTransformacion obTransformation = new CTransformacion();

        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;

        public fmrPoligonoEstrellado()
        {
            InitializeComponent();
            this.picCanvas.MouseWheel += picCanvas_MouseWheel;
            this.KeyPreview = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!objPoligono.ReadData(txtSide))
                return;

            obTransformation.Reset();
            obTransformation.Pivot = new PointF(picCanvas.Width / 2f, picCanvas.Height / 2f);

            currentMode = TransformMode.None;
            scaleModeActive = false;

            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;

            RedrawFigure();
        }

        private void RedrawFigure()
        {
            objPoligono.DibujarPoligono(picCanvas, obTransformation);
        }

        // ---------------------- TRASLADAR ----------------------
        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            currentMode = TransformMode.Translate;
            picCanvas.Focus();

            MessageBox.Show("Usa las flechas del teclado para mover la figura.",
                "Modo Traslación Activo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fmrPoligonoEstrellado_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentMode != TransformMode.Translate)
                return;

            bool redraw = true;

            switch (e.KeyCode)
            {
                case Keys.Left: obTransformation.Translate(-5, 0); break;
                case Keys.Right: obTransformation.Translate(5, 0); break;
                case Keys.Up: obTransformation.Translate(0, -5); break;
                case Keys.Down: obTransformation.Translate(0, 5); break;
                default: redraw = false; break;
            }

            if (redraw)
                RedrawFigure();
        }

        // ------------------------ ROTAR ------------------------
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

        // ------------------------ ESCALAR ------------------------
        private void btnEscalar_Click(object sender, EventArgs e)
        {
            scaleModeActive = true;
            picCanvas.Focus();

            MessageBox.Show("Usa el scroll del mouse o el pad para escalar.",
                "Modo Escala Activo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!scaleModeActive)
                return;

            if (e.Delta > 0)
                obTransformation.AdjustScale(1.1f);
            else
                obTransformation.AdjustScale(1 / 1.1f);

            int newValue = (int)(obTransformation.Scale * 100);
            newValue = Math.Max(hScrollEscala.Minimum, Math.Min(hScrollEscala.Maximum, newValue));

            obTransformation.SetScale(newValue / 100f);
            hScrollEscala.Value = newValue;

            RedrawFigure();
        }

        private void hScrollEscala_Scroll(object sender, EventArgs e)
        {
            if (!scaleModeActive)
                return;

            float newScale = hScrollEscala.Value / 100f;
            obTransformation.SetScale(newScale);
            RedrawFigure();
        }

        // ------------------------ RESET ------------------------
        private void btnResetear_Click(object sender, EventArgs e)
        {
            scaleModeActive = false;
            currentMode = TransformMode.None;

            txtSide.Text = string.Empty;

            obTransformation.Reset();
            hScrollEscala.Value = 100;

            this.picCanvas.Image?.Dispose();
            var bmp = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (var g = Graphics.FromImage(bmp)) g.Clear(Color.White);
            picCanvas.Image = bmp;

            objPoligono.InitializeData(txtSide, picCanvas);
        }

        // ------------------------ SALIR ------------------------
        private void btnSalir_Click(object sender, EventArgs e)
        {
            objPoligono.CloseForm(this);
        }

        private void fmrPoligonoEstrellado_Load(object sender, EventArgs e)
        {
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;
        }

      
    }
}
