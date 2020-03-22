namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private string _desc_string_label = Reflection.BaseArguments.NULL;
		private string _destination_point = Reflection.BaseArguments.NULL;
		private string _desc_attrib = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string DescStringLabel
		{
			get => this._desc_string_label;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._desc_string_label = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string DestinationPoint
		{
			get => this._destination_point;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._destination_point = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string DescAttrib
		{
			get => this._desc_attrib;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._desc_attrib = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public byte Unknown0x34 { get; set; }
		
		[Reflection.Attributes.AccessModifiable()]
		public byte Unknown0x35 { get; set; }
	}
}