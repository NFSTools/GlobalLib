using GlobalLib.Reflection.Abstract;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new PresetRide(CName, this.Database);

            result._brightness = this._brightness;
            result._saturation = this._saturation;
            result._paint_type = this._paint_type;
            result._paint_swatch = this._paint_swatch;
            result._exhaust_style = this._exhaust_style;
            result._exhaust_size = this._exhaust_size;
            result._is_center_exhaust = this._is_center_exhaust;
            result._hood_style = this._hood_style;
            result._is_autosculpt_hood = this._is_autosculpt_hood;
            result._is_carbonfibre_hood = this._is_carbonfibre_hood;
            result._spoiler_style = this._spoiler_style;
            result._spoiler_type = this._spoiler_type;
            result._is_autosculpt_spoiler = this._is_autosculpt_spoiler;
            result._is_carbonfibre_spoiler = this._is_carbonfibre_spoiler;
            result._autosculpt_rearbumper = this._autosculpt_rearbumper;
            result._autosculpt_skirt = this._autosculpt_skirt;
            result._roofscoop_style = this._roofscoop_style;
            result._is_autosculpt_roofscoop = this._is_autosculpt_roofscoop;
            result._is_dual_roofscoop = this._is_dual_roofscoop;
            result.IsCarbonfibreRoofScoop = this._is_carbonfibre_roofscoop;
            result._rim_brand = this._rim_brand;
            result._rim_style = this._rim_style;
            result._rim_size = this._rim_size;
            result._popup_headlights_exist = this._popup_headlights_exist;
            result._popup_heaglights_on = this._popup_heaglights_on;
            result._choptop_is_on = this._choptop_is_on;
            result._choptop_size = this._choptop_size;
            result._window_tint_type = this._window_tint_type;
            result._specific_vinyl = this._specific_vinyl;
            result._generic_vinyl = this._generic_vinyl;
            result._autosculpt_frontbumper = this._autosculpt_frontbumper;
            result._aftermarket_bodykit = this._aftermarket_bodykit;
            result.MODEL = this.MODEL;
            result.Pvehicle = this.Pvehicle;
            result.Frontend = this.Frontend;

            result.FRONTBUMPER = this.FRONTBUMPER.PlainCopy();
            result.REARBUMPER = this.REARBUMPER.PlainCopy();
            result.SKIRT = this.SKIRT.PlainCopy();
            result.WHEELS = this.WHEELS.PlainCopy();
            result.HOOD = this.HOOD.PlainCopy();
            result.SPOILER = this.SPOILER.PlainCopy();
            result.ROOFSCOOP = this.ROOFSCOOP.PlainCopy();
            result.VINYL01 = this.VINYL01.PlainCopy();
            result.VINYL02 = this.VINYL02.PlainCopy();
            result.VINYL03 = this.VINYL03.PlainCopy();
            result.VINYL04 = this.VINYL04.PlainCopy();
            result.VINYL05 = this.VINYL05.PlainCopy();
            result.VINYL06 = this.VINYL06.PlainCopy();
            result.VINYL07 = this.VINYL07.PlainCopy();
            result.VINYL08 = this.VINYL08.PlainCopy();
            result.VINYL09 = this.VINYL09.PlainCopy();
            result.VINYL10 = this.VINYL10.PlainCopy();
            result.VINYL11 = this.VINYL11.PlainCopy();
            result.VINYL12 = this.VINYL12.PlainCopy();
            result.VINYL13 = this.VINYL13.PlainCopy();
            result.VINYL14 = this.VINYL14.PlainCopy();
            result.VINYL15 = this.VINYL15.PlainCopy();
            result.VINYL16 = this.VINYL16.PlainCopy();
            result.VINYL17 = this.VINYL17.PlainCopy();
            result.VINYL18 = this.VINYL18.PlainCopy();
            result.VINYL19 = this.VINYL19.PlainCopy();
            result.VINYL20 = this.VINYL20.PlainCopy();

            Buffer.BlockCopy(this.data, 0, result.data, 0, this.data.Length);
            
            return result;
        }
    }
}