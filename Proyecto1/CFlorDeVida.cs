using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Proyecto1
{
    internal class CFlorDeVida
    {
        private float mRadio; // Radio de los círculos
        private Pen mPen;
        private const float SF = 1f; // Escalamiento

        public CFlorDeVida()
        {
            mRadio = 0.0f;
        }

        public bool ReadData(TextBox txtRadio)
        {
            bool respuesta = true;
            try
            {
                mRadio = float.Parse(txtRadio.Text);
                if (mRadio <= 0.0f)
                    throw new Exception();
            }
            catch
            {
                respuesta = false;
                MessageBox.Show("Ingrese un valor válido para el radio.", "ERROR");
            }
            return respuesta;
        }

        public void InitializeData(TextBox txtRadio, PictureBox picCanvas)
        {
            mRadio = 0.0f;
            txtRadio.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public void DibujarFlorDeVida(PictureBox picCanvas, CTransformacion transform)
        {
            if (mRadio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un radio válido.", "ERROR");
                return;
            }

            // Crear o actualizar el lienzo
            if (picCanvas.Image == null || picCanvas.Image.Width != picCanvas.Width || picCanvas.Image.Height != picCanvas.Height)
            {
                picCanvas.Image?.Dispose();
                picCanvas.Image = new Bitmap(Math.Max(1, picCanvas.Width), Math.Max(1, picCanvas.Height));
            }

            using (Graphics g = Graphics.FromImage(picCanvas.Image))
            {
                g.Clear(Color.Black);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsState state = g.Save();

                // 🔸 1. Trasladar el origen al centro del PictureBox
                float offsetX = picCanvas.Width / 2f;
                float offsetY = picCanvas.Height / 2f;
                g.TranslateTransform(offsetX, offsetY);

                // 🔸 2. Aplicar transformaciones (rotación, escala, traslación)
                // Estas se aplicarán alrededor del nuevo origen (el centro del lienzo)
                transform?.ApplyTransforms(g);

                // 🔸 3. Dibujar la Flor de la Vida centrada en (0,0)
                mPen = new Pen(Color.White, 1.5f);

                DibujarCapa(g, 0, 0, mRadio, 0);
                DibujarCapa(g, 0, 0, mRadio, 1);
                DibujarCapa(g, 0, 0, mRadio, 2);

                // 🔸 4. Círculo envolvente centrado
                float radioEnvolvente = 3 * mRadio;
                using (Pen penPunteado = new Pen(Color.White, 1.3f))
                {
                    penPunteado.DashStyle = DashStyle.Dash;
                    g.DrawEllipse(penPunteado, -radioEnvolvente, -radioEnvolvente, 2 * radioEnvolvente, 2 * radioEnvolvente);
                }

                // 🔸 5. Restaurar el estado gráfico
                g.Restore(state);
            }

            picCanvas.Refresh();
        }


        private void DibujarCapa(Graphics g, float cx, float cy, float radio, int nivel)
        {
            if (nivel == 0)
            {
                g.DrawEllipse(mPen, cx - radio, cy - radio, 2 * radio, 2 * radio);
                return;
            }

            float distancia = radio * nivel;
            int cantidad = (nivel == 1) ? 6 : 12;
            float anguloInicial = (nivel == 1) ? 0 : 15;

            for (int i = 0; i < cantidad; i++)
            {
                float angulo = anguloInicial + (360f / cantidad) * i;
                float x = cx + distancia * (float)Math.Cos(angulo * Math.PI / 180f);
                float y = cy + distancia * (float)Math.Sin(angulo * Math.PI / 180f);
                g.DrawEllipse(mPen, x - radio, y - radio, 2 * radio, 2 * radio);
            }
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}
