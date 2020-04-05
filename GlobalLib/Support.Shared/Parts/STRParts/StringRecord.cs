using System;
using GlobalLib.Utils;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Shared.Class;



namespace GlobalLib.Support.Shared.Parts.STRParts
{
	public class StringRecord : SubPart
	{
		public uint Key { get; set; }
		public string Label { get; set; }
		public string Text { get; set; }
		public int NulledLabelLength { get => (this.Label == null) ? 0 : this.Label.Length + 1; }
		public int NulledTextLength { get => (this.Text == null) ? 0 : this.Text.Length + 1; }
		public const string key = "Key";
		public const string label = "Label";
		public const string text = "Text";

		public STRBlock ThisSTRBlock { get; set; }

		// Default constructor: make label empty
		public StringRecord(STRBlock block)
		{
			this.Label = string.Empty;
			this.ThisSTRBlock = block;
		}

		public override bool Equals(object obj)
		{
			return obj is StringRecord && this == (StringRecord)obj;
		}

		public override int GetHashCode()
		{
			return Tuple.Create(this.Key, this.Label ?? string.Empty, this.Text ?? string.Empty).GetHashCode();
		}

		public static bool operator== (StringRecord s1, StringRecord s2)
		{
			if (ReferenceEquals(s1, null)) return ReferenceEquals(s2, null);
			else if (ReferenceEquals(s2, null)) return false;
			else return s1.Key == s2.Key;
		}

		public static bool operator!= (StringRecord s1, StringRecord s2)
		{
			return !(s1 == s2);
		}

		public override string ToString()
		{
			return $"Bin{key}: {this.Key.ToString("X8")} | {label}: {this.Label} | {text}: {this.Text}";
		}

		public bool TrySetValue(string PropertyName, string value)
		{
			switch (PropertyName)
			{
				case key:
					var hash = ConvertX.ToUInt32(value);
					if (hash == 0) return false;
					if (this.ThisSTRBlock.GetRecord(hash) != null) return false;
					this.Key = hash;
					return true;
				case label:
					this.Label = value;
					return true;
				case text:
					this.Text = value;
					return true;
				default:
					return false;
			}
		}

		public bool TrySetValue(string PropertyName, string value, out string error)
		{
			error = null;
			switch (PropertyName)
			{
				case key:
					var hash = ConvertX.ToUInt32(value);
					if (hash == 0)
					{
						error = $"Unable to convert key passed to a hex-hash, or it equals 0.";
						return false;
					}
					if (this.ThisSTRBlock.GetRecord(hash) != null)
					{
						error = $"StringRecord with key {value} already exist.";
						return false;
					}
					this.Key = hash;
					return true;
				case label:
					this.Label = value;
					return true;
				case text:
					this.Text = value;
					return true;
				default:
					error = $"Field named {PropertyName} does not exist.";
					return false;
			}
		}
	}
}