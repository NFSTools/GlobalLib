namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			*(uint*)byteptr_t = Utils.Bin.SmartHash(this._collection_name);
			*(uint*)(byteptr_t + 4) = Utils.Bin.SmartHash(this._req_event_completed1);
			*(uint*)(byteptr_t + 8) = Utils.Bin.SmartHash(this._req_event_completed2);
		}
	}
}