namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private Reflection.Enum.ePerformanceType _part_perf_type = Reflection.Enum.ePerformanceType.NOS;
		private int _upgrade_level;
		private int _upgrade_part_index;
		private int _part_index;

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.ePerformanceType PartPerformanceType
		{
			get => this._part_perf_type;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.ePerformanceType), value))
					throw new Reflection.Exception.MappingFailException();
				if (this.CheckIfTypeCanBeSwitched(value))
					this.SwitchPerfType(value);
				else
					throw new System.Exception("Unable to set: no available perf part slots in this group exist.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public int UpgradeLevel
		{
			get => (this._upgrade_level + 1);
			set
			{
				--value;
				if (this.CheckIfLevelCanBeSwitched(value))
					this.SwitchUpgradeLevel(value);
				else
					throw new System.Exception("Unable to set: no available perf part slots in this level exist.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public int UpgradePartIndex
		{
			get => this._upgrade_part_index;
			set
			{
				if (this.CheckIfIndexCanBeSwitched(value))
					this.SwitchUpgradePartIndex(value);
				else
					throw new System.Exception("Unable to set: the perf slot is already taken by a different part.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public int PartIndex
		{
			get => this._part_index;
			set
			{
				foreach (var cla in this.Database.PartPerformances.Classes)
				{
					if (cla.PartIndex == value)
						throw new System.Exception("Performance Part with the same PartIndex already exists.");
				}
				this._part_index = value;
			}
		}
	}
}