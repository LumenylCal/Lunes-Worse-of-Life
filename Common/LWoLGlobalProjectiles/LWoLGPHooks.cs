using LuneWoL.Common.LWoLPlayers;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace LuneWoL.Common.WoLGlobalProjectiles
{
    public partial class LWoLGPHooks : GlobalProjectile
    {
        public override void OnSpawn(Projectile Projectile, IEntitySource source)
        {
            var Config = LuneWoL.LWoLServerConfig.Main;

            if (LWoLPlayer.DmgPlrBcCrit && Config.CritFailMode != 0 && Projectile.owner == Main.myPlayer)
            {
                Projectile.damage = 0;
                Projectile.penetrate = -1;
            }
            base.OnSpawn(Projectile, source);
        }
    }
}
