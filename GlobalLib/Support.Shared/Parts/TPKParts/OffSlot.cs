namespace GlobalLib.Support.Shared.Parts.TPKParts
{
	public class OffSlot
	{
		public uint Key { get; set; }
		public int AbsoluteOffset { get; set; }
		public int CompressedSize { get; set; }
		public int ActualSize { get; set; }
		public int ToHeaderOffset { get; set; }
		public int UnknownInt32 { get; set; }
	}
}