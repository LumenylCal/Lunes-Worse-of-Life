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
        }

        public override void UpdateEquips()
        {
            base.UpdateEquips(); //emgpty
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

        public override void PreUpdateMovement()
        {
            base.PostUpdateBuffs();
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

        public override void PostUpdateBuffs()
        {
            base.PostUpdateBuffs();
        }

        public override void PostUpdateMiscEffects()
        {
            HeatExhaustion();
        }

        public override void PreUpdate()
        {
            base.PreUpdate(); //empyu
        }

        public override void PostUpdate()
        {
            if (Player.whoAmI == Main.myPlayer && LuneLib.LuneLib.debug.DebugMessages)
            {
                Main.NewText($"Heat = {HeatStrokeCounter}, Bliz = {tundraBlizzardCounter}");
            }

            if (DmgPlrBcCrit && LuneWoL.LWoLServerConfig.CritFailMode > 0)
            {
                CritFailDamage(Player);
            }

            // https://steamcommunity.com/sharedfiles/filedetails/?id=2395507804
        }

        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            if (!IsCritFail && LuneWoL.LWoLServerConfig.CritFailMode != 0)
            {
                CritFail(Player, npc);
            }
        }

        #endregion

    }
}