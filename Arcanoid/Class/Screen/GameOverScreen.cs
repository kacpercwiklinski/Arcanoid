using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                saveScore();
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mGameOverScreenBackground, Vector2.Zero, Color.White);
            drawScore(spriteBatch);
            base.Draw(spriteBatch);
        }

        private void drawScore(SpriteBatch spriteBatch) {
            String scoreString = "Score: " + GameScreen.score.ToString();
            float fontLenght = Game1.textureManager.optionFont.MeasureString(scoreString).Length();
            spriteBatch.DrawString(Game1.textureManager.optionFont, scoreString, new Vector2((float)Game1.WIDTH/2 - fontLenght / 2, (float)Game1.HEIGHT / 2), Color.White);
        }

        private void saveScore() {
            if (!Directory.Exists("D:/Arkanoid/")) {
                Directory.CreateDirectory("D:/Arkanoid/");
            }
            var writer = new StreamWriter("D:/Arkanoid/highscores.txt", true);
            writer.WriteLine(GameScreen.score.ToString());
            writer.Close();
        }
    }
}
