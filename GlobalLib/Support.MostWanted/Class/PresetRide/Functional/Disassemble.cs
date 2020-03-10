namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide
    {
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            // Copy array into the memory
            for (int x = 0; x < 0x290; ++x)
                this.data[x] = *(byteptr_t + x);

            string MODEL = ""; // for Model of the car
            string hex = "0x"; // for hex representations
            string v1 = "";    // main for class strings
            string v2 = "";    // main for system strings
            string v3 = "";    // extra for strings
            string v4 = "";    // extra for strings
            uint a1 = 0;     // only if one hash at a time
            uint a2 = 0;     // read hash from file only
            uint a3 = 0;     // extra for hashes, loops
            uint a4 = 0;     // extra for hashes, loops

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
                this.Frontend = hex + a1.ToString("X8");

            // Pvehicle hash
            a1 = *(uint*)(byteptr_t + 0x50);
            if (Core.Map.VltKeys.TryGetValue(a1, out v1))
                this.Pvehicle = v1;
            else
                this.Pvehicle = hex + a1.ToString("X8");

            a1 = Utils.Bin.Hash(MODEL + parts._BASE); // for RaiderKeys

            // try to match _BODY
            a2 = *(uint*)(byteptr_t + 0xBC);
            if (a2 == 0)
            {
                this._aftermarket_bodykit = -1; // basically no difference between this one and next one
                goto LABEL_SPOILER;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._BASE_KIT);
            if (a1 == a2)
            {
                this._aftermarket_bodykit = -1;
                goto LABEL_SPOILER;
            }
            else // (MODEL)_BODY_KIT(00-05)
            {
                for (int x1 = 0; x1 < 6; ++x1) // 5 bodykits max
                {
                    a1 = Utils.Bin.Hash(MODEL + parts._BASE_KIT + add_on._KIT + x1.ToString());
                    if (a1 == a2)
                    {
                        this._aftermarket_bodykit = (sbyte)x1;
                        goto LABEL_SPOILER;
                    }
                }
            }

        LABEL_SPOILER:
            // Try match spoiler
            // (MODEL)_SPOILER[SPOILER_STYLE(01 - 44)(TYPE)(_CF)]
            a2 = *(uint*)(byteptr_t + 0x110);
            if (a2 == 0)
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.Enum.eSTypes.NULL; // means spoiler is nulled
                goto LABEL_ROOF;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._SPOILER);
            if (a1 == a2) // stock spoiler
            {
                this._spoiler_style = 0;
                this._spoiler_type = Reflection.Enum.eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 45; ++x2) // all 44 spoiler styles
                    {
                        v3 = (x2 < 10)
                            ? add_on.SPOILER + add_on._STYLE + add_on._0 + x2.ToString() + add_on._CSTYPE[x1]
                            : add_on.SPOILER + add_on._STYLE + x2.ToString() + add_on._CSTYPE[x1];
                        a3 = Utils.Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            v4 = add_on._CSTYPE[x1];
                            goto LABEL_ROOF; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Utils.Bin.Hash(v3 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                v4 = add_on._CSTYPE[x1];
                                this._is_carbonfibre_spoiler = Reflection.Enum.eBoolean.True;
                                goto LABEL_ROOF; // break the whole loop
                            }
                        }
                    }
                }
            }

        // escape from a really big spoiler loop
        LABEL_ROOF:
            // fix spoiler settings first
            if (v4 == "")
                this._spoiler_type = Reflection.Enum.eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v4, out this._spoiler_type);

            // Try to match ROOF_STYLE
            a2 = *(uint*)(byteptr_t + 0x158);
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
                            this._is_offset_roofscoop = Reflection.Enum.eBoolean.True;
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
            a2 = *(uint*)(byteptr_t + 0x15C);
            a1 = Utils.Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                this._hood_style = 0;
                goto LABEL_RIM;
            }
            else
            {
                for (byte x1 = 1; x1 < 33; ++x1) // 33 hood styles
                {
                    v1 = (x1 < 10)
                        ? MODEL + add_on._STYLE + add_on._0 + x1.ToString() + parts._HOOD
                        : MODEL + add_on._STYLE + x1.ToString() + parts._HOOD;
                    a1 = Utils.Bin.Hash(v1);
                    if (a1 == a2)
                    {
                        this._hood_style = x1;
                        goto LABEL_RIM;
                    }
                    else // try carbonfibre
                    {
                        a1 = Utils.Bin.Hash(v1 + add_on._CF);
                        if (a3 == a2)
                        {
                            this._hood_style = x1;
                            this._is_carbonfibre_hood = Reflection.Enum.eBoolean.True;
                            goto LABEL_RIM;
                        }
                    }
                }
            }

        // Escape from a really big hood loop
        LABEL_RIM:
            a2 = *(uint*)(byteptr_t + 0x168);
            if (a2 == 0)
            {
                this._rim_brand = Reflection.BaseArguments.NULL;
                goto LABEL_PRECOMPVINYL;
            }
            a1 = Utils.Bin.Hash(MODEL + parts._WHEEL);
            if (a1 == a2)
            {
                this._rim_brand = Reflection.BaseArguments.STOCK;
                goto LABEL_PRECOMPVINYL;
            }
            else
            {
                for (byte x1 = 1; x1 < Core.Map.RimBrands.Count; ++x1) // else try match aftermarket wheels
                {
                    for (byte x2 = 1; x2 < 7; ++x2) // 3 loops: 18 manufacturers, 6 styles, 4 sizes
                    {
                        for (byte x3 = 17; x3 < 21; ++x3)
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
            // Try find Body Paint
            a2 = *(uint*)(byteptr_t + 0x190);
            if (a2 != 0)
                this.BodyPaint = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.BPAINT;

            // Try find Vinyl Name
            a2 = *(uint*)(byteptr_t + 0x194);
            if (a2 != 0)
                this.VinylName = Core.Map.Lookup(a2) ?? (hex + a2.ToString("X8"));

            // Try find Rim Paint
            a2 = *(uint*)(byteptr_t + 0x198);
            if (a2 != 0)
                this.RimPaint = Core.Map.Lookup(a2) ?? Reflection.BaseArguments.NULL;

            // Try find swatches
            this._vinylcolor1 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x19C)));
            this._vinylcolor2 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x1A0)));
            this._vinylcolor3 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x1A4)));
            this._vinylcolor4 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x1A8)));

            // _WINDOW_TINT
            a2 = *(uint*)(byteptr_t + 0x26C);
            a1 = Utils.Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                this._window_tint_type = Reflection.BaseArguments.STOCK;
            else
            {
                v2 = Core.Map.Lookup(a2);
                this._window_tint_type = Core.Map.WindowTintMap.Contains(v2) ? v2 : Reflection.BaseArguments.STOCK;
            }
        }
    }
}