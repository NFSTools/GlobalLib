namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
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
				if (!Framework.Validate.PartUnlockableCollectionName(value))
					throw new System.Exception("Unable to parse CarPartID from the collection name provided.");
				if (this.Database.PartUnlockables.GetClassIndex(value) != -1)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
			}
		}

		public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

		public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
	}
}