using Terraria;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Content.Buffs.Debuffs
{
    public class NightChild : ModBuff 
    {
        public override string Texture => "LuneWoL/Assets/Images/Buffs/Debuffs/NightChild";

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.LibPlayer().NightChild = true;
        }
    }
}
