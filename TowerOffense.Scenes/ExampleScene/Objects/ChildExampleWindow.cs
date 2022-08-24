using Microsoft.Xna.Framework;
using TowerOffense.Window;

namespace TowerOffense.Scenes.TestScene.Objects {
    public class ChildTestWindow : TestWindow {
        public ChildTestWindow(Scene scene, int width, int height) : base(scene, width, height) { }
        public override void Render(GameTime gameTime) { }
        public override void Update(GameTime gameTime) { }
    }
}