using LuneWoL.PressureCheckFolder.Mode2;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.PressureCheckFolder
{
    public static class LWoLDepthUtils
    {
        public static PressureModeTwo ModeTwo;
        public static void asd()
        {
            LP.TryGetModPlayer(out PressureModeTwo result);
            ModeTwo = result;
        }
    }
}
