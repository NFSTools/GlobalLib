using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Shared.Parts.PresetParts;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;

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

            var parts = new Concatenator(); // assign actual concatenator
            var add_on = new Add_On(); // assign actual add_on

            // Get the model name
            for (int x = 8; *(byteptr_t + x) != 0; ++x)
                MODEL += ((char)*(byteptr_t + x)).ToString();

            // Assign MODEL string
            this.MODEL = MODEL;
            this.OriginalModel = MODEL;

            // Frontend hash
            a1 = *(uint*)(byteptr_t + 0x48);
            if (Map.VltKeys.TryGetValue(a1, out v1))
                this.Frontend = v1;
            else
                this.Frontend = $"{hex}{a1:X8}";

            // Pvehicle hash
            a1 = *(uint*)(byteptr_t + 0x50);
            if (Map.VltKeys.TryGetValue(a1, out v1))
                this.Pvehicle = v1;
            else
                this.Pvehicle = $"{hex}{a1:X8}";

            a1 = Bin.Hash(MODEL + parts._BASE); // for RaiderKeys

            // try to match _BODY
            a2 = *(uint*)(byteptr_t + 0xBC);
            if (a2 == 0)
            {
                this._aftermarket_bodykit = -1; // basically no difference between this one and next one
                goto LABEL_SPOILER;
            }
            a1 = Bin.Hash(MODEL + parts._BASE_KIT);
            if (a1 == a2)
            {
                this._aftermarket_bodykit = -1;
                goto LABEL_SPOILER;
            }
            else // (MODEL)_BODY_KIT(00-05)
            {
                for (int x1 = 0; x1 < 6; ++x1) // 5 bodykits max
                {
                    a1 = Bin.Hash(MODEL + parts._BASE_KIT + add_on._KIT + x1.ToString());
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
                this._spoiler_type = eSTypes.NULL; // means spoiler is nulled
                goto LABEL_ROOF;
            }
            a1 = Bin.Hash(MODEL + parts._SPOILER);
            if (a1 == a2) // stock spoiler
            {
                this._spoiler_style = 0;
                this._spoiler_type = eSTypes.STOCK;
            }
            else
            {
                for (byte x1 = 0; x1 < 4; ++x1) // all 4 spoiler types
                {
                    for (byte x2 = 1; x2 < 45; ++x2) // all 44 spoiler styles
                    {
                        v3 = add_on.SPOILER + add_on._STYLE + x2.ToString("00") + add_on._CSTYPE[x1];
                        a3 = Bin.Hash(v3);
                        if (a3 == a2)
                        {
                            this._spoiler_style = x2;
                            v4 = add_on._CSTYPE[x1];
                            goto LABEL_ROOF; // break the whole loop
                        }
                        else // try carbonfibre
                        {
                            a3 = Bin.Hash(v3 + add_on._CF);
                            if (a3 == a2)
                            {
                                this._spoiler_style = x2;
                                v4 = add_on._CSTYPE[x1];
                                this._is_carbonfibre_spoiler = eBoolean.True;
                                goto LABEL_ROOF; // break the whole loop
                            }
                        }
                    }
                }
            }

        // escape from a really big spoiler loop
        LABEL_ROOF:
            // fix spoiler settings first
            if (v4 == string.Empty)
                this._spoiler_type = eSTypes.BASE; // use BASE to make it clearer
            else
                System.Enum.TryParse(v4, out this._spoiler_type);

            // Try to match ROOF_STYLE
            a2 = *(uint*)(byteptr_t + 0x158);
            a1 = Bin.Hash(parts.ROOF_STYLE + add_on._0 + add_on._0);
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
                    v3 = parts.ROOF_STYLE + x1pad + add_on._OFFSET;
                    v4 = parts.ROOF_STYLE + x1pad + add_on._DUAL;
                    a1 = Bin.Hash(v1);
                    a3 = Bin.Hash(v3);
                    a4 = Bin.Hash(v4);
                    if (a1 == a2)
                    {
                        this._roofscoop_style = x1;
                        goto LABEL_HOOD;
                    }
                    else if (a3 == a2)
                    {
                        this._roofscoop_style = x1;
                        this._is_offset_roofscoop = eBoolean.True;
                        goto LABEL_HOOD;
                    }
                    else if (a4 == a2)
                    {
                        this._roofscoop_style = x1;
                        this._is_dual_roofscoop = eBoolean.True;
                        goto LABEL_HOOD;
                    }
                    else
                    {
                        a1 = Bin.Hash(v1 + add_on._CF);
                        a3 = Bin.Hash(v3 + add_on._CF);
                        a4 = Bin.Hash(v4 + add_on._CF);
                        if (a1 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_carbonfibre_roofscoop = eBoolean.True;
                            goto LABEL_HOOD;
                        }
                        else if (a3 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_offset_roofscoop = eBoolean.True;
                            this._is_carbonfibre_roofscoop = eBoolean.True;
                            goto LABEL_HOOD;
                        }
                        else if (a4 == a2)
                        {
                            this._roofscoop_style = x1;
                            this._is_dual_roofscoop = eBoolean.True;
                            this._is_carbonfibre_roofscoop = eBoolean.True;
                            goto LABEL_HOOD;
                        }
                    }
                }
            }

        // escape from a really big roofscoop loop
        LABEL_HOOD:
            // Try match _HOOD
            a2 = *(uint*)(byteptr_t + 0x15C);
            a1 = Bin.Hash(MODEL + add_on._KIT + add_on._0 + parts._HOOD);
            if (a2 == 0 || a1 == a2)
            {
                this._hood_style = 0;
                goto LABEL_RIM;
            }
            else
            {
                for (byte x1 = 1; x1 < 33; ++x1) // 33 hood styles
                {
                    v1 = MODEL + add_on._STYLE + x1.ToString("00") + parts._HOOD;
                    a1 = Bin.Hash(v1);
                    if (a1 == a2)
                    {
                        this._hood_style = x1;
                        goto LABEL_RIM;
                    }
                    else // try carbonfibre
                    {
                        a1 = Bin.Hash(v1 + add_on._CF);
                        if (a3 == a2)
                        {
                            this._hood_style = x1;
                            this._is_carbonfibre_hood = eBoolean.True;
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
                this._rim_brand = BaseArguments.NULL;
                goto LABEL_PRECOMPVINYL;
            }
            a1 = Bin.Hash(MODEL + parts._WHEEL);
            if (a1 == a2)
            {
                this._rim_brand = BaseArguments.STOCK;
                goto LABEL_PRECOMPVINYL;
            }
            else
            {
                for (byte x1 = 1; x1 < Map.RimBrands.Count; ++x1) // else try match aftermarket wheels
                {
                    for (byte x2 = 1; x2 < 7; ++x2) // 3 loops: 18 manufacturers, 6 styles, 4 sizes
                    {
                        for (byte x3 = 17; x3 < 21; ++x3)
                        {
                            a1 = Bin.Hash(Map.RimBrands[x1] + add_on._STYLE + add_on._0 + x2.ToString() + "_" + x3.ToString() + add_on._25);
                            if (a1 == a2)
                            {
                                this._rim_brand = Map.RimBrands[x1];
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
            this.BodyPaint = Map.Lookup(a2, true) ?? BaseArguments.BPAINT;

            // Try find Vinyl Name
            a2 = *(uint*)(byteptr_t + 0x194);
            this.VinylName = Map.Lookup(a2, true) ?? (hex + a2.ToString("X8"));

            // Try find Rim Paint
            a2 = *(uint*)(byteptr_t + 0x198);
            this.RimPaint = Map.Lookup(a2, true) ?? BaseArguments.NULL;

            // Try find swatches
            this._vinylcolor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x19C), false));
            this._vinylcolor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x1A0), false));
            this._vinylcolor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x1A4), false));
            this._vinylcolor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x1A8), false));

            // _WINDOW_TINT
            a2 = *(uint*)(byteptr_t + 0x26C);
            a1 = Bin.Hash(parts.WINDOW_TINT_STOCK);
            if (a2 == 0 || a1 == a2)
                this._window_tint_type = BaseArguments.STOCK;
            else
            {
                v2 = Map.Lookup(a2, false);
                this._window_tint_type = Map.WindowTintMap.Contains(v2) ? v2 : BaseArguments.STOCK;
            }
        }
    }
}