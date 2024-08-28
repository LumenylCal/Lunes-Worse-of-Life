using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Content.Buffs
{
    public class Caffeinated : ModBuff
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneWoL.LWoLServerConfig.DarkerNights;
        }
        public override string Texture => "LuneWoL/Assets/Images/Buffs/Caffeinated";

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.LibPlayer().Caffeinated = true;
        }
    }
}
