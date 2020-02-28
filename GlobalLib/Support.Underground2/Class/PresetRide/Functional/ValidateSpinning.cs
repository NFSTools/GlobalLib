namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
		private bool ValidateSpinning()
		{
			string rim = $"{this._rim_brand}_STYLE";
			rim += (this._rim_style < 10) ? "0" + this._rim_style.ToString() : this._rim_style.ToString();
			rim += $"_{this._rim_size.ToString()}_{this._rim_outer_max.ToString()}_SPI";
			foreach (var str in Core.Map.RimBrands)
			{
				if (rim == str)
					return true;
			}
			return false;
		}
	}
}