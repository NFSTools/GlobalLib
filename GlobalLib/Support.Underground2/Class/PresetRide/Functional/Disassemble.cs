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

            var audios = new System.Collections.Generic.List<string>();
            foreach (var audio in Core.Map.AudioTypes)
            {
                if (audio.StartsWith("AUDIO_COMP_SPEAKER"))
                {
                    audios.AddRange(new string[]
                    {
                        audio,
                        $"{audio}_8",
                        $"{audio}_10",
                        $"{audio}_12",
                        $"{audio}_15",
                    });
                }
                else
                {
                    audios.AddRange(new string[]
                    {
                        audio,
                        $"{audio}_SMALL",
                        $"{audio}_MEDIUM",
                        $"{audio}_LARGE",
                    });
                }
            }


            // ALL TRUNK AUDIOS AND BUFFERS
            a2 = *(uint*)(byteptr_t + 0xD8);
            this._audio_comp_00 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xDC);
            this._audio_comp_01 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE0);
            this._audio_comp_02 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE4);
            this._audio_comp_03 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xE8);
            this._audio_comp_04 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xEC);
            this._audio_comp_05 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF0);
            this._audio_comp_06 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF4);
            this._audio_comp_07 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xF8);
            this._audio_comp_08 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0xFC);
            this._audio_comp_09 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x100);
            this._audio_comp_10 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;
            a2 = *(uint*)(byteptr_t + 0x104);
            this._audio_comp_11 = Core.Map.Lookup(a2)?.Substring(0, v1.LastIndexOf('_')) ?? Reflection.BaseArguments.NULL;

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

            // Paint types and vinyls
            a2 = *(uint*)(byteptr_t + 0x148);
            this._base_paint_type = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.UGPAINT;



        }
    }
}