using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace BezieCurve
{
    class Program
    {
        static Game game;
        static RenderWindow rw;
        static void Main(string[] args)
        {
            VideoMode vm = new VideoMode(800, 600);
            rw = new RenderWindow(vm, "Bezie");
            game = new Game();

            rw.Closed += OnClose;
            rw.KeyPressed += OnKey;
            rw.MouseButtonPressed += MousePressed;
            rw.MouseButtonReleased += MouseReleased;
            rw.MouseMoved += MouseMoved;

            while (rw.IsOpen)
            {
                rw.DispatchEvents();
                rw.Clear();
                game.Draw(rw);
                rw.Display();
            }
        }

        static void OnClose(object sender, EventArgs e)
        {
            (sender as RenderWindow)?.Close();
        }

        static void OnKey(object sender, KeyEventArgs e)
        {
            game.OnKeyPressed(sender, e);
            if (e.Code == Keyboard.Key.Escape)
                rw.Close();
        }

        static void MousePressed(object sender, MouseButtonEventArgs e)
        {
            game.OnMousePressed(sender, e);
        }

        static void MouseReleased(object sender, MouseButtonEventArgs e)
        {
            game.OnMouseReleased(sender, e);
        }

        static void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            game.OnMouseMoved(sender, e);
        }
    }
}
