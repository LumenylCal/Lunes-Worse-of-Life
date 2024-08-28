using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        private int DustSpawnCanYN;
        private int Tajmer = LuneWoL.LWoLServerConfig.DespawnItemsTimer * 60;
        private bool a = true;
        private void DespawnItemsAfterTime(Item item)
        {
            if (LuneWoL.LWoLServerConfig.DespawnItemsTimer > -1)
            {            
                if (Tajmer > 0)
                {
                    Tajmer--;
                }
                else if (Tajmer <= 0)
                {
                    Tajmer = LuneWoL.LWoLServerConfig.DespawnItemsTimer * 60;
                }


                if (a && Tajmer <= 0)
                {
                    item.TurnToAir(true);
                    DustSpawnCanYN = 30;
                    a = false;
                }
                if (Tajmer <= 0)
                {
                    DustyDespawn(item);
                }
            }
        }
        private void DustyDespawn(Item item)
        {
            if (LuneWoL.LWoLServerConfig.DespawnItemsTimer > -1)
            {
                for (int i = 0; i < 30; i++)
                {
                    Dust.NewDust(item.position, 1, 1, DustID.Smoke, 0f, 0f, 100, default, 1f);
                }
            }
        }
    }
}
