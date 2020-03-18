namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		public unsafe byte[] Assemble()
		{
			var result = new byte[0xC];
			fixed (byte* byteptr_t = &result[0])
			{
				*(uint*)byteptr_t = this.BinKey;
				if (this._req_event_completed1 != Reflection.BaseArguments.NULL)
					*(uint*)(byteptr_t + 4) = Utils.Bin.Hash(this._req_event_completed1);
				if (this._req_event_completed2 != Reflection.BaseArguments.NULL)
					*(uint*)(byteptr_t + 8) = Utils.Bin.Hash(this._req_event_completed2);
			}
			return result;
		}
	}
}