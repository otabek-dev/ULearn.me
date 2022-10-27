using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics graphics;

        public static void GetInitialization(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, Graphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Drawer.GetInitialization(graphics);

            var sizeMin = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (sizeMin * 0.375f + sizeMin * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            //Рисуем 1-ую сторону
            DrowingScale(sizeMin, 0);

            //Рисуем 2-ую сторону
            DrowingScale(sizeMin, -Math.PI / 2);

            //Рисуем 3-ю сторону
            DrowingScale(sizeMin, Math.PI);

            //Рисуем 4-ую сторону
            DrowingScale(sizeMin, Math.PI / 2);
        }

        private static void DrowingScale(int sizeMin, double angle)
        {
            var scale = 0.375f;
            var minScale = 0.04f;

            Drawer.MakeIt(Pens.Yellow, sizeMin * scale, angle);
            Drawer.MakeIt(Pens.Yellow, sizeMin * minScale * Math.Sqrt(2), angle + Math.PI / 4);
            Drawer.MakeIt(Pens.Yellow, sizeMin * scale, angle + Math.PI);
            Drawer.MakeIt(Pens.Yellow, sizeMin * scale - sizeMin * minScale, angle + Math.PI / 2);

            Drawer.Change(sizeMin * minScale, angle - Math.PI);
            Drawer.Change(sizeMin * minScale * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}