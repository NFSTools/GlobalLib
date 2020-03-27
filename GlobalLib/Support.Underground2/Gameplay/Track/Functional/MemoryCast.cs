namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track
	{
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Reflection.Abstract.Collectable MemoryCast(string CName)
		{
			var result = new Track(CName, this.Database);

            result._difficulty_forward = this._difficulty_forward;
            result._difficulty_reverse = this._difficulty_reverse;
            result._drift_type = this._drift_type;
            result._is_looping_race = this._is_looping_race;
            result._is_performance_tuning = this._is_performance_tuning;
            result._is_valid_race = this._is_valid_race;
            result._location_directory = this._location_directory;
            result._location_index = this._location_index;
            result._location_type = this._location_type;
            result._race_descrition = this._race_descrition;
            result._race_gameplay_mode = this._race_gameplay_mode;
            result._region_directory = this._region_directory;
            result._region_name = this._region_name;
            result._reverse_version_exists = this._reverse_version_exists;
            result._sun_info_name = this._sun_info_name;
            result._track_directory = this._track_directory;
            result.CarRaceStartConfig = this.CarRaceStartConfig;
            result.RaceLength = this.RaceLength;
            result.TimeLimitToBeatForward = this.TimeLimitToBeatForward;
            result.TimeLimitToBeatReverse = this.TimeLimitToBeatReverse;
            result.ScoreToBeatDriftForward = this.ScoreToBeatDriftForward;
            result.ScoreToBeatDriftReverse = this.ScoreToBeatDriftReverse;
            result.NumSecBeforeShorcutsAllowed = this.NumSecBeforeShorcutsAllowed;
            result.DriftSecondsMax = this.DriftSecondsMax;
            result.DriftSecondsMin = this.DriftSecondsMin;
            result.TrackMapCalibrationOffsetX = this.TrackMapCalibrationOffsetX;
            result.TrackMapCalibrationOffsetY = this.TrackMapCalibrationOffsetY;
            result.TrackMapCalibrationRotation = this.TrackMapCalibrationRotation;
            result.TrackMapCalibrationWidth = this.TrackMapCalibrationWidth;
            result.TrackMapCalibrationZoomIn = this.TrackMapCalibrationZoomIn;
            result.TrackMapFinishlineAngle = this.TrackMapFinishlineAngle;
            result.TrackMapStartgridAngle = this.TrackMapStartgridAngle;
            result.MenuMapStartZoomed = this.MenuMapStartZoomed;
            result.MenuMapZoomOffsetX = this.MenuMapZoomOffsetX;
            result.MenuMapZoomOffsetY = this.MenuMapZoomOffsetY;
            result.MenuMapZoomWidth = this.MenuMapZoomWidth;
            result.MaxTrafficCars_0_0 = this.MaxTrafficCars_0_0;
            result.MaxTrafficCars_0_1 = this.MaxTrafficCars_0_1;
            result.MaxTrafficCars_1_0 = this.MaxTrafficCars_1_0;
            result.MaxTrafficCars_1_1 = this.MaxTrafficCars_1_1;
            result.MaxTrafficCars_2_0 = this.MaxTrafficCars_2_0;
            result.MaxTrafficCars_2_1 = this.MaxTrafficCars_2_1;
            result.MaxTrafficCars_3_0 = this.MaxTrafficCars_3_0;
            result.MaxTrafficCars_3_1 = this.MaxTrafficCars_3_1;
            result.TrafAllowedNearFinishline = this.TrafAllowedNearFinishline;
            result.TrafAllowedNearStartgrid = this.TrafAllowedNearStartgrid;
            result.TrafMinInitDistFromFinish = this.TrafMinInitDistFromFinish;
            result.TrafMinInitDistFromStart = this.TrafMinInitDistFromStart;
            result.TrafMinInitDistInbetweenA = this.TrafMinInitDistInbetweenA;
            result.TrafMinInitDistInbetweenB = this.TrafMinInitDistInbetweenB;
            result.TrafOncomingFraction1 = this.TrafOncomingFraction1;
            result.TrafOncomingFraction2 = this.TrafOncomingFraction2;
            result.TrafOncomingFraction3 = this.TrafOncomingFraction3;
            result.TrafOncomingFraction4 = this.TrafOncomingFraction4;

            return result;
        }
    }
}