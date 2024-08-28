using System;

using Terraria;
using Terraria.ModLoader;

using LuneLib.Utilities;

using static LuneLib.Utilities.LuneLibUtils;
using static LuneWoL.PressureCheckFolder.LWoLDepthUtils;

namespace LuneWoL.PressureCheckFolder.Mode2
{
    public partial class PressureModeTwo : ModPlayer
    {
        public float rD = 0f;

        public int mD;

        public int rDD;

        public float tDC;

        public float tD;

        public int pDTA;

        public float lDD;

        //[JITWhenModsEnabled("CalamityMod")]
        //public int CLMD()
        //{
        //    if (Player.LibPlayer().IsNearLune)
        //    {
        //        mD = int.MaxValue;
        //        Player.LibPlayer().depthwaterPressure = false;
        //        Player.LibPlayer().currentDepthPressure = 0;
        //    }
        //    else if (Player.arcticDivingGear)
        //    {
        //        mD = 1000;
        //    }
        //    else if (Player.accDivingHelm)
        //    {
        //        mD = 750;
        //    }
        //    else if (Player.gills)
        //    {
        //        mD = 500;
        //    }
        //    else
        //    {
        //        mD = 200;
        //    }
        //    return mD;
        //}

        public int MD() // Max Depth
        {
            if (Player.LibPlayer().IsNearLune)
            {
                mD = int.MaxValue;
                Player.LibPlayer().depthwaterPressure = false;
                Player.LibPlayer().currentDepthPressure = 0;
            }
            else if (Player.arcticDivingGear)
            {
                mD = 500;
            }
            else if (Player.accDivingHelm && Player.accFlipper)
            {
                mD = 450;
            }
            else if (Player.accDivingHelm)
            {
                mD = 350;
            }
            else if (Player.gills)
            {
                mD = 250;
            }
            else
            {
                mD = 200;
            }
            return mD;
        }

        public float RD() // Reduced Depth
        {
            rD = 1f;

            if (Player.arcticDivingGear)
            {
                rD -= 0.15f;
            }
            else if (Player.accDivingHelm && Player.accFlipper)
            {
                rD -= 0.1f;
            }
            else if (Player.accDivingHelm)
            {
                rD -= 0.1f;
            }

            if (Player.gills)
            {
                rD -= 0.05f;
            }

            if (rD <= 0.25f)
            {
                rD = 0.25f;
            }

            return rD;
        }

        public int RDD() // Reduced Depth Difference
        {
            return rDD = (int)((LP.position.Y - pointSetter.EntryPoint.Y) * CalcedRM.rD) / 16;
        }

        public float TDC() // Tile Difference Clamped
        {
            float aTDC = rDD;
            aTDC = Math.Clamp(aTDC, 0, CalcedRM.mD);

            return tDC = aTDC;
        }
        
        public float TD() // Tile Difference
        {
            return tD = (int)(LP.position.Y - pointSetter.EntryPoint.Y) / 16;
        }

        public int PDTA() // Pressure Dammage To Apply
        {
            int pressureDamageToApply = CalcedRM.rDD;

            return pDTA = pressureDamageToApply;
        }
        
        public float LDD() // Light Depth Difference
        {
            float lightDepthDifference = CalcedRM.tDC / CalcedRM.mD;

            return lDD = lightDepthDifference;
        }
    }
}
