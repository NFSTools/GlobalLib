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
				parts._BASE_KIT = MODEL + add_on._K10 + add_on._0 + parts._BASE_KIT;

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
				else if (this._spoiler_style == 0 || this._spoiler_type == Reflection.Enum.eSTypes.BASE)
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
				parts._TRUNK_UNDER = MODEL + add_on._K10 + add_on._0 + parts._TRUNK_UNDER;

				// _FRONT_BRAKE
				if (this._front_brake_style == 0)
					parts._FRONT_BRAKE = MODEL + add_on._KIT + add_on._0 + parts._FRONT_BRAKE;
				else
					parts._FRONT_BRAKE = add_on.BRAKE + add_on._STYLE + this._front_brake_style.ToString("00");

				// _REAR_BRAKE
				if (this._rear_brake_style == 0)
					parts._REAR_BRAKE = MODEL + add_on._KIT + add_on._0 + parts._REAR_BRAKE;
				else
					parts._REAR_BRAKE = add_on.BRAKE + add_on._STYLE + this._rear_brake_style.ToString("00");

				// _WHEEL
				parts._WHEEL = this.GetValidRimString();

				// _MIRROR
				if (this._wing_mirror_style == Reflection.BaseArguments.NULL || this._wing_mirror_style == Reflection.BaseArguments.STOCK)
					parts._WING_MIRROR = MODEL + add_on._KIT + add_on._0 + parts._WING_MIRROR;
				else
					parts._WING_MIRROR = this._wing_mirror_style;

				// _TRUNK_AUDIO
				parts._TRUNK_AUDIO = MODEL + add_on._KIT + this._trunk_audio_style.ToString() + parts._TRUNK_AUDIO;







			}
			return result;
		}
	}
}