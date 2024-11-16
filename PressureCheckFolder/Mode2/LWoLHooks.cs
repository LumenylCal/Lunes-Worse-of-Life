using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.PressureCheckFolder.LWoLDepthUtils;

namespace LuneWoL.PressureCheckFolder.Mode2
{
    public partial class PressureModeTwo : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            var Config = LuneWoL.LWoLServerConfig.WaterRelated;

            if (Player.whoAmI == Main.myPlayer && Config.DepthPressureMode == 2)
            {
                CheckWaterDepth();

                if (LuneLib.LuneLib.clientConfig.DebugMessages)
                {
                    Main.NewText($"W = {InWaterBody}, E = {EntryPoint.Y}, X = {ExitPoint.Y}");
                }
            }
        }
        public override void PostUpdateEquips()
        {
            var Config = LuneWoL.LWoLServerConfig.WaterRelated;

            if (!LL && Player.whoAmI == Main.myPlayer && LP.OceanMan() && Config.DepthPressureMode == 2)
            {
                BreathChecker();
                DamageChecker();
            }

            if (Player.whoAmI == Main.myPlayer && Config.DepthPressureMode == 2)
            {
                MD();
                RD();
                RDD();
                TDC();
                TD();
                PDTA();
                LDD();
            }
        }

        public override void PostUpdate()
        {
            var Config = LuneWoL.LWoLServerConfig.WaterRelated;

            if (Player.LibPlayer().LWaterEyes && Player.whoAmI == Main.myPlayer && Config.DepthPressureMode == 2)
            {
                float value = 0f;
                float amount = 0.1f;
                if (Player.LibPlayer().LWaterEyes && Player.whoAmI == Main.myPlayer)
                {
                    value = 1f;
                    amount = ModeTwo.lDD;
                }
                ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
            }

            float reversedLDD = (1 - LWoLDepthUtils.ModeTwo.lDD);
            float clampedLDD = MathHelper.Clamp(reversedLDD, 0.5f, 1f);
            if (LP.LibPlayer().LWaterEyes && Config.DepthPressureMode == 2 && Player.whoAmI == Main.myPlayer)
            {
                Lighting.GlobalBrightness *= clampedLDD;
            }

            if (LuneLib.LuneLib.clientConfig.DebugMessages && Player.whoAmI == Main.myPlayer && Config.DepthPressureMode == 2)
            {
                Main.NewText($"MD = {mD}, RD = {rD}, RDD = {rDD}, CDP = {Player.LibPlayer().currentDepthPressure}, LDD = {lDD}");
            }
        }
    }
}
