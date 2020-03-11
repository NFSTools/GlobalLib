﻿namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Gets index of the class from the list of the database.
        /// </summary>
        /// <param name="CName">Collection Name of the class.</param>
        /// <param name="classtype">Class type to be found.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public int GetClassIndex(string CName, eClassType classtype)
        {
            switch (classtype)
            {
                case eClassType.Material:
                    for (int a1 = 0; a1 < this.Materials.Count; ++a1)
                        if (CName == this.Materials[a1].CollectionName)
                            return a1;
                    break;

                case eClassType.CarTypeInfo:
                    for (int a1 = 0; a1 < this.CarTypeInfos.Count; ++a1)
                        if (CName == this.CarTypeInfos[a1].CollectionName)
                            return a1;
                    break;

                case eClassType.PresetRide:
                    for (int a1 = 0; a1 < this.PresetRides.Count; ++a1)
                        if (CName == this.PresetRides[a1].CollectionName)
                            return a1;
                    break;

                case eClassType.PresetSkin:
                    for (int a1 = 0; a1 < this.PresetSkins.Count; ++a1)
                        if (CName == this.PresetSkins[a1].CollectionName)
                            return a1;
                    break;

                case eClassType.FNGroup:
                    for (int a1 = 0; a1 < this.FNGroups.Count; ++a1)
                        if (CName == this.FNGroups[a1].CollectionName)
                            return a1;
                    break;

                case eClassType.TPKBlock:
                    for (int a1 = 0; a1 < this.TPKBlocks.Count; ++a1)
                        if (CName == this.TPKBlocks[a1].CollectionName)
                            return a1;
                    break;

                default:
                    break;
            }
            return -1;
        }
    }
}