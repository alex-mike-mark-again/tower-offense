using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TowerOffense.Scenes.Objects;

namespace TowerOffense.Scenes {



    public class Scene {

        private List<ObjectBase> _objects = new List<ObjectBase>();

        public void AddObject(ObjectBase obj) {
            _objects.Add(obj);
        }

        public void Update(GameTime gameTime) {
            _objects.RemoveAll(obj => obj.isDestroyed);
            foreach (var obj in _objects) {
                obj.Update(gameTime);
            }
        }

        public void Render(GameTime gameTime) {
            _objects.RemoveAll(obj => obj.isDestroyed);
            foreach (var obj in _objects) {
                obj.Render(gameTime);
            }
        }

        public virtual void Init() { }
    }
}