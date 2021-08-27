using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace TaikoTools.ToolRuntime.Game {
    public class Runtime : GameBase {
        public ScreenStack ScreenStack;

        [BackgroundDependencyLoader]
        private void load() {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Child = ScreenStack = new ScreenStack {
                RelativeSizeAxes = Axes.Both
            };

            Global.ScreenStack = this.ScreenStack;
        }

        protected override void LoadComplete() {
            base.LoadComplete();

            ScreenStack.Push(new MainScreen());
        }
    }
}
