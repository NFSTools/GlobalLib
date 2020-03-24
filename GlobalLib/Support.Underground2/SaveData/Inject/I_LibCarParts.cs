namespace GlobalLib.Support.Underground2
{
	public partial class SaveData
	{
		private static unsafe void I_LibCarParts(Database.Underground2 db, System.IO.BinaryWriter bw)
		{
			int strsize = 0;
			int libsize = 0x58;
			int padding = 0;

			foreach (var car in db.CarTypeInfos.Classes.Values)
				strsize += car.CollectionName.Length + car.UsesCarPartsOf.Length + 2;

			padding = 0x10 - ((strsize + libsize) % 0x10);
			if (padding == 0x10) padding = 0;
			libsize += strsize + padding;

			var mw = new Utils.MemoryWriter(libsize);
			mw.Write(0);
			mw.Write(libsize - 8);
			mw.Write(Reflection.ID.Global.GlobalLib);
			mw.Position = 0x10;
			mw.WriteNullTerminated("GlobalLib by MaxHwoy " + System.DateTime.Today.ToString("dd-MM-yyyy"), 0x20);
			mw.WriteNullTerminated("CarParts Block", 0x20);
			mw.Write(db.CarTypeInfos.Length);
			mw.Write(strsize);
			foreach (var car in db.CarTypeInfos.Classes.Values)
			{
				mw.WriteNullTerminated(car.CollectionName);
				mw.WriteNullTerminated(car.UsesCarPartsOf);
			}
			bw.Write(mw.Data);
		}
	}
}