using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneWoL.Core.Config
{
    [BackgroundColor(15, 25, 50)]
    public class LWoLClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [BackgroundColor(205, 240, 255, 0)]
        [DefaultValue(false)]
        public bool STFUCHAT { get; set; }

        public override void OnLoaded()
        {
            LuneWoL.LWoLClientConfig = this;
        }
    }
}
