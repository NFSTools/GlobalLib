namespace GlobalLib.Support.Shared.Parts.STRParts
{
	public class StringRecord
	{
		public uint Key { get; set; }
		public string Label { get; set; }
		public string Text { get; set; }
		public int NulledLabelLength { get => (this.Label == null) ? 0 : this.Label.Length + 1; }
		public int NulledTextLength { get => (this.Text == null) ? 0 : this.Text.Length + 1; }

		// Default constructor: make label empty
		public StringRecord() { this.Label = string.Empty; }

		public override string ToString()
		{
			return $"BinKey: {this.Key.ToString("X8")} | Text: {this.Text}";
		}
	}
}