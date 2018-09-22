//using System;
using System.Drawing;

namespace StarWars

{
    class GameObject
    {
        protected Point _Position;
        protected Point _Speed;
        protected Size _Size;

        public GameObject(Point Position, Point Speed, Size Size)
        {
            _Position = Position;
            _Speed = Speed;
            _Size = Size;
        }

        public virtual void Draw()
        {
            var g = Game.Buffer.Graphics;
            Image image = Image.FromFile(@"Images\Asteroid.png");
            g.DrawImage(image, _Position);
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, new Rectangle(_Position, _Size));
        }

        public virtual void Update()
        {
            _Position.X += _Speed.X;
            _Position.Y += _Speed.Y;

            if (_Position.X < 0 || _Position.X > Game.Width - _Size.Width)
            {
                _Speed.X *= -1;
            }
            if (_Position.Y < 0 || _Position.Y > Game.Height - _Size.Height)
            {
                _Speed.Y *= -1;
            }
        }
    }

}
