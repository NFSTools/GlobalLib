using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchUpgradePartIndex(int value)
		{
			// Clear slot
			int index = (int)this._part_perf_type;
			int level = this._upgrade_level;
			this.ClearPartTableSlot();

			// Move to another
			this._upgrade_part_index = value;
			Map.PerfPartTable[index, level, value] = this.BinKey;
		}
	}
}