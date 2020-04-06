using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge
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
				if (this.Database.WorldChallenges.FindCollection(value) != null)
					throw new CollectionExistenceException();
				this._collection_name = value;
			}
		}

		public uint BinKey { get => Bin.Hash(this._collection_name); }

		public uint VltKey { get => Vlt.Hash(this._collection_name); }
	}
}