//using System.Reflection;

//using Mono.Cecil.Cil;
//using MonoMod.Cil;

//using Terraria;
//using Terraria.ModLoader;

//using CalamityMod.NPCs;

//using static MonoMod.Cil.ILContext;

//using static LuneLib.Utilities.LuneLibUtils;


//namespace LuneWoL.CalamityModChanges
//{
//    [JITWhenModsEnabled("CalamityMod")]
//    public partial class CalamityILandReflection : GlobalNPC
//    {
//        public override bool IsLoadingEnabled(Mod mod)
//        {
//            return LuneWoL.CalamityRebuffs.DifficultyRebuff;
//        }

//        public static void load()
//        {  
//            MethodInfo method = typeof(CalamityGlobalNPC).GetMethod("AdjustMasterModeStatScaling");
//            MethodInfo method2 = typeof(CalamityGlobalNPC).GetMethod("AdjustExpertModeStatScaling");
//            MonoModHooks.Modify(method, new Manipulator(AdjustMasterModeStatScaling));
//            MonoModHooks.Modify(method2, new Manipulator(AdjustExpertModeStatScaling));
//        }

//        public static void AdjustMasterModeStatScaling(ILContext iL)
//        {
//            var c = new ILCursor(iL);

//            if (c.TryGotoNext(MoveType.Before, i => i.MatchLdfld<NPC>("knockBackResist"), i => i.MatchLdloc(1)))
//            {
//                c.Emit(OpCodes.Ldloc_1, 1f);
//            }
//            updateOffsets(c);
//        }
//        public static void AdjustExpertModeStatScaling(ILContext iL)
//        {
//            var c = new ILCursor(iL);

//            if (c.TryGotoNext(MoveType.Before, i => i.MatchLdcR8(0.75D)))
//            {
//                c.Remove();
//                c.Emit(OpCodes.Ldc_R8, 1D);
//            }

//            if (c.TryGotoNext(MoveType.Before, i => i.MatchLdcR8(0.9D)))
//            {
//                c.Remove();
//                c.Emit(OpCodes.Ldc_R8, 1D);
//            }
//            updateOffsets(c);
//        }
//    }
//}
