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

				default:
					return;
			}
		}
	}
}