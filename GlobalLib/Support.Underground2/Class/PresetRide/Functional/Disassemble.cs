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
            this._performance_level = *(int*)(byteptr_t + 0x48);
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
                a1 = Utils.Bin.Hash($"{MODEL}{add_on._KIT}{a3:00}{parts._FRONT_BUMPER}");
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
                a1 = Utils.Bin.Hash($"{MODEL}{add_on._KIT}{a3:00}{parts._REAR_BUMPER}");
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
                    string x1pad = x1.ToString("00");
                    v1 = parts.ROOF_STYLE + x1pad;
                    v3 = parts.ROOF_STYLE + x1pad + add_on._OFFSET;
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
                        this._is_offset_roofscoop = Reflection.Enum.eBoolean.True;
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
                            this._is_dual_roofscoop = Reflection.Enum.eBoolean.True;
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
                    v1 = $"{MODEL}{add_on._STYLE}{x1:00}{parts._HOOD}";
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
                            this._is_carbonfibre_hood = Reflection.Enum.eBoolean.True;
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
                a1 = Utils.Bin.Hash($"{MODEL}{add_on._KIT}{a3:00}{parts._SKIRT}");
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
                this._spoiler_type = Reflection.Enum.eSTypes.NULL; // means spoiler is nulled
                goto LABEL_ENGINE;
            }
            if (a1 == a2)
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.Enum.eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 3; ++x1) // all 3 spoiler types
                {
                    for (byte x2 = 1; x2 < 41; ++x2) // all 40 spoiler styles
                    {
                        v3 = $"{add_on.SPOILER}{add_on._STYLE}{x2:00}{add_on._USTYPE[x1]}";
                        a3 = Utils.Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            v4 = add_on._USTYPE[x1];
                            goto LABEL_ENGINE; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Utils.Bin.Hash(v3 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                v4 = add_on._USTYPE[x1];
                                this._is_carbonfibre_spoiler = Reflection.Enum.eBoolean.True;
                                goto LABEL_ENGINE; // break the whole loop
                            }
                        }
                    }
                }
            }

        LABEL_ENGINE:
            // fix spoiler settings first
            if (v4 == "" || v4 == string.Empty)
                this._spoiler_type = Reflection.Enum.eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v4, out this._spoiler_type);

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
                a1 = Utils.Bin.Hash($"{MODEL}{add_on._STYLE}{a3:00}{parts._HEADLIGHT}");
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
                a1 = Utils.Bin.Hash($"{MODEL}{add_on._STYLE}{a3:00}{parts._BRAKELIGHT}");
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
                a1 = Utils.Bin.Hash($"{add_on.EXHAUST}{add_on._STYLE}{a3:00}{add_on._LEVEL1}");
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
                this._wing_mirror_style = Reflection.BaseArguments.STOCK;
            else
                this._wing_mirror_style = $"0x{a2:X8}";


            // TRUNK_AUDIO
            a2 = *(uint*)(byteptr_t + 0xD4);
            for (a3 = 0; a3 < 4; ++a3)
            {
                a1 = Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._TRUNK_AUDIO);
                if (a1 == a2)
                {
                    this._trunk_audio_style = (byte)a3;
                    break;
                }
            }

            // ALL TRUNK AUDIOS AND BUFFERS
            a2 = *(uint*)(byteptr_t + 0xD8);
            this.AUDIO_COMP.AudioComp00 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xDC);
            this.AUDIO_COMP.AudioComp01 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE0);
            this.AUDIO_COMP.AudioComp02 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE4);
            this.AUDIO_COMP.AudioComp03 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE8);
            this.AUDIO_COMP.AudioComp04 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xEC);
            this.AUDIO_COMP.AudioComp05 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF0);
            this.AUDIO_COMP.AudioComp06 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF4);
            this.AUDIO_COMP.AudioComp07 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF8);
            this.AUDIO_COMP.AudioComp08 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xFC);
            this.AUDIO_COMP.AudioComp09 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x100);
            this.AUDIO_COMP.AudioComp10 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x104);
            this.AUDIO_COMP.AudioComp11 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;

            // Skip all Damage, goto decal types
            a2 = *(uint*)(byteptr_t + 0x11C);
            a3 = Utils.Bin.Hash(MODEL + parts._DECAL_HOOD_RECT_MEDIUM);
            a4 = Utils.Bin.Hash(MODEL + parts._DECAL_HOOD_RECT_SMALL);
            if (a3 == a2) this._decaltype_hood = Reflection.Enum.eDecalType.MEDIUM;
            else if (a4 == a2) this._decaltype_hood = Reflection.Enum.eDecalType.SMALL;
            else this._decaltype_hood = Reflection.Enum.eDecalType.NONE;

            Utils.Bin.Hash(MODEL + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM);
            Utils.Bin.Hash(MODEL + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM);
            Utils.Bin.Hash(MODEL + parts._DECAL_LEFT_DOOR_RECT_MEDIUM);
            Utils.Bin.Hash(MODEL + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM);

            a2 = *(uint*)(byteptr_t + 0x130);
            a3 = Utils.Bin.Hash(MODEL + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM);
            a4 = Utils.Bin.Hash(MODEL + parts._DECAL_LEFT_QUARTER_RECT_SMALL);
            if (a3 == a2) this._decaltype_leftquarter = Reflection.Enum.eDecalType.MEDIUM;
            else if (a4 == a2) this._decaltype_leftquarter = Reflection.Enum.eDecalType.SMALL;
            else this._decaltype_leftquarter = Reflection.Enum.eDecalType.NONE;

            a2 = *(uint*)(byteptr_t + 0x134);
            a3 = Utils.Bin.Hash(MODEL + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM);
            a4 = Utils.Bin.Hash(MODEL + parts._DECAL_RIGHT_QUARTER_RECT_SMALL);
            if (a3 == a2) this._decaltype_rightquarter = Reflection.Enum.eDecalType.MEDIUM;
            else if (a4 == a2) this._decaltype_rightquarter = Reflection.Enum.eDecalType.SMALL;
            else this._decaltype_rightquarter = Reflection.Enum.eDecalType.NONE;

            var widestrings = System.Enum.GetNames(typeof(Reflection.Enum.eWideDecalType));
            a2 = *(uint*)(byteptr_t + 0x138);
            foreach (var wide in widestrings)
            {
                a1 = Utils.Bin.Hash($"{MODEL}_{wide}{parts._DECAL_LEFT_DOOR_RECT_MEDIUM}");
                if (a1 == a2)
                {
                    System.Enum.TryParse(wide, out this._decalwide_leftdoor);
                    break;
                }
            }
            a2 = *(uint*)(byteptr_t + 0x13C);
            foreach (var wide in widestrings)
            {
                a1 = Utils.Bin.Hash($"{MODEL}_{wide}{parts._DECAL_RIGHT_DOOR_RECT_MEDIUM}");
                if (a1 == a2)
                {
                    System.Enum.TryParse(wide, out this._decalwide_rightdoor);
                    break;
                }
            }
            a2 = *(uint*)(byteptr_t + 0x140);
            foreach (var wide in widestrings)
            {
                a1 = Utils.Bin.Hash($"{MODEL}_{wide}{parts._DECAL_LEFT_QUARTER_RECT_MEDIUM}");
                if (a1 == a2)
                {
                    System.Enum.TryParse(wide, out this._decalwide_leftquarter);
                    break;
                }
            }
            a2 = *(uint*)(byteptr_t + 0x144);
            foreach (var wide in widestrings)
            {
                a1 = Utils.Bin.Hash($"{MODEL}_{wide}{parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM}");
                if (a1 == a2)
                {
                    System.Enum.TryParse(wide, out this._decalwide_rightquarter);
                    break;
                }
            }

            // Paint Types
            a2 = *(uint*)(byteptr_t + 0x148);
            this.PAINT_TYPES.BasePaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x15C);
            this.PAINT_TYPES.EnginePaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x160);
            this.PAINT_TYPES.SpoilerPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x164);
            this.PAINT_TYPES.BrakesPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x168);
            this.PAINT_TYPES.ExhaustPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x16C);
            this.PAINT_TYPES.AudioPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x170);
            this.PAINT_TYPES.RimsPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x174);
            this.PAINT_TYPES.SpinnersPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x178);
            this.PAINT_TYPES.RoofPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x17C);
            this.PAINT_TYPES.MirrorsPaintType = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;

            // Vinyls and Colors
            a2 = *(uint*)(byteptr_t + 0x14C);
            if (a2 != 0) this.VINYL_SETS.VinylLayer0 = Core.Map.Lookup(a2) ?? $"0x{a2:X8}";
            a2 = *(uint*)(byteptr_t + 0x150);
            if (a2 != 0) this.VINYL_SETS.VinylLayer1 = Core.Map.Lookup(a2) ?? $"0x{a2:X8}";
            a2 = *(uint*)(byteptr_t + 0x154);
            if (a2 != 0) this.VINYL_SETS.VinylLayer2 = Core.Map.Lookup(a2) ?? $"0x{a2:X8}";
            a2 = *(uint*)(byteptr_t + 0x158);
            if (a2 != 0) this.VINYL_SETS.VinylLayer3 = Core.Map.Lookup(a2) ?? $"0x{a2:X8}";
            a2 = *(uint*)(byteptr_t + 0x180);
            this.VINYL_SETS.Vinyl0_Color0 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x184);
            this.VINYL_SETS.Vinyl0_Color1 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x188);
            this.VINYL_SETS.Vinyl0_Color2 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x18C);
            this.VINYL_SETS.Vinyl0_Color3 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x190);
            this.VINYL_SETS.Vinyl1_Color0 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x194);
            this.VINYL_SETS.Vinyl1_Color1 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x198);
            this.VINYL_SETS.Vinyl1_Color2 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x19C);
            this.VINYL_SETS.Vinyl1_Color3 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1A0);
            this.VINYL_SETS.Vinyl2_Color0 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1A4);
            this.VINYL_SETS.Vinyl2_Color1 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1A8);
            this.VINYL_SETS.Vinyl2_Color2 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1AC);
            this.VINYL_SETS.Vinyl2_Color3 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1B0);
            this.VINYL_SETS.Vinyl3_Color0 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1B4);
            this.VINYL_SETS.Vinyl3_Color1 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1B8);
            this.VINYL_SETS.Vinyl3_Color2 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x1BC);
            this.VINYL_SETS.Vinyl3_Color3 = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;

            // Carbonfibre Settings
            a2 = *(uint*)(byteptr_t + 0x1C0);
            if (a2 != 0 && Core.Map.Lookup(a2) == parts.CARBON_FIBRE)
                this.HasCarbonfibreBody = Reflection.Enum.eBoolean.True;
            else
                this.HasCarbonfibreBody = Reflection.Enum.eBoolean.False;

            a2 = *(uint*)(byteptr_t + 0x1C4);
            if (a2 != 0 && Core.Map.Lookup(a2) == parts.CARBON_FIBRE)
                this.HasCarbonfibreHood = Reflection.Enum.eBoolean.True;
            else
                this.HasCarbonfibreHood = Reflection.Enum.eBoolean.False;

            a2 = *(uint*)(byteptr_t + 0x1C8);
            if (a2 != 0 && Core.Map.Lookup(a2) == parts.CARBON_FIBRE)
                this.HasCarbonfibreDoors = Reflection.Enum.eBoolean.True;
            else
                this.HasCarbonfibreDoors = Reflection.Enum.eBoolean.False;

            a2 = *(uint*)(byteptr_t + 0x1CC);
            if (a2 != 0 && Core.Map.Lookup(a2) == parts.CARBON_FIBRE)
                this.HasCarbonfibreTrunk = Reflection.Enum.eBoolean.True;
            else
                this.HasCarbonfibreTrunk = Reflection.Enum.eBoolean.False;

            // Decal Arrays
            this.DECALS_HOOD.Read(byteptr_t + 0x1D0);
            this.DECALS_FRONT_WINDOW.Read(byteptr_t + 0x1F0);
            this.DECALS_REAR_WINDOW.Read(byteptr_t + 0x210);
            this.DECALS_LEFT_DOOR.Read(byteptr_t + 0x230);
            this.DECALS_RIGHT_DOOR.Read(byteptr_t + 0x250);
            this.DECALS_LEFT_QUARTER.Read(byteptr_t + 0x270);
            this.DECALS_RIGHT_QUARTER.Read(byteptr_t + 0x290);

            // WINDOW_TINT
            a2 = *(uint*)(byteptr_t + 0x2A0);
            if (a2 == 0 || a2 == Utils.Bin.Hash(parts.WINDOW_TINT_STOCK))
                this._window_tint_type = Reflection.BaseArguments.STOCK;
            else
                this._window_tint_type = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.STOCK;

            // Specialties
            a1 = Utils.Bin.Hash(parts.NEON_NONE);
            a2 = *(uint*)(byteptr_t + 0x2A4);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.NeonBody = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.NeonBody = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x2A8);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.NeonEngine = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.NeonEngine = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x2AC);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.NeonCabin = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.NeonCabin = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x2B0);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.NeonTrunk = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.NeonTrunk = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;

            a2 = *(uint*)(byteptr_t + 0x2B4);
            if (a2 != 0)
            {
                for (a3 = 0; a3 < 4; ++a3)
                {
                    a1 = Utils.Bin.Hash(parts.CABIN_NEON_STYLE0 + a3.ToString());
                    if (a1 == a2)
                    {
                        this.SPECIALTIES.NeonCabinStyle = (byte)a3;
                        break;
                    }
                }
            }

            a1 = Utils.Bin.Hash(Reflection.BaseArguments.STOCK);
            a2 = *(uint*)(byteptr_t + 0x2B8);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.HeadlightBulbStyle = Reflection.BaseArguments.STOCK;
            else this.SPECIALTIES.HeadlightBulbStyle = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.STOCK;
            a2 = *(uint*)(byteptr_t + 0x2BC);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.DoorOpeningStyle = Reflection.BaseArguments.STOCK;
            else this.SPECIALTIES.DoorOpeningStyle = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.STOCK;
            a1 = Utils.Bin.Hash(parts.NO_HYDRAULICS);
            a2 = *(uint*)(byteptr_t + 0x2C0);
            if (a2 == 0 || a1 == a2) this.SPECIALTIES.HydraulicsStyle = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.HydraulicsStyle = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x2C4);
            if (a2 == 0) this.SPECIALTIES.NOSPurgeStyle = Reflection.BaseArguments.NULL;
            else this.SPECIALTIES.NOSPurgeStyle = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;

            // HUD Options
            a2 = *(uint*)(byteptr_t + 0x2D8);
            if (a2 == 0) this._custom_hud_style = Reflection.BaseArguments.STOCK;
            else this._custom_hud_style = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.STOCK;
            a2 = *(uint*)(byteptr_t + 0x2DC);
            if (a2 == 0) this._hud_backing_color = Reflection.BaseArguments.WHITE;
            else this._hud_backing_color = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.WHITE;
            a2 = *(uint*)(byteptr_t + 0x2E0);
            if (a2 == 0) this._hud_needle_color = Reflection.BaseArguments.WHITE;
            else this._hud_needle_color = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.WHITE;
            a2 = *(uint*)(byteptr_t + 0x2E4);
            if (a2 == 0) this._hud_character_color = Reflection.BaseArguments.WHITE;
            else this._hud_character_color = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.WHITE;
        }
    }
}