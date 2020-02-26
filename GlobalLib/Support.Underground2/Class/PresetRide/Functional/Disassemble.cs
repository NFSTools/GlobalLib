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

            // Get the model name
            for (int x = 8; *(byteptr_t + x) != 0; ++x)
                MODEL += ((char)*(byteptr_t + x)).ToString();

            // Assign MODEL string
            this.MODEL = MODEL;
            this.OriginalModel = MODEL;

            // Begin reading
            this.uversion = *(int*)(byteptr_t + 0x48);
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
                for (byte x1 = 1; x1 < 29; ++x1) // 29 hood styles
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
            
            
        }
    }
}