namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadStrings(byte* byteptr_t, int offset)
		{
			if (offset == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + offset) != Reflection.ID.GCareerInfo.STRING_BLOCK)
				return; // check strings block ID

            int ReaderSize = 8 + *(int*)(byteptr_t + offset + 4);
            int current = offset + 8;
            while (current < ReaderSize)
            {
                string str = Utils.ScriptX.NullTerminatedString(byteptr_t + current);
                Utils.Bin.Hash(str);
                current += str.Length + 1;
            }
        }
    }
}