using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Screen {
    class GameOverScreen : Screen {
        Texture2D mGameOverScreenBackground;
        public GameOverScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mGameOverScreenBackground = Game1.textureManager.gameOverScreenBackground;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mGameOverScreenBackground, Vector2.Zero, Color.White);

            base.Draw(spriteBatch);
        }
    }
}
