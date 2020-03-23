using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test {
    public class Player : Entity {

        private static float pAcc = 4.15f;
        private static float pGrav = 2;
        private static float pLow = 10;
        private static float pJump = 25;
        private static float pFall = 12;
        private static float pSpd = 12;
        private static float pFric = 0.85f;


        public Player(Texture2D texture, Vector2 initialPosition) : base(texture, initialPosition, pAcc, pGrav, pLow, pJump, pFall, pSpd, pFric) {
            
        }

        private void Move(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                MoveRight(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                MoveLeft(gameTime);
            }

            if(grounded && Keyboard.GetState().IsKeyDown(Keys.Space)) {
                Jump();
            }
        }

        public override void Update(GameTime gameTime) {
            Move(gameTime);

            base.Update(gameTime);
        }
    }
}