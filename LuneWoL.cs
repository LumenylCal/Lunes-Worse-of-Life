using LuneWoL.Core.Config;
using LuneWoL.WoL_IL_Edits;
using Terraria.ModLoader;

namespace LuneWoL
{
    public partial class LuneWoL : Mod
    {
        public static Mod Instance;
        public static LuneWoL instance;
        public static LWoLServerConfig LWoLServerConfig;
        public static LWoLClientConfig LWoLClientConfig;
        public static LWoLServerStatConfig LWoLServerStatConfig;

        public override void Load()
        {
            instance = this;
            Instance = this;

            // hi coyote mods!11!!111! stop trying to IL my shit its not hard to patch nor are any of your users using my mod lmfao
            if (LuneLib.LuneLib.instance.CoyoteframesLoaded)
            {
                throw new System.Exception($"disable coyote frames mod... skill issue if you need that shit!!!! this cannot be turned off because i just dont feel like it LMFAO\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); 
            }

            if (LuneLib.LuneLib.instance.StrongerReforgesLoaded && LWoLServerConfig.Equipment.ReforgeNerf)
            {
                throw new System.Exception($"Disable `Reforge Nerf` in the config if you wanna use the `Stronger Reforges` mod.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); 
            }
            
            if (LuneLib.LuneLib.instance.DarkSurfaceLoaded && LWoLServerConfig.Main.DarkerNights)
            {
                throw new System.Exception($"Disable `Darker Nights` in the config if you wanna use the `Dark Surface` mod.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); 
            }

            LWoLILEdits.load();

            //if (LuneLib.LuneLib.instance.CalamityModLoaded)
            //{ CalamityILandReflection.load(); }
        }

        public override void Unload()
        {
            Instance = null;
            instance = null;
            LWoLServerConfig = null;
            LWoLClientConfig = null;
            LWoLServerStatConfig = null;
        }
    }
}
