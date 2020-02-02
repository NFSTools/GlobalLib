namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
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
            byte result = Utils.FormatX.GetByte(name, "VINYL{XX}");
            if (result != 0 && result <= 20)
                return this.Vinyls[result - 1];
            else
                return null;
        }
    }
}