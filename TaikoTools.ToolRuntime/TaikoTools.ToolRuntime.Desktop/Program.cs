using osu.Framework.Platform;
using osu.Framework;
using TaikoTools.ToolRuntime.Game;

namespace TaikoTools.ToolRuntime.Desktop {
    public static class Program {
        public static void Main() {
            using (GameHost host = Host.GetSuitableHost(@"TaikoTools"))
                using (osu.Framework.Game game = new Runtime())
                    host.Run(game);
        }
    }
}
