namespace GlobalLib.Support.MostWanted.Class
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
            var result = new PresetRide(CName, this.Database);

            result.VinylName = this.VinylName;
            result.VinylColor1 = this.VinylColor1;
            result.VinylColor2 = this.VinylColor2;
            result.VinylColor3 = this.VinylColor3;
            result.VinylColor4 = this.VinylColor4;
            result.WindowTintType = this.WindowTintType;
            result.HoodStyle = this.HoodStyle;
            result.IsCarbonfibreHood = this.IsCarbonfibreHood;
            result.SpoilerStyle = this.SpoilerStyle;
            result.SpoilerType = this.SpoilerType;
            result.IsCarbonfibreSpoiler = this.IsCarbonfibreSpoiler;
            result.RoofScoopStyle = this.RoofScoopStyle;
            result.IsOffsetRoofScoop = this.IsOffsetRoofScoop;
            result.IsDualRoofScoop = this.IsDualRoofScoop;
            result.IsCarbonfibreRoofScoop = this.IsCarbonfibreRoofScoop;
            result.RimBrand = this.RimBrand;
            result.RimStyle = this.RimStyle;
            result.RimSize = this.RimSize;
            result.BodyPaint = this.BodyPaint;
            result.RimPaint = this.RimPaint;
            result.AftermarketBodykit = this.AftermarketBodykit;
            result.CollectionName = this.CollectionName;
            result.MODEL = this.MODEL;
            result.Pvehicle = this.Pvehicle;
            result.Frontend = this.Frontend;

            System.Buffer.BlockCopy(this.data, 0, result.data, 0, this.data.Length);
            Core.Map.BinKeys[result.BinKey] = CName;
            return result;
        }
    }
}