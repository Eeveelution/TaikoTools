using PeppyCodeEngineGL.Engine.Graphics;

namespace TaikoTools.ToolRuntime {
    public abstract class TaikoTool {
        /// <summary>
        /// The tools name, eg. Taiko Replay Viewer,
        /// </summary>
        public abstract string ToolName { get; set; }
        /// <summary>
        /// Tool author, eg Eevee
        /// </summary>
        public abstract string ToolAuthor { get; set; }
        /// <summary>
        /// Tool Version string, something like 1.5.2
        /// </summary>
        public abstract string ToolVersionString { get; set; }
        /// <summary>
        /// This method is supposed to Initialize anything it needs and then return with a Screen to run
        /// </summary>
        /// <returns></returns>
        public abstract Screen Run();
    }
}
