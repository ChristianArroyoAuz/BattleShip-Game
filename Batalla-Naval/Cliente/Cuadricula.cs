using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System;


namespace Cliente
{
    class Cuadricula
    {
        public System.Drawing.SolidBrush color_blanco = new System.Drawing.SolidBrush(SystemColors.Control);
        public System.Drawing.SolidBrush color_verde = new System.Drawing.SolidBrush(Color.Green);
        public System.Drawing.SolidBrush color_rojo = new System.Drawing.SolidBrush(Color.Red);
        public Pen lineas_verdes = new Pen(Color.Green);
        public Pen lineas_negras = new Pen(Color.Black);
        public Pen lineas_rojas = new Pen(Color.Red);
        private Graphics graficos;
        private int ancho;
        private int alto;

        public void Llenar_Rectangulo(Brush color, Cuadrado colocuadro_actual, int posicion_Y, int posicion_X)
        {
            graficos.FillRectangle(color, (colocuadro_actual.minimo.X + (ancho * posicion_X) + 1), (colocuadro_actual.minimo.Y + (alto * posicion_Y) + 1), ancho - 1, alto - 1);
        }
        public void Llenar_Elipse(Brush color, Cuadrado cuadro_actual, int posicion_Y, int posicion_X)
        {
            graficos.FillEllipse(color, (cuadro_actual.minimo.X + (ancho * posicion_X) + 1), (cuadro_actual.minimo.Y + (alto * posicion_Y) + 1), ancho - 2, alto - 2);
        }
        public void Elipse(Pen color, Cuadrado cuadro_actual, int posicion_Y, int posicion_X)
        {
            graficos.DrawEllipse(color, (cuadro_actual.minimo.X + (ancho * posicion_X) + 1), (cuadro_actual.minimo.Y + (alto * posicion_Y) + 1), ancho - 2, alto - 2);
        }
        public void Lineas_Horizontales(Pen color, Point tamaño, int ancho)
        {
            graficos.DrawLine(color, new Point(0, ancho * (tamaño.Y / 10)), new Point(tamaño.X, ancho * (tamaño.Y / 10)));
        }
        public void Lineas_Verticales(Pen color, Point tamaño, int alto)
        {
            graficos.DrawLine(color, new Point(alto * (tamaño.X / 10), 0), new Point(alto * (tamaño.X / 10), tamaño.Y));
        }
        public Cuadricula(Panel panel, int ini_ancho, int ini_alto)
        {
            graficos = panel.CreateGraphics();
            ancho = ini_ancho;
            alto = ini_alto;
        }
    }
    class Cuadrado
    {
        private int codigo_barco;
        public Point minimo;
        public Point maximo;
        public bool disparo;
        public int tamaño;
        public bool poner;
        public Ship barco;
        public bool ok;

        public Cuadrado(Point ini_minimo, Point ini_maximo)
        {
            minimo = ini_minimo;
            maximo = ini_maximo;
            ok = false;
            poner = false;
            disparo = false;
            barco = new Ship();
            tamaño = -1;
        }
        public void poner_codigo_barco(int codigo)
        {
            codigo_barco = codigo;
        }
        public int obtener_codigo_barco()
        {
            return codigo_barco;
        }
    }
    class Ship
    {
        public bool izquierda;
        public bool derecha;
        public bool arriba;
        public bool abajo;

        public Ship()
        {
            izquierda = false;
            derecha = false;
            arriba = false;
            abajo = false;
        }
    }
}