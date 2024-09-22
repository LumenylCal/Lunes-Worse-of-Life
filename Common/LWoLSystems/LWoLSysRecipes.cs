using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static LuneLib.LuneLib;

namespace LuneWoL.Common.LWoLSystems
{
    public partial class LWoLSystem : ModSystem
    {
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

        public void RecipeMulti()
        {
            var Config = LuneWoL.LWoLServerConfig.Recipes;

            if (Config.RecipePercent == 100) return;

            foreach (Recipe recipe in Main.recipe)
            {
                foreach (Item item in recipe.requiredItem)
                {
                    if (item.stack > 0 && !Config.IgnoreStacksOfOne)
                    {
                        item.stack = (int)(item.stack * (100f / Config.RecipePercent));
                    }
                    else if (item.stack > 1 && Config.IgnoreStacksOfOne)
                    {
                        item.stack = (int)(item.stack * (100f / Config.RecipePercent));
                    }
                }
            }
        }
    }
}
