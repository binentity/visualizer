using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Program {

    internal class Playground {

        private const string TITLE = "Playground window";

        private RenderWindow window;
        private VideoMode videoMode;

        private Entity entity1;
        private Entity entity2;

        private List<Entity> entities;

        private readonly Clock clock;

        public Playground() {
            videoMode = new VideoMode(2550, 1440);
            window = new RenderWindow(videoMode, TITLE);
            window.Closed += WindowClosed;
            clock = new Clock();

            InitEntities();
            Run();
        }

        private void InitEntities() {
            entity1 = new Entity(10f, new Vector2f(200f, 500f), 10f, new Vector2f(2, 2), Color.Green);
            entity2 = new Entity(50f, new Vector2f(500f, 500f), 500f, new Vector2f(0, 0), Color.Blue);
            entities = [entity1, entity2];
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
                foreach (var se in entities) {
                    if (se.Equals(e)) {
                        continue;
                    }

                    e.Update(delta, se);
                }

                Repaint();
            }

        }
    }
}
