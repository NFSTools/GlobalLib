﻿namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
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

            string MODEL = ""; // MODEL of the car, MODEL = this.result._SETTINGS[1]
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

            // Lowercase model, try and see if frontend and pvehicle hashes match
            // If do not match, keep hex representation of the bin hashes
            v1 = MODEL.ToLower();
            a1 = Utils.Vlt.Hash(v1);
            a2 = *(uint*)(byteptr_t + 0x48); // frontend vlt hash
            this.Frontend = (a1 == a2)
                ? v1
                : hex + a2.ToString("X8");
            a2 = *(uint*)(byteptr_t + 0x50); // pvehicle vlt hash
            this.Pvehicle = (a1 == a2)
                ? v1
                : hex + a2.ToString("X8");

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
            this._popup_headlights_exist = a2 == 0;  // either this
            this._popup_headlights_exist = a1 == a2; // or this
            a2 = *(uint*)(byteptr_t + 0xE4);
            if (a2 == 0)
                goto LABEL_EXHAUST; // skip if statements if null
            if (this._popup_headlights_exist)
            {
                a1 = Utils.Bin.Hash(MODEL + parts._LEFT_HEADLIGHT_GLASS + add_on._OFF);
                this._popup_heaglights_on = a1 == a2;
            }
            else
                this._popup_heaglights_on = false;

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
                    v1 = (x1 < 10)
                        ? add_on.EXHAUST + add_on._STYLE + add_on._0 + x1.ToString() + add_on._LEVEL1
                        : add_on.EXHAUST + add_on._STYLE + x1.ToString() + add_on._LEVEL1;
                    a1 = Utils.Bin.Hash(v1);
                    if (a1 == a2)
                    {
                        this._exhaust_style = x1;
                        goto LABEL_SPOILER;
                    }
                    else
                    {
                        v1 = (x1 < 10)
                            ? add_on.EXHAUST + add_on._STYLE + add_on._0 + x1.ToString() + add_on._CENTER + add_on._LEVEL1
                            : add_on.EXHAUST + add_on._STYLE + x1.ToString() + add_on._CENTER + add_on._LEVEL1;
                        a1 = Utils.Bin.Hash(v1);
                        if (a1 == a2)
                        {
                            this._exhaust_style = x1;
                            this._is_center_exhaust = true;
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
                this._spoiler_type = Reflection.BaseArguments.NULL; // means spoiler is nulled
                goto LABEL_FRONT_BUMPER;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._SPOILER);
            if (a1 == a2)
            {   // stock spoiler
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.BaseArguments.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 30; ++x2) // all 29 spoiler styles
                    {

                        if (x2 < 10) // check for being less than 10
                        {
                            v3 = add_on.SPOILER + add_on._STYLE + add_on._0 + x2.ToString() + add_on._STYPE[x1];
                            v4 = add_on.AS_SPOILER + add_on._STYLE + add_on._0 + x2.ToString() + add_on._STYPE[x1];
                        }
                        else
                        {
                            v3 = add_on.SPOILER + add_on._STYLE + x2.ToString() + add_on._STYPE[x1];
                            v4 = add_on.AS_SPOILER + add_on._STYLE + x2.ToString() + add_on._STYPE[x1];
                        }

                        a3 = Utils.Bin.Hash(v3);
                        a4 = Utils.Bin.Hash(v4);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            this._spoiler_type = add_on._STYPE[x1];
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }
                        else if (a4 == a2)
                        {
                            this._spoiler_style = x2;
                            this._spoiler_type = add_on._STYPE[x1];
                            this._is_autosculpt_spoiler = true;
                            goto LABEL_FRONT_BUMPER; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Utils.Bin.Hash(v3 + add_on._CF);
                            a4 = Utils.Bin.Hash(v4 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                this._spoiler_type = add_on._STYPE[x1];
                                this._is_carbonfibre_spoiler = true;
                                goto LABEL_FRONT_BUMPER; // break the whole loop
                            }
                            else if (a4 == a2)
                            {
                                this._spoiler_style = x2;
                                this._spoiler_type = add_on._STYPE[x1];
                                this._is_autosculpt_spoiler = true;
                                this._is_carbonfibre_spoiler = true;
                                goto LABEL_FRONT_BUMPER; // break the whole loop
                            }
                        }
                    }
                }
            }

        // escape from a really big spoiler loop
        LABEL_FRONT_BUMPER:
            // fix spoiler settings first
            if (this._spoiler_type == "")
                this._spoiler_type = Reflection.Info.STypes.BASE; // use BASE to make it clearer

            // try to match _FRONT_BUMPER
            a2 = *(uint*)(byteptr_t + 0x180);
            if (a2 == 0)
            {
                this._autosculpt_frontbumper = -1;
                goto LABEL_REAR_BUMPER;
            }
            for (a3 = 0; a3 < 10; ++a3)
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
            a2 = *(uint*)(byteptr_t + 0x188);
            if (a2 == 0)
            {
                this._autosculpt_rearbumper = -1;
                goto LABEL_ROOF;
            }
            for (a3 = 0; a3 < 10; ++a3) // 10 rear bumper styles
            {
                a1 = (a3 < 10)
                    ? Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._REAR_BUMPER)
                    : Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._REAR_BUMPER);
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
                this._choptop_is_on = false; // means no roof at all
            else
            {
                a1 = Utils.Bin.Hash(MODEL + parts._ROOF + "_CHOP_TOP");
                if (a1 == a2)
                    this._choptop_is_on = true;
            } // _SETTINGS[26] (chop top size) is in autosculpt zone later on

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
                    if (x1 < 10)
                    {
                        v1 = parts.ROOF_STYLE + add_on._0 + x1.ToString();
                        v3 = parts.ROOF_STYLE + add_on._0 + x1.ToString() + add_on._AUTOSCULPT;
                        v4 = parts.ROOF_STYLE + add_on._0 + x1.ToString() + add_on._DUAL;
                    }
                    else
                    {
                        v1 = parts.ROOF_STYLE + x1.ToString();
                        v3 = parts.ROOF_STYLE + x1.ToString() + add_on._AUTOSCULPT;
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
                        this._is_autosculpt_roofscoop = true;
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
                        this._is_autosculpt_hood = true;
                        goto LABEL_SKIRT;
                    }
                    else
                    {
                        a3 = Utils.Bin.Hash(v3 + add_on._CF);
                        a4 = Utils.Bin.Hash(v4 + add_on._CF);
                        if (a3 == a2)
                        {
                            this._hood_style = x1;
                            this._is_carbonfibre_hood = true;
                            goto LABEL_SKIRT;
                        }
                        else if (a4 == a2)
                        {
                            this._hood_style = x1;
                            this._is_autosculpt_hood = true;
                            this._is_carbonfibre_hood = true;
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
            for (a3 = 0; a3 < 15; ++a3) // basically 14 styles max
            {
                a1 = (a3 < 10)
                    ? Utils.Bin.Hash(MODEL + add_on._KIT + a3.ToString() + parts._SKIRT)
                    : Utils.Bin.Hash(MODEL + add_on._K10 + a3.ToString() + parts._SKIRT);
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
                    a1 = (x1 < 10)
                        ? Utils.Bin.Hash(Core.Map.RimBrands[0] + add_on._STYLE + add_on._0 + x1.ToString() + "_17" + add_on._25)
                        : Utils.Bin.Hash(Core.Map.RimBrands[0] + add_on._STYLE + x1.ToString() + "_17" + add_on._25);
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
            if (a2 != 0)
                this._specific_vinyl = Core.Map.Lookup(a2) ?? (hex + a2.ToString("X8"));

            a2 = *(uint*)(byteptr_t + 0x1D8);
            if (a2 != 0)
                this._generic_vinyl = Core.Map.Lookup(a2) ?? (hex + a2.ToString("X8"));

            // _WINDOW_TINT
            a2 = *(uint*)(byteptr_t + 0x1F8);
            a1 = Utils.Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                this._window_tint_type = Reflection.BaseArguments.STOCK;
            else
            {
                v2 = Core.Map.Lookup(a2);
                this._window_tint_type = Core.Map.WindowTintMap.Contains(v2) ? v2 : Reflection.BaseArguments.STOCK;
            }

            // COLOR TYPE
            a2 = *(uint*)(byteptr_t + 0x20C);
            if (a2 == 0)
                this._painttype = Reflection.BaseArguments.PPAINT;
            else
                this._painttype = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.PPAINT;

            // Paint Swatch
            this._paintswatch = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x210)));

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
            for (uint x1 = 0; x1 < 20; ++x1)
            {
                a2 = *(uint*)(byteptr_t + 0x290 + x1 * 0x2C);
                if (a2 != 0)
                { // check if it exists
                    var VINYL = new Parts.PresetParts.Vinyl();
                    VINYL.VectorVinyl = Core.Map.Lookup(a2) ?? ("0x" + a2.ToString("X8"));
                    VINYL.PositionY = *(short*)(byteptr_t + 0x294 + x1 * 0x2C);
                    VINYL.PositionX = *(short*)(byteptr_t + 0x296 + x1 * 0x2C);
                    VINYL.Rotation = *(sbyte*)(byteptr_t + 0x298 + x1 * 0x2C);
                    VINYL.Skew = *(sbyte*)(byteptr_t + 0x299 + x1 * 0x2C);
                    VINYL.ScaleY = *(sbyte*)(byteptr_t + 0x29A + x1 * 0x2C);
                    VINYL.ScaleX = *(sbyte*)(byteptr_t + 0x29B + x1 * 0x2C);
                    VINYL.SwatchColor1 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x29C + x1 * 0x2C)));
                    VINYL.SwatchColor2 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x2A4 + x1 * 0x2C)));
                    VINYL.SwatchColor3 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x2AC + x1 * 0x2C)));
                    VINYL.SwatchColor4 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x2B4 + x1 * 0x2C)));
                    VINYL.Saturation1 = *(byteptr_t + 0x2A0 + x1 * 0x2C);
                    VINYL.Saturation2 = *(byteptr_t + 0x2A8 + x1 * 0x2C);
                    VINYL.Saturation3 = *(byteptr_t + 0x2B0 + x1 * 0x2C);
                    VINYL.Saturation4 = *(byteptr_t + 0x2B8 + x1 * 0x2C);
                    VINYL.Brightness1 = *(byteptr_t + 0x2A1 + x1 * 0x2C);
                    VINYL.Brightness2 = *(byteptr_t + 0x2A9 + x1 * 0x2C);
                    VINYL.Brightness3 = *(byteptr_t + 0x2B1 + x1 * 0x2C);
                    VINYL.Brightness4 = *(byteptr_t + 0x2B9 + x1 * 0x2C);
                    this.Vinyls[_number_of_vinyls++] = VINYL;
                }
            }
        }
    }
}