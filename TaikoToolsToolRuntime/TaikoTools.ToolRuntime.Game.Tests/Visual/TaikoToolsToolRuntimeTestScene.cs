using osu.Framework.Testing;

namespace TaikoTools.ToolRuntime.Game.Tests.Visual {
    public class TaikoToolsToolRuntimeTestScene : TestScene {
        protected override ITestSceneTestRunner CreateRunner() => new TaikoToolsToolRuntimeTestSceneTestRunner();

        private class TaikoToolsToolRuntimeTestSceneTestRunner : TaikoToolsToolRuntimeGameBase, ITestSceneTestRunner {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete() {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
