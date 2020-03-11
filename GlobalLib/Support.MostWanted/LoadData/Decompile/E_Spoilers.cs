namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets spoilers from slottype block and sets to cartypeinfo.
        /// </summary>
        /// <param name="db">Database of classes.</param>
        private static void E_Spoilers(Database.MostWanted db)
        {
            if (db.SlotTypes.Spoilers == null) return;
            var CNameList = new System.Collections.Generic.List<string>();
            for (int a1 = 0; a1 < db.CarTypeInfos.Length; ++a1)
                CNameList.Add(db.CarTypeInfos.Classes[a1].CollectionName);
            var AllSlots = db.SlotTypes.Spoilers.GetSpoilers(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;
            foreach (var Slot in AllSlots)
            {
                for (int a1 = 0; a1 < db.CarTypeInfos.Length; ++a1)
                {
                    if (Slot.CarTypeInfo == db.CarTypeInfos.Classes[a1].CollectionName)
                    {
                        db.CarTypeInfos.Classes[a1].Spoiler = Slot.Spoiler;
                        break;
                    }
                }
            }
        }
    }
}