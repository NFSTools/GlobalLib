namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
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
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (!Framework.Validate.TrackCollectionName(value))
					throw new System.Exception("Unable to parse TrackID from the collection name provided.");
				if (this.Database.GetClassIndex(value, GlobalLib.Database.eClassType.Track) != -1)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
				Utils.FormatX.GetUInt16(value, "Track_{X}", out ushort id);
				this.TrackID = id;
			}
		}

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }
	}
}