namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadSponsors(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[7] == -1) return; // if sponsors block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[7]) != Reflection.ID.GCareerInfo.SPONSOR_BLOCK)
				return; // check sponsors block ID

			int size = *(int*)(byteptr_t + PartOffsets[7] + 4) / 0x10;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[7] + a1 * 0x10 + 8;
				var Class = new Gameplay.Sponsor(byteptr_t + ptr_header, byteptr_t + ptr_string, db);
				db.Sponsors.Classes.Add(Class);
			}
		}
	}
}