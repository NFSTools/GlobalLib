namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets spoilers from slottype block and sets to cartypeinfo.
        /// </summary>
        /// <param name="db">Database of classes.</param>
        private static void E_Spoilers(Database.Carbon db)
        {
            if (db.SlotTypes.Spoilers == null) return;
            var CNameList = new System.Collections.Generic.List<string>();
            for (int a1 = 0; a1 < db.CarTypeInfos.Count; ++a1)
                CNameList.Add(db.CarTypeInfos[a1].CollectionName);
            var AllSlots = db.SlotTypes.Spoilers.GetSpoilers(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;
            foreach (var Slot in AllSlots)
            {
                for (int a1 = 0; a1 < db.CarTypeInfos.Count; ++a1)
                {
                    if (Slot.CarTypeInfo == db.CarTypeInfos[a1].CollectionName)
                    {
                        db.CarTypeInfos[a1].Spoiler = Slot.Spoiler;
                        db.CarTypeInfos[a1].SpoilerAS = Slot.SpoilerAS;
                        break;
                    }
                }
            }
        }
    }
}