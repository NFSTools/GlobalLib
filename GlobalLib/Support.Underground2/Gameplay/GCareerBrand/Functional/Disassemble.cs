using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand
	{
		private unsafe void Disassemble(byte* byteptr_t)
		{
			// CollectionName
			this._collection_name = ScriptX.NullTerminatedString(byteptr_t, 0x20);

			// Ingame Brand Name
			this._ingame_brand_name = ScriptX.NullTerminatedString(byteptr_t + 0x20, 0x20);
		}
	}
}