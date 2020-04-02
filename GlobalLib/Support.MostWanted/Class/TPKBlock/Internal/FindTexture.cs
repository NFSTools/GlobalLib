namespace GlobalLib.Support.MostWanted.Class
{
	public partial class TPKBlock
	{
		public Texture FindTexture(string CName)
		{
			return this.Textures.Find(t => t.CollectionName == CName);
		}

		public Texture FindTexture(uint key, Database.Collection.eKeyType type)
		{
			switch (type)
			{
				case GlobalLib.Database.Collection.eKeyType.BINKEY:
					return this.Textures.Find(t => t.BinKey == key);
				case GlobalLib.Database.Collection.eKeyType.VLTKEY:
					return this.Textures.Find(t => t.VltKey == key);
				case GlobalLib.Database.Collection.eKeyType.CUSTOM:
					throw new System.NotImplementedException();
				default:
					return null;
			}
		}
	}
}
