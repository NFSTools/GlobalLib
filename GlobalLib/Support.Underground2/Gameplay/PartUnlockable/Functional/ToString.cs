namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				$"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}