namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldChallenge : Reflection.Abstract.Collectable, Reflection.Interface.ICastable<WorldChallenge>
	{
		// Default constructor
		public WorldChallenge() { }

		// Default constructor: create new world challenge
		public WorldChallenge(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble world challenge
		public unsafe WorldChallenge(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~WorldChallenge() { }
	}
}