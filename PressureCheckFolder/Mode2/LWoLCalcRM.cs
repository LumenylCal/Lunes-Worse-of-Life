using LuneLib.Utilities;
using System;
using Terraria;
using Terraria.ModLoader;
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

        //TODO: add difficulty options and mod compat such as calamity

        public int MD() // Max Depth
        {
            if (Player.arcticDivingGear)
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
            return rDD = (int)((LP.position.Y - ModeTwo.EntryPoint.Y) * ModeTwo.rD) / 16;
        }

        public float TDC() // Tile Difference Clamped
        {
            return tDC = Math.Clamp(rDD, 0, ModeTwo.mD);
        }

        public float TD() // Tile Difference
        {
            return tD = (int)(LP.position.Y - ModeTwo.EntryPoint.Y) / 16;
        }

        public int PDTA() // Pressure Dammage To Apply
        {
            return pDTA = ModeTwo.rDD - ModeTwo.mD;
        }

        public float LDD() // Light Depth Difference
        {
            return lDD = ModeTwo.tDC / ModeTwo.mD;
        }
    }
}
