using System.Collections.Generic;

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
            var CNameList = new List<string>(db.CarTypeInfos.Length);
            foreach (var car in db.CarTypeInfos.Collections)
                CNameList.Add(car.CollectionName);

            var AllSlots = db.SlotTypes.SpoilMirrs.GetSpoilMirrs(CNameList);
            if (AllSlots == null || AllSlots.Count == 0) return;

            foreach (var Slot in AllSlots)
            {
                var car = db.CarTypeInfos.FindCollection(Slot.CarTypeInfo);
                if (car != null)
                {
                    if (Slot.SpoilerNoMirror)
                        car.Spoiler = Slot.Spoiler;
                    else
                        car.Mirrors = Slot.Mirrors;
                }
            }
        }
    }
}