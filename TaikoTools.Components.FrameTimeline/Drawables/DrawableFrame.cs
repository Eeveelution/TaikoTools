using Microsoft.Xna.Framework;
using OsuParsers.Enums.Replays;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Audio;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;
using TaikoTools.ReplayParser;

namespace TaikoTools.Components.FrameTimeline {
    public class DrawableFrame {
        private pSprite       _frameSprite;
        private ReplayClick   _click;
        private FrameTimeline _timeline;

        public int Time;
        public DrawableFrame(FrameTimeline timeline, ReplayClick click) {
            this._click    = click;
            this._timeline = timeline;

            this.UpdateSprite(timeline);

            timeline.CurrentTime.ValueChanged += (_, _) => {
                UpdateSprite(this._timeline);
            };
        }

        public void UpdateSprite(FrameTimeline timeline) {
            double pixelLength = (timeline.TimeToTimelinePos(timeline.CurrentTime, this._click.UpTime) - timeline.TimeToTimelinePos(timeline.CurrentTime, this._click.DownTime));
            //for testing ill just draw a box later ill replace it with something nicer looking
            Color lineColor = ((this._click.Key == TaikoKeys.lBlue) || (this._click.Key == TaikoKeys.rBlue)) ? Color.Cyan : Color.Red;

            this._frameSprite = new pSprite(pEngineGame.WhitePixel, OriginTypes.TopLeft, ClockTypes.Audio, new Vector2((float)timeline.TimeToTimelinePos(timeline.CurrentTime, this.Time), 120), 0.1f, true, lineColor) {
                UseVectorScale = true,
                VectorScale = new Vector2((float)pixelLength, 32)
            };
        }

        public pSprite GetSprite() => this._frameSprite;
    }
}
