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
using static LuneWoL.Common.LWoLPlayers.LWoLPlayer;
using static LuneWoL.LuneWoL;

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
            var Config = LWoLServerConfig.BiomeSpecific;

            if (!Config.SpacePain) return;

            if (Player.whoAmI != Main.myPlayer) return;

            if (!Player.ZoneNormalSpace) return;

            if (Player.behindBackWall) return;

            Main.buffNoTimeDisplay[ModContent.BuffType<BoilFreezeDB>()] = true;
            Player.AddBuff(ModContent.BuffType<BoilFreezeDB>(), 15, true, false);
        }

        #endregion

        #region hell hot

        public void HellIsQuiteHot()
        {
            var Config = LWoLServerConfig.BiomeSpecific;

            if (!Config.HellIsHot) return;

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
            var Config = LWoLServerConfig.WaterRelated;

            if (Player.OceanMan() && Config.SlowWater && !LL)
            {
                float maxSpeed = 10f;
                if (Player.velocity.Length() > maxSpeed)
                {
                    Player.velocity = Vector2.Normalize(Player.velocity) * maxSpeed;
                }
            }
        }

        #endregion

        #region Armour Rework

        public bool ArmourReworked()
        {
            var Config = LWoLServerConfig.Equipment;

            if (!Config.ArmourRework) return false;

            LeadRework();

            return true;

        }

        public bool ArmourReworkedMove()
        {
            var Config = LWoLServerConfig.Equipment;

            if (!Config.ArmourRework) return false;

            TungstenReworkMove();

            return true;

        }

        public void LeadRework()
        {
            if (WearingFullLead || WearingTwoLeadPieces || WearingOneLeadPiece)
            {
                Player.LibPlayer().LeadPoison = true;

                Main.buffNoTimeDisplay[BuffID.Poisoned] = true;
                Player.AddBuff(BuffID.Poisoned, 5);
            }
        }

        public void TungstenReworkMove()
        {
            if (WearingFullTungsten)
            {
                Player.maxRunSpeed *= 0.6f;
                Player.accRunSpeed *= 0.6f;
            }
            else if (WearingTwoTungstenPieces)
            {
                Player.maxRunSpeed *= 0.7f;
                Player.accRunSpeed *= 0.7f;
            }
            else if (WearingOneTungstenPiece)
            {
                Player.maxRunSpeed *= 0.8f;
                Player.accRunSpeed *= 0.8f;
            }
        }

        #endregion

        #region water poison

        public void WaterPoison()
        {
            var Config = LWoLServerConfig.WaterRelated;

            if (!Config.WaterPoison) return;
            if (!Player.wet || Player.lavaWet || Player.honeyWet) return;
            if (LL) return;

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
            var Config = LWoLServerConfig.BiomeSpecific;

            if (!Config.WeatherPain) return;

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
                var Config = LWoLServerConfig.BiomeSpecific;

                if (!Config.Chilly) return;

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
                var Config = LWoLServerConfig.BiomeSpecific;

                if (!Main.dayTime) return;

                if (!Config.NoEvilDayTime) return;

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
            public override void PostAI(Projectile Projectile)
            {
                var Config = LWoLServerConfig.Main;

                if (Config.WindArrows && Projectile.arrow && 
                    (double)Projectile.Center.Y < Main.worldSurface * 16.0 
                    && Main.tile[(int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16] != null 
                    && Main.tile[(int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16].WallType == 0 
                    && ((Projectile.velocity.X > 0f 
                    && Main.windSpeedCurrent < 0f) 
                    || (Projectile.velocity.X < 0f 
                    && Main.windSpeedCurrent > 0f) 
                    || Math.Abs(Projectile.velocity.X) < Math.Abs(Main.windSpeedCurrent * Main.windPhysicsStrength) * 180f) 
                    && Math.Abs(Projectile.velocity.X) < 16f)
                {
                    Projectile.velocity.X += Main.windSpeedCurrent * Main.windPhysicsStrength;
                    MathHelper.Clamp(Projectile.velocity.X, -16f, 16f); ;
                }
                base.PostAI(Projectile);
            }
        }

        #endregion

        #region DarkerNights

            // giving players darkness during nights or even blackout
            public void DarkerNights()
            {
                var Config = LWoLServerConfig.Main;

                if (!Config.DarkerNights) return;

                if (!Main.dayTime && !Player.HasBuff<Caffeinated>())
                {
                    Main.buffNoTimeDisplay[ModContent.BuffType<NightChild>()] = true;
                    Player.AddBuff(ModContent.BuffType<NightChild>(), 60);

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
            var Config = LWoLServerConfig.BiomeSpecific;

            if (!Config.HeatStroke) return;

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
                if (LL) return;

                if (Player.whoAmI != Main.myPlayer) return;

                var Config = LuneWoL.LWoLServerConfig.WaterRelated;

                if (Player.OceanMan() && Config.DarkWaters && Config.DepthPressureMode > 0)
                {
                    Player.LibPlayer().LWaterEyes = true;
                }
                else if (Player.OceanMan() && Config.DarkWaters && Config.DepthPressureMode !> 0) 
                { 
                    Player.LibPlayer().LWaterEyes = true;
                    Lighting.GlobalBrightness *= 0.8f;
                }
                else
                {
                    Player.LibPlayer().LWaterEyes = false;
                }
            }

        #endregion

        // (annoyinh to do) maybe penalties for dying such as reduced max hp just to be evil obviously in masochist config

        // literally so annoying to make // rain leaves water behind leading to floods when alot of rain and droghuts when there hasnt been rain in a long time (excludig if the player is in the beach biome)

        // maybe later... // poor air quality in caves leading player to take DoT unless they have {Immunity Item/Buff}

        #endregion

    }
}
