using LuneWoL.Common.LWoLPlayers;
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
        private bool DrinkingCoffeeCanQuationMark = true;

        public override bool InstancePerEntity => true;

        public override void AddRecipes()
        {
            AddCoffee();
        }

        public override bool? UseItem(Item item, Player player)
        {
            #region coffee
            if (LuneWoL.LWoLServerConfig.DarkerNights)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.dead)
                    {
                        DrinkingCoffeeCanQuationMark = true;
                    }
                    CanConsumeMoreCoffee(); 
                }
                if (item.type == ItemID.CoffeeCup)
                {
                    Caffeinated(player);
                }
            }
            #endregion

            if (player.whoAmI == Main.myPlayer && LuneWoL.LWoLServerConfig.CritFailMode != 0 && LWoLPlayer.IsCritFail)
            {
                if (LuneWoL.LWoLServerConfig.CritFailMode == 1)
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
            #region coffee
            if (LuneWoL.LWoLServerConfig.DarkerNights)
            {
                if (item.type == ItemID.CoffeeCup)
                {
                    if (player.whoAmI == Main.myPlayer && DrinkingCoffeeCanQuationMark)
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
            if (LuneWoL.LWoLServerConfig.NoAccessories)
            {
                NoAccessories(item);
            }
        }

        public override void PostUpdate(Item item)
        {
            if (LuneWoL.LWoLServerConfig.DespawnItemsTimer >= -1)
            {
                DespawnItemsAfterTime(item);
            }
        }
    }
}
