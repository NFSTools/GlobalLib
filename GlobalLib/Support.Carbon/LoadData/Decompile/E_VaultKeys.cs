namespace GlobalLib.Support.Carbon
{
	public static partial class LoadData
	{
		private static unsafe void E_VaultKeys(byte* byteptr_t)
		{
			uint ID = *(uint*)byteptr_t;
			int size = *(int*)(byteptr_t + 4) + 8;
			if (ID != 0x53747245) return;

			int offset = 8;
			while (offset < size)
			{
				string CName = "";
				for (int a1 = offset; *(byteptr_t + a1) != 0 && a1 < size; ++a1)
					CName += ((char)*(byteptr_t + a1)).ToString();
				uint key = Utils.Vlt.Hash(CName);
				Core.Map.VltKeys[key] = CName;
				offset += CName.Length + 1;
			}
		}
	}
}