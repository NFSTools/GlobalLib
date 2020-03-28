namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		private Reflection.Enum.eSponsorRaceType _sponsor_race1 = Reflection.Enum.eSponsorRaceType.Circuit;
		private Reflection.Enum.eSponsorRaceType _sponsor_race2 = Reflection.Enum.eSponsorRaceType.Circuit;
		private Reflection.Enum.eSponsorRaceType _sponsor_race3 = Reflection.Enum.eSponsorRaceType.Circuit;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eSponsorRaceType ReqSponsorRace1
		{
			get => this._sponsor_race1;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eSponsorRaceType), value))
					this._sponsor_race1 = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eSponsorRaceType ReqSponsorRace2
		{
			get => this._sponsor_race2;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eSponsorRaceType), value))
					this._sponsor_race2 = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eSponsorRaceType ReqSponsorRace3
		{
			get => this._sponsor_race3;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eSponsorRaceType), value))
					this._sponsor_race3 = value;
				else
					throw new Reflection.Exception.MappingFailException();
			}
		}
	}
}