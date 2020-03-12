namespace GlobalLib.Support.Underground2.Parts.GameParts
{
	public class Opponent : Framework.VirtualPart, Reflection.Interface.ICopyable<Opponent>
	{
		public string Name { get; set; } = string.Empty;
		public ushort StatsMultiplier { get; set; }
		public string PresetRide { get; set; } = Reflection.BaseArguments.RANDOM;
		public byte SkillEasy { get; set; }
		public byte SkillMedium { get; set; }
		public byte SkillHard { get; set; }
		public byte CatchUp { get; set; }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Opponent PlainCopy()
		{
			var result = new Opponent();
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
