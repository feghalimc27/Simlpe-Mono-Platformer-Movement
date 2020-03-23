using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test {
    public class Entity {
        protected Tile tile;
        
        // Attributes
        protected float acceleration;
        protected float gravity;
        protected float lowJumpVelocity;
        protected float jumpVelocity;
        protected float fallSpeed;
        protected float speed;
        protected float friction;
        protected bool direction = true;
        protected bool grounded = true;

        // Vectors
        protected Vector2 movement;

        // Temporary
        protected float groundLevel = 400f;

        public Entity(Texture2D texture, Vector2 initialPosition, float acceleration, float gravity, float lowJumpVelocity, float jumpVelocity, float fallSpeed, float speed, float friction) {
            tile = new Tile(texture, initialPosition);

            movement = Vector2.Zero;

            this.acceleration = acceleration;
            this.gravity = gravity;
            this.lowJumpVelocity = lowJumpVelocity;
            this.jumpVelocity = jumpVelocity;
            this.fallSpeed = fallSpeed;
            this.speed = speed;
            this.friction = friction;
        }

        protected void IncrementMovement(float x, float y, GameTime gameTime) {
            movement.X += x * gameTime.ElapsedGameTime.Milliseconds / 10;
            movement.Y += y * gameTime.ElapsedGameTime.Milliseconds / 10;
        }

        protected void UpdateMovement(float x, float y) {
            movement.X = x;
            movement.Y = y;
        }

        protected virtual void SetDimensions(float x, float y) {
            tile.Origin = new Vector2(x / 2, y / 2);
            tile.Dimensions = new Rectangle((int)0, (int)0, (int)x, (int)y);
            // Rectangle would need to be updated manually with another function
        }

        protected void ApplyGravity(GameTime gameTime) {
            if (movement.Y < fallSpeed && !grounded) {
                IncrementMovement(0, gravity, gameTime);
            }
            else if (tile.Position.Y > groundLevel) {
                tile.SetPosition(tile.Position.X, groundLevel);
                movement.Y = 0;
            }

            // Temporary ground check
            if (tile.Position.Y >= groundLevel) {
                grounded = true;
            }
            else {
                grounded = false;
            }
        }

        protected void ApplyFriction(GameTime gameTime) {
            // Moving right
            if (direction) {
                if (movement.X != 0) {
                    IncrementMovement(-friction, 0, gameTime);
                }
            }
            else {
                if(movement.X != 0) {
                    IncrementMovement(friction, 0, gameTime);
                }
            }

            if (movement.X > -0.5 && movement.X < 0.5) {
                movement.X = 0;
            }
        }

        protected virtual void MoveLeft(GameTime gameTime) {
            IncrementMovement(-acceleration, 0, gameTime);
        }

        protected virtual void MoveRight(GameTime gameTime) {
            IncrementMovement(acceleration, 0, gameTime);
        }

        protected virtual void Jump() {
            movement.Y = -jumpVelocity;
        }

        protected virtual void LowJump() {
            movement.Y = -lowJumpVelocity;
        }

        protected virtual void UpdateDirection() {
            if (movement.X > 0) {
                direction = true;
            }
            else if (movement.X < 0) {
                direction = false;
            }
        }

        public virtual void Update(GameTime gameTime) {
            ApplyGravity(gameTime);
            ApplyFriction(gameTime);
            NormalizeMovement();
            UpdateDirection();

            // Add collision code

            tile.Position += movement;
        }

        protected virtual void NormalizeMovement() {
            if (movement.X >= speed) {
                movement.X = speed;
            }
            if (movement.X <= -speed) {
                movement.X = -speed;
            }
            if (movement.Y >= fallSpeed) {
                movement.Y = fallSpeed;
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            tile.Draw(gameTime, spriteBatch);
        }

        public void DrawDebugInfo(GameTime gameTime, SpriteBatch spriteBatch) {
            // Draw debug info to screen in top right corner
            string debugString = string.Format("Movement: ({0}, {1})\nPosition: ({2}, {3})\nElapsed Time: {4}", movement.X, movement.Y, tile.Position.X, tile.Position.Y, gameTime.ElapsedGameTime.Milliseconds);

            spriteBatch.DrawString(Generator.font, debugString, new Vector2(130, 10), Color.Black);
        }
    }
}