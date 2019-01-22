using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    class TailEffect {

        int historySize = 10;
        Ball ball;
        List<Vector2> history;
        float samplingRate = 50f;
        float counter = 50f;

        
        public TailEffect(Ball _ball) {
            this.ball = _ball;
            this.history = new List<Vector2>();
        }

        public void UpdateTail(GameTime gameTime) {
            if (Ball.gameStarted) {
                Counter(gameTime);

                if (history.Count() < historySize && counter >= samplingRate) {
                    history.Add(ball.position);
                    counter = 0;
                } else if (history.Count() == historySize && counter >= samplingRate) {
                    history.RemoveAt(history.Count() - 1);
                    history.Insert(0, ball.position);
                    counter = 0;
                }
            }
        }

        private void Counter(GameTime gameTime) {
            counter += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void DrawTail(SpriteBatch spriteBatch) {
            if (Ball.gameStarted) {
                history.ForEach((position) => {
                    float scale = 0.9f;
                    if (history.IndexOf(position) != 0) {
                        scale = (1 / (history.IndexOf(position) + 1f)) * 2f;
                    }
                    spriteBatch.Draw(Game1.textureManager.ball, position, null, Color.White * (scale / 2f), 0f, new Vector2(Game1.textureManager.ball.Width / 2, Game1.textureManager.ball.Height / 2), scale, SpriteEffects.None, 0f);
                });
            }
        }
    }
}
