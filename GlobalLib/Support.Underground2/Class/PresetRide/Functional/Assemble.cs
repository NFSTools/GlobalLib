namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		public override unsafe byte[] Assemble()
		{
			var result = new byte[this.data.Length];
			System.Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);
			fixed (byte* byteptr_t = &result[0])
			{
				var parts = new Shared.Parts.PresetParts.Concatenator();
				var add_on = new Shared.Parts.PresetParts.Add_On();

				// BASE PARTS
				parts._BASE = MODEL + parts._BASE;

				// _FRONT_BUMPER
				if (this._autosculpt_frontbumper == -1)
					parts._FRONT_BUMPER = string.Empty;
				else
					parts._FRONT_BUMPER = MODEL + add_on._K10 + this._autosculpt_frontbumper.ToString("00") + parts._FRONT_BUMPER;

				// _REAR_BUMPER
				if (this._autosculpt_rearbumper == -1)
					parts._REAR_BUMPER = string.Empty;
				else
					parts._REAR_BUMPER = MODEL + add_on._K10 + this._autosculpt_rearbumper.ToString("00") + parts._REAR_BUMPER;
				
				// _BODY
				parts._BASE_KIT = MODEL + add_on._KIT + add_on._0 + parts._BASE_KIT;

				// _KITW_BODY
				if (this._aftermarket_bodykit == -1)
					parts._KITW_BODY = string.Empty;
				else
					parts._KITW_BODY = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString() + parts._KITW_BODY;

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

				// _TRUNK
				parts._TRUNK = MODEL + add_on._KIT + add_on._0 + parts._TRUNK;

				// _SKIRT
				if (this._autosculpt_skirt == -1)
					parts._SKIRT = string.Empty;
				else
					parts._SKIRT = MODEL + add_on._K10 + this._autosculpt_skirt.ToString("00") + parts._SKIRT;

				// _SPOILER
				if (this._spoiler_type == Reflection.Enum.eSTypes.NULL)
					parts._SPOILER = string.Empty;
				else if (this._spoiler_style == 0 || this._spoiler_type == Reflection.Enum.eSTypes.STOCK)
					parts._SPOILER = MODEL + add_on._KIT + add_on._0 + parts._SPOILER;
				else
				{
					parts._SPOILER = add_on.SPOILER + add_on._STYLE + this._spoiler_style.ToString("00");
					if (this._spoiler_type != Reflection.Enum.eSTypes.BASE)
						parts._SPOILER += this._spoiler_type.ToString();
					if (this._is_carbonfibre_spoiler == Reflection.Enum.eBoolean.True)
						parts._SPOILER += add_on._CF;
				}

				// _ENGINE
				if (this._engine_style == 0)
					parts._ENGINE = MODEL + add_on._KIT + add_on._0 + parts._ENGINE;
				else
					parts._ENGINE = MODEL + add_on._STYLE + this._exhaust_style.ToString("00") + parts._ENGINE;

				// _HEADLIGHT
				if (this._headlight_style == 0)
					parts._HEADLIGHT = MODEL + add_on._KIT + add_on._0 + parts._HEADLIGHT;
				else
					parts._HEADLIGHT = MODEL + add_on._STYLE + this._headlight_style.ToString("00") + parts._HEADLIGHT;

				// _BRAKELIGHT
				if (this._brakelight_style == 0)
					parts._BRAKELIGHT = MODEL + add_on._KIT + add_on._0 + parts._HEADLIGHT;
				else
					parts._BRAKELIGHT = MODEL + add_on._STYLE + this._brakelight_style.ToString("00") + parts._BRAKELIGHT;

				// _EXHAUST
				if (this._exhaust_style == 0)
					parts._KIT00_EXHAUST = MODEL + parts._KIT00_EXHAUST;
				else
					parts._KIT00_EXHAUST = add_on.EXHAUST + add_on._STYLE + this._exhaust_style.ToString("00") + add_on._LEVEL1;

				// _DOOR / _PANEL / _SILL
				if (this._aftermarket_bodykit == -1 || this._aftermarket_bodykit == 0)
				{
					string KIT = MODEL + add_on._KIT + add_on._0;
					parts._DOOR_LEFT = KIT + parts._DOOR_LEFT;
					parts._DOOR_RIGHT = KIT + parts._DOOR_RIGHT;
					parts._DOOR_PANEL_LEFT = KIT + parts._DOOR_PANEL_LEFT;
					parts._DOOR_PANEL_RIGHT = KIT + parts._DOOR_PANEL_RIGHT;
					parts._DOOR_SILL_LEFT = KIT + parts._DOOR_SILL_LEFT;
					parts._DOOR_SILL_RIGHT = KIT + parts._DOOR_SILL_RIGHT;
				}
				else
				{
					string KITW = MODEL + add_on._KITW + this._aftermarket_bodykit.ToString();
					parts._DOOR_LEFT = KITW + parts._DOOR_LEFT;
					parts._DOOR_RIGHT = KITW + parts._DOOR_RIGHT;
					parts._DOOR_PANEL_LEFT = KITW + parts._DOOR_PANEL_LEFT;
					parts._DOOR_PANEL_RIGHT = KITW + parts._DOOR_PANEL_RIGHT;
					parts._DOOR_SILL_LEFT = KITW + parts._DOOR_SILL_LEFT;
					parts._DOOR_SILL_RIGHT = KITW + parts._DOOR_SILL_RIGHT;
				}

				// _HOOD_UNDER
				parts._HOOD_UNDER = MODEL + add_on._K10 + this._under_hood_style.ToString("00") + parts._HOOD_UNDER;

				// _TRUNK_UNDER
				parts._TRUNK_UNDER = MODEL + add_on._KIT + add_on._0 + parts._TRUNK_UNDER;

				// _REAR_BRAKE
				if (this._rear_brake_style == 0)
					parts._REAR_BRAKE = MODEL + add_on._KIT + add_on._0 + parts._FRONT_BRAKE;
				else
					parts._REAR_BRAKE = add_on.BRAKE + add_on._STYLE + this._rear_brake_style.ToString("00");

				// _FRONT_BRAKE
				if (this._front_brake_style == 0)
					parts._FRONT_BRAKE = MODEL + add_on._KIT + add_on._0 + parts._FRONT_BRAKE;
				else
					parts._FRONT_BRAKE = add_on.BRAKE + add_on._STYLE + this._front_brake_style.ToString("00");

				// _WHEEL
				parts._WHEEL = this.GetValidRimString();

				// _MIRROR
				if (this._wing_mirror_style == Reflection.BaseArguments.NULL || this._wing_mirror_style == Reflection.BaseArguments.STOCK)
					parts._WING_MIRROR = MODEL + add_on._KIT + add_on._0 + parts._WING_MIRROR;
				else
					parts._WING_MIRROR = this._wing_mirror_style;

				// _TRUNK_AUDIO
				parts._TRUNK_AUDIO = MODEL + add_on._KIT + this._trunk_audio_style.ToString() + parts._TRUNK_AUDIO;

				// _DECAL_RECT
				parts._DECAL_HOOD_RECT_ = MODEL + parts._DECAL_HOOD_RECT_ + this._decaltype_hood.ToString();
				parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_FRONT_WINDOW_WIDE_MEDIUM;
				parts._DECAL_REAR_WINDOW_WIDE_MEDIUM = MODEL + parts._DECAL_REAR_WINDOW_WIDE_MEDIUM;
				parts._DECAL_LEFT_DOOR_RECT_= MODEL + parts._DECAL_LEFT_DOOR_RECT_;
				parts._DECAL_RIGHT_DOOR_RECT_ = MODEL + parts._DECAL_RIGHT_DOOR_RECT_;
				parts._DECAL_LEFT_QUARTER_RECT_ = MODEL + parts._DECAL_LEFT_QUARTER_RECT_ + this._decaltype_leftquarter.ToString();
				parts._DECAL_RIGHT_QUARTER_RECT_ = MODEL + parts._DECAL_RIGHT_QUARTER_RECT_ + this._decaltype_rightquarter.ToString();
				parts._DECAL_LEFT_DOOR_RECT_MEDIUM = MODEL + "_" + this._decalwide_leftdoor.ToString() + parts._DECAL_LEFT_DOOR_RECT_MEDIUM;
				parts._DECAL_RIGHT_DOOR_RECT_MEDIUM = MODEL + "_" + this._decalwide_rightdoor.ToString() + parts._DECAL_RIGHT_DOOR_RECT_MEDIUM;
				parts._DECAL_LEFT_QUARTER_RECT_MEDIUM = MODEL + "_" + this._decalwide_leftquarter.ToString() + parts._DECAL_LEFT_QUARTER_RECT_MEDIUM;
				parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM = MODEL + "_" + this._decalwide_rightquarter.ToString() + parts._DECAL_RIGHT_QUARTER_RECT_MEDIUM;

				// KIT_CARBON
				if (this._carbon_body == Reflection.Enum.eBoolean.True)
					parts.KIT_CARBON = parts.CARBON_FIBRE;
				else
					parts.KIT_CARBON = parts.CARBON_FIBRE_NONE;

				// HOOD_CARBON
				if (this._carbon_hood == Reflection.Enum.eBoolean.True)
					parts.HOOD_CARBON = parts.CARBON_FIBRE;
				else
					parts.HOOD_CARBON = parts.CARBON_FIBRE_NONE;

				// DOOR_CARBON
				if (this._carbon_doors == Reflection.Enum.eBoolean.True)
					parts.DOOR_CARBON = parts.CARBON_FIBRE;
				else
					parts.DOOR_CARBON = parts.CARBON_FIBRE_NONE;

				// TRUNK_CARBON
				if (this._carbon_trunk == Reflection.Enum.eBoolean.True)
					parts.TRUNK_CARBON = parts.CARBON_FIBRE;
				else
					parts.TRUNK_CARBON = parts.CARBON_FIBRE_NONE;

				// WINDOW_TINT
				if (this._window_tint_type != Reflection.BaseArguments.STOCK)
					parts.WINDOW_TINT_STOCK = this._window_tint_type;

				// CABIN_NEON
				parts.CABIN_NEON_STYLE0 += this.SPECIALTIES.NeonCabinStyle.ToString();

				// _CV
				if (this._cv_misc_style == 0)
					parts._CV = MODEL + parts._CV;
				else
					parts._CV = MODEL + add_on._KITW + this._cv_misc_style.ToString() + parts._CV;

				// Hash all strings to keys
				var keys = this.StringToKey(parts);

				// In UG2 support it does not matter if a car exists/was modified, we still
				// can write all the strings in it b/c all of them are known
				*(uint*)byteptr_t = this._unknown1;
				*(uint*)(byteptr_t + 4) = this._unknown2;

				// Write MODEL
				for (int a1 = 8; a1 < 0x28; ++a1)
					*(byteptr_t + a1) = (byte)0;
				for (int a1 = 0; a1 < this.MODEL.Length; ++a1)
					*(byteptr_t + 8 + a1) = (byte)this.MODEL[a1];

				// Write CollectionName
				for (int a1 = 0x28; a1 < 0x48; ++a1)
					*(byteptr_t + a1) = (byte)0;
				for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
					*(byteptr_t + 0x28 + a1) = (byte)this._collection_name[a1];

				// Performance Level
				*(int*)(byteptr_t + 0x48) = this._performance_level;

				// Begin Writing Keys
				*(uint*)(byteptr_t + 0x4C) = keys[0];
				*(uint*)(byteptr_t + 0x50) = keys[1];
				*(uint*)(byteptr_t + 0x54) = keys[2];
				*(uint*)(byteptr_t + 0x60) = keys[3];
				*(uint*)(byteptr_t + 0x64) = keys[4];
				*(uint*)(byteptr_t + 0x68) = keys[5];

				for (int a1 = 0; a1 < 14; ++a1)
					*(uint*)(byteptr_t + 0x70 + a1 * 4) = keys[6 + a1];

				for (int a1 = 0; a1 < 5; ++a1)
					*(uint*)(byteptr_t + 0xB0 + a1 * 4) = keys[20 + a1];

				*(uint*)(byteptr_t + 0xC4) = keys[24];

				for (int a1 = 0; a1 < 15; ++a1)
					*(uint*)(byteptr_t + 0xCC + a1 * 4) = keys[25 + a1];

				for (int a1 = 0; a1 < 45; ++a1)
					*(uint*)(byteptr_t + 0x11C + a1 * 4) = keys[40 + a1];

				// Write Decals
				this.DECALS_HOOD.Write(byteptr_t + 0x1D0);
				this.DECALS_FRONT_WINDOW.Write(byteptr_t + 0x1F0);
				this.DECALS_REAR_WINDOW.Write(byteptr_t + 0x210);
				this.DECALS_LEFT_DOOR.Write(byteptr_t + 0x230);
				this.DECALS_RIGHT_DOOR.Write(byteptr_t + 0x250);
				this.DECALS_LEFT_QUARTER.Write(byteptr_t + 0x270);
				this.DECALS_RIGHT_QUARTER.Write(byteptr_t + 0x290);

				// Finish Writing Keys
				for (int a1 = 0; a1 < 14; ++a1)
					*(uint*)(byteptr_t + 0x2B0 + a1 * 4) = keys[85 + a1];

				*(uint*)(byteptr_t + 0x2F0) = keys[99];
			}
			return result;
		}
	}
}