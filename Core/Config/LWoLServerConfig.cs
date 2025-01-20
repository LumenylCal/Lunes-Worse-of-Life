using System;
using System.Drawing;
using Terraria.ModLoader.Config;

namespace LuneWoL.Core.Config
{
    [BackgroundColor(15, 25, 50, 255)]
    public class LWoLServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public override bool NeedsReload(ModConfig pendingConfig)
        {
            if (pendingConfig is not LWoLServerConfig newConfig)
                return base.NeedsReload(pendingConfig);

            return !Main.Equals(newConfig.Main) ||
                   !Equipment.Equals(newConfig.Equipment) ||
                   !Recipes.Equals(newConfig.Recipes) ||
                   !Tiles.Equals(newConfig.Tiles) ||
                   !NPCs.Equals(newConfig.NPCs) ||
                   !WaterRelated.Equals(newConfig.WaterRelated) ||
                   !Misc.Equals(newConfig.Misc);
        }

        public class MainDented
        {
            [BackgroundColor(205, 240, 255, 255)]
            [SliderColor(205, 240, 255, 255)]
            [Slider]
            [Range(0, 4)]
            public int CritFailMode { get; set; }

            [BackgroundColor(205, 240, 255, 255)]
            [SliderColor(205, 240, 255, 255)]
            [Slider]
            [Range(0, 3)]
            [ReloadRequired]
            public int DeathPenaltyMode { get; set; }

            [BackgroundColor(205, 240, 255, 255)]
            [ReloadRequired]
            public bool DarkerNights { get; set; }

            [BackgroundColor(205, 240, 255, 255)]
            public bool WindArrows { get; set; }
            
            [BackgroundColor(205, 240, 255, 255)]
            public bool DemonMode { get; set; }

            public MainDented()
            {
                CritFailMode = 0;
                CritFailMode = 0;
                DarkerNights = false;
                WindArrows = false;
                DemonMode = false;
            }

            public override bool Equals(object obj)
            {
                return obj is MainDented other &&
                       DeathPenaltyMode == other.DeathPenaltyMode &&
                       DarkerNights == other.DarkerNights;

            }

            public override int GetHashCode() =>
                HashCode.Combine(DeathPenaltyMode, DarkerNights);
        }

        public class BiomeSpecificDented
        {
            [BackgroundColor(240, 240, 215, 255)]
            public bool Chilly { get; set; }

            [BackgroundColor(240, 240, 215, 255)]
            public bool HeatStroke { get; set; }

            [BackgroundColor(240, 240, 215, 255)]
            public bool HellIsHot { get; set; }

            [BackgroundColor(240, 240, 215, 255)]
            public bool NoEvilDayTime { get; set; }

            [BackgroundColor(240, 240, 215, 255)]
            public bool SpacePain { get; set; }

            [BackgroundColor(240, 240, 215, 255)]
            public bool WeatherPain { get; set; }

            public BiomeSpecificDented()
            {
                Chilly = false;
                HeatStroke = false;
                HellIsHot = false;
                NoEvilDayTime = false;
                SpacePain = false;
                WeatherPain = false;
            }
        }

        public class BuffsAndDebuffsDented
        {
            [BackgroundColor(214, 218, 242, 255)]
            [Slider]
            [SliderColor(214, 218, 242, 255)]
            [Range(0, 100)]
            public int HealingPotionBadPercent { get; set; }

            public BuffsAndDebuffsDented()
            {
                HealingPotionBadPercent = 100;
            }
        }

        public class EquipmentDented
        {
            [BackgroundColor(214, 242, 215, 255)]
            public bool ArmourRework { get; set; }

            [BackgroundColor(214, 242, 215, 255)]
            [ReloadRequired]
            public bool DisableAutoReuse { get; set; }

            [BackgroundColor(214, 242, 215, 255)]
            [ReloadRequired]
            public bool NoAccessories { get; set; }

            [BackgroundColor(214, 242, 215, 255)]
            [ReloadRequired]
            public bool ReforgeNerf { get; set; }

            public EquipmentDented()
            {
                ArmourRework = false;
                DisableAutoReuse = false;
                NoAccessories = false;
                ReforgeNerf = false;
            }
            public override bool Equals(object obj)
            {
                return obj is EquipmentDented other &&
                       DisableAutoReuse == other.DisableAutoReuse &&
                       NoAccessories == other.NoAccessories &&
                       ReforgeNerf == other.ReforgeNerf;

            }

            public override int GetHashCode() =>
                HashCode.Combine(DisableAutoReuse, NoAccessories, ReforgeNerf);
        }

        public class RecipesDented
        {
            [BackgroundColor(90, 185, 175, 255)]
            [ReloadRequired]
            public bool IgnoreStacksOfOne;

            [BackgroundColor(90, 185, 175, 255)]
            [SliderColor(90, 185, 175, 255)]
            [Range(0f, 100f)]
            [Increment(1f)]
            [ReloadRequired]
            public float RecipePercent;

            public RecipesDented()
            {
                IgnoreStacksOfOne = true;
                RecipePercent = 0f;
            }

            public override bool Equals(object obj)
            {
                return obj is RecipesDented other &&
                       RecipePercent == other.RecipePercent &&
                       IgnoreStacksOfOne == other.IgnoreStacksOfOne;
            }

