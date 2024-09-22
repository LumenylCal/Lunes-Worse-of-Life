using LuneWoL.Common.LWoLPlayers;
using Terraria;
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

            if (player.whoAmI == Main.myPlayer && main.CritFailMode != 0 && LWoLPlayer.IsCritFail)
            {
                if (main.CritFailMode == 1)
                {
                    LWoLPlayer.AplyDmgAmt = player.GetWeaponDamage(item);
                }

                LWoLPlayer.DmgPlrBcCrit = true;
            }

            if (item.type == ItemID.LifeCrystal && main.DeathPenaltyMode == 1)
            {
                if (player.ConsumedLifeCrystals >= Player.LifeCrystalMax)
                {
                    LWoLPlayer.AUURHGHRUGH = true;
                }
            }

            if (item.type == ItemID.LifeFruit && main.DeathPenaltyMode == 1)
            {
                if (player.ConsumedLifeFruit >= Player.LifeFruitMax)
                {
                    LWoLPlayer.AUURHGHRUGH = true;
                }
            }

            if (item.type == ItemID.ManaCrystal)
            {
                if (player.ConsumedManaCrystals >= Player.ManaCrystalMax && main.DeathPenaltyMode == 1)
                {
                    LWoLPlayer.AUURHGHRUGHpart2ofc = true;
                }
            }

            return base.UseItem(item, player);
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
