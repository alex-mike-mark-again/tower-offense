using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

using TowerOffense.Window;


namespace TowerOffense {
    public class TOGame : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int SCREENX = 250, SCREENY = 250;
        private List<TOWindow> _windows;

        public TOGame() {
            _graphics = new GraphicsDeviceManager(this);
            _windows = new List<TOWindow>();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {

            _windows.Add(new TOWindow(this, 120, 120));
            _windows.Add(new TOWindow(this, 120, 120));

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {

            foreach (var window in _windows) {
                GraphicsDevice.SetRenderTarget(window.RenderTarget);
                GraphicsDevice.Clear(Color.DarkSlateGray);

                window.RenderTarget.Present();
            }

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            // TODO Draw primary screen here
            base.Draw(gameTime);
        }
    }
}
