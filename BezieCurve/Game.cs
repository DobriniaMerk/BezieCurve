using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace BezieCurve
{
    class Game
    {
        Curve curve = new Curve();
        bool drawPoints = true;

        public Game()
        {
            curve.AddPoint(400, 400);
            curve.AddPoint(300, 270);
            curve.AddPoint(530, 160);
            curve.AddPoint(500, 300);
        }

        public void Draw(RenderWindow rw)
        {
            curve.Draw(rw, drawPoints);
        }

        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.D:
                    drawPoints = !drawPoints;
                    break;
            }
        }

        public void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
                curve.MousePressed(new Vector2f(e.X, e.Y));
            else if (e.Button == Mouse.Button.Right)
                curve.AddPoint(e.X, e.Y);
        }

        public void OnMouseReleased(object sender, MouseButtonEventArgs e)
        {
            curve.MouseReleased();
        }

        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            curve.MouseMoved(new Vector2f(e.X, e.Y));
        }
    }
}
