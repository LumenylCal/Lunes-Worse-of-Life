using CalamityMod.NPCs.CalClone;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using static LuneWoL.Core.Config.LWoLServerStatConfig;

namespace LuneWoL.Core.Config
{
    [BackgroundColor(15, 25, 50)]
    public class LWoLServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public class MainDented
        {
            [BackgroundColor(205, 240, 255, 255)]
            [SliderColor(205, 240, 255, 255)]
            [Slider]
            [Range(0, 4)]
            public int CritFailMode { get; set; }

            [BackgroundColor(205, 240, 255, 255)]
            [ReloadRequired]
            public bool DarkerNights { get; set; }

            [BackgroundColor(205, 240, 255, 255)]
            public bool WindArrows { get; set; }

            public MainDented()
            {
                CritFailMode = 0;
                DarkerNights = false;
                WindArrows = false;
            }
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
            public bool InvasionsAnywhere { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Slider]
            [Range(-1, 50)]
            public int InvasionMultiplier { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            public bool NeverGoldEnough { get; set; }

            [BackgroundColor(245, 85, 80, 255)]
            [SliderColor(245, 85, 80, 255)]
            [Range(0f, 1f)]
            [Increment(0.05f)]
            public float NoMoneh { get; set; }

            public NPCsDented()
            {
                BuyMult = 1f;
                SellMult = 1f;
                InvasionsAnywhere = false;
                InvasionMultiplier = -1;
                NeverGoldEnough = false;
                NoMoneh = 1f;
            }
        }

        public class WaterRelatedDented
        {
            [BackgroundColor(155, 160, 225, 255)]
            public bool DarkWaters { get; set; }

            [BackgroundColor(155, 160, 225, 255)]
            [SliderColor(155, 160, 225, 255)]
            [Slider]
            [Range(0, 2)]
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
        }

        public class MiscDented
        {
            [BackgroundColor(245, 205, 255, 255)]
            [Range(-1, int.MaxValue)]
            public int DespawnItemsTimer { get; set; }

            [BackgroundColor(245, 205, 255, 255)]
            [ReloadRequired]
            public bool DisableWoLItems { get; set; }

            public MiscDented()
            {
                DisableWoLItems = false;
                DespawnItemsTimer = -1;
            }
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
