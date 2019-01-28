using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Class.Utils {
    public class AudioManager {

        public SoundEffect blockHit;
        public SoundEffect gameOver;
        public SoundEffect lostLive;
        public SoundEffect nextLevel;

        public AudioManager(ContentManager contentManager) {
            loadAudio(contentManager);
        }

        private void loadAudio(ContentManager contentManager) {
            blockHit = contentManager.Load<SoundEffect>("Audio/blockHit");
            gameOver = contentManager.Load<SoundEffect>("Audio/gameOver");
            lostLive = contentManager.Load<SoundEffect>("Audio/lostLive");
            nextLevel = contentManager.Load<SoundEffect>("Audio/nextLevel");
        }
    }
}
