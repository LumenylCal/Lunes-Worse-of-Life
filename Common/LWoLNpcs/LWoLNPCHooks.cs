using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.Npcs
{
    public partial class WoLNpc : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            LessMoneyDrops(npc);

            NeverGoldEnough(npc);
        }
    }
}