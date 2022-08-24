using Microsoft.Xna.Framework;
using TowerOffense.Scenes.ExampleScene.Objects;
using TowerOffense.Window;

namespace TowerOffense.Scenes.ExampleScene {
    public class ExampleScene : Scene {
        public ExampleScene() : base() {
            var window = new ExampleWindow(this, 200, 200);
            window.ClearColor = Color.Black;
            window.Position = Point.Zero;
            AddObject(window);

            var childWindow = new ChildExampleWindow(this, 120, 120);
            childWindow.ClearColor = Color.Black;
            childWindow.Position = Point.Zero;
            AddObject(childWindow);
        }
    }
}