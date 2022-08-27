using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;
using TowerOffense.Objects.Common;
using TowerOffense.Scenes;

namespace TowerOffense.Objects.Towers {
    public class GravityTower : Tower {
        public GravityTower(
            Scene scene,
            EntityManager entityManager,
            Point? position = null) : base(
            scene,
            entityManager,
            new Point(100, 100),
            position: position) {

            TitleBarColor = new Color(225, 185, 255);
            FocusedBorderColor = TitleBarColor;
            BorderColor = new Color(118, 93, 128);

            _range = float.MaxValue;
            _attackSpeed = 0.5f;
            _damage = 0.5f;
            _sellPrice = 1;
        }

        public override void Update(GameTime gameTime) {

            _enemiesInRange = GetEnemiesInRange();

            var first = _enemiesInRange.Where(e => e.EnemyState != EnemyState.Neutralized).FirstOrDefault();

            _targetedEnemies = (first != null) ?
            new List<Enemy> { first } :
            new List<Enemy>();

            while (_attackTimer >= _attackSpeed) {
                foreach (var enemy in _targetedEnemies) {
                    enemy.Damage(_damage);
                }
                _attackTimer -= _attackSpeed;
            }

            base.Update(gameTime);
        }

        public override void Render(GameTime gameTime) {
            base.Render(gameTime);
        }
    }
}