using System.Collections.Generic;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
		public unsafe byte[] GetCarSkins(int index = 0xFF)
		{
			// Precalculate size of the array first
			var skinsused = new List<byte>();
			if (this.AvailableSkinNumbers01 > 0) skinsused.Add(1);
			if (this.AvailableSkinNumbers02 > 0) skinsused.Add(2);
			if (this.AvailableSkinNumbers03 > 0) skinsused.Add(3);
			if (this.AvailableSkinNumbers04 > 0) skinsused.Add(4);
			if (this.AvailableSkinNumbers05 > 0) skinsused.Add(5);
			if (this.AvailableSkinNumbers06 > 0) skinsused.Add(6);
			if (this.AvailableSkinNumbers07 > 0) skinsused.Add(7);
			if (this.AvailableSkinNumbers08 > 0) skinsused.Add(8);
			if (this.AvailableSkinNumbers09 > 0) skinsused.Add(9);
			if (this.AvailableSkinNumbers10 > 0) skinsused.Add(10);
			if (skinsused.Count == 0) return null;

			var result = new byte[0x40 * skinsused.Count];
			fixed (byte* byteptr_t = &result[0])
			{
				int offset = 0;
				for (int a1 = 0; a1 < skinsused.Count; ++a1)
				{
					switch (skinsused[a1])
					{
						case 1:
							this.CARSKIN01.Write(byteptr_t + offset, index, 1);
							goto default;
						case 2:
							this.CARSKIN02.Write(byteptr_t + offset, index, 2);
							goto default;
						case 3:
							this.CARSKIN03.Write(byteptr_t + offset, index, 3);
							goto default;
						case 4:
							this.CARSKIN04.Write(byteptr_t + offset, index, 4);
							goto default;
						case 5:
							this.CARSKIN05.Write(byteptr_t + offset, index, 5);
							goto default;
						case 6:
							this.CARSKIN06.Write(byteptr_t + offset, index, 6);
							goto default;
						case 7:
							this.CARSKIN07.Write(byteptr_t + offset, index, 7);
							goto default;
						case 8:
							this.CARSKIN08.Write(byteptr_t + offset, index, 8);
							goto default;
						case 9:
							this.CARSKIN09.Write(byteptr_t + offset, index, 9);
							goto default;
						case 10:
							this.CARSKIN10.Write(byteptr_t + offset, index, 10);
							goto default;
						default:
							offset += 0x40;
							break;
					}
				}
			}
			return result;
		}
	}
}