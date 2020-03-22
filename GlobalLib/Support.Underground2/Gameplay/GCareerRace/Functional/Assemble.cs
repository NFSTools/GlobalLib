namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		public unsafe void Assemble(byte* byteptr_t, Utils.MemoryWriter mw)
		{
			ushort pointer = 0; // for pointers

			pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this._collection_name);
			*(ushort*)byteptr_t = pointer;

			if (!string.IsNullOrWhiteSpace(this.IntroMovie))
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this._intro_movie);
				*(ushort*)(byteptr_t + 0x02) = pointer;
			}

			if (!string.IsNullOrWhiteSpace(this.OutroMovie))
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this._outro_movie);
				*(ushort*)(byteptr_t + 0x04) = pointer;
			}

			if (this._event_trigger != Reflection.BaseArguments.NULL)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this._event_trigger);
				*(ushort*)(byteptr_t + 0x06) = pointer;
			}

			*(uint*)(byteptr_t + 0x08) = this.BinKey;
			*(byteptr_t + 0x0C) = (byte)this._unlock_method;
			*(byteptr_t + 0x0D) = (byte)this._is_suv_race;
			*(byteptr_t + 0x0E) = this._padding0;
			*(byteptr_t + 0x0F) = (byte)this._event_behavior;

			if (this._unlock_method == Reflection.Enum.eUnlockCondition.SPECIFIC_RACE_WON)
				*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this._required_spec_race_won);
			else
			{
				*(byteptr_t + 0x10) = this.RequiredSpecificURLWon;
				*(byteptr_t + 0x11) = this.SponsorChosenToUnlock;
				*(byteptr_t + 0x12) = this.RequiredRacesWon;
				*(byteptr_t + 0x13) = this.RequiredURLWon;
			}

			*(int*)(byteptr_t + 0x14) = this.EarnableRespect;
			*(ushort*)(byteptr_t + 0x18) = this.TrackID_Stage1;
			*(ushort*)(byteptr_t + 0x1C) = this.TrackID_Stage2;
			*(ushort*)(byteptr_t + 0x20) = this.TrackID_Stage3;
			*(ushort*)(byteptr_t + 0x24) = this.TrackID_Stage4;
			*(byteptr_t + 0x1A) = (byte)this.InReverseDirection_Stage1;
			*(byteptr_t + 0x1E) = (byte)this.InReverseDirection_Stage2;
			*(byteptr_t + 0x22) = (byte)this.InReverseDirection_Stage3;
			*(byteptr_t + 0x26) = (byte)this.InReverseDirection_Stage4;
			*(byteptr_t + 0x1B) = this.NumLaps_Stage1;
			*(byteptr_t + 0x1F) = this.NumLaps_Stage2;
			*(byteptr_t + 0x23) = this.NumLaps_Stage3;
			*(byteptr_t + 0x27) = this.NumLaps_Stage4;

			*(uint*)(byteptr_t + 0x28) = Utils.Bin.Hash(this._event_trigger);
			*(uint*)(byteptr_t + 0x2C) = Utils.Bin.SmartHash(this._player_car_type);
			*(int*)(byteptr_t + 0x30) = this.CashValue;
			*(byteptr_t + 0x34) = (byte)this._event_icon_type;
			*(byteptr_t + 0x35) = (byte)this._is_drive_to_gps;
			*(byteptr_t + 0x36) = (byte)this._difficulty_level;
			*(byteptr_t + 0x37) = this.BelongsToStage;
			*(byteptr_t + 0x38) = this.NumMapItems;
			*(byteptr_t + 0x39) = this._padding1;
			*(byteptr_t + 0x3A) = this.Unknown0x3A;
			*(byteptr_t + 0x3B) = this.Unknown0x3B;
			*(uint*)(byteptr_t + 0x3C) = Utils.Bin.SmartHash(this._gps_destination);

			*(byteptr_t + 0x7C) = this._num_of_opponents;
			*(byteptr_t + 0x7D) = this.UnknownDragValue;
			*(byteptr_t + 0x7E) = this._num_of_stages;
			*(byteptr_t + 0x7F) = (byte)this._is_hidden_event;
			*(int*)(byteptr_t + 0x80) = this._padding2;
			*(int*)(byteptr_t + 0x84) = this._padding3;

			// Goto based on whether event is a drift downhill
			if (this.DriftTypeIfDriftRace == Reflection.Enum.eDriftType.DOWNHILL)
				goto LABEL_DRIFT_DOWNHILL;
			else
				goto LABEL_BASIC;

			// If none of the events are drift downhill, write opponent data based on number of the opponents
		LABEL_BASIC:
			if (this._num_of_opponents > 0)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT1.Name);
				*(ushort*)(byteptr_t + 0x40) = pointer;
				*(ushort*)(byteptr_t + 0x42) = this.OPPONENT1.StatsMultiplier;
				*(uint*)(byteptr_t + 0x44) = Utils.Bin.SmartHash(this.OPPONENT1.PresetRide);
				*(byteptr_t + 0x48) = this.OPPONENT1.SkillEasy;
				*(byteptr_t + 0x49) = this.OPPONENT1.SkillMedium;
				*(byteptr_t + 0x4A) = this.OPPONENT1.SkillHard;
				*(byteptr_t + 0x4B) = this.OPPONENT1.CatchUp;
			}
			if (this._num_of_opponents > 1)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT2.Name);
				*(ushort*)(byteptr_t + 0x4C) = pointer;
				*(ushort*)(byteptr_t + 0x4E) = this.OPPONENT2.StatsMultiplier;
				*(uint*)(byteptr_t + 0x50) = Utils.Bin.SmartHash(this.OPPONENT2.PresetRide);
				*(byteptr_t + 0x54) = this.OPPONENT2.SkillEasy;
				*(byteptr_t + 0x55) = this.OPPONENT2.SkillMedium;
				*(byteptr_t + 0x56) = this.OPPONENT2.SkillHard;
				*(byteptr_t + 0x57) = this.OPPONENT2.CatchUp;
			}
			if (this._num_of_opponents > 2)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT3.Name);
				*(ushort*)(byteptr_t + 0x58) = pointer;
				*(ushort*)(byteptr_t + 0x5A) = this.OPPONENT3.StatsMultiplier;
				*(uint*)(byteptr_t + 0x5C) = Utils.Bin.SmartHash(this.OPPONENT3.PresetRide);
				*(byteptr_t + 0x60) = this.OPPONENT3.SkillEasy;
				*(byteptr_t + 0x61) = this.OPPONENT3.SkillMedium;
				*(byteptr_t + 0x62) = this.OPPONENT3.SkillHard;
				*(byteptr_t + 0x63) = this.OPPONENT3.CatchUp;
			}
			if (this._num_of_opponents > 3)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT4.Name);
				*(ushort*)(byteptr_t + 0x64) = pointer;
				*(ushort*)(byteptr_t + 0x66) = this.OPPONENT4.StatsMultiplier;
				*(uint*)(byteptr_t + 0x68) = Utils.Bin.SmartHash(this.OPPONENT4.PresetRide);
				*(byteptr_t + 0x6C) = this.OPPONENT4.SkillEasy;
				*(byteptr_t + 0x6D) = this.OPPONENT4.SkillMedium;
				*(byteptr_t + 0x6E) = this.OPPONENT4.SkillHard;
				*(byteptr_t + 0x6F) = this.OPPONENT4.CatchUp;
			}
			if (this._num_of_opponents > 4)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT5.Name);
				*(ushort*)(byteptr_t + 0x70) = pointer;
				*(ushort*)(byteptr_t + 0x72) = this.OPPONENT5.StatsMultiplier;
				*(uint*)(byteptr_t + 0x74) = Utils.Bin.SmartHash(this.OPPONENT5.PresetRide);
				*(byteptr_t + 0x78) = this.OPPONENT5.SkillEasy;
				*(byteptr_t + 0x79) = this.OPPONENT5.SkillMedium;
				*(byteptr_t + 0x7A) = this.OPPONENT5.SkillHard;
				*(byteptr_t + 0x7B) = this.OPPONENT5.CatchUp;
			}
			return;

			// If at least one of the events is drift downhill, write at least 3 opponents
		LABEL_DRIFT_DOWNHILL:
			pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this.OPPONENT1.Name);
			*(ushort*)(byteptr_t + 0x40) = pointer;
			*(ushort*)(byteptr_t + 0x42) = this.OPPONENT1.StatsMultiplier;
			*(uint*)(byteptr_t + 0x44) = Utils.Bin.SmartHash(this.OPPONENT1.PresetRide);
			*(byteptr_t + 0x48) = this.OPPONENT1.SkillEasy;
			*(byteptr_t + 0x49) = this.OPPONENT1.SkillMedium;
			*(byteptr_t + 0x4A) = this.OPPONENT1.SkillHard;
			*(byteptr_t + 0x4B) = this.OPPONENT1.CatchUp;

			pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this.OPPONENT2.Name);
			*(ushort*)(byteptr_t + 0x4C) = pointer;
			*(ushort*)(byteptr_t + 0x4E) = this.OPPONENT2.StatsMultiplier;
			*(uint*)(byteptr_t + 0x50) = Utils.Bin.SmartHash(this.OPPONENT2.PresetRide);
			*(byteptr_t + 0x54) = this.OPPONENT2.SkillEasy;
			*(byteptr_t + 0x55) = this.OPPONENT2.SkillMedium;
			*(byteptr_t + 0x56) = this.OPPONENT2.SkillHard;
			*(byteptr_t + 0x57) = this.OPPONENT2.CatchUp;

			pointer = (ushort)mw.Position;
			mw.WriteNullTerminated(this.OPPONENT3.Name);
			*(ushort*)(byteptr_t + 0x58) = pointer;
			*(ushort*)(byteptr_t + 0x5A) = this.OPPONENT3.StatsMultiplier;
			*(uint*)(byteptr_t + 0x5C) = Utils.Bin.SmartHash(this.OPPONENT3.PresetRide);
			*(byteptr_t + 0x60) = this.OPPONENT3.SkillEasy;
			*(byteptr_t + 0x61) = this.OPPONENT3.SkillMedium;
			*(byteptr_t + 0x62) = this.OPPONENT3.SkillHard;
			*(byteptr_t + 0x63) = this.OPPONENT3.CatchUp;

			if (this._num_of_opponents > 3)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT4.Name);
				*(ushort*)(byteptr_t + 0x64) = pointer;
				*(ushort*)(byteptr_t + 0x66) = this.OPPONENT4.StatsMultiplier;
				*(uint*)(byteptr_t + 0x68) = Utils.Bin.SmartHash(this.OPPONENT4.PresetRide);
				*(byteptr_t + 0x6C) = this.OPPONENT4.SkillEasy;
				*(byteptr_t + 0x6D) = this.OPPONENT4.SkillMedium;
				*(byteptr_t + 0x6E) = this.OPPONENT4.SkillHard;
				*(byteptr_t + 0x6F) = this.OPPONENT4.CatchUp;
			}
			if (this._num_of_opponents > 4)
			{
				pointer = (ushort)mw.Position;
				mw.WriteNullTerminated(this.OPPONENT5.Name);
				*(ushort*)(byteptr_t + 0x70) = pointer;
				*(ushort*)(byteptr_t + 0x72) = this.OPPONENT5.StatsMultiplier;
				*(uint*)(byteptr_t + 0x74) = Utils.Bin.SmartHash(this.OPPONENT5.PresetRide);
				*(byteptr_t + 0x78) = this.OPPONENT5.SkillEasy;
				*(byteptr_t + 0x79) = this.OPPONENT5.SkillMedium;
				*(byteptr_t + 0x7A) = this.OPPONENT5.SkillHard;
				*(byteptr_t + 0x7B) = this.OPPONENT5.CatchUp;
			}
			return;
		}
	}
}