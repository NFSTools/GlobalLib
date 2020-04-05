using GlobalLib.Support.Shared.Parts.PresetParts;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Class
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
            uint[] _Part_Hash = new uint[100];
            /* 0x04C = 00 */ _Part_Hash[offset++] = Bin.Hash(parts._BASE);
            /* 0x050 = 01 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_BUMPER);
            /* 0x054 = 02 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_BUMPER);
            /* 0x060 = 03 */ _Part_Hash[offset++] = Bin.Hash(parts._BASE_KIT);
            /* 0x064 = 04 */ _Part_Hash[offset++] = Bin.Hash(parts._KITW_BODY);
            /* 0x068 = 05 */ _Part_Hash[offset++] = Bin.Hash(parts.ROOF_STYLE);
            /* 0x070 = 06 */ _Part_Hash[offset++] = Bin.Hash(parts._HOOD);
            /* 0x074 = 07 */ _Part_Hash[offset++] = Bin.Hash(parts._TRUNK);
            /* 0x078 = 08 */ _Part_Hash[offset++] = Bin.Hash(parts._SKIRT);
            /* 0x07C = 09 */ _Part_Hash[offset++] = Bin.Hash(parts._SPOILER);
            /* 0x080 = 10 */ _Part_Hash[offset++] = Bin.Hash(parts._ENGINE);
            /* 0x084 = 11 */ _Part_Hash[offset++] = Bin.Hash(parts._HEADLIGHT);
            /* 0x088 = 12 */ _Part_Hash[offset++] = Bin.Hash(parts._BRAKELIGHT);
            /* 0x08C = 13 */ _Part_Hash[offset++] = Bin.Hash(parts._KIT00_EXHAUST);
            /* 0x090 = 14 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_LEFT);
            /* 0x094 = 15 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_RIGHT);
            /* 0x098 = 16 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_PANEL_LEFT);
            /* 0x09C = 17 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_PANEL_RIGHT);
            /* 0x0A0 = 18 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_SILL_LEFT);
            /* 0x0A4 = 19 */ _Part_Hash[offset++] = Bin.Hash(parts._DOOR_SILL_RIGHT);
            /* 0x0B0 = 20 */ _Part_Hash[offset++] = Bin.Hash(parts._HOOD_UNDER);
            /* 0x0B4 = 21 */ _Part_Hash[offset++] = Bin.Hash(parts._TRUNK_UNDER);
            /* 0x0B8 = 22 */ _Part_Hash[offset++] = Bin.Hash(parts._FRONT_BRAKE);
            /* 0x0BC = 23 */ _Part_Hash[offset++] = Bin.Hash(parts._REAR_BRAKE);
            /* 0x0C0 = 24 */ _Part_Hash[offset++] = Bin.Hash(parts._WHEEL);
            /* 0x0CC = 25 */ _Part_Hash[offset++] = Bin.SmartHash(parts._WING_MIRROR);
            /* 0x0D0 = 26 */ _Part_Hash[offset++] = Bin.Hash(parts.LICENSE_PLATE_STYLE01);
            /* 0x0D4 = 27 */ _Part_Hash[offset++] = Bin.Hash(parts._TRUNK_AUDIO);
            /* 0x0D8 = 28 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall00);
            /* 0x0DC = 29 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall01);
            /* 0x0E0 = 30 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompMedium02);
            /* 0x0E4 = 31 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompMedium03);
            /* 0x0E8 = 32 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompLarge04);
            /* 0x0EC = 33 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompLarge05);
            /* 0x0F0 = 34 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall06);
            /* 0x0F4 = 35 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall07);
            /* 0x0F8 = 36 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall08);
            /* 0x0FC = 37 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompSmall09);
            /* 0x100 = 38 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompMedium10);
            /* 0x104 = 39 */ _Part_Hash[offset++] = Bin.SmartHash(this.AUDIO_COMP.AudioCompMedium11);
            /* 0x11C = 40 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_HOOD_RECT_);
            /* 0x120 = 41 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM);
            /* 0x124 = 42 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_REAR_WINDOW_WIDE_MEDIUM);
            /* 0x128 = 43 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_DOOR_RECT_);
            /* 0x12C = 44 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_DOOR_RECT_);
            /* 0x130 = 45 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_QUARTER_RECT_);
            /* 0x134 = 46 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_QUARTER_RECT_);
            /* 0x138 = 47 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_DOOR_RECT_MEDIUM);
            /* 0x13C = 48 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_DOOR_RECT_MEDIUM);
            /* 0x140 = 49 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_LEFT_QUARTER_RECT_MEDIUM);
            /* 0x144 = 50 */ _Part_Hash[offset++] = Bin.Hash(parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM);
            /* 0x148 = 51 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.BasePaintType);
            /* 0x14C = 52 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.VinylLayer0);
            /* 0x150 = 53 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.VinylLayer1);
            /* 0x154 = 54 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.VinylLayer2);
            /* 0x158 = 55 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.VinylLayer3);
            /* 0x15C = 56 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.EnginePaintType);
            /* 0x160 = 57 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.SpoilerPaintType);
            /* 0x164 = 58 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.BrakesPaintType);
            /* 0x168 = 59 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.ExhaustPaintType);
            /* 0x16C = 60 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.AudioPaintType);
            /* 0x170 = 61 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.RimsPaintType);
            /* 0x174 = 62 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.SpinnersPaintType);
            /* 0x178 = 63 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.RoofPaintType);
            /* 0x17C = 64 */ _Part_Hash[offset++] = Bin.SmartHash(this.PAINT_TYPES.MirrorsPaintType);
            /* 0x180 = 65 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl0_Color0);
            /* 0x184 = 66 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl0_Color1);
            /* 0x188 = 67 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl0_Color2);
            /* 0x18C = 68 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl0_Color3);
            /* 0x190 = 69 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl1_Color0);
            /* 0x194 = 70 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl1_Color1);
            /* 0x198 = 71 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl1_Color2);
            /* 0x19C = 72 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl1_Color3);
            /* 0x1A0 = 73 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl2_Color0);
            /* 0x1A4 = 74 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl2_Color1);
            /* 0x1A8 = 75 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl2_Color2);
            /* 0x1AC = 76 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl2_Color3);
            /* 0x1B0 = 77 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl3_Color0);
            /* 0x1B4 = 78 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl3_Color1);
            /* 0x1B8 = 79 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl3_Color2);
            /* 0x1BC = 80 */ _Part_Hash[offset++] = Bin.SmartHash(this.VINYL_SETS.Vinyl3_Color3);
            /* 0x1C0 = 81 */ _Part_Hash[offset++] = Bin.SmartHash(parts.KIT_CARBON);
            /* 0x1C4 = 82 */ _Part_Hash[offset++] = Bin.SmartHash(parts.HOOD_CARBON);
            /* 0x1C8 = 83 */ _Part_Hash[offset++] = Bin.SmartHash(parts.DOOR_CARBON);
            /* 0x1CC = 84 */ _Part_Hash[offset++] = Bin.SmartHash(parts.TRUNK_CARBON);
            /* 0x2B0 = 85 */ _Part_Hash[offset++] = Bin.Hash(parts.WINDOW_TINT_STOCK);
            /* 0x2B4 = 86 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.NeonBody);
            /* 0x2B8 = 87 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.NeonEngine);
            /* 0x2BC = 88 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.NeonCabin);
            /* 0x2C0 = 89 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.NeonTrunk);
            /* 0x2C4 = 90 */ _Part_Hash[offset++] = Bin.Hash(parts.CABIN_NEON_STYLE0);
            /* 0x2C8 = 91 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.HeadlightBulbStyle);
            /* 0x2CC = 92 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.DoorOpeningStyle);
            /* 0x2D0 = 93 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.HydraulicsStyle);
            /* 0x2D4 = 94 */ _Part_Hash[offset++] = Bin.SmartHash(this.SPECIALTIES.NOSPurgeStyle);
            /* 0x2D8 = 95 */ _Part_Hash[offset++] = Bin.SmartHash(this.CustomHUDStyle);
            /* 0x2DC = 96 */ _Part_Hash[offset++] = Bin.SmartHash(this.HUDBackingColor);
            /* 0x2E0 = 97 */ _Part_Hash[offset++] = Bin.SmartHash(this.HUDNeedleColor);
            /* 0x2E4 = 98 */ _Part_Hash[offset++] = Bin.SmartHash(this.HUDCharacterColor);
            /* 0x2F0 = 99 */ _Part_Hash[offset++] = Bin.Hash(parts._CV);
            return _Part_Hash;
        }
    }
}