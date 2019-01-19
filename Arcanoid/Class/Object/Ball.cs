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
    class Ball {

        public static Boolean gameStarted = false;

        Random random;
        Vector2 position;
        Texture2D texture;
        Vector2 direction;
        float speed;
        Rectangle boundingBox;
        Player player;
        Level level;
        Color[] colorData;

        public Ball(Player _player, Level _level) {
            random = new Random();
            this.player = _player;
            this.level = _level;
            this.texture = Game1.textureManager.ball;
            this.position = new Vector2(this.player.position.X, this.player.position.Y - texture.Height);
            this.direction = new Vector2(3,-3);
            this.speed = 200f;
            this.boundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width, this.texture.Height);

            getColorData();
        }

        public void Update(GameTime gameTime) {

            this.player.position = player.getPlayerPos();

            mapCollisions();
            handleMovement(gameTime);
            updateBoundingBox();

        }

        private void updateBoundingBox() {
            if (Game1.boundingBoxes.Contains(this.boundingBox)){
                Game1.boundingBoxes.Remove(this.boundingBox);
            }

            this.boundingBox = new Rectangle((int)this.position.X - this.texture.Width / 2, (int)this.position.Y - this.texture.Height / 2, this.texture.Width, this.texture.Height);
            Game1.boundingBoxes.Add(this.boundingBox);
        }

        private void handleMovement(GameTime gameTime) {
            if (!gameStarted) {
                this.position = new Vector2(player.position.X, player.position.Y - texture.Height);
            } else {
                this.position += this.direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void mapCollisions() {
            // Map intersections

            if(this.position.X + this.texture.Width/2 >= Game1.WIDTH) {
                Vector2 normal = Vector2.Normalize(new Vector2(-Game1.HEIGHT,0));
                this.direction = Vector2.Reflect(this.direction, normal);
            }else if(this.position.X - this.texture.Width / 2 <= 0) {
                Vector2 normal = Vector2.Normalize(new Vector2(Game1.HEIGHT, 0));
                this.direction = Vector2.Reflect(this.direction, normal);
            } else if (this.position.Y + this.texture.Width / 2 >= Game1.HEIGHT) {
                Vector2 normal = Vector2.Normalize(new Vector2(0, Game1.WIDTH));
                this.direction = Vector2.Reflect(this.direction, normal);
            } else if(this.position.Y - this.texture.Width / 2 <= 0) {
                Vector2 normal = Vector2.Normalize(new Vector2(0, -Game1.WIDTH));
                this.direction = Vector2.Reflect(this.direction, normal);
            }

            // Paddle intersections
            if (this.boundingBox.Intersects(player.boundingBox)) {
                Vector2 normal = Vector2.Normalize(new Vector2(0, -player.texture.Width));
                this.direction = Vector2.Reflect(this.direction, normal);
            }

            // Block intersections
            level.blocks.ForEach((block) => {
                if (block.boundingBox.Intersects(this.boundingBox) && block.isTriggerable) {
                    bool collision = PerPixelCollision.IntersectsPixel(boundingBox, this.colorData, block.boundingBox, block.colorData);
                    if (collision) {
                        block.Hit();

                    }
                }
            });
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, new Vector2(this.position.X - this.texture.Width / 2, this.position.Y - this.texture.Height / 2), Color.White);
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }
    }
}
