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
    class Screen {
        
        protected EventHandler ScreenEvent;

        public Screen(EventHandler theScreenEvent) {
            ScreenEvent = theScreenEvent;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {

}

    }
}
