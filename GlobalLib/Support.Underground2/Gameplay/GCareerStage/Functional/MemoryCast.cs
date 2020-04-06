using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new GCareerStage(CName, this.Database);
			result._stage_sponsor1 = this._stage_sponsor1;
			result._stage_sponsor2 = this._stage_sponsor2;
			result._stage_sponsor3 = this._stage_sponsor3;
			result._stage_sponsor4 = this._stage_sponsor4;
			result._stage_sponsor5 = this._stage_sponsor5;
			result._last_stage_event = this._last_stage_event;
			result.AttribSponsor1 = this.AttribSponsor1;
			result.AttribSponsor2 = this.AttribSponsor2;
			result.AttribSponsor3 = this.AttribSponsor3;
			result.AttribSponsor4 = this.AttribSponsor4;
			result.AttribSponsor5 = this.AttribSponsor5;
			result.OutrunCashValue = this.OutrunCashValue;
			result.MaxCircuitsShownOnMap = this.MaxCircuitsShownOnMap;
			result.MaxDragsShownOnMap = this.MaxDragsShownOnMap;
			result.MaxStreetXShownOnMap = this.MaxStreetXShownOnMap;
			result.MaxDriftsShownOnMap = this.MaxDriftsShownOnMap;
			result.MaxSprintsShownOnMap = this.MaxSprintsShownOnMap;
			result.MaxOutrunEvents = this.MaxOutrunEvents;
			result.Unknown0x04 = this.Unknown0x04;
			result.Unknown0x06 = this.Unknown0x06;
			result.Unknown0x26 = this.Unknown0x26;
			result.Unknown0x2C = this.Unknown0x2C;
			result.Unknown0x2D = this.Unknown0x2D;
			result.Unknown0x2E = this.Unknown0x2E;
			result.Unknown0x2F = this.Unknown0x2F;
			result.Unknown0x35 = this.Unknown0x35;
			result.Unknown0x36 = this.Unknown0x36;
			result.Unknown0x37 = this.Unknown0x37;
			result.Unknown0x38 = this.Unknown0x38;
			result.Unknown0x39 = this.Unknown0x39;
			result.Unknown0x3A = this.Unknown0x3A;
			result.Unknown0x3B = this.Unknown0x3B;
			result.Unknown0x3C = this.Unknown0x3C;
			result.Unknown0x3D = this.Unknown0x3D;
			result.Unknown0x3E = this.Unknown0x3E;
			result.Unknown0x3F = this.Unknown0x3F;
			result.Unknown0x41 = this.Unknown0x41;
			result.Unknown0x42 = this.Unknown0x42;
			result.Unknown0x43 = this.Unknown0x43;
			result.Unknown0x44 = this.Unknown0x44;
			result.Unknown0x48 = this.Unknown0x48;
			result.Unknown0x4C = this.Unknown0x4C;
			return result;
		}
	}
}