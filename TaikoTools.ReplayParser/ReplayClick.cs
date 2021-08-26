using System.Collections.Generic;
using OsuParsers.Enums.Replays;
using OsuParsers.Replays.Objects;

namespace TaikoTools.ReplayParser {
    public class ReplayClick {
        /// <summary>
        /// What Key is this Click
        /// </summary>
        public TaikoKeys Key;
        /// <summary>
        /// Frames Belonging to this Click
        /// </summary>
        public List<ReplayFrame> Frames;
        /// <summary>
        /// When did the Click Begin
        /// </summary>
        public int               DownTime;
        /// <summary>
        /// When did the Click End
        /// </summary>
        public int               UpTime;
        /// <summary>
        /// REPLAY PARSER SPECIFIC VARIABLE
        /// </summary>
        public int               LastSeenTime;
    }
}
