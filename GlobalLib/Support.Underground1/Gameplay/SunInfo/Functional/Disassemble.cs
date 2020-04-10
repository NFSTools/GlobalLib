namespace GlobalLib.Support.Underground1.Gameplay
{
	public partial class SunInfo
	{
		/// <summary>
		/// Disassembles suninfo block into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the suninfo block.</param
		protected unsafe void Disassemble(byte* byteptr_t)
		{
			this.Version = *(int*)byteptr_t;
			this.PositionX = *(float*)(byteptr_t + 0x20);
			this.PositionY = *(float*)(byteptr_t + 0x24);
			this.PositionZ = *(float*)(byteptr_t + 0x28);
			this.CarShadowPositionX = *(float*)(byteptr_t + 0x2C);
			this.CarShadowPositionY = *(float*)(byteptr_t + 0x30);
			this.CarShadowPositionZ = *(float*)(byteptr_t + 0x34);
			this.SUNLAYER1.Read(byteptr_t + 0x38 + 0x24 * 0);
			this.SUNLAYER2.Read(byteptr_t + 0x38 + 0x24 * 1);
			this.SUNLAYER3.Read(byteptr_t + 0x38 + 0x24 * 2);
			this.SUNLAYER4.Read(byteptr_t + 0x38 + 0x24 * 3);
			this.SUNLAYER5.Read(byteptr_t + 0x38 + 0x24 * 4);
			this.SUNLAYER6.Read(byteptr_t + 0x38 + 0x24 * 5);
		}
	}
}