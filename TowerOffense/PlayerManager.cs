using TowerOffense;
using TowerOffense.Scenes.GameOver;
namespace TowerOffense{
    public class PlayerManager {
        private int _hp, _score, _cash;

        public int Hp { get => _hp; }
        public int Score { get => _score; }
        public int Cash { get => _cash; }

        private PlayerManager() {
            _hp = 100; // Put this in a config file somewhere maybe
            _score = 0;
            _cash = 0;
        }

        private static PlayerManager instance = null;
        public static PlayerManager Instance {
            get {
                if ( instance == null ){
                    instance = new PlayerManager();
                }
                return instance;
            }
        }

        public void SubtractHp(int change){
            _hp -= change;
            if (_hp <= 0){
                Die();
            }
        }

        public void AddCash(int change){
            _cash += change;
        }

        // returns false if you can't reduce this cash.
        public bool SubtractCash(int change){
            if( _cash < change ){
                return false;
            }
            _cash -= change;
            return true;
        }
        public void AddScore(int change){
            _score += change;
        }

        public void AddTower(/*Tower tower*/){} // Implement when towers exist

        public void Die(){
            TOGame.Scenes.PushScene<GameOverScene>();
        }

        public void Reset(){
            instance = new PlayerManager();
        }
    }
}

// singleton info taken from https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/