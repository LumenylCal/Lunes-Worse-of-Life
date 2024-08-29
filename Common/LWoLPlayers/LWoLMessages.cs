using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {
        public async void EnterWorldMessage()
        {
            if (LuneWoL.LWoLClientConfig.STFUCHAT) return;

            await Task.Delay(5000);

            if (Player.whoAmI == Main.myPlayer)
            {
                Main.NewText($"Dont forget to join the Discord!... Please?\nI have a half assed wiki too! https://github.com/LumenylCal/Lunes-Worse-of-Life/wiki\nYou can turn this message off in the client config.", 70, 80, 150);
            }
        }
    }
}
