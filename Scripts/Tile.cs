using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test {
    public class Tile {
        private Texture2D texture;
        private Vector2 position;

        private Rectangle dimensions;
        private Vector2 origin;
        private Vector2 scale;
        private float rotation;
        private float layer;
        private bool direction;
        private SpriteEffects dirEffect;

        public Tile(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.position = position;

            dimensions = new Rectangle(0, 0, texture.Width, texture.Height);
            origin = Vector2.Zero;
            scale = Vector2.One;
            rotation = 0;
            layer = 0;
            direction = false;
            UpdateDirectionEffect();
        }

        public Rectangle Dimensions { get => dimensions; set => dimensions = value; }
        public Vector2 Origin { get => origin; set => origin = value; }
        public Vector2 Scale { get => scale; set => scale = value; }
        public float Rotation { get => rotation; set => rotation = value; }
        public float Layer { get => layer; set => layer = value; }
        public bool Direction { get => direction; set => direction = value; }
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Position { get => position; set => position = value; }

        private void UpdateDirectionEffect() {
            if (direction) {
                dirEffect = SpriteEffects.FlipHorizontally;
            }
            else {
                dirEffect = SpriteEffects.None;
            }
        }

        public virtual void Update(GameTime gameTime) {
            UpdateDirectionEffect();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, dimensions, Color.SpringGreen, rotation, origin, scale, dirEffect, 0);
        }

        public void SetPosition(float x, float y) {
            position.X = x;
            position.Y = y;
        }
    }
}