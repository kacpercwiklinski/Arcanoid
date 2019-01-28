using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Screen {
    class HighScoresScreen : Screen {
        Texture2D mHighScoreBackground;

        List<int> highScores;

        private String filePath = "D:/Arkanoid/highscores.txt";

        Boolean highScoresLoaded = false;

        public HighScoresScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mHighScoreBackground = Game1.textureManager.highScoreBackground;

            highScores = new List<int>();
        }

        public override void Update(GameTime gameTime) {

            if (!highScoresLoaded) {
                getHighscores();
                highScoresLoaded = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                highScoresLoaded = false;
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(mHighScoreBackground, Vector2.Zero, Color.White);
            drawTopHighscores(spriteBatch);
            base.Draw(spriteBatch);
        }

        private void drawTopHighscores(SpriteBatch spriteBatch) {
            if (highScoresLoaded) {
                highScores.Take(5).ToList().ForEach((score) => {
                    String scoreString = (highScores.IndexOf(score)+1).ToString() + ". " + score.ToString();
                    spriteBatch.DrawString(Game1.textureManager.optionFont,scoreString,new Vector2(Game1.WIDTH/2.5f,Game1.HEIGHT/4 + highScores.IndexOf(score) * 100),Color.White);
                });
            }
        }

        private void getHighscores() {
            highScores.Clear();

            if (File.Exists(filePath)) {
                var reader = new StreamReader("D:/Arkanoid/highscores.txt");
                String stringData = reader.ReadToEnd();

                String[] lines = stringData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (var line in lines) {
                    if (!line.Equals("")) {
                        highScores.Add(Convert.ToInt32(line));
                    }
                }
                highScores = highScores.Distinct().ToList();
                highScores.Sort((x1,x2) => x2.CompareTo(x1));

                reader.Close();
            }
        }
    }






}
