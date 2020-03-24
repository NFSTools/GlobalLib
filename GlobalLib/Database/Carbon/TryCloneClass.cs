namespace GlobalLib.Database
{
    public partial class Carbon
    {
        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="type">Type of the class to clone. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, eClassType type)
        {
            if (string.IsNullOrWhiteSpace(newname)) return false;

            switch (type)
            {
                case eClassType.Material:
                    var material = this.Materials.FindClass(copyfrom);
                    if (this.Materials.Classes.ContainsKey(newname)) return false;
                    if (material == null) return false;
                    if (newname.Length > 0x1B) return false;
                    this.Materials.Classes[newname] = material.MemoryCast(newname);
                    return true;

                case eClassType.CarTypeInfo:
                    var car = this.CarTypeInfos.FindClass(copyfrom);
                    if (this.CarTypeInfos.Classes.ContainsKey(newname)) return false;
                    if (car == null) return false;
                    if (newname.Length > 0xD) return false;
                    this.CarTypeInfos.Classes[newname] = car.MemoryCast(newname);
                    return true;

                case eClassType.PresetRide:
                    var ride = this.PresetRides.FindClass(copyfrom);
                    if (this.PresetRides.Classes.ContainsKey(newname)) return false;
                    if (ride == null) return false;
                    if (newname.Length > 0x1E) return false;
                    this.PresetRides.Classes[newname] = ride.MemoryCast(newname);
                    return true;

                case eClassType.PresetSkin:
                    var skin = this.PresetSkins.FindClass(copyfrom);
                    if (this.PresetSkins.Classes.ContainsKey(newname)) return false;
                    if (skin == null) return false;
                    if (newname.Length > 0x1E) return false;
                    this.PresetSkins.Classes[newname] = skin.MemoryCast(newname);
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="root">Root of the class to clone. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, string root)
        {
            return System.Enum.TryParse(root, out eClassType type) && this.TryCloneClass(newname, copyfrom, type);
        }
    }
}