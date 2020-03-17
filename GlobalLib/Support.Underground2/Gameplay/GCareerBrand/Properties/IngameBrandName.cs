namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand
	{
		private string _ingame_brand_name = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string IngameBrandName
		{
			get => this._ingame_brand_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._ingame_brand_name = value;
			}
		}
	}
}