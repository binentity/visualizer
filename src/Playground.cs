using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Program {

    internal class Playground {

        private const string TITLE = "Playground window";

        private RenderWindow window;
        private VideoMode videoMode;

        private Entity entity1;
        private Entity entity3;
        private Entity entity2;

        private Font font;
        private Text text;

        private List<Entity> entities;

        private readonly Clock clock;

        public Playground() {
            videoMode = new VideoMode(2550, 1440);
            window = new RenderWindow(videoMode, TITLE);
            window.Closed += WindowClosed;
            clock = new Clock();

            font = new Font("C:\\mono.ttf");
            text = new Text("hello", font, 24) {
                Position = new Vector2f(50, 50),
            };

            InitEntities();
            Run();
        }

        private void InitEntities() {
            entity1 = new Entity(10f, new Vector2f(500f, 500f), 5f, new Vector2f(50, 100), Color.Green);
            entity3 = new Entity(5f, new Vector2f(1000f, 500f), 5f, new Vector2f(30, 30), Color.Yellow);
            entity2 = new Entity(30f, new Vector2f(800f, 500f), 3000f, new Vector2f(0, 0), Color.Blue);
            entities = [entity1, entity2, entity3];
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
                window.Close();
            }
        }

        private void Repaint() {
            Color clearColor = new(150, 150, 150);
            window.Clear(clearColor);
            window.Draw(text);

            foreach (var e in entities) {
                window.Draw(e);
            }
        }

        private void Update(float delta) {
            foreach (var e in entities) {
                foreach (var se in entities) {
                    if (e.Equals(se)) {
                        continue;
                    }

                    e.Update(delta, se);
                }

                text.DisplayedString = entity3.Shape.Position.ToString();
                Repaint();
            }

        }
    }
}
