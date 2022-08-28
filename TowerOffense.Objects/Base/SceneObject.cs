using Microsoft.Xna.Framework;

namespace TowerOffense.Objects.Base {
    public abstract class SceneObject {

        public bool IsDestroyed { get; private set; }

        public SceneObject() {}

        public virtual void Destroy() {
            IsDestroyed = true;
        }

        public abstract void Update(GameTime gameTime);
    }
}