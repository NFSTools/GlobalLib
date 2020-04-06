using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private bool CheckIfLevelCanBeSwitched(int level)
		{
			int index = (int)this._part_perf_type;
			for (int a1 = 0; a1 < 4; ++a1)
			{
				if (Map.PerfPartTable[index, level, a1] == 0)
					return true;
			}
			return false;
		}
	}
}