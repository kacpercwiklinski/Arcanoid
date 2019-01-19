using Arcanoid.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
            started = true;
        }

        public void Update(GameTime gameTime) {

            blocks.ForEach((block) => block.Update(gameTime));

            if(started && blocks.Count() == 0) {
                levelIndex++;
                initializeLevel(levelIndex);
                Game1.boundingBoxes.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            blocks.ForEach((block) => block.Draw(spriteBatch));
        }
    }
}
