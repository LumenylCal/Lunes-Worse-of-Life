using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;

using LuneLib.Utilities;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.PressureCheckFolder.LWoLDepthUtils;

namespace LuneWoL.PressureCheckFolder.Mode2
{
    public partial class PressureModeTwo : ModPlayer
    {
        public int abyssBreathCD;

        public void DamageChecker()
        {
            Player.LibPlayer().depthwaterPressure = true;

            if (CalcedRM.rDD >= CalcedRM.mD)
            {
                Player.LibPlayer().currentDepthPressure = CalcedRM.pDTA - CalcedRM.mD;
            }
        }

        #region Breath

        public void BreathChecker()
        {
            double dR = CalcedRM.tD / CalcedRM.mD;

            dR *= 2D;

            double tick = 12D * (1D - dR);

            if (tick < 1D)
                tick = 1D;

            double tickMult = 1D +
                (Player.gills ? 4D : 0D) +
                (Player.ignoreWater ? 5D : 0D) +
                (Player.accDivingHelm ? 10D : 0D) +
                (Player.arcticDivingGear ? 10D : 0D) +
                (Player.accMerman ? 15D : 0D);

            if (tickMult > 50D)
                tickMult = 50D;

            tick *= tickMult / dR;

            abyssBreathCD++;
            if (abyssBreathCD >= (int)tick)
            {
                abyssBreathCD = 0;

                if (Player.breath > 0)
                    Player.breath -= 1;
            }
            if (Player.breath > 0)
            {
                if (Player.gills || Player.merman)
                    Player.breath -= 3;
            }

            Player.LibPlayer().depthwaterPressure = true;

            int lifeLossAtZeroBreath = (int)(6D * CalcedRM.rD);

            if (lifeLossAtZeroBreath < 0)
                lifeLossAtZeroBreath = 0;

            if (LuneLib.LuneLib.debug.DebugMessages && Player.whoAmI == Main.myPlayer)
            {
                Main.NewText($"dR = {dR}, BL = X, TM = {tickMult}, T = {tick}, LLAZB = {lifeLossAtZeroBreath}");
            }

            if (Player.breath <= 0)
            {
                Player.statLife -= lifeLossAtZeroBreath;

                if (Player.statLife <= 0 && !Player.dead)
                {
                    Player.KillMe(PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeath" + Main.rand.Next(1, 9 + 1)).Format(Player.name)), Player.statLifeMax2, 0);
                }
            }
        }

        #endregion
    }
}
