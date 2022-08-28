using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;

namespace TowerOffense.Scenes.Example.Objects {
    public class Worm : SceneWindow {

        private List<Segment> _segments;
        private Vector2 _position;
        private float _turnAngle;
        private float _angle;
        private float _speed = 3;
        private double _time;
        private Random _random;

        public Worm(Point position, Point size, int numSegments, int titleBarHeight, int borderThickness) : base(position, size, titleBarHeight, borderThickness) {
            _position = new Vector2(position.X, position.Y);
            _segments = new List<Segment>();
            _random = new Random();
            for (int i = 0; i < numSegments; i++) {
                _segments.Add(new Segment(position, new Point(60 - 5 * i, 60 - 5 * i), this));
            }
        }

        public override void Update(GameTime gameTime) {
            _segments.RemoveAll(obj => obj.IsDestroyed);
            _time += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_time >= 2000) {
                _time -= 2000;
                _turnAngle = _random.NextSingle() * 0.05f - 0.025f;
            }

            _angle += _turnAngle;
            _position += new Vector2() {
                X = MathF.Cos(_angle) * _speed,
                Y = MathF.Sin(_angle) * _speed
            };

            _position = new Vector2() {
                X = MathF.Max(0f, MathF.Min(_position.X, 1920f - Size.X)),
                Y = MathF.Max(0f, MathF.Min(_position.Y, 1080f - Size.Y))
            };

            Position = _position.ToPoint();

            base.Update(gameTime);
        }

        public override void Render(GameTime gameTime) {
            base.Render(gameTime);
        }

        public IEnumerable<Segment> GetSegments() {
            return _segments;
        }


    }
}