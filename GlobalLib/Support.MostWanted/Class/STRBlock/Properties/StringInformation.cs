using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.STRParts;



namespace GlobalLib.Support.MostWanted.Class
{
	public partial class STRBlock : Shared.Class.STRBlock
	{
		private List<StringRecord> _stringinfo = new List<StringRecord>();

		/// <summary>
		/// Length of the string information array.
		/// </summary>
		public int InfoLength { get => this._stringinfo.Count; }

		/// <summary>
		/// Gets text from the binary key of a label provided.
		/// </summary>
		/// <param name="key">Key of the string label.</param>
		/// <returns>Text of the label as a string.</returns>
		public string GetText(uint key)
		{
			for (int a1 = 0; a1 < this._stringinfo.Count; ++a1)
			{
				if (key == this._stringinfo[a1].Key)
					return this._stringinfo[a1].Text;
			}
			return string.Empty;
		}
	
		/// <summary>
		/// Attepts to set text and its label in the string information array.
		/// </summary>
		/// <param name="label">Label of the text.</param>
		/// <param name="text">Text to be set.</param>
		/// <returns>True if label is unique, false otherwise.</returns>
		public bool SetText(string label, string text)
		{
			if (string.IsNullOrEmpty(label))
				return false;
			var key = Utils.Bin.Hash(label);
			foreach (var str in this._stringinfo)
			{
				if (key == str.Key || label == str.Label)
					return false;
			}

			var info = new StringRecord();
			info.Key = key;
			info.Label = label;
			info.Text = text;
			this._stringinfo.Add(info);
			return true;
		}
	}
}