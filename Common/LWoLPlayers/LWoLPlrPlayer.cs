using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;

using Terraria.ModLoader;

using LuneLib.Utilities;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.Common.Players.LuneLibPlayer.LibPlayer;

using LuneWoL.Content.Buffs;
using LuneWoL.Content.Buffs.Debuffs;
using LuneWoL.Content.Buffs.DOT;

namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {

        public int tundraBlizzardCounter;
        public int tundraChilledCounter;
        public int HeatStrokeCounter;

        #region methods for prebuffupdateingupdating update update pre skeletron of eye chlututl

        #region space pain

        public void prebuffBurnFreeze()
        {
            if (!LuneWoL.LWoLServerConfig.SpacePain) return;

            if (!Player.ZoneNormalSpace) return;

            if (Player.behindBackWall) return;

            if (Player.whoAmI != Main.myPlayer) return;

            Main.buffNoTimeDisplay[ModContent.BuffType<BoilFreezeDB>()] = true;
            Player.AddBuff(ModContent.BuffType<BoilFreezeDB>(), 15, true, false);
        }

        #endregion

        #region hell hot

        public void HellIsQuiteHot()
        {
            if (!LuneWoL.LWoLServerConfig.HellIsHot) return;

            if (!Player.ZoneUnderworldHeight) return;

            if (Player.buffImmune[BuffID.Burning] || Player.fireWalk || Player.buffImmune[BuffID.OnFire] || Player.lavaImmune || Player.wet || Player.honeyWet && !Player.lavaWet)
            {
                return;
            }
            Main.buffNoTimeDisplay[BuffID.OnFire] = true;
            Player.AddBuff(BuffID.OnFire, 120, false, false);
        }

        #endregion

        #region slow water

        public void SlowWater()
        {
            if (Player.OceanMan() && LuneWoL.LWoLServerConfig.SlowWater && !LTSE)
            {
                float maxSpeed = 16f;
                if (Player.velocity.Length() > maxSpeed)
                {
                    Player.velocity = Vector2.Normalize(Player.velocity) * maxSpeed;
                }
            }
        }

        #endregion

        #region Armour Reword

        public bool ArmourReworked()
        {
            if (!LuneWoL.LWoLServerConfig.ArmourRework) return false;

            LeadRework();

            return true;

        }
        public bool ArmourReworkedMove()
        {
            if (!LuneWoL.LWoLServerConfig.ArmourRework) return false;

            LeadReworkMove();

            return true;

        }

        public void LeadRework()
        {
            if (WearingFullLead || WearingTwoLeadPieces || WearingOneLeadPiece)
            {
                L.LibPlayer().LeadPoison = true;

                Main.buffNoTimeDisplay[BuffID.Poisoned] = true;
                Player.AddBuff(BuffID.Poisoned, 5);
            }
        }
        public void LeadReworkMove()
        {
            if (WearingFullLead)
            {
                Player.maxRunSpeed *= 0.6f;
                Player.accRunSpeed *= 0.6f;
            }
            else if (WearingTwoLeadPieces)
            {
                Player.maxRunSpeed *= 0.7f;
                Player.accRunSpeed *= 0.7f;
            }
            else if (WearingOneLeadPiece)
            {
                Player.maxRunSpeed *= 0.8f;
                Player.accRunSpeed *= 0.8f;
            }
        }

        #endregion

        #region water poison

        public void WaterPoison()
        {
            if (!LuneWoL.LWoLServerConfig.WaterPoison) return;
            if (!Player.wet || Player.lavaWet || Player.honeyWet) return;
            if (LTSE) return;

            if (Player.ZoneCrimson)
            {
                Main.buffNoTimeDisplay[BuffID.Ichor] = true;
                Player.AddBuff(BuffID.Ichor, 180, true, false);
                if (Player.buffTime[BuffID.Ichor] > 180)
                {
                    Player.buffTime[BuffID.Ichor] = 180;
                }
            }

            if (Player.ZoneCorrupt)
            {
                Main.buffNoTimeDisplay[BuffID.CursedInferno] = true;
                Player.AddBuff(BuffID.CursedInferno, 180, true, false);
                if (Player.buffTime[BuffID.CursedInferno] > 180)
                {
                    Player.buffTime[BuffID.CursedInferno] = 180;
                }
            }

            if (Player.ZoneJungle)
            {
                Main.buffNoTimeDisplay[BuffID.Poisoned] = true;
                Player.AddBuff(BuffID.Poisoned, 180, true, false);
                if (Player.buffTime[BuffID.Poisoned] > 180)
                {
                    Player.buffTime[BuffID.Poisoned] = 180;
                }
            }

            if (Player.ZoneHallow)
            {
                Main.buffNoTimeDisplay[BuffID.Confused] = true;
                Player.AddBuff(BuffID.Confused, 180, true, false);
                if (Player.buffTime[BuffID.Confused] > 180)
                {
                    Player.buffTime[BuffID.Confused] = 180;
                }
            }
        }

        #endregion

        #region WeatherPain

        public void WeatherPain()
        {

            if (!LuneWoL.LWoLServerConfig.WeatherPain) return;

            if (Main.raining && Player.ZoneCrimson || Player.ZoneCorrupt && !Player.behindBackWall)
            {
                Main.buffNoTimeDisplay[BuffID.Bleeding] = true;
                Player.AddBuff(BuffID.Bleeding, 60, true, false);
            }

            if (Sandstorm.Happening && Player.ZoneDesert && !Player.behindBackWall)
            {
                Player.blackout = true;
                Player.LibPlayer().LStormEyeCovered = true;
            }
            else 
            {
                Player.LibPlayer().LStormEyeCovered = false;
            }

            // Check for blizzard and tundra conditions
            if (!WearingFullEskimo && Main.raining && Player.ZoneSnow && !Player.behindBackWall && !Player.HasBuff(BuffID.Campfire))
            {
                if (tundraBlizzardCounter < 0)
                    tundraBlizzardCounter = 0;

                tundraBlizzardCounter += 1;

                if (tundraBlizzardCounter >= 180)
                    tundraBlizzardCounter = 180;

                if (tundraBlizzardCounter >= 180)
                {
                    Player.LibPlayer().BlizzardFrozen = true;
                    Main.buffNoTimeDisplay[BuffID.Frozen] = true;
                    Player.AddBuff(BuffID.Frozen, 60, true, false);
                }
            }
            else
            {
                tundraBlizzardCounter = 0;
                Player.LibPlayer().BlizzardFrozen = false;
            }
        }

        #endregion

        #region worse healing potions

        // worse healing potions? reduced effectiveness and longer potion sickness?
        public class HealingPotionBad : GlobalItem
            {
                public override void GetHealLife(Item item, Player player, bool quickHeal, ref int healValue)
                {
                    if (LuneWoL.LWoLServerConfig.HealingPotionBadMult != 0 || LuneWoL.LWoLServerConfig.HealingPotionBadMult != 1)
                    {
                        healValue /= LuneWoL.LWoLServerConfig.HealingPotionBadMult;
                        base.GetHealLife(item, player, quickHeal, ref healValue);
                    }
                }
            }

        #endregion

        #region Bad Potions
        // chance of potions being "bad" giving you a debuff instead?

        //public void BadPotions()
        //{
        //}

        #endregion

        #region Cold Make Cold Brrrrr

            // cold env give chilled debuff?
            public void ColdMakeColdBrrrrr()
            {

                if (!LuneWoL.LWoLServerConfig.Chilly) return;

                if (WearingFullEskimo) return;

                if (Player.ZoneSnow && !Player.HasBuff(BuffID.Campfire) && !Player.behindBackWall && !Player.HasBuff(BuffID.OnFire) && !Player.HasBuff(BuffID.Burning))
                {
                    if (tundraChilledCounter < 0)
                        tundraChilledCounter = 0;

                    tundraChilledCounter += 1;

                    if (tundraChilledCounter >= 180)
                        tundraChilledCounter = 180;

                    if (tundraChilledCounter >= 180)
                    {
                        L.LibPlayer().Chilly = true;
                        Main.buffNoTimeDisplay[BuffID.Chilled] = true;
                        Player.AddBuff(BuffID.Chilled, 180, true, false);
                    }
                }
                else
                {
                    tundraChilledCounter = 0;
                    L.LibPlayer().Chilly = false;
                }
            }

        #endregion

        #region EVIL NIGHT TIME BABY

            // evil biomes are night time only?
            public void Thisissoevillmfao()
            {
                if (!Main.dayTime) return;

                if (!LuneWoL.LWoLServerConfig.NoEvilDayTime) return;

                if (Player.ZoneCorrupt || Player.ZoneCrimson)
                {
                    L.LibPlayer().CrimtuptionzoneNight = true;
                }
                else
                {
                    L.LibPlayer().CrimtuptionzoneNight = false;
                }
            }

        #endregion

        #region wind fucks w arrows
            public class Windproj : GlobalProjectile
            {
            public override void PostAI(Projectile projectile)
            {
                if (LuneWoL.LWoLServerConfig.WindArrows && projectile.arrow && 
                    (double)projectile.Center.Y < Main.worldSurface * 16.0 
                    && Main.tile[(int)projectile.Center.X / 16, (int)projectile.Center.Y / 16] != null 
                    && Main.tile[(int)projectile.Center.X / 16, (int)projectile.Center.Y / 16].WallType == 0 
                    && ((projectile.velocity.X > 0f 
                    && Main.windSpeedCurrent < 0f) 
                    || (projectile.velocity.X < 0f 
                    && Main.windSpeedCurrent > 0f) 
                    || Math.Abs(projectile.velocity.X) < Math.Abs(Main.windSpeedCurrent * Main.windPhysicsStrength) * 180f) 
                    && Math.Abs(projectile.velocity.X) < 16f)
                {
                    projectile.velocity.X += Main.windSpeedCurrent * Main.windPhysicsStrength;
                    MathHelper.Clamp(projectile.velocity.X, -16f, 16f); ;
                }
                base.PostAI(projectile);
            }
        }

        #endregion

        #region DarkerNights

            // giving players darkness during nights or even blackout
            public void DarkerNights()
            {
                if (!LuneWoL.LWoLServerConfig.DarkerNights) return;

                if (!Main.dayTime && !Player.HasBuff<Caffeinated>())
                {
                    Main.buffNoTimeDisplay[ModContent.BuffType<NightChild>()] = true;
                    Player.AddBuff(ModContent.BuffType<NightChild>(), 60);

                    Player.blind = true;
                    Player.LibPlayer().LNightEyes = true;
                }
                else
                {
                    Player.LibPlayer().NightChild = false;
                }
            }

        #endregion

        #region Heat Exhaustion

        // new "Heat Exhaustion" debuff increases mana costs and decreases max summons and move speed and attack speed
        public void HeatExhaustion()
        {
            if (!LuneWoL.LWoLServerConfig.HeatStroke) return;

            if (Main.dayTime && WearingAnyArmour && !Player.behindBackWall && !(Player.wet || Player.HasBuff(BuffID.Wet)) && Player.ZoneDesert)
            {
                if (HeatStrokeCounter < 0)
                    HeatStrokeCounter = 0;

                HeatStrokeCounter += 1;

                if (HeatStrokeCounter >= 180)
                    HeatStrokeCounter = 180;

                if (HeatStrokeCounter >= 180)
                {
                    Main.buffNoTimeDisplay[ModContent.BuffType<HeatStroke>()] = true;
                    Player.AddBuff(ModContent.BuffType<HeatStroke>(), 60);
                    Player.statDefense *= 0.8f;
                    Player.statLifeMax2 /= 4;
                    Player.statManaMax2 /= 4;
                    Player.GetAttackSpeed(DamageClass.Generic) *= 0.8f;
                }
            }
            else
            {
                HeatStrokeCounter -= 1;
                if (HeatStrokeCounter < 0)
                    HeatStrokeCounter = 0;
            }
        }
        public void HeatExhaustionUpdEquips()
        {
            if (HeatStrokeCounter >= 180)
            {
                Player.maxMinions /= 4;
            }
        }
        
        public void HeatExhaustionUpdRunSpeed()
        {
            if (HeatStrokeCounter >= 180)
            {
                Player.accRunSpeed *= 0.8f;
                Player.maxRunSpeed *= 0.8f;
            }
        }

        #endregion

        #region darker waters

            // blackout type debuff when oceanman dorwned collision check
            public void DarkWaters()
            {
                if (LTSE) return;

                if (Player.whoAmI != Main.myPlayer) return;

                if (Player.OceanMan() && LuneWoL.LWoLServerConfig.DarkWaters && LuneWoL.LWoLServerConfig.DepthPressureMode > 0)
                {
                Player.LibPlayer().LWaterEyes = true;
                }
                else if (Player.OceanMan() && LuneWoL.LWoLServerConfig.DarkWaters && LuneWoL.LWoLServerConfig.DepthPressureMode !> 0) 
                { 
                    Player.LibPlayer().LWaterEyes = true;
                    Player.blind = true;
                }
                else
                {
                    Player.LibPlayer().LWaterEyes = false;
                }
            }

        #endregion

        //3 implemented! //2 need immunities for this...//1 with the stored water level add pressuredepthmax to see how deep the player can go

        // (hard to do) maybe penalties for dying such as reduced max hp just to be evil obviously in masochist config

        // maybe or maybe not // ranged weapons have a change to explode but were talking 0.00001% chance or smth and when i say explode i mean it spawns an explostion at the player so the item will be intact

        // literally so hard to make // rain leaves water behind leading to floods when alot of rain and droghuts when there hasnt been rain in a long time (excludig if the player is in the beach biome)

        // maybe later... // poor air quality in caves leading player to take DoT unless they have {Immunity Item/Buff}

        #endregion
    }
}
