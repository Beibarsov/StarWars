//using System;
using System.Drawing;

namespace StarWars

{
    class Star : GameObject
    {
        public Star(Point Position, Point Speed, Size Size)
            : base(Position, Speed, Size) { }
         
        public override void Draw()
        {


            var g = Game.Buffer.Graphics;
            Image image = Image.FromFile(@"Images\Star.png");
            g.DrawImage(image, _Position);

            //var g = Game.Buffer.Graphics;
            //g.DrawLine(Pens.White, _Position.X, _Position.Y, _Position.X + _Size.Width, _Position.Y + _Size.Height);
            //g.DrawLine(Pens.White, _Position.X + _Size.Width, _Position.Y, _Position.X, _Position.Y + _Size.Height);


            // base.Draw();
        }
        public override void Update()
        {
            // base.Update();

            _Position.X -= _Speed.X;

            if (_Position.X < 0)
                _Position.X = Game.Width + _Size.Width;

        }

    }

}
