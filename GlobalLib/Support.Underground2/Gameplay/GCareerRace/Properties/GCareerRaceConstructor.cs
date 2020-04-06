using GlobalLib.Core;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Underground2.Parts.GameParts;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace : Collectable
	{
		// Default constructor
		public GCareerRace() { }

		// Default constructor: create new career race
		public GCareerRace(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this.CollectionName = CName;
			this.OPPONENT1 = new Opponent();
			this.OPPONENT2 = new Opponent();
			this.OPPONENT3 = new Opponent();
			this.OPPONENT4 = new Opponent();
			this.OPPONENT5 = new Opponent();
			Map.BinKeys[Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble career race
		public unsafe GCareerRace(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.OPPONENT1 = new Opponent();
			this.OPPONENT2 = new Opponent();
			this.OPPONENT3 = new Opponent();
			this.OPPONENT4 = new Opponent();
			this.OPPONENT5 = new Opponent();
			this.Disassemble(ptr_header, ptr_string);
		}
	}
}