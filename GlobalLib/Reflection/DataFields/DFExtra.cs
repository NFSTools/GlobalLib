namespace GlobalLib.Reflection.DataFields
{
    public static class DFExtra
    {
        public const string HeadlightFOV            = "HeadlightFOV";
        public const string PadHighPerformance      = "PadHighPerformance";
        public const string NumAvailableSkinNumbers = "NumAvailableSkinNumbers";
        public const string WhatGame                = "WhatGame";
        public const string ConvertibleFlag         = "ConvertibleFlag";
        public const string WheelOuterRadius        = "WheelOuterRadius";
        public const string WheelOuterRadiusMin     = "WheelOuterRadiusMin";
        public const string WheelInnerRadiusMax     = "WheelInnerRadiusMax";
        public const string HeadlightPositionX      = "HeadlightPositionX";
        public const string HeadlightPositionY      = "HeadlightPositionY";
        public const string HeadlightPositionZ      = "HeadlightPositionZ";
        public const string HeadlightPositionW      = "HeadlightPositionW";
        public const string DriverRenderingOffsetX  = "DriverRenderingOffsetX";
        public const string DriverRenderingOffsetY  = "DriverRenderingOffsetY";
        public const string DriverRenderingOffsetZ  = "DriverRenderingOffsetZ";
        public const string DriverRenderingOffsetW  = "DriverRenderingOffsetW";
        public const string SteeringWheelRenderingX = "SteeringWheelRenderingX";
        public const string SteeringWheelRenderingY = "SteeringWheelRenderingY";
        public const string SteeringWheelRenderingZ = "SteeringWheelRenderingZ";
        public const string SteeringWheelRenderingW = "SteeringWheelRenderingW"; 
        public const string MaxInstances1           = "MaxInstances1";
        public const string MaxInstances2           = "MaxInstances2";
        public const string MaxInstances3           = "MaxInstances3";
        public const string MaxInstances4           = "MaxInstances4";
        public const string MaxInstances5           = "MaxInstances5";
        public const string KeepLoaded1             = "KeepLoaded1";
        public const string KeepLoaded2             = "KeepLoaded2";
        public const string KeepLoaded3             = "KeepLoaded3";
        public const string KeepLoaded4             = "KeepLoaded4";
        public const string KeepLoaded5             = "KeepLoaded5";
        public const string MinTimeBetweenUses1     = "MinTimeBetweenUses1";
        public const string MinTimeBetweenUses2     = "MinTimeBetweenUses2";
        public const string MinTimeBetweenUses3     = "MinTimeBetweenUses3";
        public const string MinTimeBetweenUses4     = "MinTimeBetweenUses4";
        public const string MinTimeBetweenUses5     = "MinTimeBetweenUses5";
        public const string AvailableSkinNumbers1   = "AvailableSkinNumbers1";
        public const string AvailableSkinNumbers2   = "AvailableSkinNumbers2";
        public const string AvailableSkinNumbers3   = "AvailableSkinNumbers3";
        public const string AvailableSkinNumbers4   = "AvailableSkinNumbers4";
        public const string AvailableSkinNumbers5   = "AvailableSkinNumbers5";
        public const string AvailableSkinNumbers6   = "AvailableSkinNumbers6";
        public const string AvailableSkinNumbers7   = "AvailableSkinNumbers7";
        public const string AvailableSkinNumbers8   = "AvailableSkinNumbers8";
        public const string AvailableSkinNumbers9   = "AvailableSkinNumbers9";
        public const string AvailableSkinNumbers10  = "AvailableSkinNumbers10";
        public const string DefaultSkinNumber       = "DefaultSkinNumber";

        public static bool Contains(string field)
        {
            var ThisType = typeof(DFExtra);
            foreach (var ThisProperty in ThisType.GetFields())
            {
                if (ThisProperty.Name == field)
                    return true;
            }
            return false;
        }
    }
}