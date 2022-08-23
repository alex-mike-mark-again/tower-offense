using Microsoft.Xna.Framework;

namespace TowerOffense.Scenes.Objects {
    public abstract class ObjectBase {

        public bool isDestroyed { get; private set; } = false;

        public void Destroy() {
            isDestroyed = true;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Render(GameTime gameTime);
    }
}