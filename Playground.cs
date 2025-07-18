using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Program {

    internal class Playground {

        private const string TITLE = "Playground window";

        private RenderWindow window;
        private VideoMode videoMode;

        private readonly Entity entity;
        private readonly Entity entity1;
        private readonly Entity entity2;

        private readonly List<Entity> entities;

        private readonly Clock clock;

        public Playground() {
            videoMode = new VideoMode(2550, 1440);
            window = new RenderWindow(videoMode, TITLE);
            window.Closed += WindowClosed;
            clock = new Clock();

            // уже лучше, но все равно нагромождение данных.
            entity = new Entity(20, new Vector2f(100, 100), Color.Red);
            entity1 = new Entity(10, new Vector2f(200, 20), Color.Green);
            entity2 = new Entity(50, new Vector2f(100, 100), Color.Blue);
            entities = [entity, entity1, entity2];

            Run();
        }

        private void WindowClosed(object? sender, EventArgs e) {
            Window? window = sender as Window;
            window.Close();
        }

        private void Run() {
            while (window.IsOpen) {
                float delta = clock.Restart().AsSeconds();

                ProcessEvents();
                Update(delta);
                Repaint();

                window.Display();
            }
        }

        private void ProcessEvents() {
            window.DispatchEvents();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter)) {
                Console.WriteLine("hello Enter");
            }
        }

        private void Repaint() {
            Color clearColor = new(150, 150, 150);
            window.Clear(clearColor);
            foreach (var e in entities) {
                window.Draw(e);
            }
        }

        private void Update(float delta) {
            foreach (var e in entities) {
                e.Update(delta);
            }
        }

    }
}
