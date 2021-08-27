using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace TaikoTools.ToolRuntime.Game.Tests.Visual {
    public class TestSceneTaikoToolsToolRuntimeGame : TaikoToolsToolRuntimeTestScene {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        private TaikoToolsToolRuntimeGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host) {
            game = new TaikoToolsToolRuntimeGame();
            game.SetHost(host);

            Add(game);
        }
    }
}
