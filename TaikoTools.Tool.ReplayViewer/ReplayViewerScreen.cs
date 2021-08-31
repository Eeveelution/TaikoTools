
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PeppyCodeEngineGL.Engine.Graphics;
using TaikoTools.Components.FrameTimeline;
using TaikoTools.ReplayParser;

namespace TaikoTools.Tool.ReplayViewer {
    public class ReplayViewerScreen : Screen {
        public override void Initialize() {
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
