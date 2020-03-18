namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadPartUnlockables(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[11] == -1) return; // if part unlocks block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[11]) != Reflection.ID.GCareerInfo.PART_UNLOCKS_BLOCK)
				return; // check part unlocks block ID

			int size = *(int*)(byteptr_t + PartOffsets[11] + 4) / 0x28;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[11] + a1 * 0x28 + 8;
				var Class = new Gameplay.PartUnlockable(byteptr_t + ptr_header, db);
				db.PartUnlockables.Classes.Add(Class);
			}
		}
	}
}