namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance : Reflection.Abstract.ICollectable, Reflection.Interface.ICastable<PartPerformance>
	{
		// Default constructor
		public PartPerformance() { }

		// Default constructor: create new part performance
		public PartPerformance(string CName, Database.Underground2 db)
		{
			this.Database = db;
			this._collection_name = CName;
			this.SetToFirstAvailablePerfSlot();
		}

		// Default constructor: disassemble part performance
		public unsafe PartPerformance(byte* byteptr_t, Database.Underground2 db, params int[] args)
		{
			this.Database = db;
			this._part_perf_type = (Reflection.Enum.ePerformanceType)args[0];
			this._upgrade_level = args[1];
			this._upgrade_part_index = args[2];
			this.Disassemble(byteptr_t);
			Core.Map.PerfPartTable[args[0], args[1], args[2]] = this.BinKey;
		}

		~PartPerformance() { }
	}
}