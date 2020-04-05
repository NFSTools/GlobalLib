using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Underground2.Parts.CarParts;
using System.Collections.Generic;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.Underground2 db, BinaryWriter bw)
        {
            var SetList = new List<CarSpoilMirrType>();

			// Get all cartypeinfos with non-base spoilers and mirrors
			foreach (var car in db.CarTypeInfos.Collections)
			{
				if (car.Spoiler != eSpoiler.SPOILER)
				{
					var add = new CarSpoilMirrType();
					add.CarTypeInfo = car.CollectionName;
					add.Spoiler = car.Spoiler;
					add.SpoilerNoMirror = true;
					SetList.Add(add);
				}
				if (car.Mirrors != eMirrorTypes.MIRRORS)
				{
					var add = new CarSpoilMirrType();
					add.CarTypeInfo = car.CollectionName;
					add.Mirrors = car.Mirrors;
					add.SpoilerNoMirror = false;
					SetList.Add(add);
				}
			}

			bw.Write(db.SlotTypes.SpoilMirrs.SetSpoilMirrs(SetList));
        }
    }
}