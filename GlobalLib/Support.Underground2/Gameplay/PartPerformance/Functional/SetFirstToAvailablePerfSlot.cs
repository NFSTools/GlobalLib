namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private void SetToFirstAvailablePerfSlot()
		{
			for (int a1 = 0; a1 < 10; ++a1)
			{
				for (int a2 = 0; a2 < 3; ++a2)
				{
					for (int a3 = 0; a3 < 4; ++a3)
					{
						if (Core.Map.PerfPartTable[a1, a2, a3] == 0)
						{
							this._part_perf_type = (Reflection.Enum.ePerformanceType)a1;
							this._upgrade_level = a2;
							this._upgrade_part_index = a3;
							return;
						}
					}
				}
			}
		}
	}
}