using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		/// <summary>
		/// Disassembles track block into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the track block.</param
		protected unsafe void Disassemble(byte* byteptr_t)
		{
			this._race_descrition = ScriptX.NullTerminatedString(byteptr_t, 0x20);
			this._track_directory = ScriptX.NullTerminatedString(byteptr_t + 0x20, 0x20);
			this._region_name = ScriptX.NullTerminatedString(byteptr_t + 0x40, 0x8);
			this._region_directory = ScriptX.NullTerminatedString(byteptr_t + 0x48, 0x20);
			this._location_index = *(int*)(byteptr_t + 0x68);
			this._location_directory = ScriptX.NullTerminatedString(byteptr_t + 0x6C, 0x10);
			this._location_type = (eLocationType)(*(int*)(byteptr_t + 0x7C));
			this._drift_type = (eDriftType)(*(int*)(byteptr_t + 0x80));
			this._is_valid_race = (*(byteptr_t + 0x84) == 0)
				? eBoolean.False
				: eBoolean.True;
			this._is_looping_race = (*(byteptr_t + 0x85) == 0)
				? eBoolean.True
				: eBoolean.False;
			this._reverse_version_exists = (*(byteptr_t + 0x86) == 0)
				? eBoolean.False
				: eBoolean.True;
			this._is_performance_tuning = (*(byteptr_t + 0x88) == 0)
				? eBoolean.False
				: eBoolean.True;
			this.TrackID = *(ushort*)(byteptr_t + 0x8A);
			uint key = *(uint*)(byteptr_t + 0x90);
			this._sun_info_name = Map.Lookup(key, true) ?? $"0x{key:X8}";
			this._race_gameplay_mode = (eRaceGameplayMode)(*(int*)(byteptr_t + 0x94));
			this.RaceLength = *(uint*)(byteptr_t + 0x98);
			this.TimeLimitToBeatForward = *(float*)(byteptr_t + 0x9C);
			this.TimeLimitToBeatReverse = *(float*)(byteptr_t + 0xA0);
			this.ScoreToBeatDriftForward = *(int*)(byteptr_t + 0xA4);
			this.ScoreToBeatDriftReverse = *(int*)(byteptr_t + 0xA8);
			this.TrackMapCalibrationOffsetX = *(float*)(byteptr_t + 0xAC);
			this.TrackMapCalibrationOffsetY = *(float*)(byteptr_t + 0xB0);
			this.TrackMapCalibrationWidth = *(float*)(byteptr_t + 0xB4);
			this.TrackMapCalibrationRotation = ((float)*(ushort*)(byteptr_t + 0xB8)) * 180 / 32768;
			this.TrackMapStartgridAngle = ((float)*(ushort*)(byteptr_t + 0xBA)) * 180 / 32768;
			this.TrackMapFinishlineAngle = ((float)*(ushort*)(byteptr_t + 0xBC)) * 180 / 32768;
			this.TrackMapCalibrationZoomIn = *(float*)(byteptr_t + 0xC0);
			this._difficulty_forward = (eTrackDifficulty)(*(int*)(byteptr_t + 0xC4));
			this._difficulty_reverse = (eTrackDifficulty)(*(int*)(byteptr_t + 0xC8));
			this.NumSecBeforeShorcutsAllowed = *(short*)(byteptr_t + 0xE4);
			this.DriftSecondsMin = *(short*)(byteptr_t + 0xE6);
			this.DriftSecondsMax = *(short*)(byteptr_t + 0xE8);
			this.MaxTrafficCars_0_0 = *(byteptr_t + 0xEC);
			this.MaxTrafficCars_0_1 = *(byteptr_t + 0xED);
			this.MaxTrafficCars_1_0 = *(byteptr_t + 0xEE);
			this.MaxTrafficCars_1_1 = *(byteptr_t + 0xEF);
			this.MaxTrafficCars_2_0 = *(byteptr_t + 0xF0);
			this.MaxTrafficCars_2_1 = *(byteptr_t + 0xF1);
			this.MaxTrafficCars_3_0 = *(byteptr_t + 0xF2);
			this.MaxTrafficCars_3_1 = *(byteptr_t + 0xF3);
			this.TrafAllowedNearStartgrid = *(byteptr_t + 0xF4);
			this.TrafAllowedNearFinishline = *(byteptr_t + 0xF5);
			this.CarRaceStartConfig = *(short*)(byteptr_t + 0xF6);
			this.TrafMinInitDistFromStart = *(float*)(byteptr_t + 0xF8);
			this.TrafMinInitDistFromFinish = *(float*)(byteptr_t + 0xFC);
			this.TrafMinInitDistInbetweenA = *(float*)(byteptr_t + 0x100);
			this.TrafMinInitDistInbetweenB = *(float*)(byteptr_t + 0x104);
			this.TrafOncomingFraction1 = *(float*)(byteptr_t + 0x108);
			this.TrafOncomingFraction2 = *(float*)(byteptr_t + 0x10C);
			this.TrafOncomingFraction3 = *(float*)(byteptr_t + 0x110);
			this.TrafOncomingFraction4 = *(float*)(byteptr_t + 0x114);
			this.MenuMapZoomOffsetX = *(float*)(byteptr_t + 0x118);
			this.MenuMapZoomOffsetY = *(float*)(byteptr_t + 0x11C);
			this.MenuMapZoomWidth = *(float*)(byteptr_t + 0x120);
			this.MenuMapStartZoomed = *(int*)(byteptr_t + 0x124);
		}
	}
}