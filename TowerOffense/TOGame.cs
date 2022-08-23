using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

using TowerOffense.Window;
using System;
using TowerOffense.Scenes;
using Microsoft.Xna.Framework.Content;

namespace TowerOffense {
    public class TOGame : Game {

        public static TOGame Instance;

        public static SceneManager Scenes { get => Instance._scenes; }
        public static SpriteBatch SpriteBatch { get => Instance._spriteBatch; }

        private SceneManager _scenes;
        private Queue<Action> _commandQueue;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Random _random;


        private List<TOWindow> _windows;

        public TOGame() {

            Instance = this;

            _scenes = new SceneManager();
            _commandQueue = new Queue<Action>();
            _graphics = new GraphicsDeviceManager(this);
            _windows = new List<TOWindow>();
            _random = new Random();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// A callback that is invoked at the beginning of the next game tick
        /// </summary>
        /// <param name="action"></param>
        public static void Command(Action action) {
            Instance._commandQueue.Enqueue(action);
        }

        protected override void Initialize() {

            for (int i = 0; i < 25; i++) {
                var window = new TOWindow(this, 120, 120);
                window.Position = new Point(
                    _random.Next(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 120),
                    _random.Next(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 120)
                );
                _windows.Add(window);
            }

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime) {

            System.Console.WriteLine(gameTime.TotalGameTime.ToString());

            while (_commandQueue.Count > 0) {
                _commandQueue.Dequeue().Invoke();
            }

            Scenes.CurrentScene.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // window movement test
            foreach (var window in _windows) {
                window.Position = window.Position += new Point(_random.Next(-1, 2), _random.Next(-1, 2));
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {

            // foreach (var window in _windows) {
            //     GraphicsDevice.SetRenderTarget(window.RenderTarget);
            //     GraphicsDevice.Clear(new Color(40, 45, 50));

            //     window.RenderTarget.Present();
            // }

            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            Scenes.CurrentScene.Render(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
