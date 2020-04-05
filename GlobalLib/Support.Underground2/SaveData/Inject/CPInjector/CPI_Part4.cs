using GlobalLib.Reflection.Enum;
using GlobalLib.Support.Underground2.Parts.CarParts;
using GlobalLib.Utils;
using System.Collections.Generic;

namespace GlobalLib.Support.Underground2
{
	public static partial class SaveData
	{
		// Thanks to nlgzrgn for helping with this part!)))
		private static byte[] CPI_Part4(Database.Underground2 db)
		{
			int part4size = db.SlotTypes.Part4.Data.Length;
			var carlist = new List<string>();

			// Precalculate size of part4
			foreach (var car in db.CarTypeInfos.Collections)
			{
				if (car.Deletable && car.UsageType == eUsageType.Racer)
				{
					carlist.Add(car.CollectionName);
					part4size += 0xD8;
				}
				else if (car.Deletable && car.UsageType == eUsageType.Traffic)
				{
					carlist.Add(car.CollectionName);
					part4size += 0x48;
				}
			}

			int padding = 0x10 - ((part4size + 8) % 0x10);
			if (padding != 0x10) part4size += padding;

			// Use MemoryWriter instead of BinaryWriter so we can return an array for later processes
			var mw = new MemoryWriter(part4size);
			mw.Write(db.SlotTypes.Part4.Data);

			const uint negative = 0xFFFFFFFF;
			const uint definer  = 0xFFFF0000;

			foreach (var name in carlist)
			{
				var car = db.CarTypeInfos.FindCollection(name);
				switch (car.UsageType)
				{
					case eUsageType.Racer:
						for (int a1 = 0; a1 < 5; ++a1)
						{
							mw.Write(definer);
							mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[a1]));
							for (int a2 = 0; a2 < 7; ++a2)
								mw.Write(negative);
						}
						mw.Write(definer);
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[5]));
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[6]));
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[7]));
						mw.Write(negative);
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[8]));
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[9]));
						mw.Write(Bin.Hash(name + UsageType.MiscPartsRacer[10]));
						mw.Write(negative);
						break;

					case eUsageType.Traffic:
						mw.Write(definer);
						mw.Write(Bin.Hash(name + UsageType.MiscPartsTraffic[0]));
						for (int a1 = 0; a1 < 7; ++a1)
							mw.Write(negative);
						mw.Write(definer);
						for (int a1 = 1; a1 < 5; ++a1)
							mw.Write(Bin.Hash(name + UsageType.MiscPartsTraffic[a1]));
						for (int a1 = 0; a1 < 4; ++a1)
							mw.Write(negative);
						break;

					default: // should never happen
						break;
				}
			}

			// Fix length in the header
			mw.Position = 4;
			mw.Write(mw.Length - 8);
			db.SlotTypes.Part0.SetMiscNumber((mw.Length - 8) / 0x24);
			return mw.Data;
		}
	}
}