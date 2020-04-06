using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private bool CheckIfIndexCanBeSwitched(int value)
		{
			int index = (int)this._part_perf_type;
			if (Map.PerfPartTable[index, this._upgrade_level, value] == 0)
				return true;
			else
				return false;
		}
	}
}