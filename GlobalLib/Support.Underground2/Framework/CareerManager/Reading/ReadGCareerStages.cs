namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadGCareerStages(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[8] == -1) return; // if career stages block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[8]) != Reflection.ID.CareerInfo.STAGE_BLOCK)
				return; // check career stages block ID

			int size = *(int*)(byteptr_t + PartOffsets[8] + 4) / 0x50;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[8] + a1 * 0x50 + 8;
				var Class = new Gameplay.GCareerStage(byteptr_t + ptr_header, db);
				db.GCareerStages.Classes[Class.CollectionName] = Class;
			}
		}
	}
}