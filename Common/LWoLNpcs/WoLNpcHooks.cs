using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.Npcs
{
    public partial class WoLNpc : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (LuneWoL.LWoLServerConfig.DarkerNights && !LuneWoL.LWoLServerConfig.DisableWoLItems)
            {
                CoffeeBeanDrop(npc, npcLoot);
            }

            //if (LuneWoL.LWoLServerConfig.SmallerDropChances > 0)
            //{
            //    MoreGrinding(npc, npcLoot);
            //}
        }

        public override void SetDefaults(NPC npc)
        {
            LessMoneyDrops(npc);

            NeverGoldEnough(npc);
        }
    }
}