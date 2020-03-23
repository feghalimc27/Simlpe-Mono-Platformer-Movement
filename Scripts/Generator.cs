using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test {
    public class Generator {
        private float variance;
        private int size;
        public static SpriteFont font;
        private Vector2 debugPosition;

        public Generator() {
            variance = 0;
            size = 32;
            debugPosition = new Vector2(10, 10);
        }

        public Generator(float variance, int size) {
            this.variance = variance;
            this.size = size;
            this.debugPosition = new Vector2(10, 10);
        }

        public void Initialzie() {
            
        }

        public void DrawDebugInfo(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, "Variance: " + variance, debugPosition, Color.Black);
            spriteBatch.DrawString(font, "Size: " + size, debugPosition + new Vector2(0, 15), Color.Black);
        }

        public void SetFont(SpriteFont font) {
            Generator.font = font;
        }

        public void SetPosition(Vector2 position) {
            this.debugPosition = position;
        }

        public void SetPosition(float x, float y) {
            debugPosition = new Vector2(x, y);
        }
    }
}