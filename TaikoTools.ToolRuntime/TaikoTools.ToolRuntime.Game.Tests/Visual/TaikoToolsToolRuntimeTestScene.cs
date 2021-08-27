using osu.Framework.Testing;

namespace TaikoTools.ToolRuntime.Game.Tests.Visual {
    public class TaikoToolsToolRuntimeTestScene : TestScene {
        protected override ITestSceneTestRunner CreateRunner() => new TestSceneTestRunner();

        private class TestSceneTestRunner : GameBase, ITestSceneTestRunner {
            private osu.Framework.Testing.TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete() {
                base.LoadAsyncComplete();
                Add(runner = new osu.Framework.Testing.TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
