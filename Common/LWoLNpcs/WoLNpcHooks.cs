using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.Npcs
{
    public partial class WoLNpc : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            var main = LuneWoL.LWoLServerConfig.Main;
            var misc = LuneWoL.LWoLServerConfig.Misc;

            if (main.DarkerNights && !misc.DisableWoLItems)
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