using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using TowerOffense.Scenes.Example.Objects;

namespace TowerOffense.Scenes.Example {
    public class ExampleScene : Scene {
        public ExampleScene() : base() {

            var worm = new Worm(this, new Point(400, 400), new Point(120, 120), 10);

            worm.Controllable = false;

            AddObject(worm);
            AddObjects(worm.GetSegments());

        }
    }
}