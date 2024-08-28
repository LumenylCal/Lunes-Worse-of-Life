using Terraria.ID;
using Terraria.ModLoader;

namespace LuneWoL.Content.Items
{
    public class CoffeeBeans : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneWoL.LWoLServerConfig.DarkerNights && !LuneWoL.LWoLServerConfig.DisableWoLItems;
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
