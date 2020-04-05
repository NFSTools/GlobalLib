using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerBrand
	{
		private string _ingame_brand_name = BaseArguments.NULL;

		[AccessModifiable()]
		public string IngameBrandName
		{
			get => this._ingame_brand_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value.Length > 0x1F)
					throw new ArgumentLengthException("Length of the value should not exceed 31 character.");
				this._ingame_brand_name = value;
			}
		}
	}
}