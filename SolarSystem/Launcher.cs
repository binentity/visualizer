using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SolarSystem {

    internal class Launcher {

        private const string TITLE = "Playground window";
        private const string PATH_TO_FONT = "C:/mono.ttf";

        private readonly RenderWindow window;
        private VideoMode videoMode;

        private Font font;
        private Text text;
        // Добавить игрока

        private List<Entity> entities;
        private List<LineShape> lineShapes;

        private readonly Clock clock;

        public Launcher() {
            videoMode = new VideoMode(2550, 1440);
            window = new RenderWindow(videoMode, TITLE);
            window.Closed += WindowClosed;
            clock = new Clock();

            InitEntities();
            Run();
        }

        private void InitEntities() {

            font = new Font(PATH_TO_FONT);
            text = new Text("", font, 24) {
                Position = new Vector2f(50, 50),
            };

            // Сделать рандомайзер для создания сущностей.
            entities = [
                // Planets. Сделать сущности абстракным.
                new Entity(10f, new Vector2f(500f, 500f), 5f, new Vector2f(50, 100), Color.Green),
                new Entity(10f, new Vector2f(800f, 500f), 25f, new Vector2f(150, 50), Color.Blue),
                new Entity(10f, new Vector2f(1200f, 1000f), 25f, new Vector2f(300, 100), Color.Yellow),

                // Sun
                new Entity(30f, new Vector2f(1000f, 800f), 5000f, new Vector2f(0, 0), Color.Blue),
            ];

            // Убрать и инитить уже в SunEntity
            lineShapes = [
                new LineShape(
                    new Vector2f(15, 15),
                    new Vector2f(100, 100)
                ),
                new LineShape(
                    new Vector2f(50, 100),
                    new Vector2f(500, 500)
                ),
            ];

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
                window.Close();
            }
        }

        private void Repaint() {
            window.Clear(new Color(150, 150, 150));
            window.Draw(text);

            foreach (var e in entities) {
                window.Draw(e);
            }

            foreach (var line in lineShapes) {
                window.Draw(line);
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



                text.DisplayedString = "hello world";
            }

        }
    }
}
