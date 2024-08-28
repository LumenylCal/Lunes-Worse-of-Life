using LuneWoL.Common.LWoLPlayers;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace LuneWoL.Common.WoLGlobalProjectiles
{
    public partial class WoLGlobalProjectiles : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (LWoLPlayer.DmgPlrBcCrit && LuneWoL.LWoLServerConfig.CritFailMode != 0 && projectile.owner == Main.myPlayer)
            {
                projectile.damage = 0;
                projectile.penetrate = -1;
            }
            base.OnSpawn(projectile, source);
        }
    }
}
