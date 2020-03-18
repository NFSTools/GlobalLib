namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PerfSliderTuning : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<PerfSliderTuning>
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
		public unsafe PerfSliderTuning(byte* ptr_header, byte* ptr_string, Database.Underground2 db)
		{
			this.Database = db;
			this.Disassemble(ptr_header, ptr_string);
		}

		~PerfSliderTuning() { }
	}
}