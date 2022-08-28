using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;

namespace TowerOffense.Scenes.Example.Objects {
    public class Segment : SceneWindow {

        private SceneWindow _sceneWindow;

        public Segment(Point position, Point size, SceneWindow sceneWindow) : base(position, size) {
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Render(GameTime gameTime) {
            base.Render(gameTime);
        }


    }
}