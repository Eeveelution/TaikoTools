using Microsoft.Xna.Framework;
using PeppyCodeEngineGL.Engine;
using TaikoTools.ToolRuntime.Screens;

namespace TaikoTools.ToolRuntime {
    public class TaikoTools : pEngineGame {
        public TaikoTools() : base(new ToolScreen()) {
            this.IsMouseVisible = true;
        }
    }
}
