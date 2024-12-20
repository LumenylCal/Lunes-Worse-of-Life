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

            // leave me alone coyote devs
            if (LuneLib.LuneLib.instance.CoyoteframesLoaded && !LWoLServerConfig.Misc.SkillIssueMode)
            {
                throw new System.Exception($"Enable `Skill Issue Mode` if you wanna use the `Coyote Frames` mod.\n" + new string('\n', 20));
            }

            // compat issues im guessing (havent tried)
            if (LuneLib.LuneLib.instance.StrongerReforgesLoaded && LWoLServerConfig.Equipment.ReforgeNerf)
            {
                throw new System.Exception("Disable `Reforge Nerf` in the config if you wanna use the `Stronger Reforges` mod.\n" + new string('\n', 20));
            }

            // same as reforge thing
            if (LuneLib.LuneLib.instance.DarkSurfaceLoaded && LWoLServerConfig.Main.DarkerNights)
            {
                throw new System.Exception("Disable `Darker Nights` in the config if you wanna use the `Dark Surface` mod.\n" + new string('\n', 20));
            }

            LWoLILEdits.load();
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
