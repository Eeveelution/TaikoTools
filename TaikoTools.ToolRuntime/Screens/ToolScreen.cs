using Microsoft.Xna.Framework;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Graphics;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;

namespace TaikoTools.ToolRuntime.Screens {
    public class ToolScreen : Screen {
        public override void Initialize() {
            pSprite purpleBackground = new pSprite(pEngineGame.WhitePixel, OriginTypes.TopLeft, ClockTypes.Game, new Vector2(0, 0), 0f, true, Color.BlueViolet) {
                VectorScale = new Vector2(pEngineGame.WindowWidth, pEngineGame.WindowHeight),
                UseVectorScale = true
            };

            this.SpriteManager.Add(purpleBackground);
        }
    }
}
