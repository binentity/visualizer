using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Program {

    internal class Playground {

        private const string TITLE = "Playground window";

        private RenderWindow window;
        private VideoMode videoMode;

        private Entity entity;
        private Entity entity1;
        private Entity entity2;

        private readonly List<Entity> entities;

        private readonly Clock clock;

        public Playground() {
            videoMode = new VideoMode(2550, 1440);
            window = new RenderWindow(videoMode, TITLE);
            window.Closed += WindowClosed;
            clock = new Clock();

            entity = new Entity(20);
            entity.Position = new Vector2f(100, 100);
            entity.FillColor = Color.Red;

            entity1 = new Entity(10);
            entity1.Position = new Vector2f(0, 0);
            entity1.FillColor = Color.Green;

            entity2 = new Entity(50);
            entity2.Position = new Vector2f(100, 0);
            entity2.FillColor = Color.Yellow;

            entities = [entity, entity1, entity2];
            Run();
        }

        private void WindowClosed(object? sender, EventArgs e) {
            Window? window = sender as Window;
            window.Close();
        }

        private void Run() {
            while (window.IsOpen) {
                window.DispatchEvents();

                float delta = clock.Restart().AsSeconds();
                Update(delta);
                Repaint();

                window.Display();
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
