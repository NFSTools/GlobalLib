namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string _base_paint_type = Reflection.BaseArguments.UGPAINT;

		[Reflection.Attributes.AccessModifiable()]
		public string BasePaintType
		{
			get => this._base_paint_type;
			set
			{
				if (!Core.Map.UG2PaintTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._base_paint_type = value;
				this.Modified = true;
			}
		}
	}
}