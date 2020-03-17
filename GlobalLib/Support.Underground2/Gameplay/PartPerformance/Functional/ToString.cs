namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public override string ToString()
		{
			string resolvedstr = Core.Map.Lookup(this.BinKey) ?? this._collection_name;
			return $"Collection Name: {resolvedstr} | " +
				$"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}