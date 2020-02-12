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
				string CName = Utils.ScriptX.NullTerminatedString(byteptr_t + offset, size - offset);
				if (CName == null) { offset += 1; continue; }
				uint key = Utils.Vlt.Hash(CName);
				Core.Map.VltKeys[key] = CName;
				offset += CName.Length + 1;
			}
		}
	}
}