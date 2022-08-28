using Microsoft.Xna.Framework;
using TowerOffense.Objects.Base;
using Microsoft.Xna.Framework.Graphics;

namespace TowerOffense.Objects {
    public class HpDisplay : SceneWindow {
        private SpriteFont _font;
        private string _text;

        public HpDisplay(Point position, Point size) : base(position, size) {
            _font = TOGame.Instance.Content.Load<SpriteFont>("Fonts/HpDisplay");
        }

        public override void Update(GameTime gameTime){
            _text = TOGame.PlayerManager.Hp.ToString();
            base.Update(gameTime);
        }
        public override void Render(GameTime gameTime){
            Vector2 textMiddlePoint = _font.MeasureString(_text) / 2;
            Vector2 position = new Vector2(48,48); // some work to center this would be cool
            DrawString(_font, _text, position, Color.Red);
            base.Render(gameTime);
        }
    }
}

// other font drawing info https://docs.monogame.net/articles/content/adding_ttf_fonts.html
