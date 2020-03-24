namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning : Reflection.Abstract.Collectable
	{
		// Default constructor
		public PerfSliderTuning() { }

		// Default constructor: create new perfslidertuning
		public PerfSliderTuning(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
		}

		// Default constructor: disassemble perfslidertuning
		public unsafe PerfSliderTuning(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t);
		}

		~PerfSliderTuning() { }
	}
}