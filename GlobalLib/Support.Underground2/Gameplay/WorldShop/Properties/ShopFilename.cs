namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		private string _shop_filename;

		[Reflection.Attributes.AccessModifiable()]
		public string ShopFilename
		{
			get => this._shop_filename;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value.Length > 0xF)
					throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
				string filepath = $"{Core.Process.GlobalDir}\\FRONTEND\\PLATFORMS\\{value}.BIN";
				if (!System.IO.File.Exists(filepath))
					throw new System.IO.FileNotFoundException($"File named {filepath} does not exist.");
				this._shop_filename = value;
			}
		}
	}
}