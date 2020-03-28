namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning
	{
		// CollectionName here is an 8-digit hexadecimal containing 4 first major indexes of the slider.
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
				if (!Framework.Validate.PerfSliderCollectionName(value))
					throw new System.Exception("Unable to parse value provided as a hexadecimal containing tuning settings.");
				if (this.Database.PerfSliderTunings.FindCollection(value) != null)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
			}
		}

		public uint BinKey { get => Utils.ConvertX.ToUInt32(this._collection_name); }

		public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
	}
}