using NuGet.Packaging.Rules;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using TaikoTools.ToolRuntime.Game.ToolAPI;

namespace TaikoTools.ToolRuntime.Game {
    public class ToolButton : CompositeDrawable {
        private TaikoTool _tool;
        private Vector2   _position;

        private Box _backgroundBox;

        public override bool HandlePositionalInput { get; } = true;
        public override bool HandleNonPositionalInput { get; } = true;

        public ToolButton(TaikoTool tool, Vector2 position) {
            this._tool     = tool;
            this._position = position;
        }

        [BackgroundDependencyLoader]
        private void load() {
            this.InternalChild = new ClickableContainer {
                RelativePositionAxes = Axes.Both,
                RelativeSizeAxes     = Axes.Both,
                Origin               = Anchor.TopLeft,
                Children = new Drawable[] {
                    this._backgroundBox = new ClickableBox {
                        Position = this._position,
                        Size     = new Vector2(1366, 64),
                        Colour = Color4.DimGray,
                        OnOnClick = () => {
                            this._tool.Initialize();

                            Global.ScreenStack.Push(this._tool.Run());
                        }
                    },
                    new SpriteText {
                        Position = this._position + new Vector2(10, 20),
                        Text     = $"{this._tool.ToolName} :: made by {this._tool.ToolAuthor}, Version {this._tool.ToolVersionString}",
                        Font     = FontUsage.Default.With(size: 25)
                    }
                }
            };
        }

        protected override bool OnHover(HoverEvent e) {
            this.FlashColour(Color4.Gray, 100);
            base.OnHover(e);
            return true;
        }

        protected override bool OnClick(ClickEvent e) {
            this.FlashColour(Color4.Gray, 100);
            base.OnClick(e);
            return true;
        }

    }
}
