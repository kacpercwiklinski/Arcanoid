using Arcanoid.Class.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    class UI {

        public UI() {
        }

        public void Update(GameTime gameTime) {
            
        }

        public void DrawUI(SpriteBatch spriteBatch) {
            drawLives(spriteBatch);
        }

        private void drawLives(SpriteBatch spriteBatch) {
            for (int i = 0; i < Player.lives; i++) {
                spriteBatch.Draw(Game1.textureManager.ball, new Vector2(10 + i * Game1.textureManager.ball.Width, 10), Color.White);
            }
        }
    }
}
