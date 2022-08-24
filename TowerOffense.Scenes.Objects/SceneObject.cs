using Microsoft.Xna.Framework;

namespace TowerOffense.Scenes.Objects {
    public abstract class SceneObject {


        public bool isDestroyed { get; private set; } = false;

        protected Scene Scene;

        public SceneObject(Scene scene) {
            Scene = scene;
        }

        public void Destroy() {
            isDestroyed = true;
        }

        public abstract void Update(GameTime gameTime);
    }
}