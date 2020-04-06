using System.Collections.Generic;

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
            var CNameList = new List<string>();
            foreach (var car in db.CarTypeInfos.Collections)
                CNameList.Add(car.CollectionName);
            var AllSlots = db.SlotTypes.Spoilers.GetSpoilers(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;
            foreach (var Slot in AllSlots)
            {
                var car = db.CarTypeInfos.FindCollection(Slot.CarTypeInfo);
                if (car == null) continue;
                car.Spoiler = Slot.Spoiler;
                car.SpoilerAS = Slot.SpoilerAS;
            }
        }
    }
}