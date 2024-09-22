using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue)
        {
            var buffs = LuneWoL.LWoLServerConfig.BuffsAndDebuffs;

            if (buffs.HealingPotionBadPercent > 0 && buffs.HealingPotionBadPercent < 100)
            {
                float max = buffs.HealingPotionBadPercent;

                float clampthethinging = max / 100;

                float result = healValue * clampthethinging;

                healValue = (int)result;

                base.GetHealLife(item, player, quickHeal, ref healValue);
            }
            else if (buffs.HealingPotionBadPercent == 0 || buffs.HealingPotionBadPercent == 1)
            {
                healValue = 0;
            }
        }
    }
}
