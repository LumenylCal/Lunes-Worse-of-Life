using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLSystems
{
    public partial class LWoLSystem : ModSystem
    {
        public override void PreUpdateInvasions()
        {
            LongerInvasions();
        }

        public override void AddRecipes()
        {
            AddMusicBox();
        }

        public override void PostAddRecipes()
        {
            RecipeMulti();
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            DarkerNightsSurfaceLight(ref tileColor, ref backgroundColor);
        }
    }
}
