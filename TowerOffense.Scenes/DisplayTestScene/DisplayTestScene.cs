using TowerOffense.Scenes.DisplayTest.Objects;
using TowerOffense.Displays;
using Microsoft.Xna.Framework;
namespace TowerOffense.Scenes.Test {

    public class DisplayTestScene : Scene {
        private HpKiller hpKiller;
        private HpDisplay hpDisplay;
        private CashDisplay cashDisplay;
        private ScoreDisplay scoreDisplay;
        public DisplayTestScene(){
            hpKiller = new HpKiller(this);
            hpDisplay = new HpDisplay(this,new Point(0,0),new Point(120,120));
            cashDisplay = new CashDisplay(this, new Point(100,100),new Point(120,120));
            scoreDisplay = new ScoreDisplay(this, new Point(100,100),new Point(120,120));
            this.AddObject(hpKiller);
            this.AddObject(hpDisplay);
            this.AddObject(cashDisplay);
            this.AddObject(scoreDisplay);
        }

        public override void Initialize() {
            System.Console.WriteLine("HpTestScene Initialized");
        }
    }
}
