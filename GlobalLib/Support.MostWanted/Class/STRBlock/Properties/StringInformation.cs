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
			return null;
		}

		/// <summary>
		/// Gets string record from index provided.
		/// </summary>
		/// <param name="index">Index of the record in the array.</param>
		/// <returns>String record class.</returns>
		public StringRecord GetRecord(int index)
		{
			if (index < 0 || index >= this._stringinfo.Count) return null;
			else return this._stringinfo[index];
		}

		/// <summary>
		/// Gets string record from hash provided.
		/// </summary>
		/// <param name="key">Hash of the record in the array.</param>
		/// <returns>String record class.</returns>
		public StringRecord GetRecord(uint key)
		{
			foreach (var info in this._stringinfo)
			{
				if (key == info.Key)
					return info;
			}
			return null;
		}

		/// <summary>
		/// Removes string record at the index specified.
		/// </summary>
		/// <param name="index">Index of the record to be removed.</param>
		/// <returns>True if deleting was successful.</returns>
		public bool DeleteRecord(int index)
		{
			if (index < 0 || index >= this._stringinfo.Count) return false;
			else
			{
				this._stringinfo.RemoveAt(index);
				return true;
			}
		}

		/// <summary>
		/// Removes string record at the index specified.
		/// </summary>
		/// <param name="key">Hash of the string record to be removed.</param>
		/// <returns>True if deleting was successful.</returns>
		public bool DeleteRecord(uint key)
		{
			for (int a1 = 0; a1 < this._stringinfo.Count; ++a1)
			{
				if (key == this._stringinfo[a1].Key)
					return this.DeleteRecord(a1);
			}
			return false;
		}

		/// <summary>
		/// Attepts to add text and its label in the string information array.
		/// </summary>
		/// <param name="label">Label of the text.</param>
		/// <param name="text">Text to be set.</param>
		/// <returns>True if label and its hash are unique, false otherwise.</returns>
		public bool SetRecord(string label, string text)
		{
			if (string.IsNullOrEmpty(label))
				return false;
			var key = Utils.Bin.Hash(label);
			foreach (var str in this._stringinfo)
			{
				if (key == str.Key || label == str.Label)
					return false;
			}

			var info = new StringRecord(this._stringinfo);
			info.Key = key;
			info.Label = label;
			info.Text = text == null ? string.Empty : text;
			this._stringinfo.Add(info);
			return true;
		}

		/// <summary>
		/// Attepts to add text and its label in the string information array.
		/// </summary>
		/// <param name="key">Hash of the string record.</param>
		/// <param name="label">Label of the text.</param>
		/// <param name="text">Text to be set.</param>
		/// <returns>True if label and its hash are unique, false otherwise.</returns>
		public bool SetRecord(uint key, string label, string text)
		{
			if (string.IsNullOrEmpty(label) || key == 0)
				return false;
			foreach (var str in this._stringinfo)
			{
				if (key == str.Key || label == str.Label)
					return false;
			}

			var info = new StringRecord(this._stringinfo);
			info.Key = key;
			info.Label = label;
			info.Text = text == null ? string.Empty : text;
			this._stringinfo.Add(info);
			return true;
		}
	}
}