using LuneWoL.PressureCheckFolder.Mode2;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.PressureCheckFolder
{
    public static class LWoLDepthUtils
    {
        public static PressureModeTwo pointSetter = LP.GetModPlayer<PressureModeTwo>();
        public static PressureModeTwo CalcedRM = LP.GetModPlayer<PressureModeTwo>();
    }
}
