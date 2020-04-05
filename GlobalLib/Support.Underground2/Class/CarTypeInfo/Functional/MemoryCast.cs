using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            var result = new CarTypeInfo(CName, this.Database);

            result._spoiler = this._spoiler;
            result._mirrors = this._mirrors;
            result.UsageType = this.UsageType;
            result.MemoryType = this.MemoryType;
            result.IsSkinnable = this.IsSkinnable;
            result.ManufacturerName = this.ManufacturerName;
            result._defaultbasepaint = this._defaultbasepaint;
            result._defaultbasepaint2 = this._defaultbasepaint2;
            result._is_suv = this._is_suv;
            result.HeadlightFOV = this.HeadlightFOV;
            result.PadHighPerformance = this.PadHighPerformance;
            result.NumAvailableSkinNumbers = this.NumAvailableSkinNumbers;
            result.WhatGame = this.WhatGame;
            result.ConvertibleFlag = this.ConvertibleFlag;
            result.WheelOuterRadius = this.WheelOuterRadius;
            result.WheelOuterRadiusMin = this.WheelOuterRadiusMin;
            result.WheelInnerRadiusMax = this.WheelInnerRadiusMax;
            result.Padding0 = this.Padding0;
            result.HeadlightPositionX = this.HeadlightPositionX;
            result.HeadlightPositionY = this.HeadlightPositionY;
            result.HeadlightPositionZ = this.HeadlightPositionZ;
            result.HeadlightPositionW = this.HeadlightPositionW;
            result.DriverRenderingOffsetX = this.DriverRenderingOffsetX;
            result.DriverRenderingOffsetY = this.DriverRenderingOffsetY;
            result.DriverRenderingOffsetZ = this.DriverRenderingOffsetZ;
            result.DriverRenderingOffsetW = this.DriverRenderingOffsetW;
            result.SteeringWheelRenderingX = this.SteeringWheelRenderingX;
            result.SteeringWheelRenderingY = this.SteeringWheelRenderingY;
            result.SteeringWheelRenderingZ = this.SteeringWheelRenderingZ;
            result.SteeringWheelRenderingW = this.SteeringWheelRenderingW;
            result.UnknownVectorValX = this.UnknownVectorValX;
            result.UnknownVectorValY = this.UnknownVectorValY;
            result.UnknownVectorValZ = this.UnknownVectorValZ;
            result.UnknownVectorValW = this.UnknownVectorValW;
            result.MaxInstances1 = this.MaxInstances1;
            result.MaxInstances2 = this.MaxInstances2;
            result.MaxInstances3 = this.MaxInstances3;
            result.MaxInstances4 = this.MaxInstances4;
            result.MaxInstances5 = this.MaxInstances5;
            result.KeepLoaded1 = this.KeepLoaded1;
            result.KeepLoaded2 = this.KeepLoaded2;
            result.KeepLoaded3 = this.KeepLoaded3;
            result.KeepLoaded4 = this.KeepLoaded4;
            result.KeepLoaded5 = this.KeepLoaded5;
            result.Padding1 = this.Padding1;
            result.MinTimeBetweenUses1 = this.MinTimeBetweenUses1;
            result.MinTimeBetweenUses2 = this.MinTimeBetweenUses2;
            result.MinTimeBetweenUses3 = this.MinTimeBetweenUses3;
            result.MinTimeBetweenUses4 = this.MinTimeBetweenUses4;
            result.MinTimeBetweenUses5 = this.MinTimeBetweenUses5;
            result.AvailableSkinNumbers01 = this.AvailableSkinNumbers01;
            result.AvailableSkinNumbers02 = this.AvailableSkinNumbers02;
            result.AvailableSkinNumbers03 = this.AvailableSkinNumbers03;
            result.AvailableSkinNumbers04 = this.AvailableSkinNumbers04;
            result.AvailableSkinNumbers05 = this.AvailableSkinNumbers05;
            result.AvailableSkinNumbers06 = this.AvailableSkinNumbers06;
            result.AvailableSkinNumbers07 = this.AvailableSkinNumbers07;
            result.AvailableSkinNumbers08 = this.AvailableSkinNumbers08;
            result.AvailableSkinNumbers09 = this.AvailableSkinNumbers09;
            result.AvailableSkinNumbers10 = this.AvailableSkinNumbers10;
            result.DefaultSkinNumber = this.DefaultSkinNumber;
            result.Padding2 = this.Padding2;
            
            result.AI_CAMERA_BUMPER = this.AI_CAMERA_BUMPER.PlainCopy();
            result.AI_CAMERA_CLOSE = this.AI_CAMERA_CLOSE.PlainCopy();
            result.AI_CAMERA_DRIFT = this.AI_CAMERA_DRIFT.PlainCopy();
            result.AI_CAMERA_DRIVER = this.AI_CAMERA_DRIVER.PlainCopy();
            result.AI_CAMERA_FAR = this.AI_CAMERA_FAR.PlainCopy();
            result.AI_CAMERA_HOOD = this.AI_CAMERA_HOOD.PlainCopy();
            result.PLAYER_CAMERA_BUMPER = this.PLAYER_CAMERA_BUMPER.PlainCopy();
            result.PLAYER_CAMERA_CLOSE = this.PLAYER_CAMERA_CLOSE.PlainCopy();
            result.PLAYER_CAMERA_DRIFT = this.PLAYER_CAMERA_DRIFT.PlainCopy();
            result.PLAYER_CAMERA_DRIVER = this.PLAYER_CAMERA_DRIVER.PlainCopy();
            result.PLAYER_CAMERA_FAR = this.PLAYER_CAMERA_FAR.PlainCopy();
            result.PLAYER_CAMERA_HOOD = this.PLAYER_CAMERA_HOOD.PlainCopy();
            result.BASE_BRAKES = this.BASE_BRAKES.PlainCopy();
            result.BASE_ENGINE = this.BASE_ENGINE.PlainCopy();
            result.BASE_RPM = this.BASE_RPM.PlainCopy();
            result.BASE_SUSPENSION = this.BASE_SUSPENSION.PlainCopy();
            result.BASE_TIRES = this.BASE_TIRES.PlainCopy();
            result.BASE_TRANSMISSION = this.BASE_TRANSMISSION.PlainCopy();
            result.BASE_TURBO = this.BASE_TURBO.PlainCopy();
            result.DRIFT_ADD_CONTROL = this.DRIFT_ADD_CONTROL.PlainCopy();
            result.ECAR = this.ECAR.PlainCopy();
            result.PVEHICLE = this.PVEHICLE.PlainCopy();
            result.PRO_ECU = this.PRO_ECU.PlainCopy();
            result.PRO_RPM = this.PRO_RPM.PlainCopy();
            result.PRO_TRANSMISSION = this.PRO_TRANSMISSION.PlainCopy();
            result.STREET_ECU = this.STREET_ECU.PlainCopy();
            result.STREET_RPM = this.STREET_RPM.PlainCopy();
            result.STREET_TRANSMISSION = this.STREET_TRANSMISSION.PlainCopy();
            result.TOP_BRAKES = this.TOP_BRAKES.PlainCopy();
            result.TOP_ECU = this.TOP_ECU.PlainCopy();
            result.TOP_ENGINE = this.TOP_ENGINE.PlainCopy();
            result.TOP_NITROUS = this.TOP_NITROUS.PlainCopy();
            result.TOP_RPM = this.TOP_RPM.PlainCopy();
            result.TOP_SUSPENSION = this.TOP_SUSPENSION.PlainCopy();
            result.TOP_TIRES = this.TOP_TIRES.PlainCopy();
            result.TOP_TRANSMISSION = this.TOP_TRANSMISSION.PlainCopy();
            result.TOP_TURBO = this.TOP_TURBO.PlainCopy();
            result.TOP_WEIGHT_REDUCTION = this.TOP_WEIGHT_REDUCTION.PlainCopy();
            result.WHEEL_FRONT_LEFT = this.WHEEL_FRONT_LEFT.PlainCopy();
            result.WHEEL_FRONT_RIGHT = this.WHEEL_FRONT_RIGHT.PlainCopy();
            result.WHEEL_REAR_LEFT = this.WHEEL_REAR_LEFT.PlainCopy();
            result.WHEEL_REAR_RIGHT = this.WHEEL_REAR_RIGHT.PlainCopy();
            result.CARSKIN01 = this.CARSKIN01.PlainCopy();
            result.CARSKIN02 = this.CARSKIN02.PlainCopy();
            result.CARSKIN03 = this.CARSKIN03.PlainCopy();
            result.CARSKIN04 = this.CARSKIN04.PlainCopy();
            result.CARSKIN05 = this.CARSKIN05.PlainCopy();
            result.CARSKIN06 = this.CARSKIN06.PlainCopy();
            result.CARSKIN07 = this.CARSKIN07.PlainCopy();
            result.CARSKIN08 = this.CARSKIN08.PlainCopy();

            return result;
        }
    }
}