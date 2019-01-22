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
    class PauseScreen : Screen {

        Texture2D mPauseScreenBackground;

        public PauseScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mPauseScreenBackground = Game1.textureManager.pauseScreenBackground;
        }

        public override void Update(GameTime gameTime) {

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(mPauseScreenBackground, Vector2.Zero, Color.White);

            base.Draw(spriteBatch);
        }
    }
}
