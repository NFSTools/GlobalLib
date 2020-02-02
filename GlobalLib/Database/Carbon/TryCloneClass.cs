namespace GlobalLib.Database
{
    partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Attempts to clone class specfified in the database.
        /// </summary>
        /// <param name="newname">Collection Name of the new class.</param>
        /// <param name="copyfrom">Collection Name of the class to clone.</param>
        /// <param name="type">Type of the class to clone. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public bool TryCloneClass(string newname, string copyfrom, ClassType type)
        {
            if (this.GetClassIndex(newname, type) != -1)
                return false;

            int index = this.GetClassIndex(copyfrom, type);
            if (index == -1)
                return false;

            switch (type)
            {
                case ClassType.Material:
                    var material = this.Materials[index].MemoryCast(newname);
                    this.Materials.Add(material);
                    return true;

                case ClassType.CarTypeInfo:
                    var car = this.CarTypeInfos[index].MemoryCast(newname);
                    this.CarTypeInfos.Add(car);
                    return true;

                case ClassType.PresetRide:
                    var ride = this.PresetRides[index].MemoryCast(newname);
                    this.PresetRides.Add(ride);
                    return true;

                case ClassType.PresetSkin:
                    var skin = this.PresetSkins[index].MemoryCast(newname);
                    this.PresetSkins.Add(skin);
                    return true;

                default:
                    return false;
            }
        }
    }
}