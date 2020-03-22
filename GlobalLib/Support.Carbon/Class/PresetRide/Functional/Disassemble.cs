namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Disassembles preset ride array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset ride array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            // Copy array into the memory
            for (int x = 0; x < 0x600; ++x)
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

            // Get the model name
            for (int x = 8; *(byteptr_t + x) != 0; ++x)
                MODEL += ((char)*(byteptr_t + x)).ToString();

            // Assign MODEL string
            this.MODEL = MODEL;
            this.OriginalModel = MODEL;

            // Frontend hash
            a1 = *(uint*)(byteptr_t + 0x48);
            if (Core.Map.VltKeys.TryGetValue(a1, out v1))
                this.Frontend = v1;
            else
                this.Frontend = $"{hex}{a1:X8}";

            // Pvehicle hash
            a1 = *(uint*)(byteptr_t + 0x50);
            if (Core.Map.VltKeys.TryGetValue(a1, out v1))
                this.Pvehicle = v1;
            else
                this.Pvehicle = $"{hex}{a1:X8}";

            a1 = Utils.Bin.Hash(MODEL + parts._BASE); // for RaiderKeys

            // try to match _BODY
            a2 = *(uint*)(byteptr_t + 0xBC);
            if (a2 == 0)
            {
                this._aftermarket_bodykit = -1; // basically no difference between this one and next one
                goto LABEL_LIGHTS;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._BASE_KIT);
            if (a1 == a2)
            {
                this._aftermarket_bodykit = -1;
                goto LABEL_LIGHTS;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._BASE_KIT + add_on._KIT + add_on._0); // (MODEL)_BODY_KIT00
            if (a1 == a2)
            {
                this._aftermarket_bodykit = 0;
            }
            else
            {
                for (int x1 = 0; x1 < 6; ++x1) // 5 bodykits max
                {
                    a1 = Utils.Bin.Hash(MODEL + parts._BASE_KIT + add_on._KITW + x1.ToString());
                    if (a1 == a2)
                    {
                        this._aftermarket_bodykit = (sbyte)x1;
                        goto LABEL_LIGHTS;
                    }
                }
            }

        LABEL_LIGHTS:
            // Try match popup lights
            a2 = *(uint*)(byteptr_t + 0xE0);
            a1 = Utils.Bin.Hash(MODEL + parts._LEFT_HEADLIGHT + add_on._ON);
            this._popup_headlights_exist = (a2 == 0) ? Reflection.Enum.eBoolean.False : Reflection.Enum.eBoolean.True;  // either this
            this._popup_headlights_exist = (a1 == a2) ? Reflection.Enum.eBoolean.True : Reflection.Enum.eBoolean.False; // or this
            a2 = *(uint*)(byteptr_t + 0xE4);
            if (a2 == 0)
                goto LABEL_EXHAUST; // skip if statements if null
            if (this._popup_headlights_exist == Reflection.Enum.eBoolean.True)
            {
                a1 = Utils.Bin.Hash(MODEL + parts._LEFT_HEADLIGHT_GLASS + add_on._OFF);
                this._popup_heaglights_on = (a1 == a2) ? Reflection.Enum.eBoolean.False : Reflection.Enum.eBoolean.True;
            }
            else
                this._popup_heaglights_on = Reflection.Enum.eBoolean.False;

            LABEL_EXHAUST:
            // Try exhaust match
            a2 = *(uint*)(byteptr_t + 0x11C);
            if (a2 == 0)
            {
                this._exhaust_style = -1;
                goto LABEL_SPOILER; // skip the rest of statements
            }
            a1 = Utils.Bin.Hash(MODEL + parts._KIT00_EXHAUST); // stock exhaust
            if (a1 == a2)
            {
                this._exhaust_style = 0;
            }
            else
            {
                for (sbyte x1 = 0; x1 < 18; ++x1) // 17 exhaust styles
                {
                    a1 = Utils.Bin.Hash(add_on.EXHAUST + add_on._STYLE + x1.ToString("00") + add_on._LEVEL1);
                    if (a1 == a2)
                    {
                        this._exhaust_style = x1;
                        goto LABEL_SPOILER;
                    }
                    else
                    {
                        a1 = Utils.Bin.Hash(add_on.EXHAUST + add_on._STYLE + x1.ToString("00") + add_on._CENTER + add_on._LEVEL1);
                        if (a1 == a2)
                        {
                            this._exhaust_style = x1;
                            this._is_center_exhaust = Reflection.Enum.eBoolean.True;
                            goto LABEL_SPOILER;
                        }
                    }
                }
            } // this._exhaust_size (size of exhaust) is the autosculpt value later on

        LABEL_SPOILER:
            // Try match spoiler
            // (MODEL)_SPOILER[SPOILER_STYLE(01 - 29)(TYPE)(_CF)]
            a2 = *(uint*)(byteptr_t + 0x120);
            if (a2 == 0)
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.Enum.eSTypes.NULL; // means spoiler is nulled
                goto LABEL_FRONT_BUMPER;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._SPOILER);
            if (a1 == a2)
            {   // stock spoiler
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.Enum.eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 30; ++x2) // all 29 spoiler styles
                    {
                        v3 = add_on.SPOILER + add_on._STYLE + x2.ToString("00") + add_on._CSTYPE[x1];
                        v4 = add_on.AS_SPOILER + add_on._STYLE + x2.ToString("00") + add_on._CSTYPE[x1];
                        a3 = Utils.Bin.Hash(v3);
                        a4 = Utils.Bin.Hash(v4);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            v1 = add_on._CSTYPE[x1];
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }
                        else if (a4 == a2)
                        {
                            this._spoiler_style = x2;
                            v1 = add_on._CSTYPE[x1];
                            this._is_autosculpt_spoiler = Reflection.Enum.eBoolean.True;
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Utils.Bin.Hash(v3 + add_on._CF);
                            a4 = Utils.Bin.Hash(v4 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                v1 = add_on._CSTYPE[x1];
                                this._is_carbonfibre_spoiler = Reflection.Enum.eBoolean.True;
                                goto LABEL_FRONT_BUMPER; // break the whole loop
                            }
                            else if (a4 == a2)
                            {
                                this._spoiler_style = x2;
                                v1 = add_on._CSTYPE[x1];
                                this._is_autosculpt_spoiler = Reflection.Enum.eBoolean.True;
                                this._is_carbonfibre_spoiler = Reflection.Enum.eBoolean.True;
                                goto LABEL_FRONT_BUMPER; // break the whole loop
                            }
                        }
                    }
                }
            }

        // escape from a really big spoiler loop
        LABEL_FRONT_BUMPER:
            // fix spoiler settings first
            if (v1 == "")
                this._spoiler_type = Reflection.Enum.eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v1, out this._spoiler_type);

            // try to match _FRONT_BUMPER
            a2 = *(uint*)(byteptr_t + 0x180);
            if (a2 == 0)
            {
                this._autosculpt_frontbumper = -1;
                goto LABEL_REAR_BUMPER;
            }
            for (a3 = 0; a3 < 10; ++a3)
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString("00") + parts._FRONT_BUMPER);
                if (a1 == a2)
                {
                    this._autosculpt_frontbumper = (sbyte)a3;
                    goto LABEL_REAR_BUMPER;
                }
            }

        LABEL_REAR_BUMPER:
            // Try to match _REAR_BUMPER
            a2 = *(uint*)(byteptr_t + 0x188);
            if (a2 == 0)
            {
                this._autosculpt_rearbumper = -1;
                goto LABEL_ROOF;
            }
            for (a3 = 0; a3 < 10; ++a3) // 10 rear bumper styles
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString("00") + parts._REAR_BUMPER);
                if (a1 == a2)
                {
                    this._autosculpt_rearbumper = (sbyte)a3;
                    goto LABEL_ROOF;
                }
            }

        LABEL_ROOF:
            // Try to match _ROOF
            a2 = *(uint*)(byteptr_t + 0x190);
            if (a2 == 0 || Utils.Bin.Hash(MODEL + parts._ROOF) == a2)
                this._choptop_is_on = Reflection.Enum.eBoolean.False; // means no roof at all
            else
            {
                a1 = Utils.Bin.Hash(MODEL + parts._ROOF + "_CHOP_TOP");
                if (a1 == a2)
                    this._choptop_is_on = Reflection.Enum.eBoolean.True;
            }

            // Try to match ROOF_STYLE
            a2 = *(uint*)(byteptr_t + 0x194);
            a1 = Utils.Bin.Hash(parts.ROOF_STYLE + add_on._0 + add_on._0);
            if (a2 == 0 || a1 == a2)
            {
                this._roofscoop_style = 0;
                goto LABEL_HOOD; // skip the rest of the statements
            }
            else
            {
                for (byte x1 = 1; x1 < 19; ++x1) // all 18 roof scoop styles
                {
                    var x1pad = x1.ToString("00");
                    v1 = parts.ROOF_STYLE + x1pad;
                    v3 = parts.ROOF_STYLE + x1pad + add_on._AUTOSCULPT;
                    v4 = parts.ROOF_STYLE + x1pad + add_on._DUAL;
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
                        this._is_autosculpt_roofscoop = Reflection.Enum.eBoolean.True;
                        goto LABEL_HOOD;
                    }
                    else if (a4 == a2)
                    {
                        this._roofscoop_style = x1;
                        this._is_dual_roofscoop = Reflection.Enum.eBoolean.True;
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
                            this._is_carbonfibre_roofscoop = Reflection.Enum.eBoolean.True;
                            goto LABEL_HOOD;
                        }
                        else if (a3 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_autosculpt_roofscoop = Reflection.Enum.eBoolean.True;
                            this._is_carbonfibre_roofscoop = Reflection.Enum.eBoolean.True;
                            goto LABEL_HOOD;
                        }
                        else if (a4 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_dual_roofscoop = Reflection.Enum.eBoolean.True;
                            this._is_carbonfibre_roofscoop = Reflection.Enum.eBoolean.True;
                            goto LABEL_HOOD;
                        }
                    }
                }
            }

        // escape from a really big roofscoop loop
        LABEL_HOOD:
            // Try match _HOOD
            a2 = *(uint*)(byteptr_t + 0x198);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                this._hood_style = 0; // means no hood
                goto LABEL_SKIRT;
            }
            else
            {
                for (byte x1 = 1; x1 < 9; ++x1) // 8 styles max
                {
                    v3 = MODEL + add_on._STYLE + add_on._0 + x1.ToString() + parts._HOOD;
                    v4 = MODEL + add_on._STYLE + add_on._0 + x1.ToString() + parts._HOOD + add_on._AS;
                    a3 = Utils.Bin.Hash(v3);
                    a4 = Utils.Bin.Hash(v4);
                    if (a3 == a2)
                    {
                        this._hood_style = x1;
                        goto LABEL_SKIRT;
                    }
                    else if (a4 == a2)
                    {
                        this._hood_style = x1;
                        this._is_autosculpt_hood = Reflection.Enum.eBoolean.True;
                        goto LABEL_SKIRT;
                    }
                    else
                    {
                        a3 = Utils.Bin.Hash(v3 + add_on._CF);
                        a4 = Utils.Bin.Hash(v4 + add_on._CF);
                        if (a3 == a2)
                        {
                            this._hood_style = x1;
                            this._is_carbonfibre_hood = Reflection.Enum.eBoolean.True;
                            goto LABEL_SKIRT;
                        }
                        else if (a4 == a2)
                        {
                            this._hood_style = x1;
                            this._is_autosculpt_hood = Reflection.Enum.eBoolean.True;
                            this._is_carbonfibre_hood = Reflection.Enum.eBoolean.True;
                            goto LABEL_SKIRT;
                        }
                    }
                }
            }

        // escape from a really big hood loop
        LABEL_SKIRT:
            // Try to match _SKIRT
            a2 = *(uint*)(byteptr_t + 0x19C);
            if (a2 == 0)
            {
                this._autosculpt_skirt = -1;
                goto LABEL_RIM;
            }
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._SKIRT + "_CAPPED");
            if (a1 == a2)
            {
                this._autosculpt_skirt = -2;
                goto LABEL_RIM;
            }
            for (a3 = 0; a3 < 15; ++a3) // basically 14 styles max
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString("00") + parts._SKIRT);
                if (a1 == a2)
                {
                    this._autosculpt_skirt = (sbyte)a3;
                    goto LABEL_RIM;
                }
            }

        LABEL_RIM:
            a2 = *(uint*)(byteptr_t + 0x1B0);
            a1 = Utils.Bin.Hash(MODEL + parts._WHEEL);
            if (a2 == 0)
            {
                this._rim_brand = Reflection.BaseArguments.NULL;
                goto LABEL_PRECOMPVINYL;
            }
            else if (a1 == a2)
            {
                this._rim_brand = Reflection.BaseArguments.STOCK;
                goto LABEL_PRECOMPVINYL;
            }
            else
            {
                for (byte x1 = 1; x1 < 11; ++x1) // try autosculpt wheels
                {
                    a1 = Utils.Bin.Hash(Core.Map.RimBrands[0] + add_on._STYLE + x1.ToString("00") + "_17" + add_on._25);
                    if (a1 == a2)
                    {
                        this._rim_brand = Core.Map.RimBrands[0];
                        this._rim_style = x1;
                        this._rim_size = 17;
                        goto LABEL_PRECOMPVINYL;
                    }
                }
                for (byte x1 = 1; x1 < Core.Map.RimBrands.Count; ++x1) // else try match aftermarket wheels
                {
                    for (byte x2 = 1; x2 < 7; ++x2) // 3 loops: max manufacturers, 6 styles, 5 sizes
                    {
                        for (byte x3 = 17; x3 < 22; ++x3)
                        {
                            a1 = Utils.Bin.Hash(Core.Map.RimBrands[x1] + add_on._STYLE + add_on._0 + x2.ToString() + "_" + x3.ToString() + add_on._25);
                            if (a1 == a2)
                            {
                                this._rim_brand = Core.Map.RimBrands[x1];
                                this._rim_style = x2;
                                this._rim_size = x3;
                                goto LABEL_PRECOMPVINYL;
                            }
                        }
                    }
                }
            }

        LABEL_PRECOMPVINYL:
            a2 = *(uint*)(byteptr_t + 0x1D4);
            this._specific_vinyl = Core.Map.Lookup(a2, true) ?? $"{hex}{a2:X8}";
            a2 = *(uint*)(byteptr_t + 0x1D8);
            this._generic_vinyl = Core.Map.Lookup(a2, true) ?? $"{hex}{a2:X8}";

            // _WINDOW_TINT
            a2 = *(uint*)(byteptr_t + 0x1F8);
            a1 = Utils.Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                this._window_tint_type = Reflection.BaseArguments.STOCK;
            else
            {
                v2 = Core.Map.Lookup(a2, false);
                this._window_tint_type = Core.Map.WindowTintMap.Contains(v2) ? v2 : Reflection.BaseArguments.STOCK;
            }

            // COLOR TYPE
            a2 = *(uint*)(byteptr_t + 0x20C);
            if (System.Enum.IsDefined(typeof(Reflection.Enum.eCarbonPaint), a2))
                this._painttype = (Reflection.Enum.eCarbonPaint)a2;
            else
                this._painttype = Reflection.Enum.eCarbonPaint.GLOSS;

            // Paint Swatch
            this._paintswatch = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x210), false));

            // Saturation and Brightness
            this._saturation = *(float*)(byteptr_t + 0x214);
            this._brightness = *(float*)(byteptr_t + 0x218);

            // Front Bumper Autosculpt
            this.FRONTBUMPER.AutosculptZone1 = *(byteptr_t + 0x22C);
            this.FRONTBUMPER.AutosculptZone2 = *(byteptr_t + 0x22D);
            this.FRONTBUMPER.AutosculptZone3 = *(byteptr_t + 0x22E);
            this.FRONTBUMPER.AutosculptZone4 = *(byteptr_t + 0x22F);
            this.FRONTBUMPER.AutosculptZone5 = *(byteptr_t + 0x230);
            this.FRONTBUMPER.AutosculptZone6 = *(byteptr_t + 0x231);
            this.FRONTBUMPER.AutosculptZone7 = *(byteptr_t + 0x232);
            this.FRONTBUMPER.AutosculptZone8 = *(byteptr_t + 0x233);
            this.FRONTBUMPER.AutosculptZone9 = *(byteptr_t + 0x234);

            // Rear Bumper Autosculpt
            this.REARBUMPER.AutosculptZone1 = *(byteptr_t + 0x237);
            this.REARBUMPER.AutosculptZone2 = *(byteptr_t + 0x238);
            this.REARBUMPER.AutosculptZone3 = *(byteptr_t + 0x239);
            this.REARBUMPER.AutosculptZone4 = *(byteptr_t + 0x23A);
            this.REARBUMPER.AutosculptZone5 = *(byteptr_t + 0x23B);
            this.REARBUMPER.AutosculptZone6 = *(byteptr_t + 0x23C);
            this.REARBUMPER.AutosculptZone7 = *(byteptr_t + 0x23D);
            this.REARBUMPER.AutosculptZone8 = *(byteptr_t + 0x23E);
            this.REARBUMPER.AutosculptZone9 = *(byteptr_t + 0x23F);

            // Skirt Autosculpt
            this.SKIRT.AutosculptZone1 = *(byteptr_t + 0x242);
            this.SKIRT.AutosculptZone2 = *(byteptr_t + 0x243);
            this.SKIRT.AutosculptZone3 = *(byteptr_t + 0x244);
            this.SKIRT.AutosculptZone4 = *(byteptr_t + 0x245);
            this.SKIRT.AutosculptZone5 = *(byteptr_t + 0x246);
            this.SKIRT.AutosculptZone6 = *(byteptr_t + 0x247);
            this.SKIRT.AutosculptZone7 = *(byteptr_t + 0x248);
            this.SKIRT.AutosculptZone8 = *(byteptr_t + 0x249);
            this.SKIRT.AutosculptZone9 = *(byteptr_t + 0x24A);

            // Wheels Autosculpt
            this.WHEELS.AutosculptZone1 = *(byteptr_t + 0x24D);
            this.WHEELS.AutosculptZone2 = *(byteptr_t + 0x24E);
            this.WHEELS.AutosculptZone3 = *(byteptr_t + 0x24F);
            this.WHEELS.AutosculptZone4 = *(byteptr_t + 0x250);
            this.WHEELS.AutosculptZone5 = *(byteptr_t + 0x251);
            this.WHEELS.AutosculptZone6 = *(byteptr_t + 0x252);
            this.WHEELS.AutosculptZone7 = *(byteptr_t + 0x253);
            this.WHEELS.AutosculptZone8 = *(byteptr_t + 0x254);
            this.WHEELS.AutosculptZone9 = *(byteptr_t + 0x255);

            // Hood Bumper Autosculpt
            this.HOOD.AutosculptZone1 = *(byteptr_t + 0x258);
            this.HOOD.AutosculptZone2 = *(byteptr_t + 0x259);
            this.HOOD.AutosculptZone3 = *(byteptr_t + 0x25A);
            this.HOOD.AutosculptZone4 = *(byteptr_t + 0x25B);
            this.HOOD.AutosculptZone5 = *(byteptr_t + 0x25C);
            this.HOOD.AutosculptZone6 = *(byteptr_t + 0x25D);
            this.HOOD.AutosculptZone7 = *(byteptr_t + 0x25E);
            this.HOOD.AutosculptZone8 = *(byteptr_t + 0x25F);
            this.HOOD.AutosculptZone9 = *(byteptr_t + 0x260);

            // Spoiler Autosculpt
            this.SPOILER.AutosculptZone1 = *(byteptr_t + 0x263);
            this.SPOILER.AutosculptZone2 = *(byteptr_t + 0x264);
            this.SPOILER.AutosculptZone3 = *(byteptr_t + 0x265);
            this.SPOILER.AutosculptZone4 = *(byteptr_t + 0x266);
            this.SPOILER.AutosculptZone5 = *(byteptr_t + 0x267);
            this.SPOILER.AutosculptZone6 = *(byteptr_t + 0x268);
            this.SPOILER.AutosculptZone7 = *(byteptr_t + 0x269);
            this.SPOILER.AutosculptZone8 = *(byteptr_t + 0x26A);
            this.SPOILER.AutosculptZone9 = *(byteptr_t + 0x26B);

            // RoofScoop Autosculpt
            this.ROOFSCOOP.AutosculptZone1 = *(byteptr_t + 0x26E);
            this.ROOFSCOOP.AutosculptZone2 = *(byteptr_t + 0x26F);
            this.ROOFSCOOP.AutosculptZone3 = *(byteptr_t + 0x270);
            this.ROOFSCOOP.AutosculptZone4 = *(byteptr_t + 0x271);
            this.ROOFSCOOP.AutosculptZone5 = *(byteptr_t + 0x272);
            this.ROOFSCOOP.AutosculptZone6 = *(byteptr_t + 0x273);
            this.ROOFSCOOP.AutosculptZone7 = *(byteptr_t + 0x274);
            this.ROOFSCOOP.AutosculptZone8 = *(byteptr_t + 0x275);
            this.ROOFSCOOP.AutosculptZone9 = *(byteptr_t + 0x276);

            // Chop top and Exhaust Autosculpt
            this.ChopTopSize = *(byteptr_t + 0x279);
            this.ExhaustSize = *(byteptr_t + 0x284);

            // 20 vinyls
            this.VINYL01.Read(byteptr_t + 0x290 + 0x2C * 0);
            this.VINYL02.Read(byteptr_t + 0x290 + 0x2C * 1);
            this.VINYL03.Read(byteptr_t + 0x290 + 0x2C * 2);
            this.VINYL04.Read(byteptr_t + 0x290 + 0x2C * 3);
            this.VINYL05.Read(byteptr_t + 0x290 + 0x2C * 4);
            this.VINYL06.Read(byteptr_t + 0x290 + 0x2C * 5);
            this.VINYL07.Read(byteptr_t + 0x290 + 0x2C * 6);
            this.VINYL08.Read(byteptr_t + 0x290 + 0x2C * 7);
            this.VINYL09.Read(byteptr_t + 0x290 + 0x2C * 8);
            this.VINYL10.Read(byteptr_t + 0x290 + 0x2C * 9);
            this.VINYL11.Read(byteptr_t + 0x290 + 0x2C * 10);
            this.VINYL12.Read(byteptr_t + 0x290 + 0x2C * 11);
            this.VINYL13.Read(byteptr_t + 0x290 + 0x2C * 12);
            this.VINYL14.Read(byteptr_t + 0x290 + 0x2C * 13);
            this.VINYL15.Read(byteptr_t + 0x290 + 0x2C * 14);
            this.VINYL16.Read(byteptr_t + 0x290 + 0x2C * 15);
            this.VINYL17.Read(byteptr_t + 0x290 + 0x2C * 16);
            this.VINYL18.Read(byteptr_t + 0x290 + 0x2C * 17);
            this.VINYL19.Read(byteptr_t + 0x290 + 0x2C * 18);
            this.VINYL20.Read(byteptr_t + 0x290 + 0x2C * 19);
        }
    }
}