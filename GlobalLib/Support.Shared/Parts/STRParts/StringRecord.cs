namespace GlobalLib.Support.Shared.Parts.STRParts
{
	public class StringRecord : Reflection.Abstract.SubPart
	{
		public uint Key { get; set; }
		public string Label { get; set; }
		public string Text { get; set; }
		public int NulledLabelLength { get => (this.Label == null) ? 0 : this.Label.Length + 1; }
		public int NulledTextLength { get => (this.Text == null) ? 0 : this.Text.Length + 1; }

		public Class.STRBlock ThisSTRBlock { get; set; }

		// Default constructor: make label empty
		public StringRecord(Class.STRBlock block)
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

		public bool TrySetValue(string PropertyName, string value)
		{
			switch (PropertyName)
			{
				case "Key":
					var hash = Utils.ConvertX.ToUInt32(value);
					if (hash == 0) return false;
					if (this.ThisSTRBlock.GetRecord(hash) != null) return false;
					this.Key = hash;
					return true;
				case "Label":
					this.Label = value;
					return true;
				case "Text":
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
				case "Key":
					var hash = Utils.ConvertX.ToUInt32(value);
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
				case "Label":
					this.Label = value;
					return true;
				case "Text":
					this.Text = value;
					return true;
				default:
					error = $"Field named {PropertyName} does not exist.";
					return false;
			}
		}
	}
}