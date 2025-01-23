using LuneLib.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static LuneLib.Common.Players.LuneLibPlayer.LibPlayer;
using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.PressureCheckFolder.LWoLDepthUtils;


namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            if (ModeTwo != null)
            {
                if (ModeTwo.rDD > (ModeTwo.mD + 50) && Player.name == "Edith" && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(DrownSound, LP.Center);
                    damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeathEdith").Format(Player.name));
                }
                else if (ModeTwo.rDD > (ModeTwo.mD + 50) && Player.LibPlayer().depthwaterPressure && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(DrownSound, LP.Center);
                    damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeathTooDeep").Format(Player.name));
                }
                else if (ModeTwo.tD >= 50 && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
                {
                    SoundEngine.PlaySound(DrownSound, LP.Center);
                    damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeath" + Main.rand.Next(1, 9 + 1)).Format(Player.name));
                }
                else if (Player.LibPlayer().CrimtuptionzoneNight && Player.whoAmI == Main.myPlayer)
                {
                    damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.CrimtuptionzoneDeath").Format(Player.name));
                }
            }
            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genDust, ref damageSource);
        }
    }
}