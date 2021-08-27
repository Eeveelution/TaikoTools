using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;
using TaikoTools.ReplayParser;

namespace TaikoTools.Components.FrameTimeline {
    public class FrameTimeline : CompositeDrawable {
        private Container _frameContainer;

        public Vector2 TargetSize;
        public Vector2 WindowSize;

        public FrameTimeline(Vector2 windowSize, Vector2 targetSize, List<ReplayClick> replayClicks) {
            this.TargetSize = targetSize;
            this.WindowSize = windowSize;
        }

        [BackgroundDependencyLoader]
        private void load() {
            this.InternalChild = this._frameContainer = new Container {
                Anchor               = Anchor.BottomCentre,
                RelativePositionAxes = Axes.Both,
                RelativeSizeAxes     = Axes.Both,
                Origin               = Anchor.TopLeft,
                Position             = new Vector2(0, this.WindowSize.Y - this.WindowSize.Y),
                Children = new [] {
                    new Box() {
                        Position = new Vector2(0, this.TargetSize.Y),
                        Size     = this.TargetSize,
                        Colour   = Color4.Red
                    },
                },
            };
        }
    }
}
