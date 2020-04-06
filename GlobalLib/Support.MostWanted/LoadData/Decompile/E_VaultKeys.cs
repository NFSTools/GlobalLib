using GlobalLib.Core;
using GlobalLib.Utils;

namespace GlobalLib.Support.MostWanted
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
				string CName = ScriptX.NullTerminatedString(byteptr_t + offset, size - offset);
				if (CName == null) { offset += 1; continue; }
				uint key = Vlt.Hash(CName);
				Map.VltKeys[key] = CName;
				offset += CName.Length + 1;
			}
		}
	}
}