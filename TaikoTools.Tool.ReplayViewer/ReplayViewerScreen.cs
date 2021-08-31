
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Graphics;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;
using TaikoTools.Components.FrameTimeline;
using TaikoTools.ReplayParser;

namespace TaikoTools.Tool.ReplayViewer {
    public class ReplayViewerScreen : Screen {
        public override void Initialize() {
            pSprite purpleBackground = new pSprite(pEngineGame.WhitePixel, OriginTypes.TopLeft, ClockTypes.Game, new Vector2(0, 0), 1f, true, Color.BlueViolet) {
                VectorScale    = new Vector2(pEngineGame.WindowWidth, pEngineGame.WindowHeight),
                UseVectorScale = true
            };

            this.SpriteManager.Add(purpleBackground);

            List<ReplayClick> clicks = new ReplayParser.ReplayParser("replay.osr").ParseReplay();

            FrameTimeline timeline = new FrameTimeline(clicks);

            this.SpriteManager.Add(timeline);

            base.Initialize();
        }

        public override void Draw(GameTime gameTime) {
            this.SpriteManager.Draw();

            base.Draw(gameTime);
        }
    }
}
