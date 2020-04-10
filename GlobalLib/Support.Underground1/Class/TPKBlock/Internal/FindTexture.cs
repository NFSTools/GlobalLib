namespace GlobalLib.Support.Underground1.Class
{
	public partial class TPKBlock
	{
		/// <summary>
		/// Tries to find <see cref="Texture"/> based on the key passed.
		/// </summary>
		/// <param name="key">Key of the <see cref="Texture"/> Collection Name.</param>
		/// <param name="type">Type of the key passed.</param>
		/// <returns>Texture if it is found; null otherwise.</returns>
		public override Shared.Class.Texture FindTexture(uint key, Reflection.Enum.eKeyType type)
		{
			switch (type)
			{
				case Reflection.Enum.eKeyType.BINKEY:
					return this.Textures.Find(t => t.BinKey == key);
				case Reflection.Enum.eKeyType.VLTKEY:
					return this.Textures.Find(t => t.VltKey == key);
				case Reflection.Enum.eKeyType.CUSTOM:
					throw new System.NotImplementedException();
				default:
					return null;
			}
		}
	}
}
