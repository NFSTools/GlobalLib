namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string _custom_hud_style = Reflection.BaseArguments.STOCK;
		private string _hud_backing_color = Reflection.BaseArguments.WHITE;
		private string _hud_needle_color = Reflection.BaseArguments.WHITE;
		private string _hud_character_color = Reflection.BaseArguments.WHITE;

		[Reflection.Attributes.AccessModifiable()]
		public string CustomHUDStyle
		{
			get => this._custom_hud_style;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (!Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				this._custom_hud_style = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string HUDBackingColor
		{
			get => this._hud_backing_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (!Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				this._hud_backing_color = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string HUDNeedleColor
		{
			get => this._hud_needle_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (!Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				this._hud_needle_color = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string HUDCharacterColor
		{
			get => this._hud_character_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (!Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				this._hud_character_color = value;
				this.Modified = true;
			}
		}
	}
}