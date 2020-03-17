namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		public void ClearPartTableSlot()
		{
			int index = (int)this._part_perf_type;
			int level = this._upgrade_level;
			int value = this._upgrade_part_index;
			if (Core.Map.PerfPartTable[index, level, value] == this.BinKey)
				Core.Map.PerfPartTable[index, level, value] = 0;
		}
	}
}