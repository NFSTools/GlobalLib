using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new GCareerBrand(CName, this.Database);
			result._ingame_brand_name = this._ingame_brand_name;
			return result;
		}
	}
}