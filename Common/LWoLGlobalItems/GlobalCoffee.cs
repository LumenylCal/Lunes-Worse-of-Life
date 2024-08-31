using LuneWoL.Content.Buffs;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.Common.LWoLPlayers.LWoLPlayer;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        private async void MessageThing(Item item, Player player)
        {
            Main.NewText("Using drink...");

            await Task.Delay(1250);

            Main.NewText("You feel energized!");
        }

        private void Comedown(Player player)
        {
            if (player.whoAmI != Main.myPlayer) return;

            Main.NewText("You're starting to come down from the coffee.");
        }
        private async void CanConsumeMoreCoffee()
        {
            DrinkingCoffeeCanQuationMark = false;

            await Task.Delay(120000);

            DrinkingCoffeeCanQuationMark = true;
        }
        private async void Caffeinated(Player player)
        {
            await Task.Delay(1250);

            player.AddBuff(ModContent.BuffType<Caffeinated>(), 18000);

            await Task.Delay(297000);

            Comedown(player);
        }
    }
}
