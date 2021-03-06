﻿using GlobalLib.Reflection;
using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Carbon.Parts.PresetParts;
using GlobalLib.Support.Shared.Parts.PresetParts;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Carbon.Class
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
            Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);
            fixed (byte* byteptr_t = &result[0])
            {
                var parts = new Concatenator();
                var add_on = new Add_On();

                // Frontend and Pvehicle
                this._Frontend_Hash = Vlt.SmartHash(this.Frontend);
                this._Pvehicle_Hash = Vlt.SmartHash(this.Pvehicle);

                // _BASE
                parts._BASE = MODEL + parts._BASE;

                // _BASE_KIT
                if (this._aftermarket_bodykit == -1)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT;
                else if (this._aftermarket_bodykit == 0)
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + add_on._KIT + add_on._0;
                else
                    parts._BASE_KIT = MODEL + parts._BASE_KIT + add_on._KITW + _aftermarket_bodykit.ToString();

                // Bunch of stuff
                parts._FRONT_BRAKE = MODEL + parts._FRONT_BRAKE;
                parts._FRONT_ROTOR = MODEL + parts._FRONT_ROTOR;
                parts._FRONT_LEFT_WINDOW = MODEL + parts._FRONT_LEFT_WINDOW;
                parts._FRONT_RIGHT_WINDOW = MODEL + parts._FRONT_RIGHT_WINDOW;
                parts._FRONT_WINDOW = MODEL + parts._FRONT_WINDOW;
                parts._INTERIOR = MODEL + parts._INTERIOR;
                parts._LEFT_BRAKELIGHT = MODEL + parts._LEFT_BRAKELIGHT;
                parts._LEFT_BRAKELIGHT_GLASS = MODEL + parts._LEFT_BRAKELIGHT_GLASS;

                // _LEFT_HEADLIGHT
                if (this._popup_headlights_exist == eBoolean.False)
                    parts._LEFT_HEADLIGHT = MODEL + parts._LEFT_HEADLIGHT;
                else
                {
                    parts._LEFT_HEADLIGHT = (this._popup_heaglights_on == eBoolean.True)
                        ? MODEL + parts._LEFT_HEADLIGHT + add_on._ON
                        : MODEL + parts._LEFT_HEADLIGHT + add_on._OFF;
                }

                // _LEFT_HEADLIGHT_GLASS
                parts._LEFT_HEADLIGHT_GLASS = MODEL + parts._LEFT_HEADLIGHT_GLASS;

                // Bunch of stuff
                parts._LEFT_SIDE_MIRROR = MODEL + parts._LEFT_SIDE_MIRROR;
                parts._REAR_BRAKE = MODEL + parts._REAR_BRAKE;
                parts._REAR_ROTOR = MODEL + parts._REAR_ROTOR;
                parts._REAR_LEFT_WINDOW = MODEL + parts._REAR_LEFT_WINDOW;
                parts._REAR_RIGHT_WINDOW = MODEL + parts._REAR_RIGHT_WINDOW;
                parts._REAR_WINDOW = MODEL + parts._REAR_WINDOW;
                parts._RIGHT_BRAKELIGHT = MODEL + parts._RIGHT_BRAKELIGHT;
                parts._RIGHT_BRAKELIGHT_GLASS = MODEL + parts._RIGHT_BRAKELIGHT_GLASS;

                // _RIGHT_HEADLIGHT
                if (this._popup_headlights_exist == eBoolean.False)
                    parts._RIGHT_HEADLIGHT = MODEL + parts._RIGHT_HEADLIGHT;
                else
                {
                    parts._RIGHT_HEADLIGHT = (this._popup_heaglights_on == eBoolean.True)
                        ? MODEL + parts._RIGHT_HEADLIGHT + add_on._ON
                        : MODEL + parts._RIGHT_HEADLIGHT + add_on._OFF;
                }

                // _RIGHT_HEADLIGHT_GLASS
                parts._RIGHT_HEADLIGHT_GLASS = MODEL + parts._RIGHT_HEADLIGHT_GLASS;

                // Bunch of stuff
                parts._RIGHT_SIDE_MIRROR = MODEL + parts._RIGHT_SIDE_MIRROR;
                parts._DRIVER = MODEL + parts._DRIVER;
                parts._STEERINGWHEEL = MODEL + parts._STEERINGWHEEL;

                // _KIT00_EXHAUST
                if (this._exhaust_style == -1)
                    parts._KIT00_EXHAUST = string.Empty;
                else if (this._exhaust_style == 0 || this._aftermarket_bodykit >= 1)
                    parts._KIT00_EXHAUST = MODEL + parts._KIT00_EXHAUST;
                else
                {
                    parts._KIT00_EXHAUST = add_on.EXHAUST + add_on._STYLE + this._exhaust_style.ToString("00");
                    if (this._is_center_exhaust == eBoolean.True)
                        parts._KIT00_EXHAUST += add_on._CENTER;
                    parts._KIT00_EXHAUST += add_on._LEVEL1;
                }

                // _SPOILER
                if (this._spoiler_type == eSTypes.NULL)
                    parts._SPOILER = "";
                else if (this._spoiler_type == eSTypes.STOCK || this._spoiler_style == 0)
                    parts._SPOILER = MODEL + parts._SPOILER;
                else
                {
                    parts._SPOILER = (this._is_autosculpt_spoiler == eBoolean.True)
                        ? add_on.AS_SPOILER
                        : add_on.SPOILER;
                    parts._SPOILER += add_on._STYLE + this._spoiler_style.ToString("00");
                    if (this._spoiler_type != eSTypes.BASE)
                        parts._SPOILER += this._spoiler_type.ToString();
                    if (this._is_carbonfibre_spoiler == eBoolean.True)
                        parts._SPOILER += add_on._CF;
                }

                // _UNIVERSAL_SPOILER_BASE
                parts._UNIVERSAL_SPOILER_BASE = MODEL + parts._UNIVERSAL_SPOILER_BASE;

                // _DAMAGE0_FRONT and _DAMAGE0_REAR
                if (this._aftermarket_bodykit <= 0)
                    goto LABEL_AUTOSCULPT_DAMAGE;
                else
                    goto LABEL_AFTERMARKET_DAMAGE;

                LABEL_AUTOSCULPT_DAMAGE:
                // _FRONT_DAMAGE0 + FRONT_BUMPER
                if (this._autosculpt_frontbumper == -1)
                {
                    parts._DAMAGE0_FRONT = string.Empty;
                    parts._DAMAGE0_FRONTLEFT = string.Empty;
                    parts._DAMAGE0_FRONTRIGHT = string.Empty;
                    parts._FRONT_BUMPER = string.Empty;
                    parts._FRONT_BUMPER_BADGING_SET = string.Empty;
                }
                else
                {
                    string autofpad = this._autosculpt_frontbumper.ToString("00");
                    parts._DAMAGE0_FRONT = MODEL + add_on._K10 + autofpad + parts._DAMAGE0_FRONT;
                    parts._DAMAGE0_FRONTLEFT = MODEL + add_on._K10 + autofpad + parts._DAMAGE0_FRONTLEFT;
                    parts._DAMAGE0_FRONTRIGHT = MODEL + add_on._K10 + autofpad + parts._DAMAGE0_FRONTRIGHT;
                    parts._FRONT_BUMPER = MODEL + add_on._K10 + autofpad + parts._FRONT_BUMPER;
                    parts._FRONT_BUMPER_BADGING_SET = MODEL + add_on._KIT + (this._autosculpt_frontbumper % 9).ToString() + parts._FRONT_BUMPER_BADGING_SET;
                }

                // REAR_DAMAGE0 + REAR_BUMPER
                if (this._autosculpt_rearbumper == -1)
                {
                    parts._DAMAGE0_REAR = string.Empty;
                    parts._DAMAGE0_REARLEFT = string.Empty;
                    parts._DAMAGE0_REARRIGHT = string.Empty;
                    parts._REAR_BUMPER = string.Empty;
                    parts._REAR_BUMPER_BADGING_SET = string.Empty;
                }
                else
                {
                    var autorpad = this._autosculpt_rearbumper.ToString("00");
                    parts._DAMAGE0_REAR = MODEL + add_on._K10 + autorpad + parts._DAMAGE0_REAR;
                    parts._DAMAGE0_REARLEFT = MODEL + add_on._K10 + autorpad + parts._DAMAGE0_REARLEFT;
                    parts._DAMAGE0_REARRIGHT = MODEL + add_on._K10 + autorpad + parts._DAMAGE0_REARRIGHT;
                    parts._REAR_BUMPER = MODEL + add_on._K10 + autorpad + parts._REAR_BUMPER;
                    parts._REAR_BUMPER_BADGING_SET = MODEL + add_on._KIT + (this._autosculpt_rearbumper % 9).ToString() + parts._REAR_BUMPER_BADGING_SET;
                }
                goto LABEL_NEXT;

            LABEL_AFTERMARKET_DAMAGE:
                // FRONT_DAMAGE0 + REAR_DAMAGE0
                parts._DAMAGE0_FRONT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONT;
                parts._DAMAGE0_FRONTLEFT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONTLEFT;
                parts._DAMAGE0_FRONTRIGHT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_FRONTRIGHT;
                parts._DAMAGE0_REAR = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REAR;
                parts._DAMAGE0_REARLEFT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REARLEFT;
                parts._DAMAGE0_REARRIGHT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DAMAGE0_REARRIGHT;
                parts._FRONT_BUMPER = "";
                parts._FRONT_BUMPER_BADGING_SET = "";
                parts._REAR_BUMPER = "";
                parts._REAR_BUMPER_BADGING_SET = "";
                goto LABEL_NEXT;

            LABEL_NEXT:
                // _ROOF (_CHOP_TOP)
                parts._ROOF = (this._choptop_is_on == eBoolean.True)
                    ? MODEL + parts._ROOF + "_CHOP_TOP"
                    : MODEL + parts._ROOF;

                // ROOF_STYLE
                if (this._roofscoop_style == 0)
                    parts.ROOF_STYLE += add_on._0 + add_on._0;
                else
                {
                    parts.ROOF_STYLE += this._roofscoop_style.ToString("00");
                    if (this._is_dual_roofscoop == eBoolean.True)
                        parts.ROOF_STYLE += add_on._DUAL;
                    if ((this._is_autosculpt_roofscoop == eBoolean.True) && (this._is_dual_roofscoop == eBoolean.False))
                        parts.ROOF_STYLE += add_on._AUTOSCULPT;
                    if (this._is_carbonfibre_roofscoop == eBoolean.True)
                        parts.ROOF_STYLE += add_on._CF;
                }

                // _HOOD
                if (this._hood_style == 0)
                    parts._HOOD = MODEL + add_on._KIT + add_on._0 + parts._HOOD;
                else
                {
                    parts._HOOD = MODEL + add_on._STYLE + add_on._0 + this._hood_style.ToString() + parts._HOOD;
                    if (this._is_autosculpt_hood == eBoolean.True)
                        parts._HOOD += add_on._AS;
                    if (this._is_carbonfibre_hood == eBoolean.True)
                        parts._HOOD += add_on._CF;
                }

                // _SKIRT
                if (this._autosculpt_skirt == -1)
                    parts._SKIRT = "";
                else if (this._autosculpt_skirt == -2)
                    parts._SKIRT = MODEL + add_on._KIT + add_on._0 + parts._SKIRT + "_CAPPED";
                else
                    parts._SKIRT = MODEL + add_on._K10 + this._autosculpt_skirt.ToString("00");

                // _DOOR_LEFT and _DOOR_RIGHT
                if (this._aftermarket_bodykit == 0)
                {
                    parts._DOOR_LEFT = MODEL + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = MODEL + parts._DOOR_RIGHT;
                }
                else
                {
                    parts._DOOR_LEFT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DOOR_LEFT;
                    parts._DOOR_RIGHT = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._DOOR_RIGHT;
                }

                // _WHEEL
                switch (this._rim_brand)
                {
                    case BaseArguments.NULL:
                    case BaseArguments.STOCK:
                        parts._WHEEL = MODEL + parts._WHEEL; // null, empty, NULL or STOCK
                        break;
                    case "AUTOSCLPT":
                        parts._WHEEL = $"{this._rim_brand}{add_on._STYLE}{this._rim_style:00}_17{add_on._25}";
                        break;
                    default:
                        parts._WHEEL = $"{this._rim_brand}{add_on._STYLE}{this._rim_style:00}_{this._rim_size}{add_on._25}";
                        break;
                }

                // _KIT00_DOORLINE
                parts._KIT00_DOORLINE = (this._aftermarket_bodykit <= 0)
                    ? MODEL + parts._KIT00_DOORLINE
                    : string.Empty;

                // WINDOW_TINT
                if (this._window_tint_type != BaseArguments.STOCK)
                    parts.WINDOW_TINT_STOCK = this._window_tint_type;

                // Carpaint
                parts.PAINT = this._paint_type.ToString();
                parts.SWATCH_COLOR = Resolve.GetSwatchString(this._paint_swatch);

                // Hash all strings to keys
                var keys = this.StringToKey(parts);

                // If the preset already existed, it is better to internally modify its main values
                // rather than overwriting it, to avoid changing some other values; also, if the model
                // was not changed, it skips bunch of other conversions and hashing stages
                if (this.Exists && this.MODEL == this.OriginalModel)
                {
                    if (!this.Modified) // if exists and not modified, return original array
                        goto LABEL_FINAL;

                    // Write settings that could have been changed
                    fixed (uint* uintptr_t = &keys[0])
                    {
                        *(uint*)(byteptr_t + 0x60) = *(uintptr_t + 0);   // _BASE
                        *(uint*)(byteptr_t + 0xBC) = *(uintptr_t + 1);   // _BASE_KIT
                        *(uint*)(byteptr_t + 0xE0) = *(uintptr_t + 10);  // _LEFT_HEADLIGHT
                        *(uint*)(byteptr_t + 0xE4) = *(uintptr_t + 11);  // _LEFT_HEADLIGHT_GLASS
                        *(uint*)(byteptr_t + 0x108) = *(uintptr_t + 20); // _RIGHT_HEADLIGHT
                        *(uint*)(byteptr_t + 0x10C) = *(uintptr_t + 21); // _RIGHT_HEADLIGHT_GLASS
                        *(uint*)(byteptr_t + 0x11C) = *(uintptr_t + 25); // _EXHAUST
                        *(uint*)(byteptr_t + 0x120) = *(uintptr_t + 26); // _SPOILER
                        *(uint*)(byteptr_t + 0x128) = *(uintptr_t + 28); // _DAMAGE0_FRONT
                        *(uint*)(byteptr_t + 0x12C) = *(uintptr_t + 29); // _DAMAGE0_FRONTLEFT
                        *(uint*)(byteptr_t + 0x130) = *(uintptr_t + 30); // _DAMAGE0_FRONTRIGHT
                        *(uint*)(byteptr_t + 0x134) = *(uintptr_t + 31); // _DAMAGE0_REAR
                        *(uint*)(byteptr_t + 0x138) = *(uintptr_t + 32); // _DAMAGE0_REARLEFT
                        *(uint*)(byteptr_t + 0x13C) = *(uintptr_t + 33); // _DAMAGE0_REARRIGHT
                        *(uint*)(byteptr_t + 0x180) = *(uintptr_t + 34); // _FRONT_BUMPER
                        *(uint*)(byteptr_t + 0x184) = *(uintptr_t + 35); // _FRONT_BUMPER_BADGING_SET
                        *(uint*)(byteptr_t + 0x188) = *(uintptr_t + 36); // _REAR_BUMPER
                        *(uint*)(byteptr_t + 0x18C) = *(uintptr_t + 37); // _REAR_BUMPER_BADGING_SET
                        *(uint*)(byteptr_t + 0x190) = *(uintptr_t + 38); // _ROOF
                        *(uint*)(byteptr_t + 0x194) = *(uintptr_t + 39); // _ROOF_STYLE
                        *(uint*)(byteptr_t + 0x198) = *(uintptr_t + 40); // _HOOD
                        *(uint*)(byteptr_t + 0x19C) = *(uintptr_t + 41); // _SKIRT
                        *(uint*)(byteptr_t + 0x1A8) = *(uintptr_t + 42); // _DOOR_LEFT
                        *(uint*)(byteptr_t + 0x1AC) = *(uintptr_t + 43); // _DOOR_RIGHT
                        *(uint*)(byteptr_t + 0x1B0) = *(uintptr_t + 44); // _WHEEL
                        *(uint*)(byteptr_t + 0x1BC) = *(uintptr_t + 46); // _KIT00_DOORLINE
                        *(uint*)(byteptr_t + 0x1D4) = *(uintptr_t + 47); // SPECIFIC
                        *(uint*)(byteptr_t + 0x1D8) = *(uintptr_t + 48); // GENERIC
                        *(uint*)(byteptr_t + 0x1F8) = *(uintptr_t + 49); // WINDOW_TINT
                        *(uint*)(byteptr_t + 0x20C) = *(uintptr_t + 50); // PAINT_TYPE
                        *(uint*)(byteptr_t + 0x210) = *(uintptr_t + 51); // SWATCH_COLOR
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
                        *(uint*)(byteptr_t + 0x60) = *uintptr_t;

                        for (int a1 = 0; a1 < 33; ++a1)
                            *(uint*)(byteptr_t + 0xBC + a1 * 4) = *(uintptr_t + 1 + a1);

                        for (int a1 = 0; a1 < 8; ++a1)
                            *(uint*)(byteptr_t + 0x180 + a1 * 4) = *(uintptr_t + 34 + a1);

                        *(uint*)(byteptr_t + 0x1A8) = *(uintptr_t + 42);
                        *(uint*)(byteptr_t + 0x1AC) = *(uintptr_t + 43);
                        *(uint*)(byteptr_t + 0x1B0) = *(uintptr_t + 44);
                        *(uint*)(byteptr_t + 0x1B8) = *(uintptr_t + 45);
                        *(uint*)(byteptr_t + 0x1BC) = *(uintptr_t + 46);
                        *(uint*)(byteptr_t + 0x1D4) = *(uintptr_t + 47);
                        *(uint*)(byteptr_t + 0x1D8) = *(uintptr_t + 48);
                        *(uint*)(byteptr_t + 0x1F8) = *(uintptr_t + 49);
                        *(uint*)(byteptr_t + 0x20C) = *(uintptr_t + 50);
                        *(uint*)(byteptr_t + 0x210) = *(uintptr_t + 51);
                    }
                }

            LABEL_FINAL:
                // Write CollectionName
                for (int a1 = 0; a1 < 0x20; ++a1)
                    *(byteptr_t + 0x28 + a1) = (byte)0;
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + 0x28 + a1) = (byte)this.CollectionName[a1];

                // Write Fronend and Pvehicle
                *(uint*)(byteptr_t + 0x48) = this._Frontend_Hash;
                *(uint*)(byteptr_t + 0x50) = this._Pvehicle_Hash;

                // Write Colors
                *(int*)(byteptr_t + 0x208) = 1;
                *(float*)(byteptr_t + 0x214) = this._saturation;
                *(float*)(byteptr_t + 0x218) = this._brightness;

                *(byteptr_t + 0x22C) = this.FRONTBUMPER.AutosculptZone1;
                *(byteptr_t + 0x22D) = this.FRONTBUMPER.AutosculptZone2;
                *(byteptr_t + 0x22E) = this.FRONTBUMPER.AutosculptZone3;
                *(byteptr_t + 0x22F) = this.FRONTBUMPER.AutosculptZone4;
                *(byteptr_t + 0x230) = this.FRONTBUMPER.AutosculptZone5;
                *(byteptr_t + 0x231) = this.FRONTBUMPER.AutosculptZone6;
                *(byteptr_t + 0x232) = this.FRONTBUMPER.AutosculptZone7;
                *(byteptr_t + 0x233) = this.FRONTBUMPER.AutosculptZone8;
                *(byteptr_t + 0x234) = this.FRONTBUMPER.AutosculptZone9;

                *(byteptr_t + 0x237) = this.REARBUMPER.AutosculptZone1;
                *(byteptr_t + 0x238) = this.REARBUMPER.AutosculptZone2;
                *(byteptr_t + 0x239) = this.REARBUMPER.AutosculptZone3;
                *(byteptr_t + 0x23A) = this.REARBUMPER.AutosculptZone4;
                *(byteptr_t + 0x23B) = this.REARBUMPER.AutosculptZone5;
                *(byteptr_t + 0x23C) = this.REARBUMPER.AutosculptZone6;
                *(byteptr_t + 0x23D) = this.REARBUMPER.AutosculptZone7;
                *(byteptr_t + 0x23E) = this.REARBUMPER.AutosculptZone8;
                *(byteptr_t + 0x23F) = this.REARBUMPER.AutosculptZone9;
                if (this._autosculpt_rearbumper >= 1 && this._autosculpt_rearbumper <= 10)
                    *(byteptr_t + 0x237 + Zones.ExhPos[this._autosculpt_rearbumper]) = this._exhaust_size;

                *(byteptr_t + 0x242) = this.SKIRT.AutosculptZone1;
                *(byteptr_t + 0x243) = this.SKIRT.AutosculptZone2;
                *(byteptr_t + 0x244) = this.SKIRT.AutosculptZone3;
                *(byteptr_t + 0x245) = this.SKIRT.AutosculptZone4;
                *(byteptr_t + 0x246) = this.SKIRT.AutosculptZone5;
                *(byteptr_t + 0x247) = this.SKIRT.AutosculptZone6;
                *(byteptr_t + 0x248) = this.SKIRT.AutosculptZone7;
                *(byteptr_t + 0x249) = this.SKIRT.AutosculptZone8;
                *(byteptr_t + 0x24A) = this.SKIRT.AutosculptZone9;

                *(byteptr_t + 0x24D) = this.WHEELS.AutosculptZone1;
                *(byteptr_t + 0x24E) = this.WHEELS.AutosculptZone2;
                *(byteptr_t + 0x24F) = this.WHEELS.AutosculptZone3;
                *(byteptr_t + 0x250) = this.WHEELS.AutosculptZone4;
                *(byteptr_t + 0x251) = this.WHEELS.AutosculptZone5;
                *(byteptr_t + 0x252) = this.WHEELS.AutosculptZone6;
                *(byteptr_t + 0x253) = this.WHEELS.AutosculptZone7;
                *(byteptr_t + 0x254) = this.WHEELS.AutosculptZone8;
                *(byteptr_t + 0x255) = this.WHEELS.AutosculptZone9;

                *(byteptr_t + 0x258) = this.HOOD.AutosculptZone1;
                *(byteptr_t + 0x259) = this.HOOD.AutosculptZone2;
                *(byteptr_t + 0x25A) = this.HOOD.AutosculptZone3;
                *(byteptr_t + 0x25B) = this.HOOD.AutosculptZone4;
                *(byteptr_t + 0x25C) = this.HOOD.AutosculptZone5;
                *(byteptr_t + 0x25D) = this.HOOD.AutosculptZone6;
                *(byteptr_t + 0x25E) = this.HOOD.AutosculptZone7;
                *(byteptr_t + 0x25F) = this.HOOD.AutosculptZone8;
                *(byteptr_t + 0x260) = this.HOOD.AutosculptZone9;

                *(byteptr_t + 0x263) = this.SPOILER.AutosculptZone1;
                *(byteptr_t + 0x264) = this.SPOILER.AutosculptZone2;
                *(byteptr_t + 0x265) = this.SPOILER.AutosculptZone3;
                *(byteptr_t + 0x266) = this.SPOILER.AutosculptZone4;
                *(byteptr_t + 0x267) = this.SPOILER.AutosculptZone5;
                *(byteptr_t + 0x268) = this.SPOILER.AutosculptZone6;
                *(byteptr_t + 0x269) = this.SPOILER.AutosculptZone7;
                *(byteptr_t + 0x26A) = this.SPOILER.AutosculptZone8;
                *(byteptr_t + 0x26B) = this.SPOILER.AutosculptZone9;

                *(byteptr_t + 0x26E) = this.ROOFSCOOP.AutosculptZone1;
                *(byteptr_t + 0x26F) = this.ROOFSCOOP.AutosculptZone2;
                *(byteptr_t + 0x270) = this.ROOFSCOOP.AutosculptZone3;
                *(byteptr_t + 0x271) = this.ROOFSCOOP.AutosculptZone4;
                *(byteptr_t + 0x272) = this.ROOFSCOOP.AutosculptZone5;
                *(byteptr_t + 0x273) = this.ROOFSCOOP.AutosculptZone6;
                *(byteptr_t + 0x274) = this.ROOFSCOOP.AutosculptZone7;
                *(byteptr_t + 0x275) = this.ROOFSCOOP.AutosculptZone8;
                *(byteptr_t + 0x276) = this.ROOFSCOOP.AutosculptZone9;

                *(byteptr_t + 0x279) = this._choptop_size;
                *(byteptr_t + 0x284) = this._exhaust_size;

                this.VINYL01.Write(byteptr_t + 0x290 + 0x2C * 0);
                this.VINYL02.Write(byteptr_t + 0x290 + 0x2C * 1);
                this.VINYL03.Write(byteptr_t + 0x290 + 0x2C * 2);
                this.VINYL04.Write(byteptr_t + 0x290 + 0x2C * 3);
                this.VINYL05.Write(byteptr_t + 0x290 + 0x2C * 4);
                this.VINYL06.Write(byteptr_t + 0x290 + 0x2C * 5);
                this.VINYL07.Write(byteptr_t + 0x290 + 0x2C * 6);
                this.VINYL08.Write(byteptr_t + 0x290 + 0x2C * 7);
                this.VINYL09.Write(byteptr_t + 0x290 + 0x2C * 8);
                this.VINYL10.Write(byteptr_t + 0x290 + 0x2C * 9);
                this.VINYL11.Write(byteptr_t + 0x290 + 0x2C * 10);
                this.VINYL12.Write(byteptr_t + 0x290 + 0x2C * 11);
                this.VINYL13.Write(byteptr_t + 0x290 + 0x2C * 12);
                this.VINYL14.Write(byteptr_t + 0x290 + 0x2C * 13);
                this.VINYL15.Write(byteptr_t + 0x290 + 0x2C * 14);
                this.VINYL16.Write(byteptr_t + 0x290 + 0x2C * 15);
                this.VINYL17.Write(byteptr_t + 0x290 + 0x2C * 16);
                this.VINYL18.Write(byteptr_t + 0x290 + 0x2C * 17);
                this.VINYL19.Write(byteptr_t + 0x290 + 0x2C * 18);
                this.VINYL20.Write(byteptr_t + 0x290 + 0x2C * 19);
            }
            return result;
        }
    }
}