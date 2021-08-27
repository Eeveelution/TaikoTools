using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;
using TaikoTools.ReplayParser;

namespace TaikoTools.Tools.Components.FrameTimeline {
    public class FrameTimeline : CompositeDrawable {
        private Container _frameContainer;

        private Vector2 _targetSize;
        private Vector2 _windowSize;

        public FrameTimeline(Vector2 windowSize, Vector2 targetSize, List<ReplayClick> replayClicks) {
            this._targetSize = targetSize;
            this._windowSize = windowSize;
        }

        [BackgroundDependencyLoader]
        private void load() {
            InternalChild = this._frameContainer = new Container {
                Anchor               = Anchor.BottomCentre,
                RelativePositionAxes = Axes.Both,
                RelativeSizeAxes     = Axes.Both,
                Origin               = Anchor.TopLeft,
                Position             = new Vector2(0, this._windowSize.Y - this._targetSize.Y),
                Children = new [] {
                    new Box() {
                        Position = new Vector2(0, this._targetSize.Y),
                        Size     = this._targetSize,
                        Colour   = Color4.Red
                    },
                }
            };
        }
    }
}
