﻿using GlobalLib.Support.Shared.Parts.PresetParts;
using GlobalLib.Utils;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected override unsafe uint[] StringToKey(Concatenator parts)
        {
            int offset = 0;
            uint[] _Part_Hash = new uint[80];
            // Convert everything to bin hashes, put everything in one uint vector _Part_Hash
            /* 0x060 = 00 */ _Part_Hash[offset++] = Bin.Hash(parts._BASE);
            /* 0x064 = 01 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_FRONT_WINDOW);
            /* 0x068 = 02 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_BODY);
            /* 0x06C = 03 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_COP_LIGHTS);
            /* 0x070 = 04 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_SPOILER);
            /* 0x074 = 05 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_FRONT_WHEEL);
            /* 0x078 = 06 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_LEFT_BRAKELIGHT);
            /* 0x07C = 07 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_RIGHT_BREAKLIGHT);
            /* 0x080 = 08 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_LEFT_HEADLIGHT);
            /* 0x084 = 09 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_RIGHT_HEADLIGHT);
            /* 0x088 = 10 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_HOOD);
            /* 0x08C = 11 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_BUSHGUARD);
            /* 0x090 = 12 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_FRONT_BUMPER);
            /* 0x094 = 13 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_RIGHT_DOOR);
            /* 0x098 = 14 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_RIGHT_REAR_DOOR);
            /* 0x09C = 15 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_TRUNK);
            /* 0x0A0 = 16 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_REAR_BUMPER);
            /* 0x0A4 = 17 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_REAR_LEFT_WINDOW);
            /* 0x0A8 = 18 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_FRONT_LEFT_WINDOW);
            /* 0x0AC = 19 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_FRONT_RIGHT_WINDOW);
            /* 0x0B0 = 20 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_REAR_RIGHT_WINDOW);
            /* 0x0B4 = 21 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_LEFT_DOOR);
            /* 0x0B8 = 22 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE_0_REAR_DOOR);
            /* 0x0BC = 23 */ _Part_Hash[offset++] = Bin.Hash(parts._BASE_KIT);
            /* 0x0C0 = 24 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_BRAKE);
            /* 0x0C4 = 25 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_LEFT_WINDOW);
            /* 0x0C8 = 26 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_RIGHT_WINDOW);
            /* 0x0CC = 27 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_WINDOW);
            /* 0x0D0 = 28 */ _Part_Hash[offset++] = Bin.Hash(parts._INTERIOR);
            /* 0x0D4 = 29 */ _Part_Hash[offset++] = Bin.Hash(parts._LEFT_BRAKELIGHT);
            /* 0x0D8 = 30 */ _Part_Hash[offset++] = Bin.Hash(parts._LEFT_BRAKELIGHT_GLASS);
            /* 0x0DC = 31 */ _Part_Hash[offset++] = Bin.Hash(parts._LEFT_HEADLIGHT);
            /* 0x0E0 = 32 */ _Part_Hash[offset++] = Bin.Hash(parts._LEFT_HEADLIGHT_GLASS);
            /* 0x0E4 = 33 */ _Part_Hash[offset++] = Bin.Hash(parts._LEFT_SIDE_MIRROR);
            /* 0x0E8 = 34 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_BRAKE);
            /* 0x0EC = 35 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_LEFT_WINDOW);
            /* 0x0F0 = 36 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_RIGHT_WINDOW);
            /* 0x0F4 = 37 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_WINDOW);
            /* 0x0F8 = 38 */ _Part_Hash[offset++] = Bin.Hash(parts._RIGHT_BRAKELIGHT);
            /* 0x0FC = 39 */ _Part_Hash[offset++] = Bin.Hash(parts._RIGHT_BRAKELIGHT_GLASS);
            /* 0x100 = 40 */ _Part_Hash[offset++] = Bin.Hash(parts._RIGHT_HEADLIGHT);
            /* 0x104 = 41 */ _Part_Hash[offset++] = Bin.Hash(parts._RIGHT_HEADLIGHT_GLASS);
            /* 0x108 = 42 */ _Part_Hash[offset++] = Bin.Hash(parts._RIGHT_SIDE_MIRROR);
            /* 0x10C = 43 */ _Part_Hash[offset++] = Bin.Hash(parts._DRIVER);
            /* 0x110 = 44 */ _Part_Hash[offset++] = Bin.Hash(parts._SPOILER);
            /* 0x114 = 45 */ _Part_Hash[offset++] = Bin.Hash(parts._UNIVERSAL_SPOILER_BASE);
            /* 0x118 = 46 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_FRONT);
            /* 0x11C = 47 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_FRONTLEFT);
            /* 0x120 = 48 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_FRONTRIGHT);
            /* 0x124 = 49 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_REAR);
            /* 0x128 = 50 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_REARLEFT);
            /* 0x12C = 51 */ _Part_Hash[offset++] = Bin.Hash(parts._DAMAGE0_REARRIGHT);
            for (uint a = 0; a < 10; ++a)
            {
                /* 0x130 = 52 */ _Part_Hash[offset++] = Bin.Hash(parts._ATTACHMENT + a.ToString());
            }
            /* 0x158 = 62 */ _Part_Hash[offset++] = Bin.Hash(parts.ROOF_STYLE);
            /* 0x15C = 63 */ _Part_Hash[offset++] = Bin.Hash(parts._HOOD);
            /* 0x168 = 64 */ _Part_Hash[offset++] = Bin.Hash(parts._WHEEL);
            /* 0x174 = 65 */ _Part_Hash[offset++] = Bin.Hash(parts.LICENSE_PLATE_STYLE01);
            /* 0x178 = 66 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM);
            /* 0x17C = 67 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_REAR_WINDOW_WIDE_MEDIUM);
            /* 0x180 = 68 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_DOOR_RECT_MEDIUM);
            /* 0x184 = 69 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_DOOR_RECT_MEDIUM);
            /* 0x188 = 70 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_QUARTER_RECT_MEDIUM);
            /* 0x18C = 71 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM);
            /* 0x190 = 72 */ _Part_Hash[offset++] = Bin.Hash(parts.PAINT);
            /* 0x194 = 73 */ _Part_Hash[offset++] = Bin.SmartHash(parts.VINYL_LAYER);
            /* 0x198 = 74 */ _Part_Hash[offset++] = Bin.Hash(parts.RIM_PAINT);
            /* 0x19C = 75 */ _Part_Hash[offset++] = Bin.Hash(parts.SWATCH[0]);
            /* 0x1A0 = 76 */ _Part_Hash[offset++] = Bin.Hash(parts.SWATCH[1]);
            /* 0x1A4 = 77 */ _Part_Hash[offset++] = Bin.Hash(parts.SWATCH[2]);
            /* 0x1A8 = 78 */ _Part_Hash[offset++] = Bin.Hash(parts.SWATCH[3]);
            /* 0x26C = 79 */ _Part_Hash[offset++] = Bin.Hash(parts.WINDOW_TINT_STOCK);
            return _Part_Hash;
        }
    }
}