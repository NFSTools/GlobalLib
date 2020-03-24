namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadGCareerRaces(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[1] == -1) return; // if career races block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[1]) != Reflection.ID.CareerInfo.EVENT_BLOCK)
				return; // check career races block ID

			int size = *(int*)(byteptr_t + PartOffsets[1] + 4) / 0x88;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[1] + a1 * 0x88 + 8;
				var Class = new Gameplay.GCareerRace(byteptr_t + ptr_header, byteptr_t + ptr_string, db);
				db.GCareerRaces.Classes[Class.CollectionName] = Class;
			}
		}
	}
}