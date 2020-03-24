namespace GlobalLib.Support.Underground2
{
	public static partial class LoadData
	{
		private static void E_DefaultCarPartValues(Database.Underground2 db)
		{
			foreach (var part in db.SlotTypes.Part56)
			{
				if (!part.IsCar) continue;
				var car = db.CarTypeInfos.FindClass(part.BelongsTo);
				if (car == null) continue;
				if (!Core.Map.CarPartsMap.Contains(part.BelongsTo))
					Core.Map.CarPartsMap.Add(part.BelongsTo);
				car.UsesCarPartsOf = part.BelongsTo;
			}
		}
	}
}