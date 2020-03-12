namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void Diassemble(byte* byteptr_t)
		{
			var PartOffsets = this.FindOffsets(byteptr_t);
			var GCareerRaceCount = this.GetGCareerRaceCount(byteptr_t, PartOffsets[1]);
			if (GCareerRaceCount == 0) return; // if no GCareerRaces allocated.

			this.ReadStrings(byteptr_t, PartOffsets[0]);

			for (int a1 = 0; a1 < GCareerRaceCount; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[1] + a1 * 0x88 + 8;
				var Class = new GCareerRace(byteptr_t + ptr_header, byteptr_t + ptr_string, this.Database);
				this.Database.GCareerRaces.Classes.Add(Class);
			}

		}
	}
}