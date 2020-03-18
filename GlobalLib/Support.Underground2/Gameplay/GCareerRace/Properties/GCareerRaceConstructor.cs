namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<GCareerRace>
	{
		// Default constructor
		public GCareerRace() { }

		// Default constructor: create new career race
		public GCareerRace(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.OPPONENT1 = new Parts.GameParts.Opponent();
			this.OPPONENT2 = new Parts.GameParts.Opponent();
			this.OPPONENT3 = new Parts.GameParts.Opponent();
			this.OPPONENT4 = new Parts.GameParts.Opponent();
			this.OPPONENT5 = new Parts.GameParts.Opponent();
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble career race
		public unsafe GCareerRace(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.OPPONENT1 = new Parts.GameParts.Opponent();
			this.OPPONENT2 = new Parts.GameParts.Opponent();
			this.OPPONENT3 = new Parts.GameParts.Opponent();
			this.OPPONENT4 = new Parts.GameParts.Opponent();
			this.OPPONENT5 = new Parts.GameParts.Opponent();
			this.Disassemble(ptr_header, ptr_string);
		}
	}
}