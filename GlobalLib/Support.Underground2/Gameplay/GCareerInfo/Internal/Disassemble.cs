namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void Diassemble(byte* byteptr_t)
		{
			var PartOffsets = this.FindOffsets(byteptr_t);

			this.ReadStrings(byteptr_t, PartOffsets);
			this.ReadGCareerRaces(byteptr_t, PartOffsets);
			this.ReadWorldShops(byteptr_t, PartOffsets);
			this.ReadGCareerBrands(byteptr_t, PartOffsets);
			this.ReadPartPerformances(byteptr_t, PartOffsets);
			this.ReadGShowcases(byteptr_t, PartOffsets);
			this.ReadSMSMessages(byteptr_t, PartOffsets);
			this.ReadSponsors(byteptr_t, PartOffsets);
			this.ReadWorldChallenges(byteptr_t, PartOffsets);
			this.ReadPartUnlockables(byteptr_t, PartOffsets);
			this.ReadBankTriggers(byteptr_t, PartOffsets);
		}
	}
}