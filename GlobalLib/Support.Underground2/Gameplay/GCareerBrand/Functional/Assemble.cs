using GlobalLib.Reflection;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand
	{
		public unsafe void Assemble(byte* byteptr_t, MemoryWriter mw)
		{
			mw.WriteNullTerminated(this._collection_name);

			for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
				*(byteptr_t + a1) = (byte)this._collection_name[a1];

			if (this._ingame_brand_name != BaseArguments.NULL)
			{
				for (int a1 = 0; a1 < this._ingame_brand_name.Length; ++a1)
					*(byteptr_t + 0x20 + a1) = (byte)this._ingame_brand_name[a1];
			}

			*(uint*)(byteptr_t + 0x40) = this.BinKey;
		}
	}
}