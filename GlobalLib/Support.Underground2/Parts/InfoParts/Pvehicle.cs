namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Pvehicle : VirtualBase, Reflection.Interface.ICopyable<Pvehicle>
	{
		/* 0x0220 */ public float Massx1000Multiplier { get; set; }
        /* 0x0224 */ public float TensorScaleX { get; set; }
        /* 0x0228 */ public float TensorScaleY { get; set; }
        /* 0x022C */ public float TensorScaleZ { get; set; }
        /* 0x0230 */ public float TensorScaleW { get; set; }
        /* 0x0270 */ public float InitialHandlingRating { get; set; }
        /* 0x0370 */ public float TopSpeedUnderflow { get; set; }
        /* 0x03A0 */ public float StockTopSpeedLimiter { get; set; }

        public Pvehicle() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Pvehicle PlainCopy()
        {
            var result = new Pvehicle();
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
