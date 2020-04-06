using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage : Collectable
	{
		// Default constructor
		public GCareerStage() { }

		// Default constructor: create new career stage
		public GCareerStage(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			Map.BinKeys[Bin.Hash(CName)] = CName;
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