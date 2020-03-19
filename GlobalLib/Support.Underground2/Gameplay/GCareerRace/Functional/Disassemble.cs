﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		protected unsafe void Disassemble(byte* ptr_header, byte* ptr_string)
		{
			ushort pointer = 0; // used for reading pointer data
			uint key = 0; // for reading keys and comparison

			// Collection Name
			pointer = *(ushort*)ptr_header;
			this._collection_name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);

			// Intro Movie
			pointer = *(ushort*)(ptr_header + 2);
			this.IntroMovie = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);

			// Outro Movie
			pointer = *(ushort*)(ptr_header + 4);
			this.OutroMovie = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);

			// Event Trigger
			pointer = *(ushort*)(ptr_header + 6);
			this.EventTrigger = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);

			// Event behavior
			this._unlock_method = (Reflection.Enum.eUnlockCondition)(*(ptr_header + 0xC));
			this._is_suv_race = (*(ptr_header + 0xD) == 0) ? Reflection.Enum.eBoolean.False : Reflection.Enum.eBoolean.True;
			this._padding0 = *(ptr_header + 0xE);
			this._event_behavior = (Reflection.Enum.eEventBehaviorType)(*(ptr_header + 0xF));

			// Unlock conditions
			key = *(uint*)(ptr_header + 0x10);
			if (this._unlock_method == Reflection.Enum.eUnlockCondition.SPECIFIC_RACE_WON)
				this.RequiredSpecificRaceWon = Core.Map.Lookup(key) ?? $"0x{key:X8}";
			else
			{
				this.RequiredSpecificURLWon = *(ptr_header + 0x10);
				this.SponsorChosenToUnlock = *(ptr_header + 0x11);
				this.RequiredRacesWon = *(ptr_header + 0x12);
				this.RequiredURLWon = *(ptr_header + 0x13);
			}

			// Earnable Respect ?
			this.EarnableRespect = *(int*)(ptr_header + 0x14);

			// Stage Values
			this._num_of_stages = *(ptr_header + 0x7E);
			this.TrackID_Stage1 = *(ushort*)(ptr_header + 0x18);
			this.TrackID_Stage2 = *(ushort*)(ptr_header + 0x1C);
			this.TrackID_Stage3 = *(ushort*)(ptr_header + 0x20);
			this.TrackID_Stage4 = *(ushort*)(ptr_header + 0x24);
			this.InReverseDirection_Stage1 = (Reflection.Enum.eBoolean)(*(ptr_header + 0x1A) % 2);
			this.InReverseDirection_Stage2 = (Reflection.Enum.eBoolean)(*(ptr_header + 0x1E) % 2);
			this.InReverseDirection_Stage3 = (Reflection.Enum.eBoolean)(*(ptr_header + 0x22) % 2);
			this.InReverseDirection_Stage4 = (Reflection.Enum.eBoolean)(*(ptr_header + 0x26) % 2);
			this.NumLaps_Stage1 = *(ptr_header + 0x1B);
			this.NumLaps_Stage2 = *(ptr_header + 0x1F);
			this.NumLaps_Stage3 = *(ptr_header + 0x23);
			this.NumLaps_Stage4 = *(ptr_header + 0x27);

			// PlayerCarType and CashValue
			key = *(uint*)(ptr_header + 0x2C);
			if (key == 0)
				this._player_car_type = Reflection.BaseArguments.NULL;
			else
				this.PlayerCarType = Core.Map.Lookup(key) ?? $"0x{key:X8}";
			this.CashValue = *(int*)(ptr_header + 0x30);

			// Some UnknownValues
			this._event_icon_type = (Reflection.Enum.eEventIconType)(*(ptr_header + 0x34));
			this._is_drive_to_gps = (*(ptr_header + 0x35) == 0) ? Reflection.Enum.eBoolean.False : Reflection.Enum.eBoolean.True;
			this.DifficultyLevel = (Reflection.Enum.eTrackDifficulty)(*(ptr_header + 0x36));
			this.BelongsToStage = *(ptr_header + 0x37);

			// Some values
			this.NumMapItems = *(ptr_header + 0x38);
			this._padding1 = *(ptr_header + 0x39);
			this.Unknown0x3A = *(ptr_header + 0x3A);
			this.Unknown0x3B = *(ptr_header + 0x3B);

			// GPS Destination
			key = *(uint*)(ptr_header + 0x3C);
			if (key == 0)
				this._gps_destination = Reflection.BaseArguments.NULL;
			else
				this._gps_destination = Core.Map.Lookup(key) ?? $"0x{key:X8}";

			// Opponents Values
			this._num_of_opponents = *(ptr_header + 0x7C);
			if (this._num_of_opponents > 0)
			{
				pointer = *(ushort*)(ptr_header + 0x40);
				this.OPPONENT1.Name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
				this.OPPONENT1.StatsMultiplier = *(ushort*)(ptr_header + 0x42);
				key = *(uint*)(ptr_header + 0x44);
				this.OPPONENT1.PresetRide = Core.Map.Lookup(key) ?? $"0x{key:X8}";
				this.OPPONENT1.SkillEasy = *(ptr_header + 0x48);
				this.OPPONENT1.SkillMedium = *(ptr_header + 0x49);
				this.OPPONENT1.SkillHard = *(ptr_header + 0x4A);
				this.OPPONENT1.CatchUp = *(ptr_header + 0x4B);
			}
			if (this._num_of_opponents > 1)
			{
				pointer = *(ushort*)(ptr_header + 0x4C);
				this.OPPONENT2.Name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
				this.OPPONENT2.StatsMultiplier = *(ushort*)(ptr_header + 0x4E);
				key = *(uint*)(ptr_header + 0x50);
				this.OPPONENT2.PresetRide = Core.Map.Lookup(key) ?? $"0x{key:X8}";
				this.OPPONENT2.SkillEasy = *(ptr_header + 0x54);
				this.OPPONENT2.SkillMedium = *(ptr_header + 0x55);
				this.OPPONENT2.SkillHard = *(ptr_header + 0x56);
				this.OPPONENT2.CatchUp = *(ptr_header + 0x57);
			}
			if (this._num_of_opponents > 2)
			{
				pointer = *(ushort*)(ptr_header + 0x58);
				this.OPPONENT3.Name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
				this.OPPONENT3.StatsMultiplier = *(ushort*)(ptr_header + 0x5A);
				key = *(uint*)(ptr_header + 0x5C);
				this.OPPONENT3.PresetRide = Core.Map.Lookup(key) ?? $"0x{key:X8}";
				this.OPPONENT3.SkillEasy = *(ptr_header + 0x60);
				this.OPPONENT3.SkillMedium = *(ptr_header + 0x61);
				this.OPPONENT3.SkillHard = *(ptr_header + 0x62);
				this.OPPONENT3.CatchUp = *(ptr_header + 0x63);
			}
			if (this._num_of_opponents > 3)
			{
				pointer = *(ushort*)(ptr_header + 0x64);
				this.OPPONENT4.Name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
				this.OPPONENT4.StatsMultiplier = *(ushort*)(ptr_header + 0x66);
				key = *(uint*)(ptr_header + 0x68);
				this.OPPONENT4.PresetRide = Core.Map.Lookup(key) ?? $"0x{key:X8}";
				this.OPPONENT4.SkillEasy = *(ptr_header + 0x6C);
				this.OPPONENT4.SkillMedium = *(ptr_header + 0x6D);
				this.OPPONENT4.SkillHard = *(ptr_header + 0x6E);
				this.OPPONENT4.CatchUp = *(ptr_header + 0x6F);
			}
			if (this._num_of_opponents > 4)
			{
				pointer = *(ushort*)(ptr_header + 0x70);
				this.OPPONENT5.Name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
				this.OPPONENT5.StatsMultiplier = *(ushort*)(ptr_header + 0x72);
				key = *(uint*)(ptr_header + 0x74);
				this.OPPONENT5.PresetRide = Core.Map.Lookup(key) ?? $"0x{key:X8}";
				this.OPPONENT5.SkillEasy = *(ptr_header + 0x78);
				this.OPPONENT5.SkillMedium = *(ptr_header + 0x79);
				this.OPPONENT5.SkillHard = *(ptr_header + 0x7A);
				this.OPPONENT5.CatchUp = *(ptr_header + 0x7B);
			}

			// Last settings
			this.UnknownDragValue = *(ptr_header + 0x7D);
			this.IsHiddenEvent = (*(ptr_header + 0x7F) == 0) ? Reflection.Enum.eBoolean.False : Reflection.Enum.eBoolean.True;
			this._padding2 = *(int*)(ptr_header + 0x80);
			this._padding3 = *(int*)(ptr_header + 0x84);
		}
	}
}