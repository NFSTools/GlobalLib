using GlobalLib.Support.Shared.Parts.PresetParts;



namespace GlobalLib.Support.Carbon.Class
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
            uint[] _Part_Hash = new uint[52];
           	// Convert everything to bin hashes, put everything in one uint vector _Part_Hash
    	    /* 0x060 = 00 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._BASE);
    	    /* 0x0BC = 01 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._BASE_KIT);
    	    /* 0x0C0 = 02 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_BRAKE);
	        /* 0x0C4 = 03 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_ROTOR);
	        /* 0x0C8 = 04 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_LEFT_WINDOW);
	        /* 0x0CC = 05 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_RIGHT_WINDOW);
	        /* 0x0D0 = 06 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_WINDOW);
	        /* 0x0D4 = 07 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._INTERIOR);
	        /* 0x0D8 = 08 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._LEFT_BRAKELIGHT);
	        /* 0x0DC = 09 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._LEFT_BRAKELIGHT_GLASS);
	        /* 0x0E0 = 10 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._LEFT_HEADLIGHT);
	        /* 0x0E4 = 11 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._LEFT_HEADLIGHT_GLASS);
	        /* 0x0E8 = 12 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._LEFT_SIDE_MIRROR);
	        /* 0x0EC = 13 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_BRAKE);
	        /* 0x0F0 = 14 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_ROTOR);
	        /* 0x0F4 = 15 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_LEFT_WINDOW);
	        /* 0x0F8 = 16 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_RIGHT_WINDOW);
	        /* 0x0FC = 17 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_WINDOW);
	        /* 0x100 = 18 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._RIGHT_BRAKELIGHT);
	        /* 0x104 = 19 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._RIGHT_BRAKELIGHT_GLASS);
	        /* 0x108 = 20 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._RIGHT_HEADLIGHT);
	        /* 0x10C = 21 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._RIGHT_HEADLIGHT_GLASS);
	        /* 0x110 = 22 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._RIGHT_SIDE_MIRROR);
	        /* 0x114 = 23 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DRIVER);
	        /* 0x118 = 24 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._STEERINGWHEEL);
	        /* 0x11C = 25 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._KIT00_EXHAUST);
	        /* 0x120 = 26 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._SPOILER);
	        /* 0x124 = 27 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._UNIVERSAL_SPOILER_BASE);
	        /* 0x128 = 28 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_FRONT);
	        /* 0x12C = 29 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_FRONTLEFT);
	        /* 0x130 = 30 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_FRONTRIGHT);
	        /* 0x134 = 31 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_REAR);
	        /* 0x138 = 32 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_REARLEFT);
	        /* 0x13C = 33 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DAMAGE0_REARRIGHT);
	        /* 0x180 = 34 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_BUMPER);
	        /* 0x184 = 35 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._FRONT_BUMPER_BADGING_SET);
	        /* 0x188 = 36 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_BUMPER);
	        /* 0x18C = 37 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._REAR_BUMPER_BADGING_SET);
	        /* 0x190 = 38 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._ROOF);
	        /* 0x194 = 39 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts.ROOF_STYLE);
	        /* 0x198 = 40 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._HOOD);
	        /* 0x19C = 41 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._SKIRT);
	        /* 0x1A8 = 42 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DOOR_LEFT);
	        /* 0x1AC = 43 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._DOOR_RIGHT);
	        /* 0x1B0 = 44 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._WHEEL);
	        /* 0x1B8 = 45 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts.LICENSE_PLATE_STYLE01);
	        /* 0x1BC = 46 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts._KIT00_DOORLINE);
	        /* 0x1D4 = 47 */ _Part_Hash[offset++] = Utils.Bin.SmartHash(this._specific_vinyl);
	        /* 0x1D8 = 48 */ _Part_Hash[offset++] = Utils.Bin.SmartHash(this._generic_vinyl);
	        /* 0x1F8 = 49 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts.WINDOW_TINT_STOCK);
	        /* 0x20C = 50 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts.PAINT);
	        /* 0x210 = 51 */ _Part_Hash[offset++] = Utils.Bin.Hash(parts.SWATCH_COLOR);
            return _Part_Hash;
        }
    }
}