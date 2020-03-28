namespace GlobalLib.Support.Underground2
{
	public partial class SaveData
	{
		private static byte[] I_LibCarParts(Database.Underground2 db)
		{
			int strsize = 0;
			int libsize = 0x58;
			int padding = 0;

			foreach (var car in db.CarTypeInfos.Collections)
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
			foreach (var car in db.CarTypeInfos.Collections)
			{
				mw.WriteNullTerminated(car.CollectionName);
				mw.WriteNullTerminated(car.UsesCarPartsOf);
			}
			return mw.Data;
		}
	}
}