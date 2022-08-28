using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;

namespace TowerOffense.Scenes.HpTest.Objects {
    public class HpKiller : SceneObject {

        private double timeCount = 0;
        private double timeLimit = 1;

        public HpKiller() : base() { }

        public override void Update(GameTime gameTime) {
            timeCount += gameTime.ElapsedGameTime.TotalSeconds;
            if ( timeCount > timeLimit ){
                TOGame.PlayerManager.SubtractHp(5);
                timeCount = 0;
            }
        }
    }
}
