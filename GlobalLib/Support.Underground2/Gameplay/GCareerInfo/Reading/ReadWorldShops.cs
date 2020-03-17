namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadWorldShops(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[2] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[2]) != Reflection.ID.GCareerInfo.SHOP_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[2] + 4) / 0xA0;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_header = PartOffsets[2] + a1 * 0xA0 + 8;
				var Class = new WorldShop(byteptr_t + ptr_header, this.Database);
				this.Database.WorldShops.Classes.Add(Class);
			}
		}
	}
}