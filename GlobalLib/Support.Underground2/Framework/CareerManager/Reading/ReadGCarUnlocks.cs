namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadGCarUnlocks(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[13] == -1) return; // if car unlocks block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[13]) != Reflection.ID.CareerInfo.CAR_UNLOCKS_BLOCK)
				return; // check car unlocks block ID

			int size = *(int*)(byteptr_t + PartOffsets[13] + 4) / 0xC;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[13] + a1 * 0xC + 8;
				var Class = new Gameplay.GCarUnlock(byteptr_t + ptr_header, db);
				db.GCarUnlocks.Classes[Class.CollectionName] = Class;
			}
		}
	}
}