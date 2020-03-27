namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SwitchPerfType(Reflection.Enum.ePerformanceType perftype)
		{
			// Clear slot
			this.ClearPartTableSlot();
			
			// Move to another
			this._part_perf_type = perftype;
			int index = (int)perftype;
			for (int a1 = 0; a1 < 3; ++a1)
			{
				for (int a2 = 0; a2 < 4; ++a2)
				{
					if (Core.Map.PerfPartTable[index, a1, a2] == 0)
					{
						Core.Map.PerfPartTable[index, a1, a2] = this.BinKey;
						this._upgrade_level = a1;
						this._upgrade_part_index = a2;
						return;
					}
				}
			}
		}
	}
}