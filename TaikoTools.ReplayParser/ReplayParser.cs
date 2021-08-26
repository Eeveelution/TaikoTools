using System;
using System.Collections.Generic;
using OsuParsers.Decoders;
using OsuParsers.Replays;

namespace TaikoTools.ReplayParser
{
    public class ReplayParser {
        private Replay _workingReplay;

        public ReplayParser(Replay replay) {
            this._workingReplay = replay;
        }

        public ReplayParser(string osrFilename) {
            this._workingReplay = ReplayDecoder.Decode(osrFilename);
        }

        public List<ReplayClick> ParseReplay() {
            List<ReplayClick> totalClicks = new();
            List<ReplayClick> currentlyHeld = new();

            for (int i = 0; i != this._workingReplay.ReplayFrames[this._workingReplay.ReplayFrames.Count - 1].Time + 100) {

            }
        }
    }
}
