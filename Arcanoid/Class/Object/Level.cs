using Arcanoid.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    class Level {

        public List<Block> blocks;
        public int levelIndex = 1;
        public Boolean started = false;

        public Level() {
            blocks = new List<Block>();
            initializeLevel(levelIndex);
        }

        public void initializeLevel(int levelIndex) {
            blocks = LevelLoader.getLevelBlocks(levelIndex);
            blocks = blocks.FindAll((block) => !block.label.Equals("EmptyBlock"));
            started = true;
        }

        public void Update(GameTime gameTime) {
            blocks.ForEach((block) => block.Update(gameTime));

            if(started && blocks.Count() == 0) {
                levelIndex++;
                Game1.audioManager.nextLevel.Play(0.2f, 1f, 1f);
                initializeLevel(levelIndex);
                Ball.gameStarted = false;
            }

            blocks = blocks.FindAll((block) => !block.destroyed);
        }

        public void Draw(SpriteBatch spriteBatch) {
            blocks.ForEach((block) => block.Draw(spriteBatch));
        }
    }
}
