namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new PresetRide(CName, this.Database);

			result._aftermarket_bodykit = this._aftermarket_bodykit;
			result._autosculpt_frontbumper = this._autosculpt_frontbumper;
			result._autosculpt_rearbumper = this._autosculpt_rearbumper;
			result._autosculpt_skirt = this._autosculpt_skirt;
			result._brakelight_style = this._brakelight_style;
			result._carbon_body = this._carbon_body;
			result._carbon_doors = this._carbon_doors;
			result._carbon_hood = this._carbon_hood;
			result._carbon_trunk = this._carbon_trunk;
			result._custom_hud_style = this._custom_hud_style;
			result._cv_misc_style = this._cv_misc_style;
			result._decaltype_hood = this._decaltype_hood;
			result._decaltype_leftquarter = this._decaltype_leftquarter;
			result._decaltype_rightquarter = this._decaltype_rightquarter;
			result._decalwide_leftdoor = this._decalwide_leftdoor;
			result._decalwide_leftquarter = this._decalwide_leftquarter;
			result._decalwide_rightdoor = this._decalwide_rightdoor;
			result._decalwide_rightquarter = this._decalwide_rightquarter;
			result._engine_style = this._engine_style;
			result._exhaust_style = this._exhaust_style;
			result._front_brake_style = this._front_brake_style;
			result._headlight_style = this._headlight_style;
			result._hood_style = this._hood_style;
			result._hud_backing_color = this._hud_backing_color;
			result._hud_character_color = this._hud_character_color;
			result._hud_needle_color = this._hud_needle_color;
			result._is_carbonfibre_hood = this._is_carbonfibre_hood;
			result._is_carbonfibre_roofscoop = this._is_carbonfibre_roofscoop;
			result._is_carbonfibre_spoiler = this._is_carbonfibre_spoiler;
			result._is_dual_roofscoop = this._is_dual_roofscoop;
			result._is_offset_roofscoop = this._is_offset_roofscoop;
			result._is_spinning_rim = this._is_spinning_rim;
			result._performance_level = this._performance_level;
			result._rear_brake_style = this._rear_brake_style;
			result._rim_brand = this._rim_brand;
			result._rim_outer_max = this._rim_outer_max;
			result._rim_size = this._rim_size;
			result._rim_style = this._rim_style;
			result._roofscoop_style = this._roofscoop_style;
			result._spoiler_style = this._spoiler_style;
			result._spoiler_type = this._spoiler_type;
			result._trunk_audio_style = this._trunk_audio_style;
			result._under_hood_style = this._under_hood_style;
			result._unknown1 = this._unknown1;
			result._unknown2 = this._unknown2;
			result._window_tint_type = this._window_tint_type;
			result._wing_mirror_style = this._wing_mirror_style;

			result.DECALS_FRONT_WINDOW = this.DECALS_FRONT_WINDOW.PlainCopy();
			result.DECALS_HOOD = this.DECALS_HOOD.PlainCopy();
			result.DECALS_LEFT_DOOR = this.DECALS_LEFT_DOOR.PlainCopy();
			result.DECALS_LEFT_QUARTER = this.DECALS_LEFT_QUARTER.PlainCopy();
			result.DECALS_REAR_WINDOW = this.DECALS_REAR_WINDOW.PlainCopy();
			result.DECALS_RIGHT_DOOR = this.DECALS_RIGHT_DOOR.PlainCopy();
			result.DECALS_RIGHT_QUARTER = this.DECALS_RIGHT_QUARTER.PlainCopy();
			result.AUDIO_COMP = this.AUDIO_COMP.PlainCopy();
			result.PAINT_TYPES = this.PAINT_TYPES.PlainCopy();
			result.SPECIALTIES = this.SPECIALTIES.PlainCopy();
			result.VINYL_SETS = this.VINYL_SETS.PlainCopy();

			System.Buffer.BlockCopy(this.data, 0, result.data, 0, this.data.Length);

			return result;
        }
    }
}