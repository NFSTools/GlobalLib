﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class BankTrigger
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
				if (!Framework.Validate.BankTriggerCollectionName(value))
					throw new System.Exception("CollectionName should be of format BANK_TRIGGER_# with 2-digit index.");
				if (this.Database.BankTriggers.GetClassIndex(value) != -1)
					throw new Reflection.Exception.CollectionExistenceException();
				this._collection_name = value;
			}
		}

		public uint BinKey { get => Utils.Bin.Hash(this._collection_name); }

		public uint VltKey { get => Utils.Vlt.Hash(this._collection_name); }
	}
}