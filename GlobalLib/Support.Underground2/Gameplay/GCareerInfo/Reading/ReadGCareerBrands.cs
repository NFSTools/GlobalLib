namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadGCareerBrands(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[3] == -1) return; // if career brands block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[3]) != Reflection.ID.GCareerInfo.BRAND_BLOCK)
				return; // check career brands block ID

			int size = *(int*)(byteptr_t + PartOffsets[3] + 4) / 0x44;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[3] + a1 * 0x44 + 8;
				var Class = new GCareerBrand(byteptr_t + ptr_header, this.Database);
				this.Database.GCareerBrands.Classes.Add(Class);
			}
		}
	}
}