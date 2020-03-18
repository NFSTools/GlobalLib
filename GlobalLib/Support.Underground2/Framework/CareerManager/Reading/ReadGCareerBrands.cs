namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadGCareerBrands(byte* byteptr_t, int[] PartOffsets, Database.Underground2 db)
		{
			if (PartOffsets[3] == -1) return; // if career brands block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[3]) != Reflection.ID.GCareerInfo.BRAND_BLOCK)
				return; // check career brands block ID

			int size = *(int*)(byteptr_t + PartOffsets[3] + 4) / 0x44;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[3] + a1 * 0x44 + 8;
				var Class = new Gameplay.GCareerBrand(byteptr_t + ptr_header, db);
				db.GCareerBrands.Classes.Add(Class);
			}
		}
	}
}