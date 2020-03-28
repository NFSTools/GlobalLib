namespace GlobalLib.Support.Underground2
{
	public static partial class LoadData
	{
		private static unsafe void E_GlobalLibBlock(byte* byteptr_t, uint size, Database.Underground2 db)
		{
			var mr = new Utils.MemoryReader(byteptr_t, (int)size);

			mr.Position = 0x30;

			string type = mr.ReadNullTerminated(0x20);
			switch (type)
			{
				case "Padding Block":
					return;

				case "CarParts Block":
					int num = mr.ReadInt32();
					int len = mr.ReadInt32();

					while (mr.Position < mr.Length && len > 0 && num > 0)
					{
						var name = mr.ReadNullTerminated();
						var part = mr.ReadNullTerminated();

						var car = db.CarTypeInfos.FindCollection(name);
						if (car == null) continue;
						var ofname = db.SlotTypes.Part56.Find(c => c.BelongsTo == name && c.IsCar);
						if (ofname == null) continue;
						var ofpart = db.SlotTypes.Part56.Find(c => c.BelongsTo == part && c.IsCar);
						if (ofpart == null) continue;

						if (!Core.Map.CarPartsMap.Contains(part) && !car.Deletable)
							Core.Map.CarPartsMap.Add(part);

						car.UsesCarPartsOf = part;
						--num; len -= (name.Length + part.Length + 2);
					}
					LibPartBlockExists = true;
					break;

				default:
					return;
			}
		}
	}
}