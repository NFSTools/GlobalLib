using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private ePerformanceType _part_perf_type = ePerformanceType.NOS;
		private int _upgrade_level;
		private int _upgrade_part_index;
		private int _part_index;
		private readonly bool _cname_is_set = false;

		[AccessModifiable()]
		public ePerformanceType PartPerformanceType
		{
			get => this._part_perf_type;
			set
			{
				if (!Enum.IsDefined(typeof(ePerformanceType), value))
					throw new MappingFailException();
				if (this.CheckIfTypeCanBeSwitched(value))
					this.SwitchPerfType(value);
				else
					throw new Exception("Unable to set: no available perf part slots in this group exist.");
			}
		}

		[AccessModifiable()]
		public int UpgradeLevel
		{
			get => (this._upgrade_level + 1);
			set
			{
				--value;
				if (this.CheckIfLevelCanBeSwitched(value))
					this.SwitchUpgradeLevel(value);
				else
					throw new Exception("Unable to set: no available perf part slots in this level exist.");
			}
		}

		[AccessModifiable()]
		public int UpgradePartIndex
		{
			get => this._upgrade_part_index;
			set
			{
				if (this.CheckIfIndexCanBeSwitched(value))
					this.SwitchUpgradePartIndex(value);
				else
					throw new Exception("Unable to set: the perf slot is already taken by a different part.");
			}
		}

		[AccessModifiable()]
		public int PartIndex
		{
			get => this._part_index;
			set
			{
				foreach (var cla in this.Database.PartPerformances.Collections)
				{
					if (cla.PartIndex == value)
						throw new Exception("Performance Part with the same PartIndex already exists.");
				}
				this._part_index = value;
			}
		}
	}
}