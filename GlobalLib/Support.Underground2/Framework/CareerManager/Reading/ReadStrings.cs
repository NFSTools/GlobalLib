using GlobalLib.Reflection.ID;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		private static unsafe void ReadStrings(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[0] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[0]) != CareerInfo.STRING_BLOCK)
				return; // check strings block ID

            int ReaderSize = 8 + *(int*)(byteptr_t + PartOffsets[0] + 4);
            int current = PartOffsets[0] + 8;
            while (current < ReaderSize)
            {
                string str = ScriptX.NullTerminatedString(byteptr_t + current);
                Bin.Hash(str);
                current += str.Length + 1;
            }
        }
    }
}