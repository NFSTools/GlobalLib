namespace GlobalLib.Support.Carbon.Class
{
	public partial class TPKBlock
	{
		/// <summary>
		/// Tries to find texture based on the key passed.
		/// </summary>
		/// <param name="key">Key of the texture's CollectionName.</param>
		/// <param name="type">Type of the key passed.</param>
		/// <returns>Texture if it is found; null otherwise.</returns>
		public override Shared.Class.Texture FindTexture(uint key, Database.Collection.eKeyType type)
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
