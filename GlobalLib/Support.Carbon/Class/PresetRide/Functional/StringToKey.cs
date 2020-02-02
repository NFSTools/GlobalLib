using GlobalLib.Support.Shared.Parts.PresetParts;



namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected override unsafe uint[] StringToKey(Concatenator parts)
        {
            int offset = 0;
            uint[] _Part_Hash = new uint[52];
            fixed (uint* uintptr_t = &_Part_Hash[0])
            {
           	    // Convert everything to bin hashes, put everything in one uint vector _Part_Hash
    	        /* 0x060 = 00 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._BASE);
    	        /* 0x0BC = 01 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._BASE_KIT);
    	        /* 0x0C0 = 02 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_BRAKE);
	            /* 0x0C4 = 03 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_ROTOR);
	            /* 0x0C8 = 04 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_LEFT_WINDOW);
	            /* 0x0CC = 05 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_RIGHT_WINDOW);
	            /* 0x0D0 = 06 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_WINDOW);
	            /* 0x0D4 = 07 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._INTERIOR);
	            /* 0x0D8 = 08 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._LEFT_BRAKELIGHT);
	            /* 0x0DC = 09 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._LEFT_BRAKELIGHT_GLASS);
	            /* 0x0E0 = 10 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._LEFT_HEADLIGHT);
	            /* 0x0E4 = 11 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._LEFT_HEADLIGHT_GLASS);
	            /* 0x0E8 = 12 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._LEFT_SIDE_MIRROR);
	            /* 0x0EC = 13 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_BRAKE);
	            /* 0x0F0 = 14 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_ROTOR);
	            /* 0x0F4 = 15 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_LEFT_WINDOW);
	            /* 0x0F8 = 16 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_RIGHT_WINDOW);
	            /* 0x0FC = 17 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_WINDOW);
	            /* 0x100 = 18 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._RIGHT_BRAKELIGHT);
	            /* 0x104 = 19 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._RIGHT_BRAKELIGHT_GLASS);
	            /* 0x108 = 20 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._RIGHT_HEADLIGHT);
	            /* 0x10C = 21 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._RIGHT_HEADLIGHT_GLASS);
	            /* 0x110 = 22 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._RIGHT_SIDE_MIRROR);
	            /* 0x114 = 23 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DRIVER);
	            /* 0x118 = 24 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._STEERINGWHEEL);
	            /* 0x11C = 25 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._KIT00_EXHAUST);
	            /* 0x120 = 26 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._SPOILER);
	            /* 0x124 = 27 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._UNIVERSAL_SPOILER_BASE);
	            /* 0x128 = 28 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_FRONT);
	            /* 0x12C = 29 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_FRONTLEFT);
	            /* 0x130 = 30 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_FRONTRIGHT);
	            /* 0x134 = 31 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_REAR);
	            /* 0x138 = 32 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_REARLEFT);
	            /* 0x13C = 33 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DAMAGE0_REARRIGHT);
	            /* 0x180 = 34 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_BUMPER);
	            /* 0x184 = 35 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._FRONT_BUMPER_BADGING_SET);
	            /* 0x188 = 36 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_BUMPER);
	            /* 0x18C = 37 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._REAR_BUMPER_BADGING_SET);
	            /* 0x190 = 38 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._ROOF);
	            /* 0x194 = 39 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts.ROOF_STYLE);
	            /* 0x198 = 40 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._HOOD);
	            /* 0x19C = 41 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._SKIRT);
	            /* 0x1A8 = 42 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DOOR_LEFT);
	            /* 0x1AC = 43 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._DOOR_RIGHT);
	            /* 0x1B0 = 44 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._WHEEL);
	            /* 0x1B8 = 45 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts.LICENSE_PLATE_STYLE01);
	            /* 0x1BC = 46 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts._KIT00_DOORLINE);
	            /* 0x1D4 = 47 */ *(uintptr_t + offset++) = Utils.Bin.Hash(this._specific_vinyl);
	            /* 0x1D8 = 48 */ *(uintptr_t + offset++) = Utils.Bin.Hash(this._generic_vinyl);
	            /* 0x1F8 = 49 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts.WINDOW_TINT_STOCK);
	            /* 0x20C = 50 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts.PAINT);
	            /* 0x210 = 51 */ *(uintptr_t + offset++) = Utils.Bin.Hash(parts.SWATCH_COLOR);
            }
            return _Part_Hash;
        }
    }
}