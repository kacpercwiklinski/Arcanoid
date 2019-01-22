using Arcanoid.Class.Screen;
using Arcanoid.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Object {
    public class Block {

        public String label;
        public Vector2 position;
        public int lives;
        public Texture2D texture;
        public Rectangle boundingBox;
        public Color[] colorData;
        public Boolean isTriggerable;
        public Boolean destroyed;

        public Block(string label, Vector2 position, Texture2D texture) {
            this.label = label;
            this.position = position;
            this.lives = 1;
            this.texture = texture;
            this.boundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width, this.texture.Height);
            this.destroyed = false;
            this.isTriggerable = true;

            getColorData();
        }

        public virtual void Update(GameTime gameTime) {
            if(this.lives <= 0) {
                this.destroyed = true;
                this.isTriggerable = false;
            }
        }

        public void Hit() {
            GameScreen.score += 100;
            this.lives--;
        }

        public void getNormal(Vector2 position) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (!this.label.Equals("EmptyBlock") && !destroyed) {
                spriteBatch.Draw(this.texture, this.position, Color.White);
            }
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }
    }
}
