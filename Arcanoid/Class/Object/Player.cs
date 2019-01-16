using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    class Player {
        public Vector2 position;
        float speed = 400f;
        public Texture2D texture { get; set; }
        public int lives;

        public Player() {
            this.texture = Game1.textureManager.playerTexture;
            this.position = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT - this.texture.Height );
            this.lives = 4;
        }
        
        public void Update(GameTime gameTime) {
            handleMovement(gameTime);
        }

        private void handleMovement(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A) && this.position.X - this.texture.Width/2 > 0) {
                this.position.X += -1 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            } else if (keyState.IsKeyDown(Keys.D) && this.position.X + this.texture.Width / 2 < Game1.WIDTH) {
                this.position.X += 1 * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyState.IsKeyDown(Keys.Space) && !Ball.gameStarted) {
                releaseBall();
            }
        }

        private void releaseBall() {
            Ball.gameStarted = true;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, new Vector2(this.position.X - this.texture.Width/2, this.position.Y - this.texture.Height/2), Color.White);
        }
    }
}
