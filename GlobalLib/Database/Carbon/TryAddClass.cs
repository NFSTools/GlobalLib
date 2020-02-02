namespace GlobalLib.Database
{
    partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Attempts to add class specfified to the database.
        /// </summary>
        /// <param name="CName">Collection Name of the new class.</param>
        /// <param name="type">Type of the new class. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class adding was successful, false otherwise.</returns>
        public bool TryAddClass(string CName, ClassType type)
        {
            if (string.IsNullOrWhiteSpace(CName)) return false;

            if (this.GetClassIndex(CName, type) != -1)
                return false;

            switch (type)
            {
                case ClassType.Material:
                    if (CName.Length > 0x1B) return false;
                    var material = new Support.Carbon.Class.Material(CName);
                    this.Materials.Add(material);
                    return true;

                case ClassType.CarTypeInfo:
                    if (CName.Length > 0xD) return false;
                    var car = new Support.Carbon.Class.CarTypeInfo(CName);
                    this.CarTypeInfos.Add(car);
                    return true;

                case ClassType.PresetRide:
                    if (CName.Length > 0x1E) return false;
                    var ride = new Support.Carbon.Class.PresetRide(CName);
                    this.PresetRides.Add(ride);
                    return true;

                case ClassType.PresetSkin:
                    if (CName.Length > 0x1E) return false;
                    var skin = new Support.Carbon.Class.PresetSkin(CName);
                    this.PresetSkins.Add(skin);
                    return true;

                default:
                    return false;
            }
        }
    }
}