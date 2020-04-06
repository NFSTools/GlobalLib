using GlobalLib.Support.Carbon.Parts.PresetParts;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        /// <summary>
        /// Returns vinyl part of the preset ride based on VINYL# string passed.
        /// </summary>
        /// <param name="name">String of format VINYL#, where # is 1-20.</param>
        /// <returns>Vinyl part of the preset ride.</returns>
        public Vinyl VinylByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            string value = name.ToUpper();
            var vinyl = this.GetType().GetProperty(name);
            if (vinyl.PropertyType == typeof(Vinyl))
                return (Vinyl)vinyl.GetValue(this);
            return null;
        }
    }
}