using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		private eSponsorRaceType _sponsor_race1 = eSponsorRaceType.Circuit;
		private eSponsorRaceType _sponsor_race2 = eSponsorRaceType.Circuit;
		private eSponsorRaceType _sponsor_race3 = eSponsorRaceType.Circuit;

		[AccessModifiable()]
		[StaticModifiable()]
		public eSponsorRaceType ReqSponsorRace1
		{
			get => this._sponsor_race1;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					this._sponsor_race1 = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eSponsorRaceType ReqSponsorRace2
		{
			get => this._sponsor_race2;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					this._sponsor_race2 = value;
				else
					throw new MappingFailException();
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eSponsorRaceType ReqSponsorRace3
		{
			get => this._sponsor_race3;
			set
			{
				if (Enum.IsDefined(typeof(eSponsorRaceType), value))
					this._sponsor_race3 = value;
				else
					throw new MappingFailException();
			}
		}
	}
}