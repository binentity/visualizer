using SFML.Graphics;
using SFML.System;

namespace Program {

    internal class Entity : Drawable {

        private CircleShape shape;
        private Vector2f velocity;

        public Vector2f Velocity { get => velocity; set => velocity = value; }
        public CircleShape Shape { get => shape; set => shape = value; }

        public Entity(float radius, Vector2f pos, Color fillColor) {
            shape = new CircleShape(radius);
            velocity = new Vector2f(0, 0);
            shape.Position = pos;
            shape.FillColor = fillColor;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(Shape, states);
        }

        public void Update(float delta) {
            velocity = new Vector2f(100 * delta, 0);
        }
    }
}
