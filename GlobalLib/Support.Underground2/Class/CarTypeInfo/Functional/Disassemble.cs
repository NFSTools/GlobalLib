using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the cartypeinfo array.</param
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            // Manufacturer name
            this.ManufacturerName = ScriptX.NullTerminatedString(byteptr_t + 0xC0, 0x10);

            // Secondary Properties
            this.HeadlightFOV = *(float*)(byteptr_t + 0xD4);
            this.PadHighPerformance = *(byteptr_t + 0xD8);
            this.NumAvailableSkinNumbers = *(byteptr_t + 0xD9);
            this.WhatGame = *(byteptr_t + 0xDA);
            this.ConvertibleFlag = *(byteptr_t + 0xDB);
            this.WheelOuterRadius = *(byteptr_t + 0xDC);
            this.WheelOuterRadiusMin = *(byteptr_t + 0xDD);
            this.WheelInnerRadiusMax = *(byteptr_t + 0xDE);
            this.Padding0 = *(byteptr_t + 0xDF);

            // Vectors
            this.HeadlightPositionX = *(float*)(byteptr_t + 0xE0);
            this.HeadlightPositionY = *(float*)(byteptr_t + 0xE4);
            this.HeadlightPositionZ = *(float*)(byteptr_t + 0xE8);
            this.HeadlightPositionW = *(float*)(byteptr_t + 0xEC);
            this.DriverRenderingOffsetX = *(float*)(byteptr_t + 0xF0);
            this.DriverRenderingOffsetY = *(float*)(byteptr_t + 0xF4);
            this.DriverRenderingOffsetZ = *(float*)(byteptr_t + 0xF8);
            this.DriverRenderingOffsetW = *(float*)(byteptr_t + 0xFC);
            this.SteeringWheelRenderingX = *(float*)(byteptr_t + 0x100);
            this.SteeringWheelRenderingY = *(float*)(byteptr_t + 0x104);
            this.SteeringWheelRenderingZ = *(float*)(byteptr_t + 0x108);
            this.SteeringWheelRenderingW = *(float*)(byteptr_t + 0x10C);
            this.UnknownVectorValX = *(float*)(byteptr_t + 0x110);
            this.UnknownVectorValY = *(float*)(byteptr_t + 0x114);
            this.UnknownVectorValZ = *(float*)(byteptr_t + 0x118);
            this.UnknownVectorValW = *(float*)(byteptr_t + 0x11C);

            // Front Left Wheel
            this.WHEEL_FRONT_LEFT.XValue = *(float*)(byteptr_t + 0x120);
            this.WHEEL_FRONT_LEFT.Springs = *(float*)(byteptr_t + 0x124);
            this.WHEEL_FRONT_LEFT.RideHeight = *(float*)(byteptr_t + 0x128);
            this.WHEEL_FRONT_LEFT.UnknownVal = *(float*)(byteptr_t + 0x12C);
            this.WHEEL_FRONT_LEFT.Diameter = *(float*)(byteptr_t + 0x130);
            this.WHEEL_FRONT_LEFT.TireSkidWidth = *(float*)(byteptr_t + 0x134);
            this.WHEEL_FRONT_LEFT.WheelID = *(int*)(byteptr_t + 0x138);
            this.WHEEL_FRONT_LEFT.YValue = *(float*)(byteptr_t + 0x13C);
            this.WHEEL_FRONT_LEFT.WideBodyYValue = *(float*)(byteptr_t + 0x140);

            // Front Left Wheel
            this.WHEEL_FRONT_RIGHT.XValue = *(float*)(byteptr_t + 0x150);
            this.WHEEL_FRONT_RIGHT.Springs = *(float*)(byteptr_t + 0x154);
            this.WHEEL_FRONT_RIGHT.RideHeight = *(float*)(byteptr_t + 0x158);
            this.WHEEL_FRONT_RIGHT.UnknownVal = *(float*)(byteptr_t + 0x15C);
            this.WHEEL_FRONT_RIGHT.Diameter = *(float*)(byteptr_t + 0x160);
            this.WHEEL_FRONT_RIGHT.TireSkidWidth = *(float*)(byteptr_t + 0x164);
            this.WHEEL_FRONT_RIGHT.WheelID = *(int*)(byteptr_t + 0x168);
            this.WHEEL_FRONT_RIGHT.YValue = *(float*)(byteptr_t + 0x16C);
            this.WHEEL_FRONT_RIGHT.WideBodyYValue = *(float*)(byteptr_t + 0x170);

            // Front Left Wheel
            this.WHEEL_REAR_RIGHT.XValue = *(float*)(byteptr_t + 0x180);
            this.WHEEL_REAR_RIGHT.Springs = *(float*)(byteptr_t + 0x184);
            this.WHEEL_REAR_RIGHT.RideHeight = *(float*)(byteptr_t + 0x188);
            this.WHEEL_REAR_RIGHT.UnknownVal = *(float*)(byteptr_t + 0x18C);
            this.WHEEL_REAR_RIGHT.Diameter = *(float*)(byteptr_t + 0x190);
            this.WHEEL_REAR_RIGHT.TireSkidWidth = *(float*)(byteptr_t + 0x194);
            this.WHEEL_REAR_RIGHT.WheelID = *(int*)(byteptr_t + 0x198);
            this.WHEEL_REAR_RIGHT.YValue = *(float*)(byteptr_t + 0x19C);
            this.WHEEL_REAR_RIGHT.WideBodyYValue = *(float*)(byteptr_t + 0x1A0);

            // Front Left Wheel
            this.WHEEL_REAR_LEFT.XValue = *(float*)(byteptr_t + 0x1B0);
            this.WHEEL_REAR_LEFT.Springs = *(float*)(byteptr_t + 0x1B4);
            this.WHEEL_REAR_LEFT.RideHeight = *(float*)(byteptr_t + 0x1B8);
            this.WHEEL_REAR_LEFT.UnknownVal = *(float*)(byteptr_t + 0x1BC);
            this.WHEEL_REAR_LEFT.Diameter = *(float*)(byteptr_t + 0x1C0);
            this.WHEEL_REAR_LEFT.TireSkidWidth = *(float*)(byteptr_t + 0x1C4);
            this.WHEEL_REAR_LEFT.WheelID = *(int*)(byteptr_t + 0x1C8);
            this.WHEEL_REAR_LEFT.YValue = *(float*)(byteptr_t + 0x1CC);
            this.WHEEL_REAR_LEFT.WideBodyYValue = *(float*)(byteptr_t + 0x1D0);

            // Base Tires Performance
            this.BASE_TIRES.StaticGripScale = *(float*)(byteptr_t + 0x1E0);
            this.BASE_TIRES.YawSpeedScale = *(float*)(byteptr_t + 0x1E4);
            this.BASE_TIRES.SteeringAmplifier = *(float*)(byteptr_t + 0x1E8);
            this.BASE_TIRES.DynamicGripScale = *(float*)(byteptr_t + 0x1EC);
            this.BASE_TIRES.SteeringResponse = *(float*)(byteptr_t + 0x1F0);
            this.BASE_TIRES.DriftYawControl = *(float*)(byteptr_t + 0x200);
            this.BASE_TIRES.DriftCounterSteerBuildUp = *(float*)(byteptr_t + 0x204);
            this.BASE_TIRES.DriftCounterSteerReduction = *(float*)(byteptr_t + 0x208);
            this.BASE_TIRES.PowerSlideBreakThru1 = *(float*)(byteptr_t + 0x20C);
            this.BASE_TIRES.PowerSlideBreakThru2 = *(float*)(byteptr_t + 0x210);

            // Pvehicle Values
            this.PVEHICLE.Massx1000Multiplier = *(float*)(byteptr_t + 0x220);
            this.PVEHICLE.TensorScaleX = *(float*)(byteptr_t + 0x224);
            this.PVEHICLE.TensorScaleY = *(float*)(byteptr_t + 0x228);
            this.PVEHICLE.TensorScaleZ = *(float*)(byteptr_t + 0x22C);
            this.PVEHICLE.TensorScaleW = *(float*)(byteptr_t + 0x230);
            this.PVEHICLE.InitialHandlingRating = *(float*)(byteptr_t + 0x270);
            this.PVEHICLE.TopSpeedUnderflow = *(float*)(byteptr_t + 0x370);
            this.PVEHICLE.StockTopSpeedLimiter = *(float*)(byteptr_t + 0x3A0);
            
            // Ecar Values
            this.ECAR.EcarUnknown1 = *(float*)(byteptr_t + 0x244);
            this.ECAR.EcarUnknown2 = *(float*)(byteptr_t + 0x258);
            this.ECAR.HandlingBuffer = *(float*)(byteptr_t + 0x710);
            this.ECAR.TopSuspFrontHeightReduce = *(float*)(byteptr_t + 0x714);
            this.ECAR.TopSuspRearHeightReduce = *(float*)(byteptr_t + 0x718);
            this.ECAR.NumPlayerCameras = *(int*)(byteptr_t + 0x720);
            this.ECAR.NumAICameras = *(int*)(byteptr_t + 0x724);
            this.ECAR.Cost = *(int*)(byteptr_t + 0x87C);

            // Base Suspension Performance
            this.BASE_SUSPENSION.ShockStiffnessFront = *(float*)(byteptr_t + 0x280);
            this.BASE_SUSPENSION.ShockExtStiffnessFront = *(float*)(byteptr_t + 0x284);
            this.BASE_SUSPENSION.SpringProgressionFront = *(float*)(byteptr_t + 0x288);
            this.BASE_SUSPENSION.ShockValvingFront = *(float*)(byteptr_t + 0x28C);
            this.BASE_SUSPENSION.SwayBarFront = *(float*)(byteptr_t + 0x290);
            this.BASE_SUSPENSION.TrackWidthFront = *(float*)(byteptr_t + 0x294);
            this.BASE_SUSPENSION.CounterBiasFront = *(float*)(byteptr_t + 0x298);
            this.BASE_SUSPENSION.ShockDigressionFront = *(float*)(byteptr_t + 0x29C);
            this.BASE_SUSPENSION.ShockStiffnessRear = *(float*)(byteptr_t + 0x2A0);
            this.BASE_SUSPENSION.ShockExtStiffnessRear = *(float*)(byteptr_t + 0x2A4);
            this.BASE_SUSPENSION.SpringProgressionRear = *(float*)(byteptr_t + 0x2A8);
            this.BASE_SUSPENSION.ShockValvingRear = *(float*)(byteptr_t + 0x2AC);
            this.BASE_SUSPENSION.SwayBarRear = *(float*)(byteptr_t + 0x2B0);
            this.BASE_SUSPENSION.TrackWidthRear = *(float*)(byteptr_t + 0x2B4);
            this.BASE_SUSPENSION.CounterBiasRear = *(float*)(byteptr_t + 0x2B8);
            this.BASE_SUSPENSION.ShockDigressionRear = *(float*)(byteptr_t + 0x2BC);

            // Base Transmission Performance
            this.BASE_TRANSMISSION.ClutchSlip = *(float*)(byteptr_t + 0x2C0);
            this.BASE_TRANSMISSION.OptimalShift = *(float*)(byteptr_t + 0x2C4);
            this.BASE_TRANSMISSION.FinalDriveRatio = *(float*)(byteptr_t + 0x2C8);
            this.BASE_TRANSMISSION.FinalDriveRatio2 = *(float*)(byteptr_t + 0x2CC);
            this.BASE_TRANSMISSION.TorqueSplit = *(float*)(byteptr_t + 0x2D0);
            this.BASE_TRANSMISSION.BurnoutStrength = *(float*)(byteptr_t + 0x2D4);
            this.BASE_TRANSMISSION.NumberOfGears = *(int*)(byteptr_t + 0x2D8);
            this.BASE_TRANSMISSION.GearEfficiency = *(float*)(byteptr_t + 0x2DC);
            this.BASE_TRANSMISSION.GearRatioR = *(float*)(byteptr_t + 0x2E0);
            this.BASE_TRANSMISSION.GearRatioN = *(float*)(byteptr_t + 0x2E4);
            this.BASE_TRANSMISSION.GearRatio1 = *(float*)(byteptr_t + 0x2E8);
            this.BASE_TRANSMISSION.GearRatio2 = *(float*)(byteptr_t + 0x2EC);
            this.BASE_TRANSMISSION.GearRatio3 = *(float*)(byteptr_t + 0x2F0);
            this.BASE_TRANSMISSION.GearRatio4 = *(float*)(byteptr_t + 0x2F4);
            this.BASE_TRANSMISSION.GearRatio5 = *(float*)(byteptr_t + 0x2F8);
            this.BASE_TRANSMISSION.GearRatio6 = *(float*)(byteptr_t + 0x2FC);

            // Base RPM Performance
            this.BASE_RPM.IdleRPMAdd = *(float*)(byteptr_t + 0x300);
            this.BASE_RPM.RedLineRPMAdd = *(float*)(byteptr_t + 0x304);
            this.BASE_RPM.MaxRPMAdd = *(float*)(byteptr_t + 0x308);

            // Base Engine Performance
            this.BASE_ENGINE.SpeedRefreshRate = *(float*)(byteptr_t + 0x30C);
            this.BASE_ENGINE.EngineTorque1 = *(float*)(byteptr_t + 0x310);
            this.BASE_ENGINE.EngineTorque2 = *(float*)(byteptr_t + 0x314);
            this.BASE_ENGINE.EngineTorque3 = *(float*)(byteptr_t + 0x318);
            this.BASE_ENGINE.EngineTorque4 = *(float*)(byteptr_t + 0x31C);
            this.BASE_ENGINE.EngineTorque5 = *(float*)(byteptr_t + 0x320);
            this.BASE_ENGINE.EngineTorque6 = *(float*)(byteptr_t + 0x324);
            this.BASE_ENGINE.EngineTorque7 = *(float*)(byteptr_t + 0x328);
            this.BASE_ENGINE.EngineTorque8 = *(float*)(byteptr_t + 0x32C);
            this.BASE_ENGINE.EngineTorque9 = *(float*)(byteptr_t + 0x330);
            this.BASE_ENGINE.EngineBraking1 = *(float*)(byteptr_t + 0x334);
            this.BASE_ENGINE.EngineBraking2 = *(float*)(byteptr_t + 0x338);
            this.BASE_ENGINE.EngineBraking3 = *(float*)(byteptr_t + 0x33C);

            // Base Turbo Performance
            this.BASE_TURBO.TurboBraking = *(float*)(byteptr_t + 0x340);
            this.BASE_TURBO.TurboVacuum = *(float*)(byteptr_t + 0x344);
            this.BASE_TURBO.TurboHeatHigh = *(float*)(byteptr_t + 0x348);
            this.BASE_TURBO.TurboHeatLow = *(float*)(byteptr_t + 0x34C);
            this.BASE_TURBO.TurboHighBoost = *(float*)(byteptr_t + 0x350);
            this.BASE_TURBO.TurboLowBoost = *(float*)(byteptr_t + 0x354);
            this.BASE_TURBO.TurboSpool = *(float*)(byteptr_t + 0x358);
            this.BASE_TURBO.TurboSpoolTimeDown = *(float*)(byteptr_t + 0x35C);
            this.BASE_TURBO.TurboSpoolTimeUp = *(float*)(byteptr_t + 0x360);

            // Base Brakes Performance
            this.BASE_BRAKES.FrontDownForce = *(float*)(byteptr_t + 0x374);
            this.BASE_BRAKES.RearDownForce = *(float*)(byteptr_t + 0x378);
            this.BASE_BRAKES.BumpJumpForce = *(float*)(byteptr_t + 0x37C);
            this.BASE_BRAKES.SteeringRatio = *(float*)(byteptr_t + 0x380);
            this.BASE_BRAKES.BrakeStrength = *(float*)(byteptr_t + 0x384);
            this.BASE_BRAKES.HandBrakeStrength = *(float*)(byteptr_t + 0x388);
            this.BASE_BRAKES.BrakeBias = *(float*)(byteptr_t + 0x38C);

            // DriftAdditionalYawControl Performance
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl1 = *(float*)(byteptr_t + 0x3C0);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl2 = *(float*)(byteptr_t + 0x3C4);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl3 = *(float*)(byteptr_t + 0x3C8);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl4 = *(float*)(byteptr_t + 0x3CC);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl5 = *(float*)(byteptr_t + 0x3D0);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl6 = *(float*)(byteptr_t + 0x3D4);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl7 = *(float*)(byteptr_t + 0x3D8);
            this.DRIFT_ADD_CONTROL.DriftAdditionalYawControl8 = *(float*)(byteptr_t + 0x3DC);

            // Skip Street + Pro Engine and Street Turbo, 0x03E0 - 0x0450

            // Top Weight Reduction Performance
            this.TOP_WEIGHT_REDUCTION.WeightReductionMassMultiplier = *(float*)(byteptr_t + 0x450);
            this.TOP_WEIGHT_REDUCTION.WeightReductionGripAddon = *(float*)(byteptr_t + 0x454);
            this.TOP_WEIGHT_REDUCTION.WeightReductionHandlingRating = *(float*)(byteptr_t + 0x458);

            // Street Transmission Performance
            this.STREET_TRANSMISSION.ClutchSlip = *(float*)(byteptr_t + 0x460);
            this.STREET_TRANSMISSION.OptimalShift = *(float*)(byteptr_t + 0x464);
            this.STREET_TRANSMISSION.FinalDriveRatio = *(float*)(byteptr_t + 0x468);
            this.STREET_TRANSMISSION.FinalDriveRatio2 = *(float*)(byteptr_t + 0x46C);
            this.STREET_TRANSMISSION.TorqueSplit = *(float*)(byteptr_t + 0x470);
            this.STREET_TRANSMISSION.BurnoutStrength = *(float*)(byteptr_t + 0x474);
            this.STREET_TRANSMISSION.NumberOfGears = *(int*)(byteptr_t + 0x478);
            this.STREET_TRANSMISSION.GearEfficiency = *(float*)(byteptr_t + 0x47C);
            this.STREET_TRANSMISSION.GearRatioR = *(float*)(byteptr_t + 0x480);
            this.STREET_TRANSMISSION.GearRatioN = *(float*)(byteptr_t + 0x484);
            this.STREET_TRANSMISSION.GearRatio1 = *(float*)(byteptr_t + 0x488);
            this.STREET_TRANSMISSION.GearRatio2 = *(float*)(byteptr_t + 0x48C);
            this.STREET_TRANSMISSION.GearRatio3 = *(float*)(byteptr_t + 0x490);
            this.STREET_TRANSMISSION.GearRatio4 = *(float*)(byteptr_t + 0x494);
            this.STREET_TRANSMISSION.GearRatio5 = *(float*)(byteptr_t + 0x498);
            this.STREET_TRANSMISSION.GearRatio6 = *(float*)(byteptr_t + 0x49C);

            // Pro Transmission Performance
            this.PRO_TRANSMISSION.ClutchSlip = *(float*)(byteptr_t + 0x4A0);
            this.PRO_TRANSMISSION.OptimalShift = *(float*)(byteptr_t + 0x4A4);
            this.PRO_TRANSMISSION.FinalDriveRatio = *(float*)(byteptr_t + 0x4A8);
            this.PRO_TRANSMISSION.FinalDriveRatio2 = *(float*)(byteptr_t + 0x4AC);
            this.PRO_TRANSMISSION.TorqueSplit = *(float*)(byteptr_t + 0x4B0);
            this.PRO_TRANSMISSION.BurnoutStrength = *(float*)(byteptr_t + 0x4B4);
            this.PRO_TRANSMISSION.NumberOfGears = *(int*)(byteptr_t + 0x4B8);
            this.PRO_TRANSMISSION.GearEfficiency = *(float*)(byteptr_t + 0x4BC);
            this.PRO_TRANSMISSION.GearRatioR = *(float*)(byteptr_t + 0x4C0);
            this.PRO_TRANSMISSION.GearRatioN = *(float*)(byteptr_t + 0x4C4);
            this.PRO_TRANSMISSION.GearRatio1 = *(float*)(byteptr_t + 0x4C8);
            this.PRO_TRANSMISSION.GearRatio2 = *(float*)(byteptr_t + 0x4CC);
            this.PRO_TRANSMISSION.GearRatio3 = *(float*)(byteptr_t + 0x4D0);
            this.PRO_TRANSMISSION.GearRatio4 = *(float*)(byteptr_t + 0x4D4);
            this.PRO_TRANSMISSION.GearRatio5 = *(float*)(byteptr_t + 0x4D8);
            this.PRO_TRANSMISSION.GearRatio6 = *(float*)(byteptr_t + 0x4DC);

            // Top Transmission Performance
            this.TOP_TRANSMISSION.ClutchSlip = *(float*)(byteptr_t + 0x4E0);
            this.TOP_TRANSMISSION.OptimalShift = *(float*)(byteptr_t + 0x4E4);
            this.TOP_TRANSMISSION.FinalDriveRatio = *(float*)(byteptr_t + 0x4E8);
            this.TOP_TRANSMISSION.FinalDriveRatio2 = *(float*)(byteptr_t + 0x4EC);
            this.TOP_TRANSMISSION.TorqueSplit = *(float*)(byteptr_t + 0x4F0);
            this.TOP_TRANSMISSION.BurnoutStrength = *(float*)(byteptr_t + 0x4F4);
            this.TOP_TRANSMISSION.NumberOfGears = *(int*)(byteptr_t + 0x4F8);
            this.TOP_TRANSMISSION.GearEfficiency = *(float*)(byteptr_t + 0x4FC);
            this.TOP_TRANSMISSION.GearRatioR = *(float*)(byteptr_t + 0x500);
            this.TOP_TRANSMISSION.GearRatioN = *(float*)(byteptr_t + 0x504);
            this.TOP_TRANSMISSION.GearRatio1 = *(float*)(byteptr_t + 0x508);
            this.TOP_TRANSMISSION.GearRatio2 = *(float*)(byteptr_t + 0x50C);
            this.TOP_TRANSMISSION.GearRatio3 = *(float*)(byteptr_t + 0x510);
            this.TOP_TRANSMISSION.GearRatio4 = *(float*)(byteptr_t + 0x514);
            this.TOP_TRANSMISSION.GearRatio5 = *(float*)(byteptr_t + 0x518);
            this.TOP_TRANSMISSION.GearRatio6 = *(float*)(byteptr_t + 0x51C);

            // Top Engine Performance
            this.TOP_ENGINE.SpeedRefreshRate = *(float*)(byteptr_t + 0x52C);
            this.TOP_ENGINE.EngineTorque1 = *(float*)(byteptr_t + 0x530);
            this.TOP_ENGINE.EngineTorque2 = *(float*)(byteptr_t + 0x534);
            this.TOP_ENGINE.EngineTorque3 = *(float*)(byteptr_t + 0x538);
            this.TOP_ENGINE.EngineTorque4 = *(float*)(byteptr_t + 0x53C);
            this.TOP_ENGINE.EngineTorque5 = *(float*)(byteptr_t + 0x540);
            this.TOP_ENGINE.EngineTorque6 = *(float*)(byteptr_t + 0x544);
            this.TOP_ENGINE.EngineTorque7 = *(float*)(byteptr_t + 0x548);
            this.TOP_ENGINE.EngineTorque8 = *(float*)(byteptr_t + 0x54C);
            this.TOP_ENGINE.EngineTorque9 = *(float*)(byteptr_t + 0x550);
            this.TOP_ENGINE.EngineBraking1 = *(float*)(byteptr_t + 0x554);
            this.TOP_ENGINE.EngineBraking2 = *(float*)(byteptr_t + 0x558);
            this.TOP_ENGINE.EngineBraking3 = *(float*)(byteptr_t + 0x55C);

            // Street RPM Performance
            this.STREET_RPM.IdleRPMAdd = *(float*)(byteptr_t + 0x560);
            this.STREET_RPM.RedLineRPMAdd = *(float*)(byteptr_t + 0x564);
            this.STREET_RPM.MaxRPMAdd = *(float*)(byteptr_t + 0x568);

            // Street ECU Performance
            this.STREET_ECU.ECUx1000Add = *(float*)(byteptr_t + 0x570);
            this.STREET_ECU.ECUx2000Add = *(float*)(byteptr_t + 0x574);
            this.STREET_ECU.ECUx3000Add = *(float*)(byteptr_t + 0x578);
            this.STREET_ECU.ECUx4000Add = *(float*)(byteptr_t + 0x57C);
            this.STREET_ECU.ECUx5000Add = *(float*)(byteptr_t + 0x580);
            this.STREET_ECU.ECUx6000Add = *(float*)(byteptr_t + 0x584);
            this.STREET_ECU.ECUx7000Add = *(float*)(byteptr_t + 0x588);
            this.STREET_ECU.ECUx8000Add = *(float*)(byteptr_t + 0x58C);
            this.STREET_ECU.ECUx9000Add = *(float*)(byteptr_t + 0x590);
            this.STREET_ECU.ECUx10000Add = *(float*)(byteptr_t + 0x594);
            this.STREET_ECU.ECUx11000Add = *(float*)(byteptr_t + 0x598);
            this.STREET_ECU.ECUx12000Add = *(float*)(byteptr_t + 0x59C);

            // Pro RPM Performance
            this.PRO_RPM.IdleRPMAdd = *(float*)(byteptr_t + 0x5A0);
            this.PRO_RPM.RedLineRPMAdd = *(float*)(byteptr_t + 0x5A4);
            this.PRO_RPM.MaxRPMAdd = *(float*)(byteptr_t + 0x5A8);

            // Pro ECU Performance
            this.PRO_ECU.ECUx1000Add = *(float*)(byteptr_t + 0x5B0);
            this.PRO_ECU.ECUx2000Add = *(float*)(byteptr_t + 0x5B4);
            this.PRO_ECU.ECUx3000Add = *(float*)(byteptr_t + 0x5B8);
            this.PRO_ECU.ECUx4000Add = *(float*)(byteptr_t + 0x5BC);
            this.PRO_ECU.ECUx5000Add = *(float*)(byteptr_t + 0x5C0);
            this.PRO_ECU.ECUx6000Add = *(float*)(byteptr_t + 0x5C4);
            this.PRO_ECU.ECUx7000Add = *(float*)(byteptr_t + 0x5C8);
            this.PRO_ECU.ECUx8000Add = *(float*)(byteptr_t + 0x5CC);
            this.PRO_ECU.ECUx9000Add = *(float*)(byteptr_t + 0x5D0);
            this.PRO_ECU.ECUx10000Add = *(float*)(byteptr_t + 0x5D4);
            this.PRO_ECU.ECUx11000Add = *(float*)(byteptr_t + 0x5D8);
            this.PRO_ECU.ECUx12000Add = *(float*)(byteptr_t + 0x5DC);

            // Top RPM Performance
            this.TOP_RPM.IdleRPMAdd = *(float*)(byteptr_t + 0x5E0);
            this.TOP_RPM.RedLineRPMAdd = *(float*)(byteptr_t + 0x5E4);
            this.TOP_RPM.MaxRPMAdd = *(float*)(byteptr_t + 0x5E8);

            // Top ECU Performance
            this.TOP_ECU.ECUx1000Add = *(float*)(byteptr_t + 0x5F0);
            this.TOP_ECU.ECUx2000Add = *(float*)(byteptr_t + 0x5F4);
            this.TOP_ECU.ECUx3000Add = *(float*)(byteptr_t + 0x5F8);
            this.TOP_ECU.ECUx4000Add = *(float*)(byteptr_t + 0x5FC);
            this.TOP_ECU.ECUx5000Add = *(float*)(byteptr_t + 0x600);
            this.TOP_ECU.ECUx6000Add = *(float*)(byteptr_t + 0x604);
            this.TOP_ECU.ECUx7000Add = *(float*)(byteptr_t + 0x608);
            this.TOP_ECU.ECUx8000Add = *(float*)(byteptr_t + 0x60C);
            this.TOP_ECU.ECUx9000Add = *(float*)(byteptr_t + 0x610);
            this.TOP_ECU.ECUx10000Add = *(float*)(byteptr_t + 0x614);
            this.TOP_ECU.ECUx11000Add = *(float*)(byteptr_t + 0x618);
            this.TOP_ECU.ECUx12000Add = *(float*)(byteptr_t + 0x61C);

            // Top Turbo Performance
            this.TOP_TURBO.TurboBraking = *(float*)(byteptr_t + 0x620);
            this.TOP_TURBO.TurboVacuum = *(float*)(byteptr_t + 0x624);
            this.TOP_TURBO.TurboHeatHigh = *(float*)(byteptr_t + 0x628);
            this.TOP_TURBO.TurboHeatLow = *(float*)(byteptr_t + 0x62C);
            this.TOP_TURBO.TurboHighBoost = *(float*)(byteptr_t + 0x630);
            this.TOP_TURBO.TurboLowBoost = *(float*)(byteptr_t + 0x634);
            this.TOP_TURBO.TurboSpool = *(float*)(byteptr_t + 0x638);
            this.TOP_TURBO.TurboSpoolTimeDown = *(float*)(byteptr_t + 0x63C);
            this.TOP_TURBO.TurboSpoolTimeUp = *(float*)(byteptr_t + 0x640);

            // Top Tires Performance
            this.TOP_TIRES.StaticGripScale = *(float*)(byteptr_t + 0x650);
            this.TOP_TIRES.YawSpeedScale = *(float*)(byteptr_t + 0x654);
            this.TOP_TIRES.SteeringAmplifier = *(float*)(byteptr_t + 0x658);
            this.TOP_TIRES.DynamicGripScale = *(float*)(byteptr_t + 0x65C);
            this.TOP_TIRES.SteeringResponse = *(float*)(byteptr_t + 0x660);
            this.TOP_TIRES.DriftYawControl = *(float*)(byteptr_t + 0x670);
            this.TOP_TIRES.DriftCounterSteerBuildUp = *(float*)(byteptr_t + 0x674);
            this.TOP_TIRES.DriftCounterSteerReduction = *(float*)(byteptr_t + 0x678);
            this.TOP_TIRES.PowerSlideBreakThru1 = *(float*)(byteptr_t + 0x67C);
            this.TOP_TIRES.PowerSlideBreakThru2 = *(float*)(byteptr_t + 0x680);

            // Top Nitrous Performance
            this.TOP_NITROUS.NOSCapacity = *(float*)(byteptr_t + 0x690);
            this.TOP_NITROUS.NOSTorqueBoost = *(float*)(byteptr_t + 0x69C);

            // Top Brakes Performance
            this.TOP_BRAKES.FrontDownForce = *(float*)(byteptr_t + 0x6B0);
            this.TOP_BRAKES.RearDownForce = *(float*)(byteptr_t + 0x6B4);
            this.TOP_BRAKES.BumpJumpForce = *(float*)(byteptr_t + 0x6B8);
            this.TOP_BRAKES.BrakeStrength = *(float*)(byteptr_t + 0x6C0);
            this.TOP_BRAKES.HandBrakeStrength = *(float*)(byteptr_t + 0x6C4);
            this.TOP_BRAKES.BrakeBias = *(float*)(byteptr_t + 0x6C8);
            this.TOP_BRAKES.SteeringRatio = *(float*)(byteptr_t + 0x6CC);

            // Top Suspension Performance
            this.TOP_SUSPENSION.ShockStiffnessFront = *(float*)(byteptr_t + 0x6D0);
            this.TOP_SUSPENSION.ShockExtStiffnessFront = *(float*)(byteptr_t + 0x6D4);
            this.TOP_SUSPENSION.SpringProgressionFront = *(float*)(byteptr_t + 0x6D8);
            this.TOP_SUSPENSION.ShockValvingFront = *(float*)(byteptr_t + 0x6DC);
            this.TOP_SUSPENSION.SwayBarFront = *(float*)(byteptr_t + 0x6E0);
            this.TOP_SUSPENSION.TrackWidthFront = *(float*)(byteptr_t + 0x6E4);
            this.TOP_SUSPENSION.CounterBiasFront = *(float*)(byteptr_t + 0x6E8);
            this.TOP_SUSPENSION.ShockDigressionFront = *(float*)(byteptr_t + 0x6EC);
            this.TOP_SUSPENSION.ShockStiffnessRear = *(float*)(byteptr_t + 0x6F0);
            this.TOP_SUSPENSION.ShockExtStiffnessRear = *(float*)(byteptr_t + 0x6F4);
            this.TOP_SUSPENSION.SpringProgressionRear = *(float*)(byteptr_t + 0x6F8);
            this.TOP_SUSPENSION.ShockValvingRear = *(float*)(byteptr_t + 0x6FC);
            this.TOP_SUSPENSION.SwayBarRear = *(float*)(byteptr_t + 0x700);
            this.TOP_SUSPENSION.TrackWidthRear = *(float*)(byteptr_t + 0x704);
            this.TOP_SUSPENSION.CounterBiasRear = *(float*)(byteptr_t + 0x708);
            this.TOP_SUSPENSION.ShockDigressionRear = *(float*)(byteptr_t + 0x70C);

            // Player Cameras
            this.PLAYER_CAMERA_FAR.CameraAngle = ((float)*(short*)(byteptr_t + 0x732)) * 180 / 32768; 
            this.PLAYER_CAMERA_FAR.CameraLag = *(float*)(byteptr_t + 0x734);
            this.PLAYER_CAMERA_FAR.CameraHeight = *(float*)(byteptr_t + 0x738);
            this.PLAYER_CAMERA_FAR.CameraLatOffset = *(float*)(byteptr_t + 0x73C);
            this.PLAYER_CAMERA_CLOSE.CameraAngle = ((float)*(short*)(byteptr_t + 0x742)) * 180 / 32768;
            this.PLAYER_CAMERA_CLOSE.CameraLag = *(float*)(byteptr_t + 0x744);
            this.PLAYER_CAMERA_CLOSE.CameraHeight = *(float*)(byteptr_t + 0x748);
            this.PLAYER_CAMERA_CLOSE.CameraLatOffset = *(float*)(byteptr_t + 0x74C);
            this.PLAYER_CAMERA_BUMPER.CameraAngle = ((float)*(short*)(byteptr_t + 0x752)) * 180 / 32768;
            this.PLAYER_CAMERA_BUMPER.CameraLag = *(float*)(byteptr_t + 0x754);
            this.PLAYER_CAMERA_BUMPER.CameraHeight = *(float*)(byteptr_t + 0x758);
            this.PLAYER_CAMERA_BUMPER.CameraLatOffset = *(float*)(byteptr_t + 0x75C);
            this.PLAYER_CAMERA_DRIVER.CameraAngle = ((float)*(short*)(byteptr_t + 0x762)) * 180 / 32768;
            this.PLAYER_CAMERA_DRIVER.CameraLag = *(float*)(byteptr_t + 0x764);
            this.PLAYER_CAMERA_DRIVER.CameraHeight = *(float*)(byteptr_t + 0x768);
            this.PLAYER_CAMERA_DRIVER.CameraLatOffset = *(float*)(byteptr_t + 0x76C);
            this.PLAYER_CAMERA_HOOD.CameraAngle = ((float)*(short*)(byteptr_t + 0x772)) * 180 / 32768;
            this.PLAYER_CAMERA_HOOD.CameraLag = *(float*)(byteptr_t + 0x774);
            this.PLAYER_CAMERA_HOOD.CameraHeight = *(float*)(byteptr_t + 0x778);
            this.PLAYER_CAMERA_HOOD.CameraLatOffset = *(float*)(byteptr_t + 0x77C);
            this.PLAYER_CAMERA_DRIFT.CameraAngle = ((float)*(short*)(byteptr_t + 0x782)) * 180 / 32768;
            this.PLAYER_CAMERA_DRIFT.CameraLag = *(float*)(byteptr_t + 0x784);
            this.PLAYER_CAMERA_DRIFT.CameraHeight = *(float*)(byteptr_t + 0x788);
            this.PLAYER_CAMERA_DRIFT.CameraLatOffset = *(float*)(byteptr_t + 0x78C);

            // AI Cameras
            this.AI_CAMERA_FAR.CameraAngle = ((float)*(short*)(byteptr_t + 0x792)) * 180 / 32768;
            this.AI_CAMERA_FAR.CameraLag = *(float*)(byteptr_t + 0x794);
            this.AI_CAMERA_FAR.CameraHeight = *(float*)(byteptr_t + 0x798);
            this.AI_CAMERA_FAR.CameraLatOffset = *(float*)(byteptr_t + 0x79C);
            this.AI_CAMERA_CLOSE.CameraAngle = ((float)*(short*)(byteptr_t + 0x7A2)) * 180 / 32768;
            this.AI_CAMERA_CLOSE.CameraLag = *(float*)(byteptr_t + 0x7A4);
            this.AI_CAMERA_CLOSE.CameraHeight = *(float*)(byteptr_t + 0x7A8);
            this.AI_CAMERA_CLOSE.CameraLatOffset = *(float*)(byteptr_t + 0x7AC);
            this.AI_CAMERA_BUMPER.CameraAngle = ((float)*(short*)(byteptr_t + 0x7B2)) * 180 / 32768;
            this.AI_CAMERA_BUMPER.CameraLag = *(float*)(byteptr_t + 0x7B4);
            this.AI_CAMERA_BUMPER.CameraHeight = *(float*)(byteptr_t + 0x7B8);
            this.AI_CAMERA_BUMPER.CameraLatOffset = *(float*)(byteptr_t + 0x7BC);
            this.AI_CAMERA_DRIVER.CameraAngle = ((float)*(short*)(byteptr_t + 0x7C2)) * 180 / 32768;
            this.AI_CAMERA_DRIVER.CameraLag = *(float*)(byteptr_t + 0x7C4);
            this.AI_CAMERA_DRIVER.CameraHeight = *(float*)(byteptr_t + 0x7C8);
            this.AI_CAMERA_DRIVER.CameraLatOffset = *(float*)(byteptr_t + 0x7CC);
            this.AI_CAMERA_HOOD.CameraAngle = ((float)*(short*)(byteptr_t + 0x7D2)) * 180 / 32768;
            this.AI_CAMERA_HOOD.CameraLag = *(float*)(byteptr_t + 0x7D4);
            this.AI_CAMERA_HOOD.CameraHeight = *(float*)(byteptr_t + 0x7D8);
            this.AI_CAMERA_HOOD.CameraLatOffset = *(float*)(byteptr_t + 0x7DC);
            this.AI_CAMERA_DRIFT.CameraAngle = ((float)*(short*)(byteptr_t + 0x7E2)) * 180 / 32768;
            this.AI_CAMERA_DRIFT.CameraLag = *(float*)(byteptr_t + 0x7E4);
            this.AI_CAMERA_DRIFT.CameraHeight = *(float*)(byteptr_t + 0x7E8);
            this.AI_CAMERA_DRIFT.CameraLatOffset = *(float*)(byteptr_t + 0x7EC);

            // Rigid Controls
            this._rigid_controls = new ushort[40];
            for (int a1 = 0; a1 < 40; ++a1)
                this._rigid_controls[a1] = *(ushort*)(byteptr_t + 0x7F0 + a1 * 2);

            // Secondary Properties
            uint key = 0;
            this.Index = *(int*)(byteptr_t + 0x840);
            this.UsageType = (eUsageType)(*(int*)(byteptr_t + 0x844));
            key = *(uint*)(byteptr_t + 0x84C);
            this._defaultbasepaint = Map.Lookup(key, true) ?? BaseArguments.NULL;
            key = *(uint*)(byteptr_t + 0x850);
            this._defaultbasepaint2 = Map.Lookup(key, true) ?? BaseArguments.NULL;
            this.MaxInstances1 = *(byteptr_t + 0x854);
            this.MaxInstances2 = *(byteptr_t + 0x855);
            this.MaxInstances3 = *(byteptr_t + 0x856);
            this.MaxInstances4 = *(byteptr_t + 0x857);
            this.MaxInstances5 = *(byteptr_t + 0x858);
            this.KeepLoaded1 = *(byteptr_t + 0x859);
            this.KeepLoaded1 = *(byteptr_t + 0x85A);
            this.KeepLoaded1 = *(byteptr_t + 0x85B);
            this.KeepLoaded1 = *(byteptr_t + 0x85C);
            this.KeepLoaded1 = *(byteptr_t + 0x85D);
            this.Padding1 = *(short*)(byteptr_t + 0x85E);
            this.MinTimeBetweenUses1 = *(float*)(byteptr_t + 0x860);
            this.MinTimeBetweenUses2 = *(float*)(byteptr_t + 0x864);
            this.MinTimeBetweenUses3 = *(float*)(byteptr_t + 0x868);
            this.MinTimeBetweenUses4 = *(float*)(byteptr_t + 0x86C);
            this.MinTimeBetweenUses5 = *(float*)(byteptr_t + 0x870);
            this.DefaultSkinNumber = (byte)(*(int*)(byteptr_t + 0x874));
            this.Padding2 = *(int*)(byteptr_t + 0x878);
            this.AvailableSkinNumbers01 = *(byteptr_t + 0x880);
            this.AvailableSkinNumbers02 = *(byteptr_t + 0x881);
            this.AvailableSkinNumbers03 = *(byteptr_t + 0x882);
            this.AvailableSkinNumbers04 = *(byteptr_t + 0x883);
            this.AvailableSkinNumbers05 = *(byteptr_t + 0x884);
            this.AvailableSkinNumbers06 = *(byteptr_t + 0x885);
            this.AvailableSkinNumbers07 = *(byteptr_t + 0x886);
            this.AvailableSkinNumbers08 = *(byteptr_t + 0x887);
            this.AvailableSkinNumbers09 = *(byteptr_t + 0x888);
            this.AvailableSkinNumbers10 = *(byteptr_t + 0x889);
            this._is_suv = (*(short*)(byteptr_t + 0x88A) == 1)
                ? eBoolean.True
                : eBoolean.False;
            this.IsSkinnable = (*(int*)(byteptr_t + 0x88C) == 0)
                ? eBoolean.False
                : eBoolean.True;
        }
    }
}