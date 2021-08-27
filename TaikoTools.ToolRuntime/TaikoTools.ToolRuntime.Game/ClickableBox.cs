using System;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;

namespace TaikoTools.ToolRuntime.Game {
    public class ClickableBox : Box {
        public override bool HandlePositionalInput { get; } = true;
        public override bool HandleNonPositionalInput { get; } = true;

        public Action OnOnClick;

        protected override bool OnClick(ClickEvent e) {
            base.OnClick(e);

            this.OnOnClick();

            return true;
        }
    }
}
