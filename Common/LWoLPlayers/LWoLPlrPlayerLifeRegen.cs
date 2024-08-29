﻿using Terraria.ModLoader;
using Terraria.ID;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneLib.Common.Players.LuneLibPlayer.LibPlayer;

namespace LuneWoL.Common.LWoLPlayers
{
    public partial class LWoLPlayer : ModPlayer
    {
        public override void UpdateBadLifeRegen()
        {
            float totalNegativeLifeRegen = 0;

            void ApplyDoTDebuff(bool hasDebuff, int negativeLifeRegenToApply, bool immuneCondition = false)
            {
                if (!hasDebuff || immuneCondition)
                    return;

                if (L.lifeRegen > 0)
                    L.lifeRegen = 0;

                L.lifeRegenTime = 0;
                totalNegativeLifeRegen += negativeLifeRegenToApply;
            }

            ApplyDoTDebuff(L.LibPlayer().BoilFreeze, 15, false);

            ApplyDoTDebuff(L.LibPlayer().depthwaterPressure, L.LibPlayer().currentDepthPressure, LTSE);

            ApplyDoTDebuff(L.LibPlayer().BlizzardFrozen, 50, L.buffImmune[BuffID.Frozen]);

            ApplyDoTDebuff(L.LibPlayer().Chilly, 2, L.buffImmune[BuffID.Chilled]);

            ApplyDoTDebuff(L.LibPlayer().CrimtuptionzoneNight, 100, false);

            ApplyDoTDebuff(WearingFullLead && L.LibPlayer().LeadPoison, 8, L.buffImmune[BuffID.Poisoned]);

            ApplyDoTDebuff(WearingTwoLeadPieces && L.LibPlayer().LeadPoison, 4, L.buffImmune[BuffID.Poisoned]);

            ApplyDoTDebuff(WearingOneLeadPiece && L.LibPlayer().LeadPoison, 2, L.buffImmune[BuffID.Poisoned]);

            L.lifeRegen -= (int)totalNegativeLifeRegen;
        }
    }
}