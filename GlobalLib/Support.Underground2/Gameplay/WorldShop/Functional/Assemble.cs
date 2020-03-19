namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		public unsafe void Assemble(byte* byteptr_t, Utils.MemoryWriter mw)
		{
			mw.WriteNullTerminated(this._collection_name);
			mw.WriteNullTerminated(this._shop_filename);

			for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
				*(byteptr_t + a1) = (byte)this._collection_name[a1];

			if (!string.IsNullOrWhiteSpace(this.IntroMovie))
			{
				mw.WriteNullTerminated(this.IntroMovie);
				for (int a1 = 0; a1 < this.IntroMovie.Length; ++a1)
					*(byteptr_t + 0x20 + a1) = (byte)this.IntroMovie[a1];
			}

			*(uint*)(byteptr_t + 0x38) = this.BinKey;
			*(uint*)(byteptr_t + 0x3C) = Utils.Bin.SmartHash(this.ShopTrigger);

			for (int a1 = 0; a1 < this._shop_filename.Length; ++a1)
				*(byteptr_t + 0x40 + a1) = (byte)this._shop_filename[a1];

			*(byteptr_t + 0x50) = (byte)this.ShopType;
			*(byteptr_t + 0x51) = (this.InitiallyHidden == Reflection.Enum.eBoolean.True) ? (byte)1 : (byte)0;
			*(uint*)(byteptr_t + 0x74) = Utils.Bin.SmartHash(this.EventToBeCompleted);
			*(byteptr_t + 0x9C) = (byte)this.RequiresEventCompleted;
			*(byteptr_t + 0x9D) = this.BelongsToStage;
		}
	}
}