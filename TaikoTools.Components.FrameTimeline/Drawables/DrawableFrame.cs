using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OsuParsers.Enums.Replays;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Audio;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;
using TaikoTools.ReplayParser;

namespace TaikoTools.Components.FrameTimeline {
    public class DrawableFrame : pSprite {
        private ReplayClick   _click;
        private FrameTimeline _timeline;

        public int Time;
        public DrawableFrame(FrameTimeline timeline, ReplayClick click) {
            this.AlwaysDraw     = true;
            this.UseVectorScale = true;
            this.Texture        = pEngineGame.WhitePixel;
            this.OriginType     = OriginTypes.TopLeft;
            this.Clock          = ClockTypes.Game;
            this.CurrentScale   = 1f;

            this._click         = click;
            this._timeline      = timeline;

            this.Time = click.DownTime;

            this.UpdateSprite(timeline);

            timeline.CurrentTime.ValueChanged += (_, _) => {
                this.UpdateSprite(this._timeline);
            };

            timeline.TimelineRange.ValueChanged += (_, _) => {
                this.UpdateSprite(this._timeline);
            };
        }

        public void UpdateSprite(FrameTimeline timeline) {
            double pixelLength = (timeline.TimeToTimelinePos(timeline.CurrentTime, this._click.UpTime) - timeline.TimeToTimelinePos(timeline.CurrentTime, this._click.DownTime));
            //for testing ill just draw a box later ill replace it with something nicer looking
            Color lineColor = ((this._click.Key == TaikoKeys.lBlue) || (this._click.Key == TaikoKeys.rBlue)) ? Color.Cyan : Color.Red;

            this.VectorScale     = new Vector2((float) pixelLength, 32);
            this.CurrentPosition = new Vector2((float) timeline.TimeToTimelinePos(timeline.CurrentTime, this.Time), 160);
            this.CurrentColour   = lineColor;
        }
    }
}
