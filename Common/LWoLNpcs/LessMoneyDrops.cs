using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.Npcs
{
    public partial class WoLNpc : GlobalNPC
    {
        private void LessMoneyDrops(NPC npc)
        {
            if (LuneWoL.LWoLServerConfig.NoMoneh == 1) return;

            npc.value = (npc.value * LuneWoL.LWoLServerConfig.NoMoneh);
        }
        private void NeverGoldEnough(NPC npc)
        {
            if (LuneWoL.LWoLServerConfig.NeverGoldEnough) return;

            if (npc.value > 1600 && LuneWoL.LWoLServerConfig.NoMoneh != 1)
            {
                npc.value = (1600 * LuneWoL.LWoLServerConfig.NoMoneh);
            }
            else if (npc.value > 1600)
            {
                npc.value = 1600;
            }
        }
    }
}
