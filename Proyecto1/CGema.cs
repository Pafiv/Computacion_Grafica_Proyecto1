using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1;

namespace Proyecto1
{
    public class CGema
    {
        Punto[][] snowPoints = new Punto[9][];
        float radio;
        private Graphics mGraphic;
        private Pen mPen;
        private const float SF = 1; // Factor de escalamiento

        public CGema()
        {
            radio = 0.0f;
            snowPoints[0] = new Punto[10];
            snowPoints[1] = new Punto[10];
            snowPoints[2] = new Punto[1];
            snowPoints[3] = new Punto[10];
            snowPoints[4] = new Punto[10];
            snowPoints[5] = new Punto[10];
            snowPoints[6] = new Punto[4];
            snowPoints[7] = new Punto[4];
            snowPoints[8] = new Punto[4];
        }

        public bool ReadData(TextBox txtRadio)
        {
            bool respuesta = true;
            try
            {
                radio = float.Parse(txtRadio.Text);
                if (radio <= 0.0f)
                {
                    throw new Exception();
                }

                for (int i = 0; i < snowPoints[0].Length; i++)
                {
                    snowPoints[0][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[1].Length; i++)
                {
                    snowPoints[1][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[2].Length; i++)
                {
                    snowPoints[2][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[3].Length; i++)
                {
                    snowPoints[3][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[4].Length; i++)
                {
                    snowPoints[4][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[5].Length; i++)
                {
                    snowPoints[5][i] = new Punto();
                }
                for (int i = 0; i < snowPoints[6].Length; i++)
                {
                    snowPoints[6][i] = new Punto();
                    snowPoints[7][i] = new Punto();
                    snowPoints[8][i] = new Punto();
                }
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
            mGraphic.DrawLine(mPen, (float)(snowPoints[a1][a2].x), (float)(snowPoints[a1][a2].y), (float)(snowPoints[b1][b2].x), (float)(snowPoints[b1][b2].y));
        }

        public void PlotShape(PictureBox picCanvas, Punto center, float tethaAdd = 0.0f, CTransformacion transform = null)
        {
            if (radio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el radio.");
                return;
            }

            // Asegurar que haya un Bitmap persistente en el PictureBox
            if (picCanvas.Image == null || picCanvas.Image.Width != picCanvas.Width || picCanvas.Image.Height != picCanvas.Height)
            {
                picCanvas.Image?.Dispose();
                picCanvas.Image = new Bitmap(Math.Max(1, picCanvas.Width), Math.Max(1, picCanvas.Height));
            }

            using (Graphics g = Graphics.FromImage(picCanvas.Image))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Guardar estado antes de aplicar transformaciones
                GraphicsState state = g.Save();
                g.TranslateTransform(picCanvas.Width / 2f, picCanvas.Height / 2f);


                if (transform != null)
                {
                    transform.ApplyTransforms(g);
                }

                mGraphic = g;
                mPen = new Pen(Color.Black, 1);

                float tetha = 0.0f;
                snowPoints[2][0].x = center.x;
                snowPoints[2][0].y = center.y;

                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        tetha = (float)((i * 0.628318) + tethaAdd + (1.25664 * j) + 0.261799);
                        snowPoints[0][i].x = (center.x + radio * Math.Cos(tetha));
                        snowPoints[0][i].y = (center.y + radio * Math.Sin(tetha));
                        snowPoints[1][i].x = (center.x + (radio * 0.95) * Math.Cos(tetha));
                        snowPoints[1][i].y = (center.y + (radio * 0.95) * Math.Sin(tetha));
                        snowPoints[6][i].x = (center.x + (radio * 0.3) * Math.Cos(tetha));
                        snowPoints[6][i].y = (center.y + (radio * 0.3) * Math.Sin(tetha));
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        DrawLine(0, i, 0, i + 1);
                        DrawLine(1, i, 1, i + 1);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        tetha = (float)((i * 0.15708) + tethaAdd + (1.25664 * j) + 0.261799);
                        snowPoints[4][i].x = (center.x + (radio * 0.1) * Math.Cos(tetha));
                        snowPoints[4][i].y = (center.y + (radio * 0.1) * Math.Sin(tetha));

                        if (i == 3 || i == 5)
                        {
                            snowPoints[3][i].x = (center.x + (radio * 0.77) * Math.Cos(tetha));
                            snowPoints[3][i].y = (center.y + (radio * 0.77) * Math.Sin(tetha));
                            snowPoints[5][i].x = (center.x + (radio * 0.68) * Math.Cos(tetha));
                            snowPoints[5][i].y = (center.y + (radio * 0.68) * Math.Sin(tetha));
                        }
                        else if (i == 4)
                        {
                            snowPoints[3][i].x = (center.x + (radio * 0.6) * Math.Cos(tetha));
                            snowPoints[3][i].y = (center.y + (radio * 0.6) * Math.Sin(tetha));
                        }
                        else
                        {
                            snowPoints[3][i].x = (center.x + (radio * 0.80) * Math.Cos(tetha));
                            snowPoints[3][i].y = (center.y + (radio * 0.80) * Math.Sin(tetha));
                        }

                        if (i == 2 || i == 6)
                        {
                            snowPoints[7][i / 2].x = (center.x + (radio * 0.45) * Math.Cos(tetha));
                            snowPoints[7][i / 2].y = (center.y + (radio * 0.45) * Math.Sin(tetha));
                            snowPoints[8][i / 2].x = (center.x + (radio * 0.67) * Math.Cos(tetha));
                            snowPoints[8][i / 2].y = (center.y + (radio * 0.67) * Math.Sin(tetha));
                        }
                    }

                    // Figura Externa
                    DrawLine(0, 2, 1, 2);
                    DrawLine(4, 2, 3, 2);
                    DrawLine(4, 6, 3, 6);
                    DrawLine(1, 1, 3, 2);
                    DrawLine(1, 1, 3, 6);
                    DrawLine(1, 1, 0, 1);

                    // Union
                    DrawLine(1, 0, 3, 3);
                    DrawLine(1, 2, 3, 5);

                    // Parte superior de Rombo
                    DrawLine(3, 3, 1, 1);
                    DrawLine(3, 5, 1, 1);

                    // Parte inferior del Rombo
                    DrawLine(3, 3, 3, 4);
                    DrawLine(3, 4, 3, 5);
                    DrawLine(3, 4, 3, 2);
                    DrawLine(3, 4, 3, 6);
                    DrawLine(4, 4, 3, 4);
                    DrawLine(5, 3, 4, 3);
                    DrawLine(5, 5, 4, 5);

                    // Curva Interna
                    PointF[] curvePoints = new PointF[9];
                    for (int i = 0; i < 9; i++)
                    {
                        curvePoints[i] = new PointF((float)snowPoints[4][i].x, (float)snowPoints[4][i].y);
                    }
                    mGraphic.DrawCurve(mPen, curvePoints);

                    // Union Laterales
                    DrawLine(6, 0, 4, 0);
                    DrawLine(6, 2, 4, 8);
                    DrawLine(7, 1, 6, 0);
                    DrawLine(7, 3, 6, 2);
                    DrawLine(8, 1, 1, 0);
                    DrawLine(8, 3, 1, 2);
                    DrawLine(7, 1, 1, 0);
                    DrawLine(7, 3, 1, 2);
                }

                // Restaurar estado
                g.Restore(state);
            }

            // Forzar repintado del PictureBox (muestra el Bitmap persistente)
            picCanvas.Refresh();
        }

        public void DibujarGema(PictureBox picCanvas, CTransformacion transform = null)
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