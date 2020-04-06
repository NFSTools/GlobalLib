using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerRace
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new GCareerRace(CName, this.Database);
			result._intro_movie = this._intro_movie;
			result._outro_movie = this._outro_movie;
			result._event_trigger = this._event_trigger;
			result._unlock_method = this._unlock_method;
			result._is_suv_race = this._is_suv_race;
			result._is_hidden_event = this._is_hidden_event;
			result._is_drive_to_gps = this._is_drive_to_gps;
			result._event_behavior = this._event_behavior;
			result._required_spec_race_won = this._required_spec_race_won;
			result.RequiredRacesWon = this.RequiredRacesWon;
			result.RequiredSpecificURLWon = this.RequiredSpecificURLWon;
			result.RequiredURLWon = this.RequiredURLWon;
			result.SponsorChosenToUnlock = this.SponsorChosenToUnlock;
			result.EarnableRespect = this.EarnableRespect;
			result.TrackID_Stage1 = this.TrackID_Stage1;
			result.TrackID_Stage2 = this.TrackID_Stage2;
			result.TrackID_Stage3 = this.TrackID_Stage3;
			result.TrackID_Stage4 = this.TrackID_Stage4;
			result._in_reverse_stage1 = this._in_reverse_stage1;
			result._in_reverse_stage2 = this._in_reverse_stage2;
			result._in_reverse_stage3 = this._in_reverse_stage3;
			result._in_reverse_stage4 = this._in_reverse_stage4;
			result.NumLaps_Stage1 = this.NumLaps_Stage1;
			result.NumLaps_Stage2 = this.NumLaps_Stage2;
			result.NumLaps_Stage3 = this.NumLaps_Stage3;
			result.NumLaps_Stage4 = this.NumLaps_Stage4;
			result._player_car_type = this._player_car_type;
			result.CashValue = this.CashValue;
			result._event_icon_type = this._event_icon_type;
			result.DifficultyLevel = this.DifficultyLevel;
			result.BelongsToStage = this.BelongsToStage;
			result.NumMapItems = this.NumMapItems;
			result.Unknown0x3A = this.Unknown0x3A;
			result.Unknown0x3B = this.Unknown0x3B;
			result._num_of_opponents = this._num_of_opponents;
			result._num_of_stages = this._num_of_stages;
			result.UnknownDragValue = this.UnknownDragValue;
			result._gps_destination = this._gps_destination;
			result.OPPONENT1 = this.OPPONENT1.PlainCopy();
			result.OPPONENT2 = this.OPPONENT2.PlainCopy();
			result.OPPONENT3 = this.OPPONENT3.PlainCopy();
			result.OPPONENT4 = this.OPPONENT4.PlainCopy();
			result.OPPONENT5 = this.OPPONENT5.PlainCopy();
			result._padding0 = this._padding0;
			result._padding1 = this._padding1;
			result._padding2 = this._padding2;
			result._padding3 = this._padding3;
			return result;
		}
	}
}