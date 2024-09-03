using Terraria.ModLoader;
using LuneWoL.WoL_IL_Edits;

using static LuneLib.Utilities.LuneLibUtils;
using LuneWoL.Core.Config;

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
