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
    class HighScoresScreen : Screen {
        Texture2D mHighScoreBackground;

        public HighScoresScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mHighScoreBackground = Game1.textureManager.highScoreBackground;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mHighScoreBackground, Vector2.Zero, Color.White);
            base.Draw(spriteBatch);
        }
    }
}
