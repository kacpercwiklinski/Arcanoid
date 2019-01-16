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
    class SplashScreen : Screen {

        private Texture2D mSplashScreenBackground;

        public SplashScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mSplashScreenBackground = Game1.textureManager.splashScreenBackground;
        }
        
        public override void Update(GameTime gameTime) {

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                ScreenEvent.Invoke(this, new EventArgs());
                return;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(mSplashScreenBackground, Vector2.Zero, Color.White);

            base.Draw(spriteBatch);
        }
    }
}
