using SFML.Graphics;
using SFML.System;

namespace Program {

    internal class Entity : Drawable {

        private CircleShape shape;
        private Vector2f speed;
        private float mass;

        public CircleShape Shape { get => shape; set => shape = value; }

        public Entity(float radius, Vector2f pos, float mass, Vector2f speed, Color fillColor) {
            shape = new CircleShape(radius);

            this.speed = speed;
            this.mass = mass;

            shape.Position = pos;
            shape.FillColor = fillColor;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(Shape, states);
        }

        public float DistanceTo(Entity other) {
            float distance = (float)Math.Sqrt(Math.Pow(shape.Position.X - other.shape.Position.X, 2) +
                                    Math.Pow(shape.Position.Y - other.shape.Position.Y, 2));

            return distance;
        }

        public void Update(float delta, Entity entity) {
            //shape.Position += speed * delta;

            speed = new Vector2f((float)(speed.X + (0.00005 * entity.mass / DistanceTo(entity) * DistanceTo(entity)) *
                                        (entity.shape.Position.X - shape.Position.X) / DistanceTo(entity)),

                    (float)(speed.Y + (0.00005 * entity.mass / DistanceTo(entity) * DistanceTo(entity)) *
                           (entity.shape.Position.Y - shape.Position.Y) / DistanceTo(entity)));       // * time.asSeconds());

            Console.WriteLine(speed.ToString());

            shape.Position = new Vector2f(shape.Position.X + speed.X, shape.Position.Y + speed.Y);
            //circle.setPosition(position);
        }

    }
}
