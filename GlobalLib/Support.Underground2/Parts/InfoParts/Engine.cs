namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
	public class Engine : VirtualBase, Reflection.Interface.ICopyable<Engine>
	{
		public float SpeedRefreshRate { get; set; }
		public float EngineTorque1 { get; set; }
		public float EngineTorque2 { get; set; }
		public float EngineTorque3 { get; set; }
		public float EngineTorque4 { get; set; }
		public float EngineTorque5 { get; set; }
		public float EngineTorque6 { get; set; }
		public float EngineTorque7 { get; set; }
		public float EngineTorque8 { get; set; }
		public float EngineTorque9 { get; set; }
		public float EngineBraking1 { get; set; }
		public float EngineBraking2 { get; set; }
		public float EngineBraking3 { get; set; }

		public Engine() { }

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Engine PlainCopy()
		{
			var result = new Engine();
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
