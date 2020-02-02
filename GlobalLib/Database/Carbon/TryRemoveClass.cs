namespace GlobalLib.Database
{
    partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be deleted.</param>
        /// <param name="type">Type of the class to delete. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public bool TryRemoveClass(string CName, ClassType type)
        {
            int index = this.GetClassIndex(CName, type);
            if (index == -1)
                return false;

            switch (type)
            {
                case ClassType.Material:
                    this.Materials.RemoveAt(index);
                    return true;

                case ClassType.CarTypeInfo:
                    if (!this.CarTypeInfos[index].Deletable)
                        return false;
                    this.CarTypeInfos.RemoveAt(index);
                    return true;

                case ClassType.PresetRide:
                    this.PresetRides.RemoveAt(index);
                    return true;

                case ClassType.PresetSkin:
                    this.PresetSkins.RemoveAt(index);
                    return true;

                default:
                    return false;
            }
        }
    }
}