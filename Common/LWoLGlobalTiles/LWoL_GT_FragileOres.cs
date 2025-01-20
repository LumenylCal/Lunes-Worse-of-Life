using Terraria;
using Terraria.ModLoader;
using LuneLib.Utilities;
using static LuneLib.Utilities.Hashsets.HashSets;
using LuneLib.Utilities.Hashsets.Vanilla;

namespace LuneWoL.Common.LWoLGlobalTiles
{
    public class LWoL_GT_FragileOres : GlobalTile
    {
        private static readonly float chance = LuneLibUtils.ToPercentage(LuneWoL.LWoLServerConfig.Tiles.OreDestroyChance);

        public override bool CanDrop(int i, int j, int type)
        {
            if (chance == 0f) return base.CanDrop(i, j, type);
            if (Main.rand.NextFloat(0f, 1f) <= chance && HashSetContainsOreTile(type)) return false;
            else return base.CanDrop(i, j, type);
        }
    }
}