namespace GlobalLib.Database
{
    partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="type">Type of the class to clone. Range: Material, CarTypeInfo, Preset Ride.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, eClassType type)
        {
            if (string.IsNullOrWhiteSpace(newname)) return false;

            switch (type)
            {
                case eClassType.Material:
                    var material = this.Materials.FindClass(copyfrom);
                    if (this.Materials.GetClassIndex(newname) != -1) return false;
                    if (material == null) return false;
                    if (newname.Length > 0x1B) return false;
                    this.Materials.Classes.Add(material.MemoryCast(newname));
                    return true;

                case eClassType.CarTypeInfo:
                    var car = this.CarTypeInfos.FindClass(copyfrom);
                    if (this.CarTypeInfos.GetClassIndex(newname) != -1) return false;
                    if (car == null) return false;
                    if (newname.Length > 0xD) return false;
                    this.CarTypeInfos.Classes.Add(car.MemoryCast(newname));
                    return true;

                case eClassType.PresetRide:
                    var ride = this.PresetRides.FindClass(copyfrom);
                    if (this.PresetRides.GetClassIndex(newname) != -1) return false;
                    if (ride == null) return false;
                    if (newname.Length > 0x1E) return false;
                    this.PresetRides.Classes.Add(ride.MemoryCast(newname));
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