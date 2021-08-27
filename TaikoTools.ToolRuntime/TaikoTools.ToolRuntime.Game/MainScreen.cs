using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using TaikoTools.Components.FrameTimeline;
using TaikoTools.ReplayParser;
using TaikoTools.ToolRuntime.Game.ToolAPI;

namespace TaikoTools.ToolRuntime.Game {
    [LongRunningLoad]
    public class MainScreen : Screen {
        [BackgroundDependencyLoader]
        private void load() {
            List<TaikoTool> taikoTools = new();

            int height = 128;

            string[] assemblies = Directory.GetFiles("Tools/", "*.tkt");

            foreach (string assembly in assemblies) {
                Assembly loadedAssembly = Assembly.LoadFile(Path.GetFullPath(assembly));

                List<Type> types = loadedAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(TaikoTool))).ToList();

                foreach (Type taikoToolType in types) {
                    TaikoTool tool = (TaikoTool) Activator.CreateInstance(taikoToolType);
                    tool.AssemblyPath = Path.GetFullPath(assembly);
                    taikoTools.Add(tool);
                }
            }

            InternalChildren = new Drawable[] {
                //soon to be background
                new Box {
                    Colour = Color4.Violet, RelativeSizeAxes = Axes.Both,
                },
                new SpriteText {
                    Y      = 20,
                    Text   = "Taiko Tools",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font   = FontUsage.Default.With(size: 40)
                },
            };

            foreach (TaikoTool taikoTool in taikoTools) {
                AddInternal(new ToolButton(taikoTool, new Vector2(0, height)));

                height += 192;
            }
        }
    }
}
