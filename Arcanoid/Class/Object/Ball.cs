using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    class Ball {
        Random random;
        Vector2 position;
        Texture2D texture;
        public static Boolean gameStarted = false;
        Player player;
        Vector2 direction;
        float speed;

        public Ball(Player _player) {
            random = new Random();
            this.player = _player;
            this.texture = Game1.textureManager.ball;
            this.position = new Vector2(this.player.position.X, this.player.position.Y - texture.Height);
            this.direction = random.Next(0, 2) == 0 ? new Vector2(-1, -1) : new Vector2(1, -1);
            this.speed = 500f;
        }

        public void Update(GameTime gameTime) {
            if (!gameStarted) {
                this.position = new Vector2(player.position.X, player.position.Y - texture.Height);
            } else {
                this.position += this.direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, new Vector2(this.position.X - this.texture.Width / 2, this.position.Y - this.texture.Height / 2), Color.White);
        }


    }
}
