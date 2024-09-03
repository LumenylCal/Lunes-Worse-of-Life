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
        public static int LalalalalaCanthearyou = 0;
        public static int UrMomIsSoSkibidiIBangedHerLastNight = 0;
        private async void MessageThing(Item item, Player player)
        {
            Main.NewText("Using drink...");

            await Task.Delay(1250);

            Main.NewText("You feel energized!");
        }

        public static void Comedown(Player player)
        {
            if (UrMomIsSoSkibidiIBangedHerLastNight >= 18160)
            {
                Main.NewText("You're starting to come down from the coffee.");
                UrMomIsSoSkibidiIBangedHerLastNight = 0;
            }
            else if (UrMomIsSoSkibidiIBangedHerLastNight <= 18159)
            {
                UrMomIsSoSkibidiIBangedHerLastNight++;
            }
        }
        public static void CanConsumeMoreCoffee()
        {
            if (LalalalalaCanthearyou >= 7200) // 7200 i thinkj is 3 mins dunno
            {
                LalalalalaCanthearyou = 7200;
                DrinkingCoffeeCanQuationMark = true;
                c = true;
            }
            else if (LalalalalaCanthearyou <= 7199)
            {
                LalalalalaCanthearyou++;
                DrinkingCoffeeCanQuationMark = false;
            }
        }
        private async void Caffeinated(Player player)
        {
            await Task.Delay(1250);
            player.AddBuff(ModContent.BuffType<Caffeinated>(), 18000);
            if (player.whoAmI == Main.myPlayer)
            {
                UrMomIsSoSkibidiIBangedHerLastNight = 0;
            }
        }
    }
}
