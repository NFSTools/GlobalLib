﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		private unsafe void ReadGCareerRaces(byte* byteptr_t, int[] PartOffsets)
		{
			if (PartOffsets[1] == -1) return; // if strings block does not exist
			if (*(uint*)(byteptr_t + PartOffsets[1]) != Reflection.ID.GCareerInfo.EVENT_BLOCK)
				return; // check strings block ID

			int size = *(int*)(byteptr_t + PartOffsets[1] + 4) / 0x88;

			for (int a1 = 0; a1 < size; ++a1)
			{
				int ptr_string = PartOffsets[0] + 8;
				int ptr_header = PartOffsets[1] + a1 * 0x88 + 8;
				var Class = new GCareerRace(byteptr_t + ptr_header, byteptr_t + ptr_string, this.Database);
				this.Database.GCareerRaces.Classes.Add(Class);
			}
		}
	}
}