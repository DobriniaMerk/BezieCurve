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
        bool newDisplay = true;

        public Game()
        {
            curve.AddPoint(6, 581);
            curve.AddPoint(778, 384);
            curve.AddPoint(624, 358);
            curve.AddPoint(778, 583);
        }

        public void Draw(RenderWindow rw)
        {
            curve.Draw(rw, drawPoints, newDisplay);
        }

        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.P:
                    drawPoints = !drawPoints;
                    break;
                case Keyboard.Key.S:
                    foreach(Vector2f v in curve.points)
                    {
                        Console.WriteLine(v.X + " " + v.Y);
                    }
                    break;
                case Keyboard.Key.D:
                    newDisplay = !newDisplay;
                    Console.WriteLine(newDisplay);
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
