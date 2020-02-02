namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetRide : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Converts all preset parts into binary memory keys.
        /// </summary>
        /// <param name="parts">PresetParts concatenator class of all preset ride's parts.</param>
        /// <returns>Sorted array of all preset parts hashes.</returns>
        protected virtual unsafe uint[] StringToKey(Parts.PresetParts.Concatenator parts) { return null; }
    }
}