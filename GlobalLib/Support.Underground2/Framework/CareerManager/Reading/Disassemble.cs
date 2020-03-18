namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		public static unsafe void Disassemble(byte* byteptr_t, Database.Underground2 db)
		{
			var PartOffsets = FindOffsets(byteptr_t);

			ReadStrings(byteptr_t, PartOffsets);
			ReadGCareerRaces(byteptr_t, PartOffsets, db);
			ReadWorldShops(byteptr_t, PartOffsets, db);
			ReadGCareerBrands(byteptr_t, PartOffsets, db);
			ReadPartPerformances(byteptr_t, PartOffsets, db);
			ReadGShowcases(byteptr_t, PartOffsets, db);
			ReadSMSMessages(byteptr_t, PartOffsets, db);
			ReadSponsors(byteptr_t, PartOffsets, db);
			ReadGCareerStages(byteptr_t, PartOffsets, db);
			ReadPerfSliderTunings(byteptr_t, PartOffsets, db);
			ReadWorldChallenges(byteptr_t, PartOffsets, db);
			ReadPartUnlockables(byteptr_t, PartOffsets, db);
			ReadBankTriggers(byteptr_t, PartOffsets, db);
			ReadGCarUnlocks(byteptr_t, PartOffsets, db);
		}
	}
}