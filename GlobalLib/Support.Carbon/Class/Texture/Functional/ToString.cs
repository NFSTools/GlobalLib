namespace GlobalLib.Support.Carbon.Class
{
	public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}