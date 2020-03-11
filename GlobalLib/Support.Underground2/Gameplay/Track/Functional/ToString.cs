namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"TrackID: {this.TrackID:0000} | Game: {this.GameSTR}";
		}
	}
}