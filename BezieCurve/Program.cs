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
    }
}
