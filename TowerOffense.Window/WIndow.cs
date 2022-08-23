using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerOffense.Window {
    class TOWindow {

        public SwapChainRenderTarget RenderTarget { get => _renderTarget; }

        private Form _form;
        private SwapChainRenderTarget _renderTarget;

        public TOWindow(Game game, int width, int height) {

            _form = (Form)Form.FromHandle(GameWindow.Create(game, width, height).Handle);

            _form.Visible = true;
            _form.ShowIcon = false;
            _form.MinimizeBox = false;
            _form.MaximizeBox = false;
            _form.Text = "";
            _form.FormBorderStyle = FormBorderStyle.FixedSingle;


            _renderTarget = new SwapChainRenderTarget(
                game.GraphicsDevice,
                _form.Handle,
                _form.Bounds.Width,
                _form.Bounds.Height,
                false,
                SurfaceFormat.Color,
                DepthFormat.Depth24Stencil8,
                1,
                RenderTargetUsage.PlatformContents,
                PresentInterval.Default);
        }
    }
}