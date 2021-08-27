using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace TaikoTools.ToolRuntime.Game.Tests {
    public class TaikoToolsToolRuntimeTestBrowser : TaikoToolsToolRuntimeGameBase {
        protected override void LoadComplete() {
            base.LoadComplete();

            AddRange(new Drawable[] {
                new TestBrowser("TaikoTools.ToolRuntime"), new CursorContainer()
            });
        }

        public override void SetHost(GameHost host) {
            base.SetHost(host);
            host.Window.CursorState |= CursorState.Hidden;
        }
    }
}
