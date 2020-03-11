namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<Track>
	{
		// Default constructor
		public Track() { }

		// Default constructor: create new track
		public Track(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble track
		public unsafe Track(byte* byteptr_t, string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.Diassemble(byteptr_t);
		}
	}
}