namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor : Reflection.Abstract.Collectable, Reflection.Interface.ICastable<Sponsor>
	{
		// Default constructor
		public Sponsor() { }

		// Default constructor: create new sponsor
		public Sponsor(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble sponsor
		public unsafe Sponsor(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~Sponsor() { }
	}
}