using LuneWoL.Common.LWoLPlayers;
using LuneWoL.Content.Items;
using System;
using Terraria;
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
