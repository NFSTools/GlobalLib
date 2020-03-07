namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Ecar : VirtualBase, Reflection.Interface.ICopyable<Ecar>
	{
		/* 0x0244 */ public float EcarUnknown1 { get; set; }
		/* 0x0258 */ public float EcarUnknown2 { get; set; }
		/* 0x0710 */ public float HandlingBuffer { get; set; }
		/* 0x0714 */ public float TopSuspFrontHeightReduce { get; set; }
		/* 0x0718 */ public float TopSuspRearHeightReduce { get; set; }
		/* 0x0720 */ public int NumPlayerCameras { get; set; }
		/* 0x0724 */ public int NumAICameras { get; set; }
        /* 0x087C */ public int Cost { get; set; }

		public Ecar() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Ecar PlainCopy()
        {
            var result = new Ecar();
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
