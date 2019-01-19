using Arcanoid.Class.Object;
using Arcanoid.Class.Utils;
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
    class GameScreen : Screen {
        Texture2D mGameScreenBackground;

        Player player;
        Ball ball;
        Level level;

        public static int score = 0;


        public GameScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mGameScreenBackground = Game1.textureManager.gameScreenBackground;

            player = new Player();
            level = new Level();
            ball = new Ball(player,level);
        }

        public override void Update(GameTime gameTime) {
            player.Update(gameTime);
            ball.Update(gameTime);
            level.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.X)) {

            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mGameScreenBackground, Vector2.Zero, Color.White);

            player.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            level.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

        public void StartGame() {
            player = new Player();
            ball = new Ball(player,level);
            Ball.gameStarted = false;
        }
    }
}
