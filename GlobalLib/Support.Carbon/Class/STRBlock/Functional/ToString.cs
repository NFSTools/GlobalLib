namespace GlobalLib.Support.Carbon.Class
{
	public partial class STRBlock : Shared.Class.STRBlock
	{
		public override string ToString()
		{
			return $"Count = {this.InfoLength.ToString()}";
		}
	}
}