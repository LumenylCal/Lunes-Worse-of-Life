using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneWoL.Config
{
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
