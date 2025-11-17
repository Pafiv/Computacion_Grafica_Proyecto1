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
    internal class CPentaFlor
    {
        Punto[][] pentaPoints = new Punto[4][];
        private float radio;
        private Graphics mGraphic;
        private Pen mPen;
        private const float SF = 1;

        public CPentaFlor()
        {
            radio = 0.0f;
            pentaPoints[0] = new Punto[5];
            pentaPoints[1] = new Punto[5];
            pentaPoints[2] = new Punto[5];
            pentaPoints[3] = new Punto[10];
        }

        public bool ReadData(TextBox txtRadio)
        {
            bool respuesta = true;
            try
            {
                radio = float.Parse(txtRadio.Text);
                if (radio <= 0.0f)
                    throw new Exception();

                for (int i = 0; i < 5; i++)
                {
                    pentaPoints[0][i] = new Punto();
                    pentaPoints[1][i] = new Punto();
                    pentaPoints[2][i] = new Punto();
                }
                for (int i = 0; i < 10; i++)
                    pentaPoints[3][i] = new Punto();
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
                (float)pentaPoints[a1][a2].x,
                (float)pentaPoints[a1][a2].y,
                (float)pentaPoints[b1][b2].x,
                (float)pentaPoints[b1][b2].y);
        }

        public void PlotShape(PictureBox picCanvas, Punto center, float tethaAdd = 0.0f, CTransformacion transform = null)
        {
            if (radio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el radio.");
                return;
            }

            if (picCanvas.Image == null || picCanvas.Image.Width != picCanvas.Width || picCanvas.Image.Height != picCanvas.Height)
            {
                picCanvas.Image?.Dispose();
                picCanvas.Image = new Bitmap(Math.Max(1, picCanvas.Width), Math.Max(1, picCanvas.Height));
            }

            using (Graphics g = Graphics.FromImage(picCanvas.Image))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                GraphicsState state = g.Save();

                // 🔥🔥🔥 AJUSTE ÚNICO QUE SOLUCIONA LA ROTACIÓN
                g.TranslateTransform((float)center.x, (float)center.y);
                g.RotateTransform((float)(tethaAdd * (180.0 / Math.PI)));
                g.TranslateTransform((float)-center.x, (float)-center.y);


                if (transform != null)
                    transform.ApplyTransforms(g);

                mGraphic = g;
                mPen = new Pen(Color.Black, 1);

                float tetha = 0.0f;

              

                // Pentágono interior
                for (int i = 0; i < 5; i++)
                {
                    tetha = (float)((i * 1.25664) + tethaAdd - 0.314159);
                    pentaPoints[0][i].x = radio * Math.Cos(tetha);
                    pentaPoints[0][i].y = radio * Math.Sin(tetha);
                }

                DrawLine(0, 0, 0, 2);
                DrawLine(0, 2, 0, 4);
                DrawLine(0, 4, 0, 1);
                DrawLine(0, 1, 0, 3);
                DrawLine(0, 3, 0, 0);

                // Pentágono medio 1
                for (int i = 0; i < 5; i++)
                {
                    tetha = (float)((i * 1.25664) + tethaAdd + 0.314159);
                    pentaPoints[1][i].x = (radio * 1.40) * Math.Cos(tetha);
                    pentaPoints[1][i].y = (radio * 1.40) * Math.Sin(tetha);
                }

                DrawLine(0, 0, 1, 0);
                DrawLine(0, 1, 1, 0);
                DrawLine(0, 1, 1, 1);
                DrawLine(0, 2, 1, 1);
                DrawLine(0, 2, 1, 2);
                DrawLine(0, 3, 1, 2);
                DrawLine(0, 3, 1, 3);
                DrawLine(0, 4, 1, 3);
                DrawLine(0, 4, 1, 4);
                DrawLine(0, 0, 1, 4);

                // Pentágono medio 2
                for (int i = 0; i < 5; i++)
                {
                    tetha = (float)((i * 1.25664) + tethaAdd + 0.314159);
                    pentaPoints[2][i].x = (radio * 2) * Math.Cos(tetha);
                    pentaPoints[2][i].y = (radio * 2) * Math.Sin(tetha);
                }

                DrawLine(0, 0, 2, 0);
                DrawLine(0, 1, 2, 0);
                DrawLine(0, 1, 2, 1);
                DrawLine(0, 2, 2, 1);
                DrawLine(0, 2, 2, 2);
                DrawLine(0, 3, 2, 2);
                DrawLine(0, 3, 2, 3);
                DrawLine(0, 4, 2, 3);
                DrawLine(0, 4, 2, 4);
                DrawLine(0, 0, 2, 4);

                // Pentágono exterior
                for (int i = 0; i < 5; i++)
                {
                    tetha = (float)((i * 1.25664) + tethaAdd - 0.314159);
                    pentaPoints[0][i].x = (radio * 2.5) * Math.Cos(tetha);
                    pentaPoints[0][i].y = (radio * 2.5) * Math.Sin(tetha);
                }

                DrawLine(0, 0, 0, 1);
                DrawLine(0, 1, 0, 2);
                DrawLine(0, 2, 0, 3);
                DrawLine(0, 3, 0, 4);
                DrawLine(0, 4, 0, 0);

                DrawLine(0, 0, 2, 1);
                DrawLine(0, 0, 2, 3);
                DrawLine(0, 1, 2, 4);
                DrawLine(0, 1, 2, 2);
                DrawLine(0, 2, 2, 0);
                DrawLine(0, 2, 2, 3);
                DrawLine(0, 3, 2, 1);
                DrawLine(0, 3, 2, 4);
                DrawLine(0, 4, 2, 2);
                DrawLine(0, 4, 2, 0);

                // Puntas exteriores
                int tethaIndex = 0;

                for (int i = 0; i < 10; i += 4)
                {
                    tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 - 0.174533);
                    pentaPoints[3][i].x = (radio * 3.25) * Math.Cos(tetha);
                    pentaPoints[3][i].y = (radio * 3.25) * Math.Sin(tetha);

                    tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 + 0.174533);
                    pentaPoints[3][i + 1].x = (radio * 3.25) * Math.Cos(tetha);
                    pentaPoints[3][i + 1].y = (radio * 3.25) * Math.Sin(tetha);

                    tethaIndex++;

                    if (i < 8)
                    {
                        tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 - 0.174533);
                        pentaPoints[3][i + 2].x = (radio * 3.25) * Math.Cos(tetha);
                        pentaPoints[3][i + 2].y = (radio * 3.25) * Math.Sin(tetha);

                        tetha = (float)((tethaIndex * 1.25664) + tethaAdd - 0.314159 + 0.174533);
                        pentaPoints[3][i + 3].x = (radio * 3.25) * Math.Cos(tetha);
                        pentaPoints[3][i + 3].y = (radio * 3.25) * Math.Sin(tetha);

                        tethaIndex++;
                    }
                }

                DrawLine(3, 0, 3, 2);
                DrawLine(3, 0, 3, 8);
                DrawLine(3, 0, 0, 4);

                DrawLine(3, 1, 3, 3);
                DrawLine(3, 1, 3, 9);
                DrawLine(3, 1, 0, 1);

                DrawLine(3, 2, 3, 4);
                DrawLine(3, 2, 0, 0);

                DrawLine(3, 3, 3, 5);
                DrawLine(3, 3, 0, 2);

                DrawLine(3, 4, 3, 6);
                DrawLine(3, 4, 0, 1);

                DrawLine(3, 5, 3, 7);
                DrawLine(3, 5, 0, 3);

                DrawLine(3, 6, 3, 8);
                DrawLine(3, 6, 0, 2);

                DrawLine(3, 7, 3, 9);
                DrawLine(3, 7, 0, 4);

                DrawLine(3, 8, 0, 3);

                DrawLine(3, 9, 0, 0);

                g.Restore(state);
            }

            picCanvas.Refresh();
        }

        public void DibujarPentaEstrella(PictureBox picCanvas, CTransformacion transform = null)
        {
            Punto center = new Punto();
            center.x = picCanvas.Width / 2.0f;
            center.y = picCanvas.Height / 2.0f;
            PlotShape(picCanvas, center, 0.0f, transform);
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}
