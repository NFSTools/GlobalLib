namespace GlobalLib.Support.Underground2.Parts.GameParts
{
	public class SunLayer : Framework.VirtualPart, Reflection.Interface.ICopyable<SunLayer>
	{
		/* 0x0000 */ public Reflection.Enum.eSunTexture SunTextureType { get; set; }
		/* 0x0004 */ public Reflection.Enum.eSunAlpha SunAlphaType { get; set; }
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
	}
}
