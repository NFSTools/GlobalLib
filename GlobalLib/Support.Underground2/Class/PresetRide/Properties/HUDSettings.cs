using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string _custom_hud_style = BaseArguments.STOCK;
		private string _hud_backing_color = BaseArguments.WHITE;
		private string _hud_needle_color = BaseArguments.WHITE;
		private string _hud_character_color = BaseArguments.WHITE;

		[AccessModifiable()]
		[StaticModifiable()]
		public string CustomHUDStyle
		{
			get => this._custom_hud_style;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (!Map.BinKeys.ContainsValue(value))
					throw new MappingFailException();
				this._custom_hud_style = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string HUDBackingColor
		{
			get => this._hud_backing_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (!Map.BinKeys.ContainsValue(value))
					throw new MappingFailException();
				this._hud_backing_color = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string HUDNeedleColor
		{
			get => this._hud_needle_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (!Map.BinKeys.ContainsValue(value))
					throw new MappingFailException();
				this._hud_needle_color = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string HUDCharacterColor
		{
			get => this._hud_character_color;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (!Map.BinKeys.ContainsValue(value))
					throw new MappingFailException();
				this._hud_character_color = value;
				this.Modified = true;
			}
		}
	}
}