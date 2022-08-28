using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;

namespace TowerOffense.Scenes.DisplayTest.Objects {
    public class HpKiller : SceneObject {

        private double timeCount = 0;
        private double timeLimit = 1;

        public HpKiller(Scene scene) : base(scene) { }

        public override void Update(GameTime gameTime) {
            timeCount += gameTime.ElapsedGameTime.TotalSeconds;
            if ( timeCount > timeLimit ){
                if(TOGame.PlayerManager.SubtractCash(25)){
                    System.Console.WriteLine("We took cash");
                } else {
                    TOGame.PlayerManager.AddCash(10);
                    System.Console.WriteLine("We didn't take cash. Adding instead");
                }
                TOGame.PlayerManager.SubtractHp(5);
                TOGame.PlayerManager.AddScore(15);
                timeCount = 0;
            }
        }
    }
}
