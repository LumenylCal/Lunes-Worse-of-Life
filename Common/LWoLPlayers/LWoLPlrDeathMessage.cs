using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;

using LuneLib.Utilities;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.PressureCheckFolder.LWoLDepthUtils;
using static LuneLib.Common.Players.LuneLibPlayer.LibPlayer;


namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            if (CalcedRM.rDD >= CalcedRM.mD && Player.name == "Edith" && Main.rand.Next(1, 10) == 5 + 1 && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(DrownSound, LP.Center);
                damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeathEdith").Format(Player.name));
            }
            else if (CalcedRM.rDD > CalcedRM.mD && Player.LibPlayer().depthwaterPressure && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
            {
                {
                    SoundEngine.PlaySound(DrownSound, LP.Center);
                    damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeathTooDeep").Format(Player.name));
                }
            }
            else if (CalcedRM.rDD >= 50 && Player.LibPlayer().depthwaterPressure && Player.OceanMan() && Player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(DrownSound, LP.Center);
                damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.PressureDeath" + Main.rand.Next(1, 9 + 1)).Format(Player.name));
            }
            else if (Player.LibPlayer().CrimtuptionzoneNight && Player.whoAmI == Main.myPlayer)
            {
                damageSource = PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.CrimtuptionzoneDeath").Format(Player.name));
            }
            return true;
        }
    }
}