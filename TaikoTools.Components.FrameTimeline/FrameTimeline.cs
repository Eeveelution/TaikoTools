using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using TaikoTools.ReplayParser;

namespace TaikoTools.Components.FrameTimeline {
    public class FrameTimeline : CompositeDrawable {
        public override bool HandlePositionalInput { get; } = true;

        private Container _frameContainer;

        public Vector2 TargetSize;
        public Vector2 WindowSize;

        public FrameTimeline(Vector2 windowSize, Vector2 targetSize, List<ReplayClick> replayClicks) {
            this.TargetSize = targetSize;
            this.WindowSize = windowSize;
        }

        [BackgroundDependencyLoader]
        private void load() {
            this.Size     = this.TargetSize;
            this.Position = new Vector2(0, this.WindowSize.Y - this.TargetSize.Y);

            this.InternalChild = this._frameContainer = new Container {
                Anchor   = Anchor.TopLeft,
                Size     = this.TargetSize,
                Origin   = Anchor.TopLeft,
                Children = new [] {
                    new Box() {
                        Size     = this.TargetSize,
                        Colour   = Color4.Red,

                    },
                },
            };
        }

        protected override bool OnClick(ClickEvent e) {
            base.OnClick(e);
            return true;
        }
    }
}
