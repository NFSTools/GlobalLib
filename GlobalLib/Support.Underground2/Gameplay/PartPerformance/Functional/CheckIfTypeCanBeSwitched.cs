namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private bool CheckIfTypeCanBeSwitched(Reflection.Enum.ePerformanceType perftype)
		{
			int index = (int)perftype;
			for (int a1 = 0; a1 < 3; ++a1)
			{
				for (int a2 = 0; a2 < 4; ++a2)
				{
					if (Core.Map.PerfPartTable[index, a1, a2] == 0)
						return true;
				}
			}
			return false;
		}
	}
}