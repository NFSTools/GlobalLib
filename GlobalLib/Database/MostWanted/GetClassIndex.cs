namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
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
                    return this.Materials.GetClassIndex(CName);
                
                case eClassType.CarTypeInfo:
                    return this.CarTypeInfos.GetClassIndex(CName);
                    
                case eClassType.PresetRide:
                    return this.PresetRides.GetClassIndex(CName);

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