using Microsoft.Xna.Framework;
using TowerOffense.Scenes.TestScene.Objects;
using TowerOffense.Window;

namespace TowerOffense.Scenes.TestScene {
    public class ExampleScene : Scene {
        public ExampleScene() : base() {
            var window = new TestWindow(this, 200, 200);
            window.ClearColor = Color.Black;
            window.Position = Point.Zero;
            AddObject(window);

            var childWindow = new ChildTestWindow(this, 120, 120);
            childWindow.ClearColor = Color.Black;
            childWindow.Position = Point.Zero;
            AddObject(childWindow);
        }
    }
}