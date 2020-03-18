namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<GCareerStage>
	{
		// Default constructor
		public GCareerStage() { }

		// Default constructor: create new career stage
		public GCareerStage(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble career stage
		public unsafe GCareerStage(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~GCareerStage() { }
	}
}