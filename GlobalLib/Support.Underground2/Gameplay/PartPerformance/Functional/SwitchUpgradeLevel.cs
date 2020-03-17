namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchUpgradeLevel(int level)
		{
			// Clear slot
			int index = (int)this._part_perf_type;
			this.ClearPartTableSlot();

			// Move to another
			this._upgrade_level = level;
			for (int a1 = 0; a1 < 4; ++a1)
			{
				if (Core.Map.PerfPartTable[index, level, a1] == 0)
				{
					Core.Map.PerfPartTable[index, level, a1] = Utils.ConvertX.ToUInt32(this._collection_name);
					this._upgrade_part_index = a1;
					return;
				}
			}
		}
	}
}