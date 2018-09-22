//using System;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StarWars

{
    public static class Game
    {
        private static BufferedGraphicsContext __Context;
        public static BufferedGraphics Buffer { get; private set; }

        private static Timer __Timer = new Timer { Interval = 70 };

        private static GameObject[] __GameObjects;

        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static void Init(Form form)
        {
            var graphics = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Buffer = __Context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            __Timer.Tick += GetTimerTick;
            __Timer.Enabled = true;
        }


        private static void GetTimerTick(object Sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            __GameObjects = new GameObject[40];

            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new Star(new Point(600, 15 + i * 27), new Point(5 + i, 25 - i), new Size(5, 5));

            }
            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length / 2+1; i++)
            {
                __GameObjects[i] = new StarBase(new Point(300, 200), new Point(1, 1), new Size(200, 200));

            }
            for (int i = __GameObjects.Length / 2 +1 ; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new GameObject(new Point(600, 50 - i), new Point(15 - i, 25 - i), new Size(20, 20));
            }
        }

        public static void Draw()
        {
            var g = Buffer.Graphics;
            g.Clear(Color.Black);
            // g.DrawRectangle(Pens.White, 100, 100, 200, 200);
            // g.FillEllipse(Brushes.Red, 100, 100, 200, 200);

            foreach (var game_object in __GameObjects)
            {
                game_object.Draw();
            }
            //После закрытия игрового окна тут возникает исключение ArgumentException
            Buffer.Render();
        }

        private static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
            }
        }
    }
}
