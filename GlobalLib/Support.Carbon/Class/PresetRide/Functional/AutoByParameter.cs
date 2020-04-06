using GlobalLib.Support.Carbon.Parts.PresetParts;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Returns autosculpt part of the preset ride using length of the name of the part.
        /// </summary>
        /// <param name="length">Length of the name of the part.</param>
        /// <returns>Autosculpt part class of the preset ride.</returns>
        public Autosculpt AutoByParameter(int length)
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

        /// <summary>
        /// Returns autosculpt part of the preset ride using name of the part.
        /// </summary>
        /// <param name="name">Name of the part.</param>
        /// <returns>Autosculpt part class of the preset ride.</returns>
        public Autosculpt AutoByParameter(string name)
        {
            switch (name)
            {
                case "HOOD":
                    return this.HOOD;
                case "SKIRT":
                    return this.SKIRT;
                case "WHEELS":
                    return this.WHEELS;
                case "SPOILER":
                    return this.SPOILER;
                case "ROOFSCOOP":
                    return this.ROOFSCOOP;
                case "REARBUMPER":
                    return this.REARBUMPER;
                case "FRONTBUMPER":
                    return this.FRONTBUMPER;
                default:
                    return null;
            }
        }
    }
}