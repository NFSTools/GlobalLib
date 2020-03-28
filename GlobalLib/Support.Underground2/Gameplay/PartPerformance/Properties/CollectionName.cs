namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
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
				if (this.Database.PartPerformances.FindCollection(value) != null)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
				if (this._cname_is_set)
					Core.Map.PerfPartTable[(int)this._part_perf_type, this._upgrade_level, this._upgrade_part_index] = Utils.ConvertX.ToUInt32(value);
			}
		}

		// CollectionName is the BinKey, but as a string
		public uint BinKey { get => Utils.Bin.SmartHash(this._collection_name); }

		public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
	}
}