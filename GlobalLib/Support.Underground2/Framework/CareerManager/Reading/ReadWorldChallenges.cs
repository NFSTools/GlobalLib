namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadWorldChallenges(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[10] == -1) return; // if world challenges block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[10]) != Reflection.ID.GCareerInfo.WORLD_CHAL_BLOCK)
				return; // check world challenges block ID

			int size = *(int*)(byteptr_t + PartOffsets[10] + 4) / 0x18;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[10] + a1 * 0x18 + 8;
				var Class = new Gameplay.WorldChallenge(byteptr_t + ptr_header, byteptr_t + ptr_string, db);
				db.WorldChallenges.Classes.Add(Class);
			}
		}
	}
}