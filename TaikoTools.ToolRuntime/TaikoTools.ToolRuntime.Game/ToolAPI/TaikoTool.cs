using System;
using osu.Framework.Screens;

namespace TaikoTools.ToolRuntime.Game.ToolAPI {
    public abstract class TaikoTool {
        /// <summary>
        /// The tools name, for example "Taiko Replay Viewer"
        /// </summary>
        public abstract string ToolName          { get; set; }
        /// <summary>
        /// The tools author(s), for example "Eevee & the oldsu! team"
        /// </summary>
        public abstract string ToolAuthor        { get; set; }
        /// <summary>
        /// The Version of your tool, could be useful to have, for example 1.5.2
        /// </summary>
        public abstract string ToolVersionString { get; set; }
        /// <summary>
        /// This method is called when the user pressed the Tool button
        /// This method is used for Preparing for launch, and at the very end,
        /// return the Tool Screen you wish the User to see
        /// </summary>
        /// <returns></returns>
        public abstract Screen Run();
        /// <summary>
        /// Configuration Manager, you could write it yourself but why when I can implement it for you /shrug
        /// </summary>
        public ConfigurationManager Config;
        /// <summary>
        /// This gets run before <see cref="Run"/> does, it basically serves to Initialize <see cref="Config"/>
        /// </summary>
        internal void Initialize() {
            this.Config = new($"{this.AssemblyPath}.cfg");
        }
        /// <summary>
        /// .tkt File Path, used for neater Configuration management
        /// </summary>
        internal string AssemblyPath = Environment.CurrentDirectory;
    }
}
