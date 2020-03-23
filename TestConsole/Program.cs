using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
	class Program
	{
		static unsafe void Main(string[] args)
		{
			var watch = new System.Diagnostics.Stopwatch();

			watch.Start();
			GlobalLib.Core.Process.Set = (int)GlobalLib.Core.GameINT.Underground2;
			GlobalLib.Core.Process.GlobalDir = @"E:\Need For Speed Underground 2\Need For Speed Underground 2";
			var db = new GlobalLib.Database.Underground2();
			GlobalLib.Core.Process.LoadData(db);
			watch.Stop();

			var elapsed_1 = watch.ElapsedMilliseconds;


			Console.WriteLine($"{elapsed_1}ms");

			/*
			using (var bw = new BinaryWriter(File.Open("UG2SLOTTYPES.BIN", FileMode.Create)))
			{
				var list = new List<GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType>();
				foreach (var car in db.CarTypeInfos.Classes)
				{
					if (car.Spoiler != GlobalLib.Reflection.Enum.eSpoiler.SPOILER)
					{
						var add = new GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType();
						add.CarTypeInfo = car.CollectionName;
						add.Spoiler = car.Spoiler;
						add.SpoilerNoMirror = true;
						list.Add(add);
					}
					if (car.Mirrors != GlobalLib.Reflection.Enum.eMirrorTypes.MIRRORS)
					{
						var add = new GlobalLib.Support.Underground2.Parts.CarParts.CarSpoilMirrType();
						add.CarTypeInfo = car.CollectionName;
						add.Mirrors = car.Mirrors;
						add.SpoilerNoMirror = false;
						list.Add(add);
					}
				}

				bw.Write(db.SlotTypes.SpoilMirrs.SetSpoilers(list));
			}
			*/

			var ride = new GlobalLib.Support.Underground2.Class.PresetRide("NIKKI", db);
			ride.MODEL = "SUPRA";
			ride.AftermarketBodykit = "1";
			ride.SpoilerStyle = 35;
			ride.IsCarbonfibreSpoiler = GlobalLib.Reflection.Enum.eBoolean.True;
			ride.SpoilerType = GlobalLib.Reflection.Enum.eSTypes.BASE;
			ride.AutosculptFrontBumper = "NULL";
			ride.AutosculptRearBumper = "NULL";
			ride.AutosculptSkirt = "NULL";
			ride.HeadlightStyle = 7;
			ride.BrakelightStyle = 9;
			ride.CustomHUDStyle = "CIRCUIT";
			ride.HUDBackingColor = "PURPLE";
			ride.HUDNeedleColor = "YELLOW";
			ride.HUDCharacterColor = "RED";
			ride.CVMiscStyle = 1;
			ride.EngineStyle = 3;
			ride.ExhaustStyle = 9;
			ride.FrontBrakeStyle = 1;
			ride.RearBrakeStyle = 1;
			ride.RimBrand = "VOLK";
			ride.RimStyle = 4;
			ride.RimSize = 18;
			ride.RimOuterMax = 25;
			ride.HoodStyle = 21;
			ride.PAINT_TYPES.BasePaintType = "MUFFLERS_L3_COLOR18";
			ride.PAINT_TYPES.EnginePaintType = "METAL_L3_TEST05";
			ride.PAINT_TYPES.SpoilerPaintType = "GLOSS_L3_TEST06";
			ride.PAINT_TYPES.ExhaustPaintType = "GLOSS_L3_TEST11";
			ride.PAINT_TYPES.MirrorsPaintType = "HOSES_L3_COLOR03";
			ride.PAINT_TYPES.RimsPaintType = "RIMS_L1_COLOR05";
			ride.VINYL_SETS.VinylLayer0 = "0x60FA8162";
			ride.PerformanceLevel = 3;
			ride.TrunkAudioStyle = 3;
			ride.UnderHoodStyle = 21;
			ride.WindowTintType = "WINDSHIELD_TINT_L3_PEARL LAVENDER";
			ride.WingMirrorStyle = "0xC093F0D9";
			ride.SPECIALTIES.DoorOpeningStyle = "SCISSOR";
			ride.SPECIALTIES.HydraulicsStyle = "LVL 3 HYDRAULICS";
			ride.SPECIALTIES.NeonBody = "NEON_BLUE_PULSE";
			ride.SPECIALTIES.NeonCabin = "NEON_BLUE_PULSE";
			ride.SPECIALTIES.NeonCabinStyle = 3;
			ride.SPECIALTIES.NeonEngine = "NEON_BLUE_PULSE";
			ride.SPECIALTIES.NeonTrunk = "NEON_BLUE_PULSE";
			ride.SPECIALTIES.NOSPurgeStyle = "TYPE 3 RED & BLUE";
			ride.SPECIALTIES.HeadlightBulbStyle = "BRIGHT XENON";
			ride.AUDIO_COMP.AudioCompSmall00 = "AUDIO_COMP_NOS_1_SMALL";
			ride.AUDIO_COMP.AudioCompSmall01 = "AUDIO_COMP_NOS_0_SMALL";
			ride.AUDIO_COMP.AudioCompMedium02 = "AUDIO_COMP_SPEAKER_1_12";
			ride.AUDIO_COMP.AudioCompMedium03 = "AUDIO_COMP_SPEAKER_4_12";
			ride.AUDIO_COMP.AudioCompLarge04 = "AUDIO_COMP_LCD_1_LARGE";
			ride.AUDIO_COMP.AudioCompLarge05 = "AUDIO_COMP_LCD_2_LARGE";
			ride.DECALS_FRONT_WINDOW.DecalSlot0 = "0x0E5372C9";
			ride.DECALS_REAR_WINDOW.DecalSlot0 = "0xF664C5BD";
			db.PresetRides.Classes.Add(ride);


			using (var bw = new BinaryWriter(File.Open("UG2CAREER.BIN", FileMode.Create)))
			{
				GlobalLib.Support.Underground2.Framework.CareerManager.Assemble(bw, db);
			}


			int aaa = 0; // for debug speed test

			Console.Read(); // for release speed test
		}
	}
}
