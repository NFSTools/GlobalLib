﻿namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string _window_tint_type = Reflection.BaseArguments.STOCK;

		[Reflection.Attributes.AccessModifiable()]
		public string WindowTintType
		{
			get => this._window_tint_type;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value == Reflection.BaseArguments.STOCK || Core.Map.WindowTintMap.Contains(value))
					this._window_tint_type = value;
				else
					throw new Reflection.Exception.MappingFailException("This value should be either a valid windshield type, or STOCK.");
				this.Modified = true;
			}
		}
	}
}