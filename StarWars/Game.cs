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
        private static Bullet __Bullet;

        public static int Width { get; set; }
        public static int Height { get; set; }

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
            try
            {

                Update();
                Draw();
                SizeWindowCheck();



            }
            catch (Exception ex)
            {
                __Timer.Tick -= GetTimerTick;
                MessageBox.Show(ex.Message);
                MessageBox.Show("Приложение будет закрыто");
                Application.Exit();


            }

        }

        public static void Load()
        {

            try
            {



                __GameObjects = new GameObject[40];
                //Звездочки
                for (int i = 0; i < __GameObjects.Length / 2; i++)
                {
                    __GameObjects[i] = new Star(new Point(600, 15 + i * 27), new Point(5 + i, 25 - i), new Size(15, 15), false);

                }
                //Звездная база
                for (int i = __GameObjects.Length / 2; i < __GameObjects.Length / 2 + 1; i++)
                {
                    __GameObjects[i] = new StarBase(new Point(300, 200), new Point(1, 1), new Size(200, 200), true);

                }
                //Астероиды
                for (int i = __GameObjects.Length / 2 + 1; i < __GameObjects.Length; i++)
                {
                    __GameObjects[i] = new Asteroid(new Point(600, 50 - i), new Point(15 - i, 25 - i), new Size(30+i, 40+i), true);
                }

                __Bullet = new Bullet(new Point(20, 200), new Point(5,0), new Size(20, 20));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Приложение будет закрыто");
                Application.Exit();
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
            __Bullet.Draw();
            //После закрытия игрового окна тут возникает исключение ArgumentException
            Buffer.Render();
        }

        private static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
                if(__Bullet.Colision(game_object))
                {
                    if (game_object._isEnemy)
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                }
            }
            __Bullet.Update();
            
            
        }

        private static void SizeWindowCheck()
        {

            Width = Form.ActiveForm.Width;
            Height = Form.ActiveForm.Height;
            if (Width > 1000 || Height > 1000 || Width < 0 || Height < 0)
            {
                throw new ArgumentOutOfRangeException("Высота или ширина окна недопустимых размеров");
            }
        }
    }
}
