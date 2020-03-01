namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
		protected override unsafe void Disassemble(byte* byteptr_t)
		{
            // Copy array into the memory
            for (int x = 0; x < 0x338; ++x)
                this.data[x] = *(byteptr_t + x);

            string MODEL = ""; // MODEL of the car
            string hex = "0x"; // for hex representations
            string v1 = "";    // main for class strings
            string v2 = "";    // main for system strings
            string v3 = "";    // extra for strings
            string v4 = "";    // extra for strings
            uint a1 = 0;       // only if one hash at a time
            uint a2 = 0;       // read hash from file only
            uint a3 = 0;       // extra for hashes, loops
            uint a4 = 0;       // extra for hashes, loops

            var parts = new Shared.Parts.PresetParts.Concatenator(); // assign actual concatenator
            var add_on = new Shared.Parts.PresetParts.Add_On(); // assign actual add_on

            // Get unknown values
            this._unknown1 = *(uint*)byteptr_t;
            this._unknown2 = *(uint*)(byteptr_t + 4);

            // Get the model name
            for (int x = 8; *(byteptr_t + x) != 0; ++x)
                MODEL += ((char)*(byteptr_t + x)).ToString();

            // Assign MODEL string
            this.MODEL = MODEL;
            this.OriginalModel = MODEL;

            // Begin reading
            this.uversion_ = *(int*)(byteptr_t + 0x48);
            a1 = Utils.Bin.Hash(MODEL + parts._BASE); // for RaiderKeys

            // try to match _FRONT_BUMPER
            a2 = *(uint*)(byteptr_t + 0x50);
            if (a2 == 0)
            {
                this._autosculpt_frontbumper = -1;
                goto LABEL_REAR_BUMPER;
            }
            for (a3 = 0; a3 < 31; ++a3)
            {
                a1 = (a3 < 10)
                    ? Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._FRONT_BUMPER)
                    : Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._FRONT_BUMPER);
                if (a1 == a2)
                {
                    this._autosculpt_frontbumper = (sbyte)a3;
                    goto LABEL_REAR_BUMPER;
                }
            }

        LABEL_REAR_BUMPER:
            // Try to match _REAR_BUMPER
            a2 = *(uint*)(byteptr_t + 0x54);
            if (a2 == 0)
            {
                this._autosculpt_rearbumper = -1;
                goto LABEL_BODY;
            }
            for (a3 = 0; a3 < 31; ++a3) // 10 rear bumper styles
            {
                a1 = (a3 < 10)
                    ? Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._REAR_BUMPER)
                    : Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._REAR_BUMPER);
                if (a1 == a2)
                {
                    this._autosculpt_rearbumper = (sbyte)a3;
                    goto LABEL_BODY;
                }
            }

        LABEL_BODY:
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._BASE_KIT); // for RaiderKeys

            // Try match _KITW_BODY
            a2 = *(uint*)(byteptr_t + 0x64);
            if (a2 == 0)
            {
                this._aftermarket_bodykit = -1;
                goto LABEL_ROOF;
            }
            for (a3 = 0; a3 < 5; ++a3) // 4 aftermarket bodykits
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._KITW + a3.ToString() + parts._BASE_KIT);
                if (a1 == a2)
                {
                    this._aftermarket_bodykit = (sbyte)a3;
                    goto LABEL_ROOF;
                }
            }

        LABEL_ROOF:
            // Try to match ROOF_STYLE
            a2 = *(uint*)(byteptr_t + 0x68);
            a1 = Utils.Bin.Hash(parts.ROOF_STYLE + add_on._0 + add_on._0);
            if (a2 == 0 || a1 == a2)
            {
                this._roofscoop_style = 0;
                goto LABEL_HOOD; // skip the rest of the statements
            }
            else
            {
                for (byte x1 = 1; x1 < 18; ++x1) // all 17 roof scoop styles
                {
                    if (x1 < 10)
                    {
                        v1 = parts.ROOF_STYLE + add_on._0 + x1.ToString();
                        v3 = parts.ROOF_STYLE + add_on._0 + x1.ToString() + add_on._OFFSET;
                        v4 = parts.ROOF_STYLE + add_on._0 + x1.ToString() + add_on._DUAL;
                    }
                    else
                    {
                        v1 = parts.ROOF_STYLE + x1.ToString();
                        v3 = parts.ROOF_STYLE + x1.ToString() + add_on._OFFSET;
                        v4 = parts.ROOF_STYLE + x1.ToString() + add_on._DUAL;
                    }
                    a1 = Utils.Bin.Hash(v1);
                    a3 = Utils.Bin.Hash(v3);
                    a4 = Utils.Bin.Hash(v4);
                    if (a1 == a2)
                    {
                        this._roofscoop_style = x1;
                        goto LABEL_HOOD;
                    }
                    else if (a3 == a2)
                    {
                        this._roofscoop_style = x1;
                        this._is_offset_roofscoop = true;
                        goto LABEL_HOOD;
                    }
                    else if (a4 == a2)
                    {
                        this._roofscoop_style = x1;
                        this._is_dual_roofscoop = true;
                        goto LABEL_HOOD;
                    }
                    else
                    {
                        a1 = Utils.Bin.Hash(v1 + add_on._CF);
                        a3 = Utils.Bin.Hash(v3 + add_on._CF);
                        a4 = Utils.Bin.Hash(v4 + add_on._CF);
                        if (a1 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_carbonfibre_roofscoop = true;
                            goto LABEL_HOOD;
                        }
                        else if (a3 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_dual_roofscoop = true;
                            this._is_carbonfibre_roofscoop = true;
                            goto LABEL_HOOD;
                        }
                        else if (a4 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_dual_roofscoop = true;
                            this._is_carbonfibre_roofscoop = true;
                            goto LABEL_HOOD;
                        }
                    }
                }
            }

        LABEL_HOOD:
            a1 = Utils.Bin.Hash(MODEL + parts._TOP); // for RaiderKeys

            // Try match _HOOD
            a2 = *(uint*)(byteptr_t + 0x70);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                this._hood_style = 0;
                goto LABEL_SKIRT;
            }
            else
            {
                for (byte x1 = 1; x1 < 29; ++x1) // 28 hood styles
                {
                    v1 = (x1 < 10)
                        ? MODEL + add_on._STYLE + add_on._0 + x1.ToString() + parts._HOOD
                        : MODEL + add_on._STYLE + x1.ToString() + parts._HOOD;
                    a1 = Utils.Bin.Hash(v1);
                    if (a1 == a2)
                    {
                        this._hood_style = x1;
                        goto LABEL_SKIRT;
                    }
                    else // try carbonfibre
                    {
                        a1 = Utils.Bin.Hash(v1 + add_on._CF);
                        if (a3 == a2)
                        {
                            this._hood_style = x1;
                            this._is_carbonfibre_hood = true;
                            goto LABEL_SKIRT;
                        }
                    }
                }
            }

        LABEL_SKIRT:
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._TRUNK);
            // Try to match _SKIRT
            a2 = *(uint*)(byteptr_t + 0x78);
            if (a2 == 0)
            {
                this._autosculpt_skirt = -1;
                goto LABEL_SPOILER;
            }
            for (a3 = 0; a3 < 31; ++a3) // 10 rear bumper styles
            {
                a1 = (a3 < 10)
                    ? Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._SKIRT)
                    : Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._SKIRT);
                if (a1 == a2)
                {
                    this._autosculpt_skirt = (sbyte)a3;
                    goto LABEL_SPOILER;
                }
            }

        LABEL_SPOILER:
            // Try to match spoiler
            a2 = *(uint*)(byteptr_t + 0x7C);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._SPOILER);
            if (a2 == 0)
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.BaseArguments.NULL; // means spoiler is nulled
                goto LABEL_ENGINE;
            }
            if (a1 == a2)
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.BaseArguments.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 3; ++x1) // all 3 spoiler types
                {
                    for (byte x2 = 1; x2 < 41; ++x2) // all 40 spoiler styles
                    {
                        v3 = (x2 < 10) // check for being less than 10
                            ? add_on.SPOILER + add_on._STYLE + add_on._0 + x2.ToString() + add_on._USTYPE[x1]
                            : add_on.SPOILER + add_on._STYLE + x2.ToString() + add_on._USTYPE[x1];

                        a3 = Utils.Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            this._spoiler_type = add_on._USTYPE[x1];
                            goto LABEL_ENGINE; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Utils.Bin.Hash(v3 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                this._spoiler_type = add_on._USTYPE[x1];
                                this._is_carbonfibre_spoiler = true;
                                goto LABEL_ENGINE; // break the whole loop
                            }
                        }
                    }
                }
            }

        LABEL_ENGINE:
            // fix spoiler settings first
            if (this._spoiler_type == "")
                this._spoiler_type = Reflection.Info.STypes.BASE; // use BASE to make it clearer

            a2 = *(uint*)(byteptr_t + 0x80);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._ENGINE);
            if (a2 == 0 || a1 == a2)
            {
                this._engine_style = 0;
                goto LABEL_HEADLIGHT;
            }
            for (a3 = 0; a3 < 4; ++a3)
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._STYLE + add_on._0 + a3.ToString() + parts._ENGINE);
                if (a1 == a2)
                {
                    this._engine_style = (byte)a3;
                    goto LABEL_HEADLIGHT;
                }
            }

        LABEL_HEADLIGHT:
            a2 = *(uint*)(byteptr_t + 0x84);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HEADLIGHT);
            if (a2 == 0 || a1 == a2)
            {
                this._headlight_style = 0;
                goto LABEL_BRAKELIGHT;
            }
            for (a3 = 0; a3 < 15; ++a3)
            {
                v1 = (a3 < 10)
                    ? MODEL + add_on._STYLE + add_on._0 + a3.ToString() + parts._HEADLIGHT
                    : MODEL + add_on._STYLE + a3.ToString() + parts._HEADLIGHT;
                a1 = Utils.Bin.Hash(v1);
                if (a1 == a2)
                {
                    this._headlight_style = (byte)a3;
                    goto LABEL_BRAKELIGHT;
                }
            }

        LABEL_BRAKELIGHT:
            a2 = *(uint*)(byteptr_t + 0x88);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._BRAKELIGHT);
            if (a2 == 0 || a1 == a2)
            {
                this._brakelight_style = 0;
                goto LABEL_EXHAUST;
            }
            for (a3 = 0; a3 < 15; ++a3)
            {
                v1 = (a3 < 10)
                    ? MODEL + add_on._STYLE + add_on._0 + a3.ToString() + parts._BRAKELIGHT
                    : MODEL + add_on._STYLE + a3.ToString() + parts._BRAKELIGHT;
                a1 = Utils.Bin.Hash(v1);
                if (a1 == a2)
                {
                    this._brakelight_style = (byte)a3;
                    goto LABEL_EXHAUST;
                }
            }

        LABEL_EXHAUST:
            a2 = *(uint*)(byteptr_t + 0x8C);
            a1 = Utils.Bin.Hash(MODEL + parts._KIT00_EXHAUST);
            if (a2 == 0 || a1 == a2)
            {
                this._exhaust_style = 0;
                goto LABEL_EXHAUST;
            }
            for (a3 = 0; a3 < 11; ++a3)
            {
                v1 = (a3 < 10)
                    ? add_on.EXHAUST + add_on._STYLE + add_on._0 + a3.ToString() + add_on._LEVEL1
                    : add_on.EXHAUST + add_on._STYLE + a3.ToString() + add_on._LEVEL1;
                a1 = Utils.Bin.Hash(v1);
                if (a1 == a2)
                {
                    this._exhaust_style = (byte)a3;
                    goto LABEL_HOOD_UNDER;
                }
            }

        LABEL_HOOD_UNDER:
            a2 = *(uint*)(byteptr_t + 0xB0);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HOOD_UNDER);
            if (a2 == 0 || a1 == a2)
                this._under_hood_style = 0;
            else
            {
                for (a3 = 21; a3 < 26; ++a3) // only 21-25 are valid
                {
                    a1 = Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._HOOD_UNDER);
                    if (a1 == a2)
                    {
                        this._under_hood_style = (byte)a3;
                        break;
                    }
                }
            }

            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._TRUNK_UNDER); // for RaiderKeys

            // FRONT_BRAKE
            a2 = *(uint*)(byteptr_t + 0xB8);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._FRONT_BRAKE);
            if (a2 == 0 || a1 == a2)
                this._front_brake_style = 0;
            else
            {
                for (a3 = 1; a3 < 4; ++a3)
                {
                    a1 = Utils.Bin.Hash(add_on.BRAKE + add_on._STYLE + add_on._0 + a3.ToString());
                    if (a1 == a2)
                    {
                        this._front_brake_style = (byte)a3;
                        break;
                    }
                }
            }

            // REAR_BRAKE
            a2 = *(uint*)(byteptr_t + 0xBC);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._FRONT_BRAKE);
            if (a2 == 0 || a1 == a2)
                this._rear_brake_style = 0;
            else
            {
                for (a3 = 1; a3 < 4; ++a3)
                {
                    a1 = Utils.Bin.Hash(add_on.BRAKE + add_on._STYLE + add_on._0 + a3.ToString());
                    if (a1 == a2)
                    {
                        this._rear_brake_style = (byte)a3;
                        break;
                    }
                }
            }

            // WHEELS
            a2 = *(uint*)(byteptr_t + 0xC0);
            if (Core.Map.BinKeys.TryGetValue(a2, out v2))
                this.DisperseRimSettings(v2);
            else
                this._rim_brand = Reflection.BaseArguments.STOCK;

            // WING_MIRROR
            a2 = *(uint*)(byteptr_t + 0xCC);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._WING_MIRROR);
            if (a2 == 0 || a1 == a2)
                this._wing_mirror_style = 0;
            else
            {
                for (a3 = 1; a3 < 41; ++a3)
                {

                }
            }





            // MODEL_BASE
            // MODEL_KIT(00-30)_FRONT_BUMPER
            // MODEL_KIT(00-30)_REAR_BUMPER
            // MODEL_KIT00_LEFT_SIDE_MIRROR  ??? (00000000)
            // MODEL_KIT00_RIGHT_SIDE_MIRROR ??? (00000000)
            // MODEL_KIT00_BODY
            // MODEL_KITW(00-04)_BODY
            // ROOF_STYLE(00-17)(_OFFSET/_DUAL)(_CF)
            // MODEL_TOP     ??? (00000000)
            // MODEL_KIT00_HOOD / MODEL_STYLE(01-28)_HOOD(_CF)
            // MODEL_KIT00_TRUNK
            // MODEL_KIT(00-30)_SKIRT
            // MODEL_KIT00_SPOILER / SPOILER_STYLE(00-40)(_HATCH/_SUV)(_CF)
            // MODEL_KIT00_ENGINE / MODEL_STYLE(01-03)_ENGINE
            // MODEL_KIT00_HEADLIGHT / MODEL_STYLE(00-14)_HEADLIGHT
            // MODEL_KIT00_BRAKELIGHT / MODEL_STYLE(00-14)_BRAKELIGHT
            // MODEL_KIT00_EXHAUST / EXHAUST_STYLE(01-10)_LEVEL1
            // MODEL_KIT(00/W01-W04)_DOOR_LEFT
            // MODEL_KIT(00/W01-W04)_DOOR_RIGHT
            // MODEL_KIT(00/W01-W04)_DOOR_PANEL_LEFT
            // MODEL_KIT(00/W01-W04)_DOOR_PANEL_RIGHT
            // MODEL_KIT(00/W01-W04)_DOOR_SILL_LEFT
            // MODEL_KIT(00/W01-W04)_DOOR_SILL_RIGHT
            // MODEL_FENDER  ??? (00000000)
            // MODEL_QUARTER ??? (00000000)
            // MODEL_KIT(00/21-25)_HOOD_UNDER
            // MODEL_KIT00_TRUNK_UNDER
            // MODEL_KIT00_FRONT_BRAKE / BRAKE_STYLE(01-03)
            // MODEL_KIT00_REAR_BRAKE  / BRAKE_STYLE(01-03)
            // MODEL_KIT00_FRONT_WHEEL / BRAND_STYLE##_##_##(_SPI)
            // MODEL_KIT00_FRONT_WHEEL / BRAND_STYLE##_##_##(_SPI)
            // MODEL_SPINNER ??? (00000000)
            // MIRROR SHENANIGANS <-- ???
            // MIRROR SHENANIGANS <-- ???
            // LICENSE_PLATE_STYLE01
            // MODEL_KIT(00-03)_TRUNK_AUDIO
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(MEDIUM) / AUDIO_COMP_SPEAKER_(STYLE)_(10/12)
            // AUDIO_COMP_(BRAND)_(STYLE)_(MEDIUM) / AUDIO_COMP_SPEAKER_(STYLE)_(10/12)
            // AUDIO_COMP_(BRAND)_(STYLE)_(LARGE) / AUDIO_COMP_SPEAKER_(STYLE)_15
            // AUDIO_COMP_(BRAND)_(STYLE)_(LARGE) / AUDIO_COMP_SPEAKER_(STYLE)_15
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(SMALL) / AUDIO_COMP_SPEAKER_(STYLE)_8
            // AUDIO_COMP_(BRAND)_(STYLE)_(MEDIUM) / AUDIO_COMP_SPEAKER_(STYLE)_(10/12)
            // AUDIO_COMP_(BRAND)_(STYLE)_(MEDIUM) / AUDIO_COMP_SPEAKER_(STYLE)_(10/12)
            // MODEL_KIT00_DAMAGE_FRONT ??? (00000000)
            // MODEL_KIT00_DAMAGE_REAR  ??? (00000000)
            // MODEL_KIT00_DAMAGE_LEFT  ??? (00000000)
            // MODEL_KIT00_DAMAGE_RIGHT ??? (00000000)
            // MODEL_KIT00_DAMAGE_TOP   ??? (00000000)
            // MODEL_DECAL_HOOD_RECT_(MEDIUM/SMALL)
            // MODEL_DECAL_FRONT_WINDOW_WIDE_MEDIUM
            // MODEL_DECAL_REAR_WINDOW_WIDE_MEDIUM
            // MODEL_DECAL_LEFT_DOOR_RECT_MEDIUM
            // MODEL_DECAL_RIGHT_DOOR_RECT_MEDIUM
            // MODEL_DECAL_LEFT_QUARTER_RECT_(MEDIUM/SMALL)
            // MODEL_DECAL_RIGHT_QUARTER_RECT_(MEDIUM/SMALL)
            // MODEL_WIDE(1-4)_DECAL_LEFT_DOOR_RECT_MEDIUM
            // MODEL_WIDE(1-4)_DECAL_LEFT_DOOR_RECT_MEDIUM
            // MODEL_WIDE(1-4)_DECAL_RIGHT_QUARTER_RECT_MEDIUM
            // MODEL_WIDE(1-4)_DECAL_RIGHT_QUARTER_RECT_MEDIUM





        }
    }
}