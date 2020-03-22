namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Gets spoilers from slottype block and sets to cartypeinfo.
        /// </summary>
        /// <param name="db">Database of classes.</param>
        private static void E_SpoilMirrs(Database.Underground2 db)
        {
            if (db.SlotTypes.SpoilMirrs == null) return;
            var CNameList = new System.Collections.Generic.List<string>();
            
            for (int a1 = 0; a1 < db.CarTypeInfos.Length; ++a1)
                CNameList.Add(db.CarTypeInfos.Classes[a1].CollectionName);
            
            var AllSlots = db.SlotTypes.SpoilMirrs.GetSpoilMirrs(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;

            foreach (var Slot in AllSlots)
            {
                var car = db.CarTypeInfos.FindClass(Slot.CarTypeInfo);
                if (car != null)
                {
                    car.Spoiler = Slot.Spoiler;
                    car.Mirrors = Slot.Mirrors;
                }
            }
        }
    }
}