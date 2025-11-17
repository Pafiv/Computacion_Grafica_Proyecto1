using System;

namespace Proyecto1
{
    // O puedes usar el namespace WinAppRectangle si es donde está la clase original
    public class Punto
    {
        public double x;
        public double y;

        // Constructor por defecto
        public Punto()
        {
            this.x = 0.0;
            this.y = 0.0;
        }

        // Constructor para inicializar valores
        public Punto(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}