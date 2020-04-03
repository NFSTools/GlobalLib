﻿namespace GlobalLib.Support.Shared.Parts.STRParts
{
	public class StringRecord
	{
		public uint Key { get; set; }
		public string Label { get; set; }
		public string Text { get; set; }
		public int NulledLabelLength { get => (this.Label == null) ? 0 : this.Label.Length + 1; }
		public int NulledTextLength { get => (this.Text == null) ? 0 : this.Text.Length + 1; }

		public System.Collections.Generic.List<StringRecord> ThisList { get; set; }

		// Default constructor: make label empty
		public StringRecord(System.Collections.Generic.List<StringRecord> thislist)
		{
			this.Label = string.Empty;
			this.ThisList = thislist;
		}

		public override bool Equals(object obj)
		{
			return obj is StringRecord && this == (StringRecord)obj;
		}

		public override int GetHashCode()
		{
			return System.Tuple.Create(this.Key, this.Label ?? string.Empty, this.Text ?? string.Empty).GetHashCode();
		}

		public static bool operator== (StringRecord s1, StringRecord s2)
		{
			return s1.Key == s2.Key || s1.Label == s2.Label;
		}

		public static bool operator!= (StringRecord s1, StringRecord s2)
		{
			return !(s1 == s2);
		}

		public override string ToString()
		{
			return $"BinKey: {this.Key.ToString("X8")} | Label: {this.Label} | Text: {this.Text}";
		}
	}
}