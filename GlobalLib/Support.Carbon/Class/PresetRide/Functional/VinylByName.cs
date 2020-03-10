namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Returns vinyl part of the preset ride based on VINYL# string passed.
        /// </summary>
        /// <param name="name">String of format VINYL#, where # is 1-20.</param>
        /// <returns>Vinyl part of the preset ride.</returns>
        public Parts.PresetParts.Vinyl VinylByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            string value = name.ToUpper();
            if (!value.StartsWith("VINYL")) return null;
            string number = Utils.FormatX.GetString(name, "VINYL{XX}");
            if (number.StartsWith("0")) return null;
            if (byte.TryParse(number, out byte result))
            {
                if (result != 0 && result <= this._number_of_vinyls)
                    return this.Vinyls[result - 1];
                else
                    return null;
            }
            else
                return null;
        }
    }
}