﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Utils {
    public class TextureManager {

        // Fonts
        public SpriteFont optionFont;

        // Background
        public Texture2D splashScreenBackground;
        public Texture2D mainMenuScreenBackground;
        public Texture2D pauseScreenBackground;
        public Texture2D highScoreBackground;
        public Texture2D gameOverScreenBackground;
        public Texture2D gameScreenBackground;

        // Object 
        public Texture2D playerTexture;
        public Texture2D ball;

        public TextureManager(ContentManager contentManager) {
            loadTextures(contentManager);
        }

        private void loadTextures(ContentManager contentManager) {

            // Fonts
            optionFont = contentManager.Load<SpriteFont>("Fonts/optionFont");

            // Background
            splashScreenBackground = contentManager.Load<Texture2D>("Textures/Background/splashScreenBackground");
            mainMenuScreenBackground = contentManager.Load<Texture2D>("Textures/Background/mainMenuScreenBackground");
            pauseScreenBackground = contentManager.Load<Texture2D>("Textures/Background/pauseScreenBackground");
            highScoreBackground = contentManager.Load<Texture2D>("Textures/Background/highScoreBackground");
            gameOverScreenBackground = contentManager.Load<Texture2D>("Textures/Background/gameOverScreenBackground");
            gameScreenBackground = contentManager.Load<Texture2D>("Textures/Background/gameScreenBackground");

            // Object
            playerTexture = contentManager.Load<Texture2D>("Textures/Object/player");
            ball = contentManager.Load<Texture2D>("Textures/Object/ball");

        }
    }
}