namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		/// <summary>
		/// Assembles material into a byte array.
		/// </summary>
		/// <returns>Byte array of the material.</returns>
		public unsafe byte[] Assemble()
		{
			var result = new byte[0x110];
			fixed (byte* byteptr_t = &result[0])
			{
				*(int*)byteptr_t = this.Version;
				*(uint*)(byteptr_t + 4) = this.BinKey;

				for (int a1 = 0; a1 < this._collection_name.Length; ++a1)
					*(byteptr_t + 8 + a1) = (byte)this._collection_name[a1];

				*(float*)(byteptr_t + 0x20) = this.PositionX;
				*(float*)(byteptr_t + 0x24) = this.PositionY;
				*(float*)(byteptr_t + 0x28) = this.PositionZ;
				*(float*)(byteptr_t + 0x2C) = this.CarShadowPositionX;
				*(float*)(byteptr_t + 0x30) = this.CarShadowPositionY;
				*(float*)(byteptr_t + 0x34) = this.CarShadowPositionZ;
				this.SUNLAYER1.Write(byteptr_t + 0x38 + 0x24 * 0);
				this.SUNLAYER2.Write(byteptr_t + 0x38 + 0x24 * 1);
				this.SUNLAYER3.Write(byteptr_t + 0x38 + 0x24 * 2);
				this.SUNLAYER4.Write(byteptr_t + 0x38 + 0x24 * 3);
				this.SUNLAYER5.Write(byteptr_t + 0x38 + 0x24 * 4);
				this.SUNLAYER6.Write(byteptr_t + 0x38 + 0x24 * 5);
			}
			return result;
		}
	}
}