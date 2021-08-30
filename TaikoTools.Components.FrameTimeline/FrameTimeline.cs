
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using PeppyCodeEngineGL.Engine.Audio;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;

namespace TaikoTools.Components.FrameTimeline {
    public class FrameTimeline : pDrawable {
        public double TimelineRange = 2000.0;

        private List<DrawableFrame> _drawableFrames = new();

        public double TimeToTimelinePos(double currentTime, double time) {
            double timelineLeftBound = currentTime  - this.TimelineRange / 2.0;
            double timelineRightBound = currentTime + this.TimelineRange / 2.0;

            return Math.Min(Math.Max((0.0 + ((this.TimelineRange - timelineLeftBound) / this.TimelineRange) * this.TimelineRange / 2.0), 0.0), 0.0 + this.TimelineRange / 2.0);
        }

        public override void Draw(SpriteBatch batch, SpriteManagerArgs args) {
            double minTime = AudioController.Time - this.TimelineRange / 2.0;
            double maxTime = AudioController.Time + this.TimelineRange / 2.0;

            if (AudioController.Time < 1500) {
                minTime = 0;
            }
        }
    }
}
