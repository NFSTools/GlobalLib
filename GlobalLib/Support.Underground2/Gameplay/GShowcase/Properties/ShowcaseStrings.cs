using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GShowcase
	{
		private string _desc_string_label = BaseArguments.NULL;
		private string _destination_point = BaseArguments.NULL;
		private string _desc_attrib = BaseArguments.NULL;

		[AccessModifiable()]
		public string DescStringLabel
		{
			get => this._desc_string_label;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._desc_string_label = value;
			}
		}

		[AccessModifiable()]
		public string DestinationPoint
		{
			get => this._destination_point;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._destination_point = value;
			}
		}

		[AccessModifiable()]
		public string DescAttrib
		{
			get => this._desc_attrib;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._desc_attrib = value;
			}
		}

		[AccessModifiable()]
		public byte Unknown0x34 { get; set; }
		
		[AccessModifiable()]
		public byte Unknown0x35 { get; set; }
	}
}