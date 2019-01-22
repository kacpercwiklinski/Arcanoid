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
    class MainMenuScreen : Screen {

        //Background texture for the Title screen
        Texture2D mTitleScreenBackground;
        public SpriteFont optionsFont;
        public List<Option> options;
        float counter = 0.2f;

        public MainMenuScreen(EventHandler theScreenEvent) : base(theScreenEvent) {
            mTitleScreenBackground = Game1.textureManager.mainMenuScreenBackground;

            options = new List<Option>();
            options.Add(new Option("Play", true));
            options.Add(new Option("Highscores", false));
            options.Add(new Option("Exit", false));

            optionsFont = Game1.textureManager.optionFont;
        }

        public void drawOptions(SpriteBatch spriteBatch) {
            int index = 0;
            options.ForEach((option) => {
                Color fontColor = option.active ? Color.White : Color.DarkSlateGray;
                float fontLenght = optionsFont.MeasureString(option.label).Length();
                spriteBatch.DrawString(optionsFont, option.label, new Vector2((float)(Game1.WIDTH / 2) - fontLenght / 2, (float)(Game1.HEIGHT / 2 - 100) + index * 100), fontColor);
                index++;
            });
        }

        public override void Update(GameTime theTime) {
            var kstate = Keyboard.GetState();

            updateCounter(theTime);

            if (kstate.IsKeyDown(Keys.Up)) changeActiveOption(1, theTime);
            if (kstate.IsKeyDown(Keys.Down)) changeActiveOption(-1, theTime);

            if (kstate.IsKeyDown(Keys.Enter) && counter <= 0f) {
                ScreenEvent.Invoke(this, new EventArgs());
                counter = 0.2f;
            }

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {
            theBatch.Draw(mTitleScreenBackground, Vector2.Zero, Color.White);

            drawOptions(theBatch);

            base.Draw(theBatch);
        }

        public void updateCounter(GameTime gameTime) {
            counter -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void changeActiveOption(int input, GameTime gameTime) {
            if (counter <= 0f) {
                int currentIndex = options.FindIndex((option) => option.active == true);
                if (input == -1) {
                    if (options.ElementAtOrDefault(currentIndex + 1) != null) {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(currentIndex + 1).active = true;
                    } else {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(0).active = true;
                    }
                } else if (input == 1) {
                    if (options.ElementAtOrDefault(currentIndex - 1) != null) {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(currentIndex - 1).active = true;
                    } else {
                        options.ElementAt(currentIndex).active = false;
                        options.Last().active = true;
                    }
                }
                counter = 0.2f;
            }

        }

        public class Option {
            public String label;
            public bool active;

            public Option(String label, bool active) {
                this.label = label;
                this.active = active;
            }
        }

    }
}
