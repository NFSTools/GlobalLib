namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public PresetRide MemoryCast(string CName)
        {
            var result = new PresetRide(CName);

            for (int a1 = 0; a1 < 20; ++a1)
                result.Vinyls[a1] = this.Vinyls[a1].PlainCopy();
            result.FRONTBUMPER = this.FRONTBUMPER.PlainCopy();
            result.REARBUMPER = this.REARBUMPER.PlainCopy();
            result.SKIRT = this.SKIRT.PlainCopy();
            result.WHEELS = this.WHEELS.PlainCopy();
            result.HOOD = this.HOOD.PlainCopy();
            result.SPOILER = this.SPOILER.PlainCopy();
            result.ROOFSCOOP = this.ROOFSCOOP.PlainCopy();

            result.PaintBrightness = this.PaintBrightness;
            result.PaintSaturation = this.PaintSaturation;
            result.PaintType = this.PaintType;
            result.PaintSwatch = this.PaintSwatch;
            result.ExhaustStyle = this.ExhaustStyle;
            result.ExhaustSize = this.ExhaustSize;
            result.IsCenterExhaust = this.IsCenterExhaust;
            result.HoodStyle = this.HoodStyle;
            result.IsAutosculptHood = this.IsAutosculptHood;
            result.IsCarbonfibreHood = this.IsCarbonfibreHood;
            result.SpoilerStyle = this.SpoilerStyle;
            result.SpoilerType = this.SpoilerType;
            result.IsAutosculptSpoiler = this.IsAutosculptSpoiler;
            result.IsCarbonfibreSpoiler = this.IsCarbonfibreSpoiler;
            result.AutosculptRearBumper = this.AutosculptRearBumper;
            result.AutosculptSkirt = this.AutosculptSkirt;
            result.RoofScoopStyle = this.RoofScoopStyle;
            result.IsAutosculptRoofScoop = this.IsAutosculptRoofScoop;
            result.IsDualRoofScoop = this.IsDualRoofScoop;
            result.IsCarbonfibreRoofScoop = this.IsCarbonfibreRoofScoop;
            result.RimBrand = this.RimBrand;
            result.RimStyle = this.RimStyle;
            result.RimSize = this.RimSize;
            result.PopupHeadlightsExist = this.PopupHeadlightsExist;
            result.PopupHeadlightsOn = this.PopupHeadlightsOn;
            result.ChopTopIsOn = this.ChopTopIsOn;
            result.ChopTopSize = this.ChopTopSize;
            result.WindowTintType = this.WindowTintType;
            result.SpecificVinyl = this.SpecificVinyl;
            result.GenericVinyl = this.GenericVinyl;
            result.NumberOfVinyls = this.NumberOfVinyls;
            result.AutosculptFrontBumper = this.AutosculptFrontBumper;
            result.AftermarketBodykit = this.AftermarketBodykit;
            result.MODEL = this.MODEL;
            result.Pvehicle = this.Pvehicle;
            result.Frontend = this.Frontend;

            System.Buffer.BlockCopy(this.data, 0, result.data, 0, this.data.Length);
            Core.Map.BinKeys[result.BinKey] = CName;
            return result;
        }
    }
}