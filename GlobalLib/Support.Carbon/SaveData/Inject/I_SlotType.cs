namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.Carbon db, System.IO.BinaryWriter bw)
        {
            var SetList = new System.Collections.Generic.List<Parts.CarParts.CarSpoilerType>();

            // Get all cartypeinfos with non-base spoilers
            foreach (var info in db.CarTypeInfos)
            {
                if (info.Spoiler != Reflection.Info.Spoiler.BASE || info.SpoilerAS != Reflection.Info.SpoilerAS.BASE)
                {
                    var Class = new Parts.CarParts.CarSpoilerType();
                    Class.CarTypeInfo = info.CollectionName;
                    Class.Spoiler = info.Spoiler;
                    Class.SpoilerAS = info.SpoilerAS;
                    SetList.Add(Class);
                }
            }

            bw.Write(db.SlotTypes.Spoilers.SetSpoilers(SetList));
        }
    }
}