using System;
using Microsoft.Xna.Framework;
using TowerOffense.Extensions;
using TowerOffense.Objects.Base;
using TowerOffense.Objects.Common;
using TowerOffense.Scenes;
using TowerOffense.Scenes.Gameplay.Objects;

namespace TowerOffense.Objects.Enemies {
    public class SpiderEnemy : Enemy {
        private const int ActiveStateTime = 10;
        private const int AttackingStateTime = 2;
        private const int NeutralizedStateTime = 10;
        private float _moveTime;
        private Vector2 _velocity;
        private float _speed = 200;
        private float _angle;

        public SpiderEnemy(
            Scene scene,
            EntityManager entityManager,
            Vector2 position,
            bool fromPortal
        ) : base(
            scene,
            entityManager,
            new Point(60, 60),
            position,
            fromPortal
        ) {

            MaxHealth = 5f;
            Health = MaxHealth;

            Damaged += (sender, amount) => {
                if (Health - amount <= 0f) {
                    ChangeState(EnemyState.Neutralized, 5f);
                }
            };

            StateChanged += (sender, state) => {

                System.Console.WriteLine($"new: {state}, old: {State}");

                switch (state) {
                    case EnemyState.Active:
                        _speed = 200;
                        if (State == EnemyState.Neutralized) Health = MaxHealth;
                        break;
                    case EnemyState.Attacking:
                        _speed = 0;
                        break;
                    case EnemyState.Neutralized:
                        _speed = 0;
                        break;
                }
            };

            ChangeState(EnemyState.Active, 10f);
        }

        public override void Update(GameTime gameTime) {

            var deltaTime = gameTime.DeltaTime();


            switch (State) {
                case EnemyState.Active:
                    if (StateTime >= 10f) {
                        ChangeState(EnemyState.Attacking, 2f);
                    }
                    break;
                case EnemyState.Attacking:
                    if (StateTime >= 2f) {
                        ChangeState(EnemyState.Active, 10f);
                    }
                    break;
                case EnemyState.Neutralized:
                    if (StateTime >= 5f) {
                        ChangeState(EnemyState.Active, 10f);
                    }
                    break;
            }

            if (State == EnemyState.Active) {

                _moveTime += deltaTime;

                while (_moveTime > 1) {
                    _moveTime -= 1;
                    _angle = new Random().NextSingle() * MathF.Tau;
                }

                _velocity = new Vector2() {
                    X = MathF.Cos(_angle) * _speed * deltaTime,
                    Y = MathF.Sin(_angle) * _speed * deltaTime
                };

                Position += _velocity;
            }

            base.Update(gameTime);
        }
    }
}