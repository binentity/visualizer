using SFML.Graphics;
using SFML.System;

namespace SolarSystem {
    internal class LineShape : Drawable {

        private readonly Vertex[] vertices;

        public LineShape(Vector2f startPosition, Vector2f endPosition) {

            vertices = [
                new Vertex(startPosition, Color.Black),
                new Vertex(endPosition, Color.Black),
            ];

        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(vertices, PrimitiveType.Lines);
        }

        public void Update(Vector2f startPosition, Vector2f endPosition) {
            vertices[0].Position = startPosition;
            vertices[1].Position = endPosition;
        }
    }
}