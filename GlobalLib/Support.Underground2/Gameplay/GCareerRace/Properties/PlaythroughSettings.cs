namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		private string _gps_destination = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string IntroMovie { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string OutroMovie { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public byte NumMapItems { get; set; }

		public byte Unknown0x3A { get; set; }
		public byte Unknown0x3B { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string GPSDestination
		{
			get => this._gps_destination;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._gps_destination = value;
			}
		}
	}
}