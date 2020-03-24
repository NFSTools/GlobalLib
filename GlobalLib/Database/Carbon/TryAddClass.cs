namespace GlobalLib.Database
{
    public partial class Carbon
    {
        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="CName">Collection Name of the new class.</param>
        /// <param name="type">Type of the new class. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public bool TryAddClass(string CName, eClassType type)
        {
            if (string.IsNullOrWhiteSpace(CName)) return false;

            switch (type)
            {
                case eClassType.Material:
                    if (this.Materials.Classes.ContainsKey(CName)) return false;
                    if (CName.Length > 0x1B) return false;
                    var material = new Support.Carbon.Class.Material(CName, this);
                    this.Materials.Classes[CName] = material;
                    return true;

                case eClassType.CarTypeInfo:
                    if (this.CarTypeInfos.Classes.ContainsKey(CName)) return false;
                    if (CName.Length > 0xD) return false;
                    var car = new Support.Carbon.Class.CarTypeInfo(CName, this);
                    this.CarTypeInfos.Classes[CName] = car;
                    return true;

                case eClassType.PresetRide:
                    if (this.PresetRides.Classes.ContainsKey(CName)) return false;
                    if (CName.Length > 0x1E) return false;
                    var ride = new Support.Carbon.Class.PresetRide(CName, this);
                    this.PresetRides.Classes[CName] = ride;
                    return true;

                case eClassType.PresetSkin:
                    if (this.PresetSkins.Classes.ContainsKey(CName)) return false;
                    if (CName.Length > 0x1E) return false;
                    var skin = new Support.Carbon.Class.PresetRide(CName, this);
                    this.PresetRides.Classes[CName] = skin;
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="CName">Collection Name of the new class.</param>
        /// <param name="root">Root of the new class. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public bool TryAddClass(string CName, string root)
        {
            return !System.Enum.TryParse(root, out eClassType type) && this.TryAddClass(CName, type);
        }
    }
}