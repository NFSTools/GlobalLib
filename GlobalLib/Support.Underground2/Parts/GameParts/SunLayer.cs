namespace GlobalLib.Support.Underground2.Parts.GameParts
{
	public class SunLayer : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<SunLayer>
	{
		/* 0x0000 */ public int SunTextureType { get; set; }
		/* 0x0004 */ public int SunAlphaType { get; set; }
		/* 0x0008 */ public float IntensityScale { get; set; }
		/* 0x000C */ public float Size { get; set; }
		/* 0x0010 */ public float OffsetX { get; set; }
		/* 0x0014 */ public float OffsetY { get; set; }
		/* 0x0018 */ public byte ColorAlpha { get; set; }
		/* 0x0019 */ public byte ColorRed { get; set; }
		/* 0x001A */ public byte ColorGreen { get; set; }
		/* 0x001B */ public byte ColorBlue { get; set; }
		/* 0x001C */ public int Angle { get; set; }
		/* 0x0020 */ public float SweepAngleAmount { get; set; }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public SunLayer PlainCopy()
		{
			var result = new SunLayer();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisProperty in ThisType.GetProperties())
			{
				var ResultField = ResultType.GetProperty(ThisProperty.Name);
				ResultField.SetValue(result, ThisProperty.GetValue(this));
			}
			return result;
		}

		public unsafe void Read(byte* byteptr_t)
		{
			this.SunTextureType = *(int*)byteptr_t;
			this.SunAlphaType = *(int*)(byteptr_t + 4);
			this.IntensityScale = *(float*)(byteptr_t + 8);
			this.Size = *(float*)(byteptr_t + 0xC);
			this.OffsetX = *(float*)(byteptr_t + 0x10);
			this.OffsetY = *(float*)(byteptr_t + 0x14);
			this.ColorAlpha = *(byteptr_t + 0x18);
			this.ColorRed = *(byteptr_t + 0x19);
			this.ColorGreen = *(byteptr_t + 0x1A);
			this.ColorBlue = *(byteptr_t + 0x1B);
			this.Angle = *(int*)(byteptr_t + 0x1C);
			this.SweepAngleAmount = *(float*)(byteptr_t + 0x20);
		}

		public unsafe void Write(byte* byteptr_t)
		{
			*(int*)byteptr_t = this.SunTextureType;
			*(int*)(byteptr_t + 4) = this.SunAlphaType;
			*(float*)(byteptr_t + 8) = this.IntensityScale;
			*(float*)(byteptr_t + 0xC) = this.Size;
			*(float*)(byteptr_t + 0x10) = this.OffsetX;
			*(float*)(byteptr_t + 0x14) = this.OffsetY;
			*(byteptr_t + 0x18) = this.ColorAlpha;
			*(byteptr_t + 0x19) = this.ColorRed;
			*(byteptr_t + 0x1A) = this.ColorGreen;
			*(byteptr_t + 0x1B) = this.ColorBlue;
			*(int*)(byteptr_t + 0x1C) = this.Angle;
			*(float*)(byteptr_t + 0x20) = this.SweepAngleAmount;
		}
	}
}
