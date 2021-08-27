using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace TaikoTools.ToolRuntime.Game.Tests {
    public class TestBrowser : GameBase {
        protected override void LoadComplete() {
            base.LoadComplete();

            AddRange(new Drawable[] {
                new osu.Framework.Testing.TestBrowser("TaikoTools.ToolRuntime"), new CursorContainer()
            });
        }

        public override void SetHost(GameHost host) {
            base.SetHost(host);
            host.Window.CursorState |= CursorState.Hidden;
        }
    }
}
