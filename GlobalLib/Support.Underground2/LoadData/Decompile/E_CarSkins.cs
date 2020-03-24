namespace GlobalLib.Support.Underground2
{
	public static partial class LoadData
	{
		private static unsafe void E_CarSkins(byte* byteptr_t, uint length, Database.Underground2 db)
		{
			const uint size = 0x40;

			for (uint loop = 0; loop < length / size; ++loop)
			{
				uint offset = loop * size;

				var Reader = new Parts.CarParts.CarSkin();
				Reader.Read(byteptr_t + offset, out int id, out int index);
				var car = db.CarTypeInfos.FindClassWithValue("Index", index);
				if (car == null) continue;
				
				switch (index)
				{
					case 1:
						car.CARSKIN01 = Reader;
						break;
					case 2:
						car.CARSKIN02 = Reader;
						break;
					case 3:
						car.CARSKIN03 = Reader;
						break;
					case 4:
						car.CARSKIN04 = Reader;
						break;
					case 5:
						car.CARSKIN05 = Reader;
						break;
					case 6:
						car.CARSKIN06 = Reader;
						break;
					case 7:
						car.CARSKIN07 = Reader;
						break;
					case 8:
						car.CARSKIN08 = Reader;
						break;
					case 9:
						car.CARSKIN09 = Reader;
						break;
					case 10:
						car.CARSKIN10 = Reader;
						break;
					default:
						break;
				}
			}
		}
	}
}