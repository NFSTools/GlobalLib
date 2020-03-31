namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
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
				if (value.Contains(" "))
					throw new System.Exception("CollectionName cannot contain whitespace.");
				if (value.Length > MaxCNameLength)
					throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
				if (this.Database.SunInfos.FindCollection(value) != null)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
			}
		}

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }
	}
}