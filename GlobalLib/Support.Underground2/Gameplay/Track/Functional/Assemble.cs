using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
		/// <summary>
		/// Assembles material into a byte array.
		/// </summary>
		/// <returns>Byte array of the material.</returns>
		public unsafe byte[] Assemble()
		{
			var result = new byte[0x128];
			fixed (byte* byteptr_t = &result[0])
			{
				for (int a1 = 0; a1 < this._race_descrition.Length; ++a1)
					*(byteptr_t + a1) = (byte)this._race_descrition[a1];
				var racedir = $"{this._location_directory}\\{this._collection_name}";
				for (int a1 = 0; a1 < racedir.Length; ++a1)
					*(byteptr_t + 0x20 + a1) = (byte)racedir[a1];
				for (int a1 = 0; a1 < this._region_name.Length; ++a1)
					*(byteptr_t + 0x40 + a1) = (byte)this._region_name[a1];
				for (int a1 = 0; a1 < this._region_directory.Length; ++a1)
					*(byteptr_t + 0x48 + a1) = (byte)this._region_directory[a1];
				for (int a1 = 0; a1 < this._location_directory.Length; ++a1)
					*(byteptr_t + 0x6C + a1) = (byte)this._location_directory[a1];
				*(int*)(byteptr_t + 0x68) = this._location_index;
				*(int*)(byteptr_t + 0x7C) = (int)this._location_type;
				*(int*)(byteptr_t + 0x80) = (int)this._drift_type;
				*(byteptr_t + 0x84) = (this._is_valid_race == eBoolean.True) ? (byte)1 : (byte)0;
				*(byteptr_t + 0x85) = (this._is_looping_race == eBoolean.True) ? (byte)0 : (byte)1;
				*(byteptr_t + 0x86) = (this._reverse_version_exists == eBoolean.True) ? (byte)1 : (byte)0;
				*(byteptr_t + 0x88) = (this._is_performance_tuning == eBoolean.True) ? (byte)1 : (byte)0;
				*(ushort*)(byteptr_t + 0x8A) = this.TrackID;
				*(ushort*)(byteptr_t + 0x8C) = this.TrackID;
				*(uint*)(byteptr_t + 0x90) = Bin.SmartHash(this._sun_info_name);
				*(int*)(byteptr_t + 0x94) = (int)this._race_gameplay_mode;
				*(uint*)(byteptr_t + 0x98) = this.RaceLength;
				*(float*)(byteptr_t + 0x9C) = this.TimeLimitToBeatForward;
				*(float*)(byteptr_t + 0xA0) = this.TimeLimitToBeatReverse;
				*(int*)(byteptr_t + 0xA4) = this.ScoreToBeatDriftForward;
				*(int*)(byteptr_t + 0xA8) = this.ScoreToBeatDriftReverse;
				*(float*)(byteptr_t + 0xAC) = this.TrackMapCalibrationOffsetX;
				*(float*)(byteptr_t + 0xB0) = this.TrackMapCalibrationOffsetY;
				*(float*)(byteptr_t + 0xB4) = this.TrackMapCalibrationWidth;
				*(ushort*)(byteptr_t + 0xB8) = (ushort)(this.TrackMapCalibrationRotation / 180 * 32768);
				*(ushort*)(byteptr_t + 0xBA) = (ushort)(this.TrackMapStartgridAngle / 180 * 32768);
				*(ushort*)(byteptr_t + 0xBC) = (ushort)(this.TrackMapFinishlineAngle / 180 * 32768);
				*(float*)(byteptr_t + 0xC0) = this.TrackMapCalibrationZoomIn;
				*(int*)(byteptr_t + 0xC4) = (int)this._difficulty_forward;
				*(int*)(byteptr_t + 0xC8) = (int)this._difficulty_reverse;
				*(int*)(byteptr_t + 0xCC) = -1;
				*(int*)(byteptr_t + 0xD0) = -1;
				*(int*)(byteptr_t + 0xD4) = -1;
				*(int*)(byteptr_t + 0xD8) = -1;
				*(int*)(byteptr_t + 0xDC) = -1;
				*(int*)(byteptr_t + 0xE0) = -1;
				*(short*)(byteptr_t + 0xE4) = this.NumSecBeforeShorcutsAllowed;
				*(short*)(byteptr_t + 0xE6) = this.DriftSecondsMin;
				*(short*)(byteptr_t + 0xE8) = this.DriftSecondsMax;
				*(byteptr_t + 0xEC) = this.MaxTrafficCars_0_0;
				*(byteptr_t + 0xED) = this.MaxTrafficCars_0_1;
				*(byteptr_t + 0xEE) = this.MaxTrafficCars_1_0;
				*(byteptr_t + 0xEF) = this.MaxTrafficCars_1_1;
				*(byteptr_t + 0xF0) = this.MaxTrafficCars_2_0;
				*(byteptr_t + 0xF1) = this.MaxTrafficCars_2_1;
				*(byteptr_t + 0xF2) = this.MaxTrafficCars_3_0;
				*(byteptr_t + 0xF3) = this.MaxTrafficCars_3_1;
				*(byteptr_t + 0xF4) = this.TrafAllowedNearStartgrid;
				*(byteptr_t + 0xF5) = this.TrafAllowedNearFinishline;
				*(short*)(byteptr_t + 0xF6) = this.CarRaceStartConfig;
				*(float*)(byteptr_t + 0xF8) = this.TrafMinInitDistFromStart;
				*(float*)(byteptr_t + 0xFC) = this.TrafMinInitDistFromFinish;
				*(float*)(byteptr_t + 0x100) = this.TrafMinInitDistInbetweenA;
				*(float*)(byteptr_t + 0x104) = this.TrafMinInitDistInbetweenB;
				*(float*)(byteptr_t + 0x108) = this.TrafOncomingFraction1;
				*(float*)(byteptr_t + 0x10C) = this.TrafOncomingFraction2;
				*(float*)(byteptr_t + 0x110) = this.TrafOncomingFraction3;
				*(float*)(byteptr_t + 0x114) = this.TrafOncomingFraction4;
				*(float*)(byteptr_t + 0x118) = this.MenuMapZoomOffsetX;
				*(float*)(byteptr_t + 0x11C) = this.MenuMapZoomOffsetY;
				*(float*)(byteptr_t + 0x120) = this.MenuMapZoomWidth;
				*(float*)(byteptr_t + 0x124) = this.MenuMapStartZoomed;
			}
			return result;
		}
	}
}