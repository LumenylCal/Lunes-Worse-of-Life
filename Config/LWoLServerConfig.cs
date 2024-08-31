using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneWoL.Config
{
    public class LWoLServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Main
        [Header("Main")]
        
        [BackgroundColor(205, 240, 255, 0)]
        [DefaultValue(0f)]
        [Range(0f, 4f)]
        [Increment(1f)]
        public float CritFailMode { get; set; }

        [BackgroundColor(205, 240, 255, 0)]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool DarkerNights { get; set; }

        [BackgroundColor(205, 240, 255, 0)]
        [DefaultValue(false)]
        public bool WindArrows { get; set; }

        #endregion

        #region BiomeSpecific
        [Header("BiomeSpecific")]

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool Chilly { get; set; }

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool HeatStroke { get; set; }

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool HellIsHot { get; set; }

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool NoEvilDayTime { get; set; }

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool SpacePain { get; set; }

        [BackgroundColor(240, 240, 215, 0)]
        [DefaultValue(false)]
        public bool WeatherPain { get; set; }

        #endregion

        #region BuffsAndDebuffs
        [Header("BuffsAndDebuffs")]

        [BackgroundColor(214, 218, 242, 0)]
        [DefaultValue(0)]
        [Range(0, 100)]
        [Increment(1f)]
        public float HealingPotionBadPercent { get; set; }

        #endregion

        #region Equipment
        [Header("Equipment")]

        [BackgroundColor(214, 242, 215, 0)]
        [DefaultValue(false)]
        public bool ArmourRework { get; set; }

        [BackgroundColor(214, 242, 215, 0)]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool DisableAutoReuse { get; set; }

        //[BackgroundColor(214, 242, 215, 0)]
        //[DefaultValue(false)]
        //public bool ExplosiveGuns { get; set; }

        [BackgroundColor(214, 242, 215, 0)]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool NoAccessories { get; set; }
        
        [BackgroundColor(214, 242, 215, 0)]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool ReforgeNerf { get; set; }

        #endregion

        #region NPCs
        [Header("NPCs")]

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(1f)]
        [Range(1f, 25f)]
        [Increment(0.1f)]
        [ReloadRequired]
        public float BuyMult { get; set; }

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(1f)]
        [Range(0f, 1f)]
        [Increment(0.1f)]
        [ReloadRequired]
        public float SellMult { get; set; }

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(false)]
        public bool InvasionsAnywhere { get; set; }

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(-1)]
        [Range(-1, 50)]
        public int InvasionMultiplier { get; set; }

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(false)]
        public bool NeverGoldEnough { get; set; }

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(1f)]
        [Range(0f, 1f)]
        [Increment(0.05f)]
        public float NoMoneh { get; set; }

        #region Calamity
        [Header("CalamityNPCs")]

        [BackgroundColor(245, 185, 185, 0)]
        [DefaultValue(false)]
        public bool DifficultyRebuff { get; set; }

        #endregion

        #endregion

        #region WaterRelated
        [Header("WaterRelated")]

        [BackgroundColor(155, 160, 225, 0)]
        [DefaultValue(false)]
        public bool DarkWaters { get; set; }

        [BackgroundColor(155, 160, 225, 0)]
        [DefaultValue(0)]
        [Range(0f, 2f)]
        [Increment(1f)]
        [ReloadRequired]
        public float DepthPressureMode { get; set; }

        [BackgroundColor(155, 160, 225, 0)]
        [DefaultValue(false)]
        public bool SlowWater { get; set; }

        [BackgroundColor(155, 160, 225, 0)]
        [DefaultValue(false)]
        public bool WaterPoison { get; set; }

        #endregion

        #region Misc
        [Header("Misc")]

        [BackgroundColor(245, 205, 255, 0)]
        [DefaultValue(-1)]
        [Range(-1, int.MaxValue)]
        public int DespawnItemsTimer { get; set; }

        [BackgroundColor(245, 205, 255, 0)]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool DisableWoLItems { get; set; }

        #endregion

        public override void OnLoaded()
        {
            LuneWoL.LWoLServerConfig = this;
        }
    }
}
