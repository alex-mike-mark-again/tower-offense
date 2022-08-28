using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;
using TowerOffense.Scenes;
using Microsoft.Xna.Framework.Graphics;

namespace TowerOffense.Displays {
    public class ScoreDisplay : SceneWindow {
        private SpriteFont _font;
        private string _text;

        public ScoreDisplay(Scene scene, Point position, Point size) : base(scene, position, size) {
            _font = TOGame.Instance.Content.Load<SpriteFont>("Fonts/HpDisplay");
        }

        public override void Update(GameTime gameTime){
            _text = TOGame.PlayerManager.Score.ToString();
            base.Update(gameTime);
        }
        public override void Render(GameTime gameTime){
            Vector2 textMiddlePoint = _font.MeasureString(_text) / 2;
            Vector2 position = new Vector2(48,48); // some work to center this would be cool
            DrawString(_font, _text, position, Color.White);
            base.Render(gameTime);
        }
    }
}

// other font drawing info https://docs.monogame.net/articles/content/adding_ttf_fonts.html
