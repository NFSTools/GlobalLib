namespace GlobalLib.Support.Underground2.Framework
{
	public static partial class CareerManager
	{
		public static unsafe void Assemble(System.IO.BinaryWriter bw, Database.Underground2 db)
		{
			// Initialize MemoryWriter for string block to its maximum size
			var mw = new Utils.MemoryWriter(0xFFFF);
			mw.Write((byte)0); // write null-termination
			mw.WriteNullTerminated("GlobalLib by MaxHwoy " + System.DateTime.Today.ToString("dd-MM-yyyy"));

			// Get arrays of all blocks
			var GCareerRacesBlock = WriteGCareerRaces(mw, db);
			var WorldShopBlock = WriteWorldShops(mw, db);
			var GCareerBrandsBlock = WriteGCareerBrands(mw, db);
			var PartPerformancesBlock = WritePartPerformances(db);
			var GShowcasesBlock = WriteGShowcases(mw, db);
			var SMSMessagesBlock = WriteSMSMessages(mw, db);
			var SponsorsBlock = WriteSponsors(mw, db);
			var GCareerStagesBlock = WriteGCareerStages(db);
			var PerfSliderTuningsBlock = WritePerfSliderTunings(db);
			var WorldChallengesBlock = WriteWorldChallenges(mw, db);
			var PartUnlockablesBlock = WritePartUnlockables(db);
			var BankTriggersBlock = WriteBankTriggers(db);
			var GCarUnlocksBlock = WriteGCarUnlocks(db);

			// Compress to the position
			mw.Position += 4 - (mw.Position % 4);
			mw.CompressToPosition();

			// Pre-calculate size
			var size = 8 + mw.Length;
			size += GCareerRacesBlock.Length;
			size += WorldShopBlock.Length;
			size += GCareerBrandsBlock.Length;
			size += PartPerformancesBlock.Length;
			size += GShowcasesBlock.Length;
			size += SMSMessagesBlock.Length;
			size += SponsorsBlock.Length;
			size += GCareerStagesBlock.Length;
			size += PerfSliderTuningsBlock.Length;
			size += WorldChallengesBlock.Length;
			size += PartUnlockablesBlock.Length;
			size += BankTriggersBlock.Length;
			size += GCarUnlocksBlock.Length;

			// Pre-calculate padding
			var padding = Utils.EA.Resolve.GetPaddingArray(size + 0x50, 0x80);
			size += padding.Length;

			// Finally, write entire Career Block
			bw.Write(Reflection.ID.CareerInfo.MAINID);
			bw.Write(size);
			bw.Write(Reflection.ID.CareerInfo.STRING_BLOCK);
			bw.Write(mw.Length);
			bw.Write(mw.Data);
			bw.Write(GCareerRacesBlock);
			bw.Write(WorldShopBlock);
			bw.Write(GCareerBrandsBlock);
			bw.Write(PartPerformancesBlock);
			bw.Write(GShowcasesBlock);
			bw.Write(SMSMessagesBlock);
			bw.Write(SponsorsBlock);
			bw.Write(GCareerStagesBlock);
			bw.Write(PerfSliderTuningsBlock);
			bw.Write(WorldChallengesBlock);
			bw.Write(PartUnlockablesBlock);
			bw.Write(BankTriggersBlock);
			bw.Write(GCarUnlocksBlock);
			bw.Write(padding);
		}
	}
}