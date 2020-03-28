namespace GlobalLib.Support.Underground2
{
	public static partial class SaveData
	{
		// Thanks to nlgzrgn for helping with this part!)))
		private static byte[] CPI_Part2(Database.Underground2 db)
		{
			int part2size = db.SlotTypes.Part2.Data.Length;
			int part3entries = (db.SlotTypes.Part3.Data.Length - 8) / 8;
            int numaddons = 0;

			// Precalculate size of part2
			foreach (var car in db.CarTypeInfos.Collections)
			{
				if (car.Deletable && car.UsageType == Reflection.Enum.eUsageType.Racer)
				{
					part2size += 0x11E;
                    ++numaddons;
				}
			}

			int padding = 0x10 - ((part2size + 4) % 0x10);
			if (padding != 0x10) part2size += padding;

			// Use MemoryWriter instead of BinaryWriter so we can return an array for later processes
			var mw = new Utils.MemoryWriter(part2size);
			mw.Write(db.SlotTypes.Part2.Data);

            // Write all info
			for (int a1 = 0; a1 < numaddons; ++a1)
			{
                // CARNAME_CV - KIT00_BODY
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCB);

                // CARNAME_W01_CV
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                
                // CARNAME_W02_CV
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                
                // CARNAME_W03_CV
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                
                // CARNAME_W04_CV
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                
                // CARNAME_KIT00_HEADLIGHT
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CDC);
                
                // CARNAME_STYLE01_HEADLIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE04_HEADLIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE10_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE11_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE02_HEADLIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE03_HEADLIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE05_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE08_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE13_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE06_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE07_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE09_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE12_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE14_HEADLIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_KIT00_BRAKELIGHT
                mw.Write((short)2);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CED);
                
                // CARNAME_STYLE01_BRAKELIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE04_BRAKELIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE10_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE11_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE02_BRAKELIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE03_BRAKELIGHT
                mw.Write((short)3);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0CCE);
                mw.Write((short)0x0CDE);
                
                // CARNAME_STYLE05_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE08_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE13_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE06_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE07_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE09_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE12_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE14_BRAKELIGHT
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_KIT22_HOOD_UNDER
                mw.Write((short)2);
                mw.Write((short)part3entries);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT24_HOOD_UNDER
                mw.Write((short)2);
                mw.Write((short)(part3entries + 1));
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT23_HOOD_UNDER
                mw.Write((short)3);
                mw.Write((short)(part3entries + 2));
                mw.Write((short)0x0D07);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT25_HOOD_UNDER
                mw.Write((short)3);
                mw.Write((short)(part3entries + 3));
                mw.Write((short)0x0D07);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT21_HOOD_UNDER
                mw.Write((short)2);
                mw.Write((short)(part3entries + 4));
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT22_HOOD_UNDER CF
                mw.Write((short)4);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0D0A);
                mw.Write((short)2);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT24_HOOD_UNDER CF
                mw.Write((short)4);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0D0B);
                mw.Write((short)2);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT23_HOOD_UNDER CF
                mw.Write((short)5);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0D07);
                mw.Write((short)0x0D0C);
                mw.Write((short)2);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT25_HOOD_UNDER CF
                mw.Write((short)5);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0D07);
                mw.Write((short)0x0D0D);
                mw.Write((short)2);
                mw.Write((short)0x0D03);
                
                // CARNAME_KIT21_HOOD_UNDER CF
                mw.Write((short)4);
                mw.Write((short)part3entries++);
                mw.Write((short)0x0D0E);
                mw.Write((short)2);
                mw.Write((short)0x0D03);
                
                // CARNAME_ENGINE
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE01_ENGINE
                mw.Write((short)1);
                mw.Write((short)part3entries++);
                
                // CARNAME_STYLE02_ENGINE
                mw.Write((short)1);
                mw.Write((short)part3entries++);
            }

            // Fix length in the header
            mw.Position = 4;
            mw.Write(mw.Length - 8);
            return mw.Data;
        }
	}
}