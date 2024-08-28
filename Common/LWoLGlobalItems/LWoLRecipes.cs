using LuneWoL.Content.Items;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        public static void AddCoffee()
        {
            if (LuneWoL.LWoLServerConfig.DisableWoLItems) return;
            if (!LuneWoL.LWoLServerConfig.DarkerNights) return;

            Recipe.Create(ItemID.CoffeeCup, 1).
                AddIngredient<CoffeeBeans>(2).
                AddIngredient(ItemID.BottledWater, 1).
                AddTile(TileID.CookingPots).
            Register();
        }
    }
}
