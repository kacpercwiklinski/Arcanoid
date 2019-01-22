using Arcanoid.Class.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Utils {
    public class LevelLoader {

        private List<Block> level1 = new List<Block>();

        private static String GetLevelData(int levelIndex) {
            Stream stream;
            switch (levelIndex) {
                case 1:
                    stream = TitleContainer.OpenStream("Content/Level/level1.txt");
                    break;
                case 2:
                    stream = TitleContainer.OpenStream("Content/Level/level2.txt");
                    break;
                default:
                    return "";
            }

            return new StreamReader(stream).ReadToEnd();
        }

        private static List<Block> loadLevel(String levelData) {
            List<Block> blocks = new List<Block>();

            if (levelData.Equals("")) {
                Random random = new Random();

                for (int i = 0; i < 7; i++) {
                    for (int j = 0; j < 14; j++) {
                        String randomChar = random.Next(0, 3).ToString();

                        if (randomChar.Equals("0")) {
                            blocks.Add(new Block("EmptyBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block1.ElementAt(0)));
                        } else if (randomChar.Equals("1")) {
                            blocks.Add(new Block("GrayBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block1.ElementAt(0)));
                        } else if (randomChar.Equals("2")) {
                            blocks.Add(new Block("RedBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block2.ElementAt(0)));
                        } else if (randomChar.Equals("3")) {
                            blocks.Add(new Block("YellowBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block3.ElementAt(0)));
                        }
                    }
                }
            } else {
                string[] lines = levelData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++) {
                    for (int j = 0; j < lines[i].Length; j++) {
                        if (lines[i][j].Equals('0')) {
                            blocks.Add(new Block("EmptyBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block1.ElementAt(0)));
                        } else if (lines[i][j].Equals('1')) {
                            blocks.Add(new Block("GrayBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block1.ElementAt(0)));
                        } else if (lines[i][j].Equals('2')) {
                            blocks.Add(new Block("RedBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block2.ElementAt(0)));
                        } else if (lines[i][j].Equals('3')) {
                            blocks.Add(new Block("YellowBlock", new Vector2(80 + j * 81, 50 + i * 25), Game1.textureManager.block3.ElementAt(0)));
                        }
                    }
                }
            }
            
            return blocks;
        }

        public static List<Block> getLevelBlocks(int levelIndex) {
               return loadLevel(GetLevelData(levelIndex));
        }
    }
}
