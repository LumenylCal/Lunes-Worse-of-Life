using Terraria.ID;
using Terraria.ModLoader;

namespace LuneWoL.Content.Items
{
    public class CoffeeBeans : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            var main = LuneWoL.LWoLServerConfig.Main;
            var misc = LuneWoL.LWoLServerConfig.Misc;

            return main.DarkerNights && !misc.DisableWoLItems;
        }

        public override string Texture => "LuneWoL/Assets/Images/Items/CoffeeBeans";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = 50;
            Item.rare = ItemRarityID.White;
        }
    }
}
