using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneWoL.WoL_IL_Edits
{
    public partial class LWoLILEdits
    {
        public static void load()
        {
            if (LuneWoL.LWoLServerConfig.SellMult != 1 || LuneWoL.LWoLServerConfig.BuyMult != 1)
            {
                IL_Player.GetItemExpectedPrice += BuyPriceandSellPrice;
            }
            //if (LuneWoL.LWoLServerConfig.)
            //{
            //    IL_Main.dro
            //}
        }

        private static void BuyPriceandSellPrice(ILContext il)
        {
            var cursor = new ILCursor(il);

            if (cursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg(0), i => i.MatchLdflda<Player>("currentShoppingSettings")))
            {
                cursor.RemoveRange(4);
                cursor.Emit(OpCodes.Ldc_R4, LuneWoL.LWoLServerConfig.BuyMult);
                cursor.Emit(OpCodes.Conv_R8);
                cursor.Emit(OpCodes.Mul);
            }
            if (cursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg(0), i => i.MatchLdflda<Player>("currentShoppingSettings")))
            {
                cursor.RemoveRange(4);
                cursor.Emit(OpCodes.Ldc_R4, LuneWoL.LWoLServerConfig.SellMult);
                cursor.Emit(OpCodes.Conv_R8);
                cursor.Emit(OpCodes.Mul);
            }
            if (cursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg(0), i => i.MatchLdflda<Player>("currentShoppingSettings")))
            {
                cursor.RemoveRange(4);
                cursor.Emit(OpCodes.Ldc_R4, LuneWoL.LWoLServerConfig.BuyMult);
                cursor.Emit(OpCodes.Conv_R8);
                cursor.Emit(OpCodes.Mul);
            }
            if (cursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg(0), i => i.MatchLdflda<Player>("currentShoppingSettings")))
            {
                cursor.RemoveRange(4);
                cursor.Emit(OpCodes.Ldc_R4, LuneWoL.LWoLServerConfig.SellMult);
                cursor.Emit(OpCodes.Conv_R8);
                cursor.Emit(OpCodes.Mul);
            }

            updateOffsets(cursor);
        }

        //public static void Dropchances(ILContext iL)
        //{
        //    var c = new ILCursor(iL);

        //    DropAttemptInfo dropAttemptInfo;

        //    if (c.TryGotoNext(MoveType.Before, i => i.MatchLdflda<NPC>("NPCDrop_DropItem"))) // i got bored
        //    { 
        //        c.Emit(OpCodes)
        //    }

        //    updateOffsets(c);
        //}
    }
}