            public override int GetHashCode() =>
                HashCode.Combine(RecipePercent, IgnoreStacksOfOne);
        }

        public class TilesDented
        {
            [BackgroundColor(75, 100, 75, 255)]
            [SliderColor(75, 100, 75, 255)]
            [Range(0f, 100f)]
            [Increment(1f)]
            [ReloadRequired]
            public float OreDestroyChance;

            public TilesDented()
            {
                OreDestroyChance = 0f;
            }

            public override bool Equals(object obj)
            {
                return obj is TilesDented other &&
                       OreDestroyChance == other.OreDestroyChance;

            }

            public override int GetHashCode() =>
                HashCode.Combine(OreDestroyChance);
        }

        public class NPCsDented
        {
            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Range(1f, 25f)]
            [Increment(0.1f)]
            [ReloadRequired]
            public float BuyMult { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Range(0f, 1f)]
            [Increment(0.1f)]
            [ReloadRequired]
            public float SellMult { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Slider]
            [Range(-1, 50)]
            public int InvasionMultiplier { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [ReloadRequired]
            public bool NeverGoldEnough { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Range(0f, 1f)]
            [Increment(0.05f)]
            [ReloadRequired]
            public float NoMoneh { get; set; }

            public NPCsDented()
            {
                BuyMult = 1f;
                SellMult = 1f;
                InvasionMultiplier = -1;
                NeverGoldEnough = false;
                NoMoneh = 1f;
            }
            public override bool Equals(object obj)
            {
                return obj is NPCsDented other &&
                       BuyMult == other.BuyMult &&
                       SellMult == other.SellMult &&
                       NeverGoldEnough == other.NeverGoldEnough &&
                       NoMoneh == other.NoMoneh;
            }

            public override int GetHashCode() =>
                HashCode.Combine(BuyMult, SellMult, NeverGoldEnough, NoMoneh);
        }

        public class WaterRelatedDented
        {
            [BackgroundColor(155, 160, 225, 255)]
            public bool DarkWaters { get; set; }

            [BackgroundColor(155, 160, 225, 255)]
            [SliderColor(155, 160, 225, 255)]
            [Slider]
            [Range(0, 1)]
            [ReloadRequired]
            public int DepthPressureMode { get; set; }

            [BackgroundColor(155, 160, 225, 255)]
            public bool SlowWater { get; set; }

            [BackgroundColor(155, 160, 225, 255)]
            public bool WaterPoison { get; set; }

            public WaterRelatedDented()
            {
                DarkWaters = false;
                DepthPressureMode = 0;
                SlowWater = false;
                WaterPoison = false;
            }
            public override bool Equals(object obj)
            {
                return obj is WaterRelatedDented other &&
                       DepthPressureMode == other.DepthPressureMode;
            }

            public override int GetHashCode() =>
                HashCode.Combine(DepthPressureMode);
        }

        public class MiscDented
        {
            [BackgroundColor(245, 205, 255, 255)]
            [Range(-1, int.MaxValue)]
            public int DespawnItemsTimer { get; set; }

            [BackgroundColor(245, 205, 255, 255)]
            [ReloadRequired]
            public bool DisableWoLItems { get; set; }

            [BackgroundColor(245, 205, 255, 255)]
            [ReloadRequired]
            public bool SkillIssueMode { get; set; }

            public MiscDented()
            {
                DisableWoLItems = false;
                SkillIssueMode = false;
                DespawnItemsTimer = -1;
            }
            public override bool Equals(object obj)
            {
                return obj is MiscDented other &&
                       DisableWoLItems == other.DisableWoLItems &&
                       SkillIssueMode == other.SkillIssueMode;
            }

            public override int GetHashCode() =>
                HashCode.Combine(DisableWoLItems, SkillIssueMode);
        }

        public class CalamityDented
        {
            [BackgroundColor(197, 32, 57, 255)]
            public bool DifficultyRebuff { get; set; }

            public CalamityDented()
            {
                DifficultyRebuff = false;
            }
        }

        #region new()

        [BackgroundColor(205, 240, 255, 255)]
        public MainDented Main = new();

        [BackgroundColor(240, 240, 215, 255)]
        public BiomeSpecificDented BiomeSpecific = new();

        [BackgroundColor(214, 218, 242, 255)]
        public BuffsAndDebuffsDented BuffsAndDebuffs = new();

        [BackgroundColor(214, 242, 215, 255)]
        public EquipmentDented Equipment = new();

        [BackgroundColor(90, 185, 175, 255)]
        public RecipesDented Recipes = new();
        
        [BackgroundColor(75, 100, 75, 255)]
        public TilesDented Tiles = new();

        [BackgroundColor(245, 85, 80, 255)]
        public NPCsDented NPCs = new();

        [BackgroundColor(155, 160, 225, 255)]
        public WaterRelatedDented WaterRelated = new();

        [BackgroundColor(245, 205, 255, 255)]
        public MiscDented Misc = new();

        [BackgroundColor(197, 32, 57, 255)]
        public CalamityDented CalamityMod = new();

        //spiritmod 82 172 244
        //[BackgroundColor(82, 172, 244, 255)]
        //public SpiritDented Spirit = new();

        #endregion

        public override void OnLoaded()
        {
            LuneWoL.LWoLServerConfig = this;
        }
    }
}
