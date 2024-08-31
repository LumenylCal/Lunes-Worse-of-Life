using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue)
        {
            if (LuneWoL.LWoLServerConfig.HealingPotionBadPercent > 0 && LuneWoL.LWoLServerConfig.HealingPotionBadPercent < 100)
            {
                float max = LuneWoL.LWoLServerConfig.HealingPotionBadPercent;

                float clampthethinging = max / 100;

                float result = healValue * clampthethinging;

                healValue = (int)result;

                base.GetHealLife(item, player, quickHeal, ref healValue);
            }
            else if (LuneWoL.LWoLServerConfig.HealingPotionBadPercent == 0)
            {
                healValue = 0;
            }
        }
    }
}
