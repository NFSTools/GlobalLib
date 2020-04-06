using GlobalLib.Core;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private string _collection_name;

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		[AccessModifiable()]
		public override string CollectionName
		{
			get => this._collection_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left left empty.");
				if (value.Contains(" "))
					throw new Exception("CollectionName cannot contain whitespace.");
				if (this.Database.PartPerformances.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
				if (this._cname_is_set)
					Map.PerfPartTable[(int)this._part_perf_type, this._upgrade_level, this._upgrade_part_index] = ConvertX.ToUInt32(value);
			}
		}

		// CollectionName is the BinKey, but as a string
		public uint BinKey { get => Bin.SmartHash(this._collection_name); }

		public uint VltKey { get => Vlt.Hash(this._collection_name); }
	}
}