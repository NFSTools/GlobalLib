namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        /// <summary>
        /// Writes all slottype into the Global data.
        /// </summary>
        /// <param name="db">Database with classes.</param>
        /// <param name="bw">BinaryWriter for writing data.</param>
        private static void I_SlotType(Database.Underground2 db, System.IO.BinaryWriter bw)
        {
            var SetList = new System.Collections.Generic.List<Parts.CarParts.CarSpoilMirrType>();

			// Get all cartypeinfos with non-base spoilers and mirrors
			foreach (var car in db.CarTypeInfos.Collections)
			{
				if (car.Spoiler != Reflection.Enum.eSpoiler.SPOILER)
				{
					var add = new Parts.CarParts.CarSpoilMirrType();
					add.CarTypeInfo = car.CollectionName;
					add.Spoiler = car.Spoiler;
					add.SpoilerNoMirror = true;
					SetList.Add(add);
				}
				if (car.Mirrors != Reflection.Enum.eMirrorTypes.MIRRORS)
				{
					var add = new Parts.CarParts.CarSpoilMirrType();
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