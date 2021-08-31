using System;

namespace TaikoTools.ToolRuntime {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new TaikoTools())
                game.Run();
        }
    }
}
