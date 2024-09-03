using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        public void NoReusing(Item item)
        {
            var equipment = LuneWoL.LWoLServerConfig.Equipment;

            if (equipment.DisableAutoReuse)
            item.autoReuse = false;
        }
    }
}
