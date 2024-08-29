﻿using InfernumMode.Core.ILEditingStuff;
using LuneLib.Utilities;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {
        public static bool IsCritFail;

        public static bool DmgPlrBcCrit;

        public static int AplyDmgAmt;

        public void CritFail(Player player, NPC npc)
        {
            if (LuneWoL.LWoLServerConfig.CritFailMode == 1 || LuneWoL.LWoLServerConfig.CritFailMode == 2)
            {
                int normalCritChance = (int)player.GetTotalCritChance(DamageClass.Generic);

                int chanceoffail = Main.rand.Next(normalCritChance + 1);

                if (chanceoffail == 1)
                {
                    IsCritFail = true;
                }
            }
            else if (LuneWoL.LWoLServerConfig.CritFailMode == 3 || LuneWoL.LWoLServerConfig.CritFailMode == 4)
            {
                int chanceoffail = Main.rand.Next(100 + 1);

                if (chanceoffail == 1)
                {
                    IsCritFail = true;
                }
            }
        }

        public void CritFailDamage(Player player)
        {
            if (LuneWoL.LWoLServerConfig.CritFailMode == 0) return;

            if (player.whoAmI == Main.myPlayer && IsCritFail && (LuneWoL.LWoLServerConfig.CritFailMode == 1 || LuneWoL.LWoLServerConfig.CritFailMode == 3))
            {
                player.Hurt(PlayerDeathReason.ByCustomReason(LuneLibUtils.GetText("Status.Death.FailedCrit" + Main.rand.Next(1, 5 + 1)).Format(Player.name)), AplyDmgAmt, 0);
            }
            if (player.whoAmI == Main.myPlayer && IsCritFail && LuneWoL.LWoLServerConfig.CritFailMode > 0)
            {
                WaitUntilZero();
            }
        }

        public static async void WaitUntilZero()
        {
            await Task.Delay(32);

            DmgPlrBcCrit = false;
            IsCritFail = false;
        }
    }
}