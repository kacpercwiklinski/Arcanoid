using Arcanoid.Class.Object;
using Arcanoid.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Screen {

    public enum EventType { Pause, Exit, GameOver, None}

    class GameScreen : Screen {
        Texture2D mGameScreenBackground;

        Player player;
        Ball ball;
        Level level;
        UI ui;
        public EventType eventType;

        public static int score = 0;

        public GameScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mGameScreenBackground = Game1.textureManager.gameScreenBackground;

            player = new Player();
            level = new Level();
            ball = new Ball(player,level);
            ui = new UI();
            eventType = EventType.None;
        }

        public override void Update(GameTime gameTime) {
            player.Update(gameTime);
            ball.Update(gameTime);
            level.Update(gameTime);
            ui.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.X)) {
                Player.lives = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P)) {
                eventType = EventType.Pause;
            } else if (Keyboard.GetState().IsKeyDown(Keys.E)) {
                eventType = EventType.Exit;
            } else if(Player.lives <= 0) {
                eventType = EventType.GameOver;
            } else {
                eventType = EventType.None;
            }

            if(eventType != EventType.None) {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mGameScreenBackground, Vector2.Zero, Color.White);

            player.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            level.Draw(spriteBatch);
            ui.DrawUI(spriteBatch);

            base.Draw(spriteBatch);
        }

        public void StartGame() {
            player = new Player();
            Player.lives = 4;
            score = 0;
            ball = new Ball(player,level);
            Ball.gameStarted = false;
        }
    }
}
