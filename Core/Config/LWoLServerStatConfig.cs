using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneWoL.Core.Config
{
    [BackgroundColor(15, 25, 50)]
    public class LWoLServerStatConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Player Stats

        public class PlayerStatDented
        {
            #region Vitality

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int LifePercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int LifeRegenPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int DefensePercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int EndurancePercent;

            #endregion

            #region Offense

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int DamagePercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int ArmorPenetrationPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int AttackSpeedPercent;

            #endregion

            #region Magic

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int ManaPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int ManaRegenPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int ManaCostPercent;

            #endregion

            #region Slavery

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int MaxMinionsPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int MaxTurretsPercent;

            #endregion

            #region Mobility

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int MoveSpeedPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int JumpSpeedPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int JumpHeightPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int WingTimePercent;

            #endregion

            #region World Shaping

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(100, 200)]
            public int PickSpeedPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(1, 100)]
            public int BlockRangePercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(100, 200)]
            public int TileSpeedPercent;

            [BackgroundColor(85, 130, 140, 255)]
            [SliderColor(85, 130, 140, 255)]
            [Slider]
            [Range(100, 200)]
            public int WallSpeedPercent;

            [BackgroundColor(85, 130, 140, 255)]
            public bool DisablePlayerStatChanges;
            #endregion

            public PlayerStatDented()
            {
                LifePercent = 100;
                LifeRegenPercent = 100;
                DefensePercent = 100;
                EndurancePercent = 100;

                DamagePercent = 100;
                ArmorPenetrationPercent = 100;
                AttackSpeedPercent = 100;

                ManaPercent = 100;
                ManaRegenPercent = 100;
                ManaCostPercent = 100;

                MaxMinionsPercent = 100;
                MaxTurretsPercent = 100;

                MoveSpeedPercent = 100;
                JumpSpeedPercent = 100;
                JumpHeightPercent = 100;
                WingTimePercent = 100;

                PickSpeedPercent = 100;
                BlockRangePercent = 100;
                TileSpeedPercent = 100;
                WallSpeedPercent = 100;
                
                DisablePlayerStatChanges = true;
            }
        }

        #endregion

        #region NPC stats

        public class NpcStatDented
        {
            [BackgroundColor(75, 105, 130, 255)]
            [Range(100, 10000)]
            public int LifePercent;

            [BackgroundColor(75, 105, 130, 255)]
            [Range(100, 10000)]
            public int DefensePercent;

            [BackgroundColor(75, 105, 130, 255)]
            [Range(100, 10000)]
            public int DamagePercent;

            [BackgroundColor(75, 105, 130, 255)]
            public bool DisableNPCStatChanges;

            public NpcStatDented()
            {
                LifePercent = 100;
                DamagePercent = 100;
                DefensePercent = 100;
                DisableNPCStatChanges = true;
            }
        }
        public class BossStatDented
        {
            [BackgroundColor(110, 90, 150, 255)]
            [Range(100, 10000)]
            public int LifePercent;

            [BackgroundColor(110, 90, 150, 255)]
            [Range(100, 10000)]
            public int DefensePercent;

            [BackgroundColor(110, 90, 150, 255)]
            [Range(100, 10000)]
            public int DamagePercent;

            [BackgroundColor(110, 90, 150, 255)]
            public bool DisableBossStatChanges;
            public BossStatDented()
            {
                LifePercent = 100;
                DamagePercent = 100;
                DefensePercent = 100;
                DisableBossStatChanges = true;
            }
        }

        #endregion

        [BackgroundColor(85, 130, 140, 255)]
        public PlayerStatDented PlayerStats = new();

        [BackgroundColor(75, 105, 130, 255)]
        public NpcStatDented NpcConfig = new();

        [BackgroundColor(110, 90, 150, 255)]
        public BossStatDented BossConfig = new();

        public override void OnLoaded()
        {
            LuneWoL.LWoLServerStatConfig = this;
        }
    }
}
