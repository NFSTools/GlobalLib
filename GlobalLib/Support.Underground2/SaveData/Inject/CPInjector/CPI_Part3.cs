namespace GlobalLib.Support.Underground2
{
	public static partial class SaveData
	{
		// Thanks to nlgzrgn for helping with this part!)))
		private static byte[] CPI_Part3(Database.Underground2 db)
		{
			int part3size = db.SlotTypes.Part3.Data.Length;
			var carlist = new System.Collections.Generic.List<string>();

			// Precalculate size of part3
			foreach (var car in db.CarTypeInfos.Collections)
			{
				if (car.Deletable && car.UsageType == Reflection.Enum.eUsageType.Racer)
					carlist.Add(car.CollectionName);
			}

			part3size += carlist.Count * 0x158;
			int padding = 0x10 - ((part3size + 8) % 0x10);
			if (padding != 0x10) part3size += padding;

			// Use MemoryWriter instead of BinaryWriter so we can return an array for later processes
			var mw = new Utils.MemoryWriter(part3size);
			mw.Write(db.SlotTypes.Part3.Data);

			const uint key1 = 0x10C98090; // ???
			const uint key2 = 0x0D4B85C7; // HOODUNDER

			// Write all info
			foreach (var name in carlist)
			{
				for (int a1 = 0; a1 < 0x2B; ++a1)
				{
					mw.Write((a1 > 34 && a1 < 40) ? key2 : key1);
					mw.Write(Utils.Bin.Hash(name + Parts.CarParts.UsageType.SpecPartNames[a1]));
				}
			}

			// Fix length in the header
			mw.Position = 4;
			mw.Write(mw.Length - 8);
			db.SlotTypes.Part0.SetRecordNumber((mw.Length - 8) / 8);
			return mw.Data;
		}
	}
}