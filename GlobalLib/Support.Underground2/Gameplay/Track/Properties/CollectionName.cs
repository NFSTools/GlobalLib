using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using GlobalLib.Support.Underground2.Framework;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
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
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value.Contains(" "))
					throw new Exception("CollectionName cannot contain whitespace.");
				if (!Validate.TrackCollectionName(value))
					throw new Exception("Unable to parse TrackID from the collection name provided.");
				if (this.Database.Tracks.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
				FormatX.GetUInt16(value, "Track_{X}", out ushort id);
				this.TrackID = id;
			}
		}

		/// <summary>
		/// Binary memory hash of the collection name.
		/// </summary>
		public uint BinKey { get => Bin.Hash(this._collection_name); }
	}
}