using Terraria;
using Terraria.ModLoader;

using static LuneWoL.LuneWoL;

namespace LuneWoL.Common.LWoLPlayers
{
    public class LWoLPlayerStatChanges : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            PlrStats();
        }

        public void PlrStats()
        {
            var plrConfig = LWoLServerStatConfig.PlayerStats;

            if (plrConfig.DisablePlayerStatChanges) return;

            #region Vitality
            if (plrConfig.LifePercent != 100)
            {
                Player.statLifeMax2 = Player.statLifeMax2 * plrConfig.LifePercent / 100;
            }
            if (plrConfig.LifeRegenPercent != 100)
            {
                Player.lifeRegen = Player.lifeRegen * plrConfig.LifeRegenPercent / 100;
            }
            if (plrConfig.DefensePercent != 100)
            {
                Player.statDefense = Player.statDefense * plrConfig.DefensePercent / 100;
            }
            if (plrConfig.EndurancePercent != 100)
            {
                Player.endurance = Player.endurance * plrConfig.EndurancePercent / 100;
            }
            #endregion

            #region Offense
            if (plrConfig.DamagePercent != 100)
            {
                Player.GetDamage(DamageClass.Generic).Base = Player.GetDamage(DamageClass.Generic).Base * plrConfig.DamagePercent / 100;
            }
            if (plrConfig.ArmorPenetrationPercent != 100)
            {
                Player.GetArmorPenetration(DamageClass.Generic) = Player.GetArmorPenetration(DamageClass.Generic) * plrConfig.ArmorPenetrationPercent / 100;
            }
            if (plrConfig.AttackSpeedPercent != 100)
            {
                Player.GetAttackSpeed(DamageClass.Generic) = Player.GetAttackSpeed(DamageClass.Generic) * (plrConfig.AttackSpeedPercent / 100f);
            }
            #endregion

            #region Magic
            if (plrConfig.ManaPercent != 100)
            {
                Player.statManaMax2 = Player.statManaMax2 * plrConfig.ManaPercent / 100;
            }
            if (plrConfig.ManaRegenPercent != 100)
            {
                Player.manaRegenBonus = Player.manaRegenBonus * plrConfig.ManaRegenPercent / 100;
            }
            if (plrConfig.ManaCostPercent != 100)
            {
                Player.manaCost = Player.manaCost * plrConfig.ManaCostPercent / 100;
            }
            #endregion

            #region Slavery
            if (plrConfig.MaxMinionsPercent != 100)
            {
                Player.maxMinions = Player.maxMinions * plrConfig.MaxMinionsPercent / 100;
            }
            if (plrConfig.MaxTurretsPercent != 100)
            {
                Player.maxTurrets = Player.maxTurrets * plrConfig.MaxTurretsPercent / 100;
            }
            #endregion

            #region Mobility
            if (plrConfig.MoveSpeedPercent != 100)
            {
                Player.moveSpeed = Player.moveSpeed * plrConfig.MoveSpeedPercent / 100;
            }
            if (plrConfig.JumpSpeedPercent != 100)
            {
                Player.jumpSpeed = Player.jumpSpeed * plrConfig.JumpSpeedPercent / 100;
            }
            if (plrConfig.JumpHeightPercent != 100)
            {
                Player.jumpHeight = Player.jumpHeight * plrConfig.JumpHeightPercent / 100;
            }
            if (plrConfig.WingTimePercent != 100)
            {
                Player.wingTimeMax = Player.wingTimeMax * plrConfig.WingTimePercent / 100;
            }
            #endregion

            #region World Shaping
            if (plrConfig.PickSpeedPercent != 100)
            {
                Player.pickSpeed = Player.pickSpeed * plrConfig.PickSpeedPercent / 100;
            }
            if (plrConfig.BlockRangePercent != 100)
            {
                Player.blockRange = Player.blockRange * plrConfig.BlockRangePercent / 100;
            }
            if (plrConfig.TileSpeedPercent != 100)
            {
                Player.tileSpeed = Player.tileSpeed * plrConfig.TileSpeedPercent / 100;
            }
            if (plrConfig.WallSpeedPercent != 100)
            {
                Player.wallSpeed = Player.wallSpeed * plrConfig.WallSpeedPercent / 100;
            }
            #endregion
        }
    }
}
