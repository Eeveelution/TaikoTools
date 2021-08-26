using OsuParsers.Enums.Replays;

namespace TaikoTools.ReplayParser {
    public static class FlagHelper {
        public static bool IsKeyDown(this TaikoKeys value, TaikoKeys flag) => (value & flag) == flag;
    }
}
