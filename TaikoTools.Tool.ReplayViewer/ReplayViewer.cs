﻿using PeppyCodeEngineGL.Engine.Graphics;
using TaikoTools.ToolRuntime;

namespace TaikoTools.Tool.ReplayViewer {
    public class ReplayViewer : TaikoTool {
        public override string ToolName { get; set; } = "Taiko Replay Viewer";
        public override string ToolAuthor { get; set; } = "Eevee";
        public override string ToolVersionString { get; set; } = "alpha 1.0";
        public override Screen Run() => new ReplayViewerScreen();
    }
}
