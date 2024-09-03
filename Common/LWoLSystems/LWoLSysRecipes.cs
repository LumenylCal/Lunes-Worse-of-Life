using LuneWoL.Content.Items;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.LuneLib;

namespace LuneWoL.Common.LWoLSystems
{
    public partial class LWoLSystem : ModSystem
    {
        public static void AddCoffee()
        {
            var misc = LuneWoL.LWoLServerConfig.Misc;
            var main = LuneWoL.LWoLServerConfig.Main;

            if (misc.DisableWoLItems) return;
            if (!main.DarkerNights) return;

            Recipe.Create(ItemID.CoffeeCup, 1).
                AddIngredient<CoffeeBeans>(1).
                AddIngredient(ItemID.BottledWater, 1).
                AddTile(TileID.CookingPots).
            Register();
        }

        public static void AddMusicBox()
        {
            if (instance.CalamityModLoaded) return;

            Recipe.Create(ItemID.MusicBox).
                AddIngredient(ItemID.Wood, 6).
                AddIngredient(ItemID.Ruby, 1).
                AddIngredient(ItemID.IronBar, 2).
                AddTile(TileID.Tables).
            Register();
        }
    }
}
