namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public CarTypeInfo MemoryCast(string CName)
        {
            var result = new CarTypeInfo(CName);

            result._spoiler = this._spoiler;
            result._spoilerAS = this._spoilerAS;
            result.CollisionExternalName = result.CollectionName;
            result.CollisionInternalName = this.CollisionInternalName;
            result.UsageType = this.UsageType;
            result.MemoryType = this.MemoryType;
            result.IsSkinnable = this.IsSkinnable;
            result.ManufacturerName = this.ManufacturerName;
            result.DefaultBasePaint = this.DefaultBasePaint;
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
            result.AvailableSkinNumbers1 = this.AvailableSkinNumbers1;
            result.AvailableSkinNumbers2 = this.AvailableSkinNumbers2;
            result.AvailableSkinNumbers3 = this.AvailableSkinNumbers3;
            result.AvailableSkinNumbers4 = this.AvailableSkinNumbers4;
            result.AvailableSkinNumbers5 = this.AvailableSkinNumbers5;
            result.AvailableSkinNumbers6 = this.AvailableSkinNumbers6;
            result.AvailableSkinNumbers7 = this.AvailableSkinNumbers7;
            result.AvailableSkinNumbers8 = this.AvailableSkinNumbers8;
            result.AvailableSkinNumbers9 = this.AvailableSkinNumbers9;
            result.AvailableSkinNumbers10 = this.AvailableSkinNumbers10;
            result.DefaultSkinNumber = this.DefaultSkinNumber;
            result.Padding2 = this.Padding2;

            Core.Map.BinKeys[result.BinKey] = CName;
            return result;
        }
    }
}