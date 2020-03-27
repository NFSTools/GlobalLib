namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Assembles preset ride into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset ride.</returns>
        public override unsafe byte[] Assemble()
        {
            var result = new byte[this.data.Length];
            System.Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);
            fixed (byte* byteptr_t = &result[0])
            {
                var parts = new Shared.Parts.PresetParts.Concatenator();
                var add_on = new Shared.Parts.PresetParts.Add_On();

                // Frontend and Pvehicle
                this._Frontend_Hash = Utils.Vlt.SmartHash(this.Frontend);
                this._Pvehicle_Hash = Utils.Vlt.SmartHash(this.Pvehicle);

                // _BASE
                parts._BASE = MODEL + parts._BASE;

                // _DAMAGE_0
                parts._DAMAGE_0_FRONT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_WINDOW;
                parts._DAMAGE_0_BODY = MODEL + parts._DAMAGE_0_BODY;
                parts._DAMAGE_0_COP_LIGHTS = MODEL + parts._DAMAGE_0_COP_LIGHTS;
                parts._DAMAGE_0_SPOILER = MODEL + parts._DAMAGE_0_SPOILER;
                parts._DAMAGE_0_FRONT_WHEEL = MODEL + parts._DAMAGE_0_FRONT_WHEEL;
                parts._DAMAGE_0_LEFT_BRAKELIGHT = MODEL + parts._DAMAGE_0_LEFT_BRAKELIGHT;
                parts._DAMAGE_0_RIGHT_BREAKLIGHT = MODEL + parts._DAMAGE_0_RIGHT_BREAKLIGHT;
                parts._DAMAGE_0_LEFT_HEADLIGHT = MODEL + parts._DAMAGE_0_LEFT_HEADLIGHT;
                parts._DAMAGE_0_RIGHT_HEADLIGHT = MODEL + parts._DAMAGE_0_RIGHT_HEADLIGHT;
                parts._DAMAGE_0_HOOD = MODEL + parts._DAMAGE_0_HOOD;
                parts._DAMAGE_0_BUSHGUARD = MODEL + parts._DAMAGE_0_BUSHGUARD;
                parts._DAMAGE_0_FRONT_BUMPER = MODEL + parts._DAMAGE_0_FRONT_BUMPER;
                parts._DAMAGE_0_RIGHT_DOOR = MODEL + parts._DAMAGE_0_RIGHT_DOOR;
                parts._DAMAGE_0_RIGHT_REAR_DOOR = MODEL + parts._DAMAGE_0_RIGHT_REAR_DOOR;
                parts._DAMAGE_0_TRUNK = MODEL + parts._DAMAGE_0_TRUNK;
                parts._DAMAGE_0_REAR_BUMPER = MODEL + parts._DAMAGE_0_REAR_BUMPER;
                parts._DAMAGE_0_REAR_LEFT_WINDOW = MODEL + parts._DAMAGE_0_REAR_LEFT_WINDOW;
                parts._DAMAGE_0_FRONT_LEFT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_LEFT_WINDOW;
                parts._DAMAGE_0_FRONT_RIGHT_WINDOW = MODEL + parts._DAMAGE_0_FRONT_RIGHT_WINDOW;
                parts._DAMAGE_0_REAR_RIGHT_WINDOW = MODEL + parts._DAMAGE_0_REAR_RIGHT_WINDOW;
                parts._DAMAGE_0_LEFT_DOOR = MODEL + parts._DAMAGE_0_LEFT_DOOR;
                parts._DAMAGE_0_REAR_DOOR = MODEL + parts._DAMAGE_0_REAR_DOOR;

                // _BASE_KIT
                if (this._aftermarket_bodykit == -1)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT;
                else
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + add_on._KIT + this._aftermarket_bodykit.ToString();

                // Bunch of stuff
                parts._FRONT_BRAKE = MODEL + parts._FRONT_BRAKE;
                parts._FRONT_LEFT_WINDOW = MODEL + parts._FRONT_LEFT_WINDOW;
                parts._FRONT_RIGHT_WINDOW = MODEL + parts._FRONT_RIGHT_WINDOW;
                parts._FRONT_WINDOW = MODEL + parts._FRONT_WINDOW;
                parts._INTERIOR = MODEL + parts._INTERIOR;
                parts._LEFT_BRAKELIGHT = MODEL + parts._LEFT_BRAKELIGHT;
                parts._LEFT_BRAKELIGHT_GLASS = MODEL + parts._LEFT_BRAKELIGHT_GLASS;
                parts._LEFT_HEADLIGHT = MODEL + parts._LEFT_HEADLIGHT;
                parts._LEFT_HEADLIGHT_GLASS = MODEL + parts._LEFT_HEADLIGHT_GLASS;
                parts._LEFT_SIDE_MIRROR = MODEL + parts._LEFT_SIDE_MIRROR;
                parts._REAR_BRAKE = MODEL + parts._REAR_BRAKE;
                parts._REAR_LEFT_WINDOW = MODEL + parts._REAR_LEFT_WINDOW;
                parts._REAR_RIGHT_WINDOW = MODEL + parts._REAR_RIGHT_WINDOW;
                parts._REAR_WINDOW = MODEL + parts._REAR_WINDOW;
                parts._RIGHT_BRAKELIGHT = MODEL + parts._RIGHT_BRAKELIGHT;
                parts._RIGHT_BRAKELIGHT_GLASS = MODEL + parts._RIGHT_BRAKELIGHT_GLASS;
                parts._RIGHT_HEADLIGHT = MODEL + parts._RIGHT_HEADLIGHT;
                parts._RIGHT_HEADLIGHT_GLASS = MODEL + parts._RIGHT_HEADLIGHT_GLASS;
                parts._RIGHT_SIDE_MIRROR = MODEL + parts._RIGHT_SIDE_MIRROR;
                parts._DRIVER = MODEL + parts._DRIVER;

                // _SPOILER
                if (this._spoiler_type == Reflection.Enum.eSTypes.NULL)
                    parts._SPOILER = "";
                else if (this._spoiler_type == Reflection.Enum.eSTypes.STOCK || this._spoiler_style == 0)
                    parts._SPOILER = MODEL + parts._SPOILER;
                else
                {
                    parts._SPOILER = add_on.SPOILER + add_on._STYLE + this._spoiler_style.ToString("00");
                    if (this.SpoilerType != Reflection.Enum.eSTypes.BASE)
                        parts._SPOILER += this._spoiler_type.ToString();
                    if (this._is_carbonfibre_spoiler == Reflection.Enum.eBoolean.True)
                        parts._SPOILER += add_on._CF;
                }

                // _UNIVERSAL_SPOILER_BASE
                parts._UNIVERSAL_SPOILER_BASE = MODEL + parts._UNIVERSAL_SPOILER_BASE;

                // _DAMAGE0_FRONT and _DAMAGE0_REAR
                parts._DAMAGE0_FRONT = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONT;
                parts._DAMAGE0_FRONTLEFT = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONTLEFT;
                parts._DAMAGE0_FRONTRIGHT = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONTRIGHT;
                parts._DAMAGE0_REAR = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REAR;
                parts._DAMAGE0_REARLEFT = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REARLEFT;
                parts._DAMAGE0_REARRIGHT = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REARRIGHT;

                // _ATTACHMENT
                parts._ATTACHMENT = MODEL + parts._ATTACHMENT;

                // ROOF_STYLE
                if (this._roofscoop_style == 0)
                    parts.ROOF_STYLE += add_on._0 + add_on._0;
                else
                {
                    parts.ROOF_STYLE += this._roofscoop_style.ToString("00");
                    if (this._is_dual_roofscoop == Reflection.Enum.eBoolean.True)
                        parts.ROOF_STYLE += add_on._DUAL;
                    if (this._is_offset_roofscoop == Reflection.Enum.eBoolean.True && this._is_dual_roofscoop == Reflection.Enum.eBoolean.False)
                        parts.ROOF_STYLE += add_on._OFFSET;
                    if (this._is_carbonfibre_roofscoop == Reflection.Enum.eBoolean.True)
                        parts.ROOF_STYLE += add_on._CF;
                }

                // _HOOD
                if (this._hood_style == 0)
                    parts._HOOD = MODEL + add_on._KIT + add_on._0 + parts._HOOD;
                else
                {
                    parts._HOOD = MODEL + add_on._STYLE + this._hood_style.ToString("00") + parts._HOOD;
                    if (this._is_carbonfibre_hood == Reflection.Enum.eBoolean.True)
                        parts._HOOD += add_on._CF;
                }

                // _WHEEL
                switch (this._rim_brand)
                {
                    case Reflection.BaseArguments.NULL:
                    case Reflection.BaseArguments.STOCK:
                        parts._WHEEL = MODEL + parts._WHEEL; // null, empty, NULL or STOCK
                        break;
                    default:
                        parts._WHEEL = $"{this._rim_brand}{add_on._STYLE}{this._rim_style:00}_{this._rim_size}{add_on._25}";
                        break;
                }

                // _DECAL
                parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM;
                parts._DECAL_REAR_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM;
                parts._DECAL_LEFT_DOOR_RECT_MEDIUM = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DECAL_LEFT_DOOR_RECT_MEDIUM;
                parts._DECAL_RIGHT_DOOR_RECT_MEDIUM = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM;
                parts._DECAL_LEFT_QUARTER_RECT_MEDIUM = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM;
                parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM = MODEL + add_on._KIT + this._aftermarket_bodykit.ToString() + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM;

                // PAINT
                parts.PAINT = this._body_paint;

                // RIMPAINT
                if (this.RimPaint != Reflection.BaseArguments.NULL)
                    parts.RIM_PAINT = this._rim_paint;

                // WINDOW_TINT
                if (this.WindowTintType != Reflection.BaseArguments.STOCK)
                    parts.WINDOW_TINT_STOCK = this._window_tint_type;

                // VINYL_LAYER
                if (this.VinylName != Reflection.BaseArguments.NULL)
                    parts.VINYL_LAYER = this.VinylName;

                // SWATCH
                parts.SWATCH[0] = Utils.EA.Resolve.GetVinylString(this._vinylcolor1);
                parts.SWATCH[1] = Utils.EA.Resolve.GetVinylString(this._vinylcolor2);
                parts.SWATCH[2] = Utils.EA.Resolve.GetVinylString(this._vinylcolor3);
                parts.SWATCH[3] = Utils.EA.Resolve.GetVinylString(this._vinylcolor4);

                // Hash all strings to keys
                var keys = this.StringToKey(parts);

                // Write CollectionName
                for (int a1 = 0; a1 < 0x20; ++a1)
                    *(byteptr_t + 0x28 + a1) = (byte)0;
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + 0x28 + a1) = (byte)this.CollectionName[a1];

                // Write Fronend and Pvehicle
                *(uint*)(byteptr_t + 0x48) = this._Frontend_Hash;
                *(uint*)(byteptr_t + 0x50) = this._Pvehicle_Hash;

                // If the preset already existed, it is better to internally modify its main values
                // rather than overwriting it, to avoid changing some other values; also, if the model
                // was not changed, it skips bunch of other conversions and hashing stages
                if (this.Exists && (this.MODEL == this.OriginalModel))
                {
                    if (!this.Modified) // if exists and not modified, return original array
                        return this.data;

                    // Write settings that could have been changed
                    fixed (uint* uintptr_t = &keys[0])
                    {
                        *(uint*)(byteptr_t + 0xBC) = *(uintptr_t + 23);  // _BASE_KIT
                        *(uint*)(byteptr_t + 0x110) = *(uintptr_t + 44); // _SPOILER
                        *(uint*)(byteptr_t + 0x114) = *(uintptr_t + 45); // _UNIVERSAL_SPOILER_BASE
                        *(uint*)(byteptr_t + 0x118) = *(uintptr_t + 46); // _DAMAGE0_FRONT
                        *(uint*)(byteptr_t + 0x11C) = *(uintptr_t + 47); // _DAMAGE0_FRONTLEFT
                        *(uint*)(byteptr_t + 0x120) = *(uintptr_t + 48); // _DAMAGE0_FRONTRIGHT
                        *(uint*)(byteptr_t + 0x124) = *(uintptr_t + 49); // _DAMAGE0_REAR
                        *(uint*)(byteptr_t + 0x128) = *(uintptr_t + 50); // _DAMAGE0_REARLEFT
                        *(uint*)(byteptr_t + 0x12C) = *(uintptr_t + 51); // _DAMAGE0_REARRIGHT
                        *(uint*)(byteptr_t + 0x158) = *(uintptr_t + 62); // ROOF_STYLE
                        *(uint*)(byteptr_t + 0x15C) = *(uintptr_t + 63); // _HOOD
                        *(uint*)(byteptr_t + 0x168) = *(uintptr_t + 64); // _WHEEL
                        *(uint*)(byteptr_t + 0x190) = *(uintptr_t + 72); // PAINT
                        *(uint*)(byteptr_t + 0x194) = *(uintptr_t + 73); // VINYL_LAYER
                        *(uint*)(byteptr_t + 0x198) = *(uintptr_t + 74); // RIM_PAINT
                        *(uint*)(byteptr_t + 0x19C) = *(uintptr_t + 75); // SWATCH[0]
                        *(uint*)(byteptr_t + 0x1A0) = *(uintptr_t + 76); // SWATCH[1]
                        *(uint*)(byteptr_t + 0x1A4) = *(uintptr_t + 77); // SWATCH[2]
                        *(uint*)(byteptr_t + 0x1A8) = *(uintptr_t + 78); // SWATCH[3]
                        *(uint*)(byteptr_t + 0x26C) = *(uintptr_t + 79); // WINDOW_TINT
                    }
                }

                // If the model was changed or if the preset car is new, either overwrite existing file completely
                // or create a new one for the new car
                else
                {
                    // Write ModelName
                    for (int a1 = 0; a1 < 0x20; ++a1)
                        *(byteptr_t + 8 + a1) = (byte)0;
                    for (int a1 = 0; a1 < this.MODEL.Length; ++a1)
                        *(byteptr_t + 8 + a1) = (byte)this.MODEL[a1];

                    // Write all keys
                    fixed (uint* uintptr_t = &keys[0])
                    {
                        for (int a1 = 0; a1 < 64; ++a1)
                            *(uint*)(byteptr_t + 0x60 + a1 * 4) = *(uintptr_t + a1);

                        *(uint*)(byteptr_t + 0x168) = *(uintptr_t + 64);

                        for (int a1 = 0; a1 < 14; ++a1)
                            *(uint*)(byteptr_t + 0x174 + a1 * 4) = *(uintptr_t + 65 + a1);

                        *(uint*)(byteptr_t + 0x26C) = *(uintptr_t + 79);
                        if (!this.Exists)
                        {
                            *(uint*)(byteptr_t + 0x270) = Utils.Bin.Hash(parts.HUD);
                            *(uint*)(byteptr_t + 0x274) = Utils.Bin.Hash(parts.HUD_BACKING);
                            *(uint*)(byteptr_t + 0x278) = Utils.Bin.Hash(parts.HUD_NEEDLE);
                            *(uint*)(byteptr_t + 0x27C) = Utils.Bin.Hash(parts.HUD_CHARS);
                        }
                    }
                }
            }
            return result;
        }
    }
}