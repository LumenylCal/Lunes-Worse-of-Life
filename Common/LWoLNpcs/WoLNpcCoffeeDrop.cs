using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using LuneWoL.Content.Items;

namespace LuneWoL.Common.Npcs
{
    public partial class WoLNpc : GlobalNPC
    {
        public void CoffeeBeanDrop(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.AngryTrapper || npc.type == NPCID.ManEater || npc.type == NPCID.Snatcher || npc.type == NPCID.BoneLee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoffeeBeans>(), 4, 1, 4));
            }
        }
    }
}