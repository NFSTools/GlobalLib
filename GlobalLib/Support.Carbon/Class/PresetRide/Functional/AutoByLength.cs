namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        /// <summary>
        /// Returns autosculpt part of the preset ride using length of the name of the part.
        /// </summary>
        /// <param name="length">Length of the name of the part.</param>
        /// <returns>Autosculpt part class of the preset ride.</returns>
        public Parts.PresetParts.Autosculpt AutoByLength(int length)
        {
            switch (length)
            {
                case 4:
                    return this.HOOD;
                case 5:
                    return this.SKIRT;
                case 6:
                    return this.WHEELS;
                case 7:
                    return this.SPOILER;
                case 9:
                    return this.ROOFSCOOP;
                case 10:
                    return this.REARBUMPER;
                case 11:
                    return this.FRONTBUMPER;
                default:
                    return null;
            }
        }
    }
}