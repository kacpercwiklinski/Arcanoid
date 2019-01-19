using Arcanoid.Class.Screen;
using Arcanoid.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Arcanoid.Class.Screen.MainMenuScreen;

namespace Arcanoid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static TextureManager textureManager;
        public static AudioManager audioManager;

        public const int WIDTH = 1280;
        public const int HEIGHT = 720;
        public const bool DEBUG_MODE = true;
        public static List<Rectangle> boundingBoxes;

        Screen mCurrentScreen;
        SplashScreen mSplashScreen;
        MainMenuScreen mMainMenuScreen;
        GameScreen mGameScreen;
        PauseScreen mPauseScreen;
        GameOverScreen mGameOverScreen;
        HighScoresScreen mHighScoresScreen;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;

            boundingBoxes = new List<Rectangle>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LineBatch.Init(GraphicsDevice);

            textureManager = new TextureManager(this.Content);
            audioManager = new AudioManager(this.Content);
            

            mSplashScreen = new SplashScreen(new EventHandler(splashScreenEvent));
            mMainMenuScreen = new MainMenuScreen(new EventHandler(mainMenuScreenEvent));
            mGameScreen = new GameScreen(new EventHandler(gameScreenEvent));
            mGameOverScreen = new GameOverScreen(new EventHandler(gameOverScreenEvent));
            mHighScoresScreen = new HighScoresScreen(new EventHandler(highScoresScreenEvent));
            mPauseScreen = new PauseScreen(new EventHandler(pauseScreenEvent));
            
            mCurrentScreen = mSplashScreen;
        }

        private void pauseScreenEvent(object sender, EventArgs e) {
            mCurrentScreen = mGameScreen;
        }

        private void highScoresScreenEvent(object sender, EventArgs e) {
            mCurrentScreen = mMainMenuScreen;
        }

        private void gameOverScreenEvent(object sender, EventArgs e) {
            mCurrentScreen = mMainMenuScreen;
        }

        private void gameScreenEvent(object sender, EventArgs e) {
            mCurrentScreen = mGameOverScreen;
        }

        private void mainMenuScreenEvent(object sender, EventArgs e) {
            Option chosenOption = mMainMenuScreen.options.Find((option) => option.active);
            if (chosenOption.label.Equals("Play")) {
                mCurrentScreen = mGameScreen;
                mGameScreen.StartGame();
            }  else if (chosenOption.label.Equals("Exit")) {
                Exit();
            }
        }

        private void splashScreenEvent(object sender, EventArgs e) {
            mCurrentScreen = mMainMenuScreen;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mCurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);

            if (DEBUG_MODE) {
                boundingBoxes.ForEach((boundingBox) => LineBatch.drawBoundingBox(boundingBox, spriteBatch));
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
