using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Common.LWoLSystems
{
    public partial class LWoLSystem : ModSystem
    {
        public bool b = true;

        public override void PreUpdateInvasions()
        {
            LongerInvasions();
        }

        public override void AddRecipes()
        {
            AddCoffee();
            AddMusicBox();
        }

        public override void ModifyLightingBrightness(ref float scale)
        {
            if (L.LibPlayer().LNightEyes)
            {
                scale *= 0.8f;
            }
            base.ModifyLightingBrightness(ref scale);
        }
    }
}
