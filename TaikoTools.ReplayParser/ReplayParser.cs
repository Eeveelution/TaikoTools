using System;
using System.Collections.Generic;
using OsuParsers.Decoders;
using OsuParsers.Enums.Replays;
using OsuParsers.Replays;
using OsuParsers.Replays.Objects;

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

            for (int currentTime = 0; currentTime != this._workingReplay.ReplayFrames[^1].Time + 100; currentTime++) {
                ReplayFrame currentFrame = this._workingReplay.ReplayFrames.Find(frame => frame.Time == currentTime);

                if (currentFrame != null) {
                    if (currentFrame.TaikoKeys.IsKeyDown(TaikoKeys.lBlue)) {
                        ReplayClick foundClick = currentlyHeld.Find(click => click.Key == TaikoKeys.lBlue);

                        if (foundClick != null) {
                            foundClick.Frames.Add(currentFrame);
                            foundClick.UpTime       = currentTime;
                            foundClick.LastSeenTime = currentTime;
                        } else {
                            ReplayClick newClick = new() {
                                Frames       = new List<ReplayFrame>(),
                                Key          = TaikoKeys.lBlue,
                                DownTime     = currentTime,
                                LastSeenTime = currentTime,
                                UpTime       = currentTime
                            };

                            currentlyHeld.Add(newClick);
                        }
                    }
                    else if (currentFrame.TaikoKeys.IsKeyDown(TaikoKeys.lRed)) {
                        ReplayClick foundClick = currentlyHeld.Find(click => click.Key == TaikoKeys.lRed);

                        if (foundClick != null) {
                            foundClick.Frames.Add(currentFrame);
                            foundClick.UpTime       = currentTime;
                            foundClick.LastSeenTime = currentTime;
                        } else {
                            ReplayClick newClick = new() {
                                Frames       = new List<ReplayFrame>(),
                                Key          = TaikoKeys.lRed,
                                DownTime     = currentTime,
                                LastSeenTime = currentTime,
                                UpTime       = currentTime
                            };

                            currentlyHeld.Add(newClick);
                        }
                    }
                    else if (currentFrame.TaikoKeys.IsKeyDown(TaikoKeys.rRed)) {
                        ReplayClick foundClick = currentlyHeld.Find(click => click.Key == TaikoKeys.rRed);

                        if (foundClick != null) {
                            foundClick.Frames.Add(currentFrame);
                            foundClick.UpTime       = currentTime;
                            foundClick.LastSeenTime = currentTime;
                        } else {
                            ReplayClick newClick = new() {
                                Frames       = new List<ReplayFrame>(),
                                Key          = TaikoKeys.rRed,
                                DownTime     = currentTime,
                                LastSeenTime = currentTime,
                                UpTime       = currentTime
                            };

                            currentlyHeld.Add(newClick);
                        }
                    }
                    else if (currentFrame.TaikoKeys.IsKeyDown(TaikoKeys.rBlue)) {
                        ReplayClick foundClick = currentlyHeld.Find(click => click.Key == TaikoKeys.rBlue);

                        if (foundClick != null) {
                            foundClick.Frames.Add(currentFrame);
                            foundClick.UpTime       = currentTime;
                            foundClick.LastSeenTime = currentTime;
                        } else {
                            ReplayClick newClick = new() {
                                Frames       = new List<ReplayFrame>(),
                                Key          = TaikoKeys.rBlue,
                                DownTime     = currentTime,
                                LastSeenTime = currentTime,
                                UpTime       = currentTime
                            };

                            currentlyHeld.Add(newClick);
                        }
                    }
                }

                for (int i = 0; i != currentlyHeld.Count; i++) {
                    ReplayClick heldKey = currentlyHeld[i];

                    if ((currentTime - heldKey.LastSeenTime) > 18) {
                        totalClicks.Add(heldKey);

                        currentlyHeld.Remove(heldKey);
                    }
                }
            }

            return totalClicks;
        }
    }
}
