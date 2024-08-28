using LuneWoL.Common.LWoLPlayers;
using LuneWoL.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneWoL.Common.SystemWoL
{
    public partial class LWoLSystem : ModSystem
    {
        public bool b = true;

        public override void PreUpdateInvasions()
        {
            if (LuneWoL.LWoLServerConfig.InvasionMultiplier != -1 && Main.invasionType != 0 && b)
            {
                Main.invasionSizeStart *= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                Main.invasionSize *= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                Main.invasionProgressMax *= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                NPC.waveNumber *= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                b = false;
            }
            else if (Main.invasionType == 0 && !b)
            {
                Main.invasionSizeStart /= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                Main.invasionSize /= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                Main.invasionProgressMax /= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                NPC.waveNumber /= LuneWoL.LWoLServerConfig.InvasionMultiplier;
                b = true;
            }

            if (LuneWoL.LWoLServerConfig.InvasionsAnywhere && Main.invasionType != 0)
            {
                Main.invasionProgressNearInvasion = true;
            }
            else if (LuneWoL.LWoLServerConfig.InvasionsAnywhere && Main.invasionType == 0)
            {
                Main.invasionProgressNearInvasion = false;
            }
        }
    }
}
