using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                healValue = healValue * (int)LuneWoL.LWoLServerConfig.HealingPotionBadPercent / 100;

                base.GetHealLife(item, player, quickHeal, ref healValue);
            }
        }
    }
}
