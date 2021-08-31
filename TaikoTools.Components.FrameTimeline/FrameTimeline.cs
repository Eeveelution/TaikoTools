
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Audio;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;
using PeppyCodeEngineGL.Engine.Helpers;
using PeppyCodeEngineGL.Engine.Input;
using TaikoTools.ReplayParser;

namespace TaikoTools.Components.FrameTimeline {
    public class FrameTimeline : pDrawable {
        public Bindable<double> TimelineRange = new Bindable<double>(2000.0);
        public Bindable<int>    CurrentTime   = new Bindable<int>(0);

        private List<DrawableFrame> _drawableFrames = new();

        private SpriteManager _frameTimelineManager = new();

        public FrameTimeline(List<ReplayClick> replayClicks) {
            this.AlwaysDraw = true;
            this.CurrentColour = Color.White;

            for(int i = 0; i != replayClicks.Count; i++)
                this._drawableFrames.Add(new DrawableFrame(this, replayClicks[i]));

            InputManager.OnKeyPress += (sender, args) => {
                if (args.Key == Keys.Right)
                    this.CurrentTime += 250;
                if (args.Key == Keys.Left)
                    this.CurrentTime -= 250;
            };
        }

        public double TimeToTimelinePos(double currentTime, double time) {
            double timelineLeftBound = currentTime  - this.TimelineRange / 2.0;
            double timelineRightBound = currentTime + this.TimelineRange / 2.0;

            return Math.Min(Math.Max((0.0 + ((time - timelineLeftBound) / this.TimelineRange) * this.TimelineRange / 2.0), 0.0), 0.0 + this.TimelineRange / 2.0);
        }

        public override void Draw(SpriteBatch batch, SpriteManagerArgs args) {
            double minTime = this.CurrentTime - this.TimelineRange / 2.0;
            double maxTime = this.CurrentTime + this.TimelineRange / 2.0;

            if (AudioController.Time < 1500) {
                minTime = 0;
            }

            List<DrawableFrame> toDraw = this._drawableFrames.FindAll(frame => frame.Time >= minTime && frame.Time <= maxTime);

            this._frameTimelineManager.Clear();

            for (int i = 0; i != toDraw.Count; i++)
                this._frameTimelineManager.Add(toDraw[i]);

            this._frameTimelineManager.Draw(false);
        }

        public void Update() {
            if (AudioController.MasterAudioTrack.IsPlaying)
                this.CurrentTime = AudioController.Time;
        }
    }
}
