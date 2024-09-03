using LuneWoL.Core.Config;
using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {

        #region Hooks

        public override void OnEnterWorld()
        {
            EnterWorldMessage();

            if (Player.whoAmI == Main.myPlayer)
            {
                LWoLGlobalItems.WoLGlobalItems.LalalalalaCanthearyou = 7200;
            }

        }

        public override void PostUpdateEquips()
        {
            HellIsQuiteHot();

            ArmourReworked();

            HeatExhaustionUpdEquips();
        }

        public override void PostUpdateRunSpeeds()
        {
            SlowWater();

            HeatExhaustionUpdRunSpeed();
        }

        public override void PreUpdateBuffs()
        {
            prebuffBurnFreeze();

            WaterPoison();

            WeatherPain();

            ColdMakeColdBrrrrr();

            Thisissoevillmfao();

            DarkWaters();

            DarkerNights();
        }

        public override void PostUpdateMiscEffects()
        {
            HeatExhaustion();
        }

        public override void PostUpdate()
        {
            var Config = LuneWoL.LWoLServerConfig.Main;

            if (Player.whoAmI == Main.myPlayer && LuneLib.LuneLib.debug.DebugMessages)
            {
                Main.NewText($"Heat = {HeatStrokeCounter}, Bliz = {tundraBlizzardCounter}");
            }

            if (DmgPlrBcCrit && Config.CritFailMode > 0)
            {
                CritFailDamage(Player);
            }
            if (Player.whoAmI == Main.myPlayer)
            {
                LWoLGlobalItems.WoLGlobalItems.CanConsumeMoreCoffee();
            }

            // https://steamcommunity.com/sharedfiles/filedetails/?id=2395507804
        }

        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            var Config = LuneWoL.LWoLServerConfig.Main;

            if (!IsCritFail && Config.CritFailMode != 0)
            {
                CritFail(Player, npc);
            }
        }

        public override void OnRespawn()
        {
            if (Player.whoAmI == Main.myPlayer)
            {
               LWoLGlobalItems.WoLGlobalItems.LalalalalaCanthearyou = 7200;
               LWoLGlobalItems.WoLGlobalItems.UrMomIsSoSkibidiIBangedHerLastNight = 0;
            }
        }

        #endregion

    }
}