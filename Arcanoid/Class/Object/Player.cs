using Arcanoid.Class.Utils;
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
        public float speed = 600f;
        public Texture2D texture { get; set; }
        public int lives;
        public Rectangle boundingBox;
        public float paddleFriction = 0.125f;
        public Vector2 direction;

        public Player() {
            this.texture = Game1.textureManager.playerTexture;
            this.position = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT - this.texture.Height );
            this.lives = 4;
            this.boundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width, this.texture.Height);
            this.direction = new Vector2(0, 0);
        }

        public Vector2 getPlayerPos() {
            return this.position;
        }
        
        public void Update(GameTime gameTime) {
            handleMovement(gameTime);
            updateBoundingBox();
        }

        private void updateBoundingBox() {
            this.boundingBox = new Rectangle((int)this.position.X - this.texture.Width / 2, (int)this.position.Y - this.texture.Height / 2, this.texture.Width, this.texture.Height);
        }

        private void handleMovement(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A) && this.position.X - this.texture.Width/2 > 0) {
                this.direction.X = -1;
            } else if (keyState.IsKeyDown(Keys.D) && this.position.X + this.texture.Width / 2 < Game1.WIDTH) {
                this.direction.X = 1;
            }else {
                this.direction.X = 0;
            }

            this.position += this.direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

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
