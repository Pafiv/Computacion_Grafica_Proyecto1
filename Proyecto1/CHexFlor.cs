using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    internal class CHexFlor
    {
        Punto[][] pentaPoints = new Punto[4][];
        private float radio;
        private Graphics mGraphic;
        private Pen mPen;
        private const float SF = 1; // Factor de escalamiento

        public CHexFlor()
        {
            radio = 0.0f;
            pentaPoints[0] = new Punto[6];
            pentaPoints[1] = new Punto[6];
            pentaPoints[2] = new Punto[1];
            pentaPoints[3] = new Punto[6];
        }

        public bool ReadData(TextBox txtRadio)
        {
            bool respuesta = true;
            try
            {
                radio = float.Parse(txtRadio.Text);
                if (radio <= 0.0f)
                    throw new Exception();

                for (int i = 0; i < 6; i++)
                {
                    pentaPoints[0][i] = new Punto();
                    pentaPoints[1][i] = new Punto();
                    pentaPoints[3][i] = new Punto();
                }
                pentaPoints[2][0] = new Punto();
            }
            catch
            {
                respuesta = false;
                MessageBox.Show("Ingrese Datos válidos...!", "ERROR!");
            }

            return respuesta;
        }

        public void InitializeData(TextBox txtRadio, PictureBox picCanvas)
        {
            radio = 0.0f;
            txtRadio.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        private void DrawLine(int a1, int a2, int b1, int b2)
        {
            mGraphic.DrawLine(mPen,
                (float)(pentaPoints[a1][a2].x),
                (float)(pentaPoints[a1][a2].y),
                (float)(pentaPoints[b1][b2].x),
                (float)(pentaPoints[b1][b2].y));
        }

        public void PlotShape(PictureBox picCanvas, Punto center, float tethaAdd = 0.0f, CTransformacion transform = null)
        {
            if (radio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el radio.");
                return;
            }

            // 🔹 Crear o ajustar el lienzo
            if (picCanvas.Image == null || picCanvas.Image.Width != picCanvas.Width || picCanvas.Image.Height != picCanvas.Height)
            {
                picCanvas.Image?.Dispose();
                picCanvas.Image = new Bitmap(Math.Max(1, picCanvas.Width), Math.Max(1, picCanvas.Height));
            }

            using (Graphics g = Graphics.FromImage(picCanvas.Image))
            {
                g.Clear(Color.Black);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // 🔸 Guardar estado gráfico inicial
                GraphicsState state = g.Save();

                // 🔹 Centrar el origen al medio del PictureBox
                float offsetX = picCanvas.Width / 2f;
                float offsetY = picCanvas.Height / 2f;
                g.TranslateTransform(offsetX, offsetY);

                // 🔹 Aplicar transformaciones (rotación, escala, traslación)
                transform?.ApplyTransforms(g);

                // 🔹 Ahora el centro (0,0) está en medio del lienzo
                center.x = 0;
                center.y = 0;

                // 🔹 Lapicero dorado
                mPen = new Pen(Color.Gold, 1.8f);
                mGraphic = g;

                float tetha = 0.0f;
                pentaPoints[2][0].x = 0;
                pentaPoints[2][0].y = 0;

                // 🔸 Hexágono exterior
                for (int i = 0; i < 6; i++)
                {
                    tetha = (float)((i * 1.0472) + tethaAdd - 0.523599);
                    pentaPoints[0][i].x = center.x + (radio * Math.Cos(tetha));
                    pentaPoints[0][i].y = center.y + (radio * Math.Sin(tetha));
                }

                // 🔸 Líneas desde el centro
                for (int i = 0; i < 6; i++)
                    DrawLine(2, 0, 0, i);

                // 🔸 Pétalos de la flor hexagonal
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            tetha = (float)((i * 1.0472) + tethaAdd - 1.5708 + (1.0472 * j));
                            pentaPoints[1][i].x = (pentaPoints[0][j].x + (radio * 0.2 * (k + 1)) * Math.Cos(tetha));
                            pentaPoints[1][i].y = (pentaPoints[0][j].y + (radio * 0.2 * (k + 1)) * Math.Sin(tetha));
                        }

                        // Conectar pétalos
                        for (int i = 0; i < 4; i++)
                            DrawLine(1, i, 1, i + 1);
                    }
                }

                // 🔹 Restaurar estado gráfico
                g.Restore(state);
            }

            picCanvas.Refresh();
        }

        public void DibujarHexFlor(PictureBox picCanvas, CTransformacion transform = null)
        {
            Punto center = new Punto();
            center.x = 0;
            center.y = 0;
            PlotShape(picCanvas, center, 0.0f, transform);
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}
