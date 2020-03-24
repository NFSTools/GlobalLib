namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		// Use hash as the collection name b/c it is actually a string label stored in language
		// files, and if it is missing, or the label is missing, it will cause problems like
		// scripting, editing and formatting.
		private string _collection_name;

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		[Reflection.Attributes.AccessModifiable()]
		public override string CollectionName
		{
			get => this._collection_name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left left empty.");
				if (!Framework.Validate.PartPerformanceCollectionName(value))
					throw new System.InvalidCastException("Unable to parse collection name as an 8-digit hexadecimal hash.");
				if (this.Database.PartPerformances.Classes.ContainsKey(value))
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
				Core.Map.PerfPartTable[(int)this._part_perf_type, this._upgrade_level, this._upgrade_part_index] = Utils.ConvertX.ToUInt32(value);
			}
		}

		// CollectionName is the BinKey, but as a string
		public uint BinKey { get => Utils.ConvertX.ToUInt32(this._collection_name); }

		public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
	}
}