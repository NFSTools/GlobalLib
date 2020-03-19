namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		public static unsafe byte[] Assemble(Database.Underground2 db)
		{
			// Initialize MemoryWriter for string block to its maximum size
			var mw = new Utils.MemoryWriter(0xFFFF);
			mw.Write((byte)0); // write null-termination

			// Get arrays of all blocks
			var EventBlock = WriteGCareerRaces(mw, db);


			return null;
		}
	}
}