using LuneWoL.Common.LWoLPlayers;
using LuneWoL.Content.Buffs;
using LuneWoL.Content.Items;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.Common.LWoLGlobalItems
{
    public partial class WoLGlobalItems : GlobalItem
    {
        public static bool DrinkingCoffeeCanQuationMark = true;
        public static bool c = true;

        public override bool InstancePerEntity => true;

        public override bool? UseItem(Item item, Player player)
        {
            var main = LuneWoL.LWoLServerConfig.Main;

            #region coffee
            if (main.DarkerNights)
            {
                if (item.type == ItemID.CoffeeCup && c)
                {
                    item.buffTime = 1;
                    Caffeinated(player);
                    if (player.whoAmI == Main.myPlayer)
                    {
                        c = false;
                        LalalalalaCanthearyou = 0;
                    }
                }
            }
            #endregion

            if (player.whoAmI == Main.myPlayer && main.CritFailMode != 0 && LWoLPlayer.IsCritFail)
            {
                if (main.CritFailMode == 1)
                {
                    LWoLPlayer.AplyDmgAmt = player.GetWeaponDamage(item);
                }

                LWoLPlayer.DmgPlrBcCrit = true;
            }

            //if (LuneWoL.LWoLServerConfig.ExplosiveGuns)
            //{
            //    if (item.DamageType == DamageClass.Ranged)
            //    {
            //        float ARGH = 1 / player.luck;
            //        if (Main.rand.NextBool((int)ARGH))
            //        {
            //            if (player.whoAmI == Main.myPlayer)
            //            {
            //                Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, Vector2.Zero, ProjectileID.Explosives, player.statLifeMax2, 0);
            //            }
            //            player.KillMe(PlayerDeathReason.ByCustomReason("test"), player.statLifeMax2, 0);
            //        }
            //    }
            //}

            return base.UseItem(item, player);
        }

        public override bool CanUseItem(Item item, Player player)
        {
            var main = LuneWoL.LWoLServerConfig.Main;

            #region coffee
            if (main.DarkerNights)
            {
                if (player.whoAmI == Main.myPlayer && item.type == ItemID.CoffeeCup)
                {
                    if (DrinkingCoffeeCanQuationMark)
                    {
                        MessageThing(item, player);
                    }
                    return DrinkingCoffeeCanQuationMark;
                }
            }
            #endregion
            return base.CanUseItem(item, player);
        }

        public override void SetDefaults(Item item)
        {
            NoAccessories(item);

            NoReusing(item);

            Stackables(item);
        }

        public override void PostUpdate(Item item)
        {
            var misc = LuneWoL.LWoLServerConfig.Misc;

            if (misc.DespawnItemsTimer >= -1)
            {
                DespawnItemsAfterTime(item);
            }
        }
    }
}
