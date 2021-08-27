using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using TaikoTools.Components.FrameTimeline;
using TaikoTools.ReplayParser;

namespace TaikoTools.Tool.ReplayViewer {
    public class ReplayViewerScreen : Screen {
        [BackgroundDependencyLoader]
        private void load() {
            InternalChildren = new Drawable[] {
                //soon to be background
                new Box {
                    Colour = Color4.Violet, RelativeSizeAxes = Axes.Both,
                },
                new SpriteText {
                    Y      = 20,
                    Text   = "Taiko Replay Viewer",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font   = FontUsage.Default.With(size: 40)
                },
                new FrameTimeline( new Vector2(1366, 768), new Vector2(1366, 480f), new List<ReplayClick>())
            };
        }
    }
}
