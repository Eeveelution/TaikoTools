using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using PeppyCodeEngineGL.Engine;
using PeppyCodeEngineGL.Engine.Graphics;
using PeppyCodeEngineGL.Engine.Graphics.Sprites;
using PeppyCodeEngineGL.Engine.State;

namespace TaikoTools.ToolRuntime.Screens {
    public class ToolScreen : Screen {
        public override void Initialize() {
            pSprite purpleBackground = new pSprite(pEngineGame.WhitePixel, OriginTypes.TopLeft, ClockTypes.Game, new Vector2(0, 0), 1f, true, Color.BlueViolet) {
                VectorScale = new Vector2(pEngineGame.WindowWidth, pEngineGame.WindowHeight),
                UseVectorScale = true
            };

            this.SpriteManager.Add(purpleBackground);

            List<TaikoTool> taikoTools = new();

            string[] toolAssemblies = Directory.GetFiles("Tools/", "*.tkt");

            foreach (string assembly in toolAssemblies) {
                Assembly loadedAssembly = Assembly.LoadFile(Path.GetFullPath(assembly));

                List<Type> types = loadedAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(TaikoTool))).ToList();

                foreach (Type taikoToolType in types) {
                    TaikoTool tool = (TaikoTool) Activator.CreateInstance(taikoToolType);
                    taikoTools.Add(tool);
                }
            }

            string[] externAssemblies = Directory.GetFiles("Tools/", "*.dll");

            foreach (string assembly in externAssemblies) {
                Assembly loadedAssembly = Assembly.LoadFrom(Path.GetFullPath(assembly));
            }

            int height = 96;

            foreach (TaikoTool tool in taikoTools) {
                EventHandler onClick = (_, _) => {
                    ScreenManager.ChangeScreen(tool.Run());
                };

                pSprite toolBackground = new pSprite(pEngineGame.WhitePixel, OriginTypes.TopLeft, ClockTypes.Game, new Vector2(0, height), 0.5f, true, new Color(42, 42, 42)) {
                    VectorScale    = new Vector2(pEngineGame.WindowWidth, 56),
                    UseVectorScale = true,
                    IsClickable    = true,
                };

                string text = $"{tool.ToolName} Version {tool.ToolVersionString} created by {tool.ToolAuthor}";

                pText toolText = new pText(text, 16f, new Vector2(10, height + 16), Vector2.Zero, 0.4f, true, Color.White, false);

                toolBackground.OnClick += onClick;
                toolText.OnClick       += onClick;

                this.SpriteManager.Add(toolBackground);
                this.SpriteManager.Add(toolText);

                height += 72;
            }



            base.Initialize();
        }
    }
}
