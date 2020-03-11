namespace GlobalLib.Database
{
    public partial class Carbon
    {
        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be deleted.</param>
        /// <param name="type">Type of the class to delete. Range: Material, CarTypeInfo, Preset Ride, Preset Skin.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public bool TryRemoveClass(string CName, eClassType type)
        {
            int index = -1;

            switch (type)
            {
                case eClassType.Material:
                    if ((index = this.Materials.GetClassIndex(CName)) == -1) return false;
                    this.Materials.Classes.RemoveAt(index);
                    return true;

                case eClassType.CarTypeInfo:
                    if ((index = this.CarTypeInfos.GetClassIndex(CName)) == -1) return false;
                    if (!this.CarTypeInfos.Classes[index].Deletable)
                        return false;
                    this.CarTypeInfos.Classes.RemoveAt(index);
                    return true;

                case eClassType.PresetRide:
                    if ((index = this.PresetRides.GetClassIndex(CName)) == -1) return false;
                    this.PresetRides.Classes.RemoveAt(index);
                    return true;

                case eClassType.PresetSkin:
                    if ((index = this.PresetSkins.GetClassIndex(CName)) == -1) return false;
                    this.PresetSkins.Classes.RemoveAt(index);
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Attempts to remove class specfified in the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be deleted.</param>
        /// <param name="root">Root of the class to delete. Range: Materials, CarTypeInfos, PresetRides.</param>
        /// <returns>True if class removing was successful, false otherwise.</returns>
        public bool TryRemoveClass(string CName, string root)
        {
            return !System.Enum.TryParse(root, out eClassType type) && this.TryRemoveClass(CName, type);
        }
    }
}