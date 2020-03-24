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
            foreach (var car in db.CarTypeInfos.Classes.Values)
                CNameList.Add(car.CollectionName);
            var AllSlots = db.SlotTypes.Spoilers.GetSpoilers(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;
            foreach (var Slot in AllSlots)
            {
                var car = db.CarTypeInfos.FindClass(Slot.CarTypeInfo);
                if (car == null) continue;
                car.Spoiler = Slot.Spoiler;
            }
        }
    }
}