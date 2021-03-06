﻿using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Enum;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the cartypeinfo array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            // Get Manufacturer name
            var name = ScriptX.NullTerminatedString(byteptr_t + 0x40, 0x10);
            if (string.IsNullOrWhiteSpace(name)) this.ManufacturerName = BaseArguments.NULL;
            else this.ManufacturerName = name;

            this.HeadlightFOV = *(float*)(byteptr_t + 0x54);
            this.PadHighPerformance = *(byteptr_t + 0x58);
            this.NumAvailableSkinNumbers = *(byteptr_t + 0x59);
            this.WhatGame = *(byteptr_t + 0x5A);
            this.ConvertibleFlag = *(byteptr_t + 0x5B);
            this.WheelOuterRadius = *(byteptr_t + 0x5C);
            this.WheelInnerRadiusMin = *(byteptr_t + 0x5D);
            this.WheelInnerRadiusMax = *(byteptr_t + 0x5E);
            this.Padding0 = *(byteptr_t + 0x5F);
            this.HeadlightPositionX = *(float*)(byteptr_t + 0x60);
            this.HeadlightPositionY = *(float*)(byteptr_t + 0x64);
            this.HeadlightPositionZ = *(float*)(byteptr_t + 0x68);
            this.HeadlightPositionW = *(float*)(byteptr_t + 0x6C);
            this.DriverRenderingOffsetX = *(float*)(byteptr_t + 0x70);
            this.DriverRenderingOffsetY = *(float*)(byteptr_t + 0x74);
            this.DriverRenderingOffsetZ = *(float*)(byteptr_t + 0x78);
            this.DriverRenderingOffsetW = *(float*)(byteptr_t + 0x7C);
            this.SteeringWheelRenderingX = *(float*)(byteptr_t + 0x80);
            this.SteeringWheelRenderingY = *(float*)(byteptr_t + 0x84);
            this.SteeringWheelRenderingZ = *(float*)(byteptr_t + 0x88);
            this.SteeringWheelRenderingW = *(float*)(byteptr_t + 0x8C);

            this.Index = *(int*)(byteptr_t + 0x90);
            this.UsageType = (eUsageType)(*(int*)(byteptr_t + 0x94));
            this.MemoryType = (eMemoryType)(*(uint*)(byteptr_t + 0x98));

            this.MaxInstances1 = *(byteptr_t + 0x9C);
            this.MaxInstances2 = *(byteptr_t + 0x9D);
            this.MaxInstances3 = *(byteptr_t + 0x9E);
            this.MaxInstances4 = *(byteptr_t + 0x9F);
            this.MaxInstances5 = *(byteptr_t + 0xA0);
            this.KeepLoaded1 = *(byteptr_t + 0xA1);
            this.KeepLoaded2 = *(byteptr_t + 0xA2);
            this.KeepLoaded3 = *(byteptr_t + 0xA3);
            this.KeepLoaded4 = *(byteptr_t + 0xA4);
            this.KeepLoaded5 = *(byteptr_t + 0xA5);
            this.Padding1 = *(short*)(byteptr_t + 0xA6);
            this.MinTimeBetweenUses1 = *(float*)(byteptr_t + 0xA8);
            this.MinTimeBetweenUses2 = *(float*)(byteptr_t + 0xAC);
            this.MinTimeBetweenUses3 = *(float*)(byteptr_t + 0xB0);
            this.MinTimeBetweenUses4 = *(float*)(byteptr_t + 0xB4);
            this.MinTimeBetweenUses5 = *(float*)(byteptr_t + 0xB8);
            this.AvailableSkinNumbers01 = *(byteptr_t + 0xBC);
            this.AvailableSkinNumbers02 = *(byteptr_t + 0xBD);
            this.AvailableSkinNumbers03 = *(byteptr_t + 0xBE);
            this.AvailableSkinNumbers04 = *(byteptr_t + 0xBF);
            this.AvailableSkinNumbers05 = *(byteptr_t + 0xC0);
            this.AvailableSkinNumbers06 = *(byteptr_t + 0xC1);
            this.AvailableSkinNumbers07 = *(byteptr_t + 0xC2);
            this.AvailableSkinNumbers08 = *(byteptr_t + 0xC3);
            this.AvailableSkinNumbers09 = *(byteptr_t + 0xC4);
            this.AvailableSkinNumbers10 = *(byteptr_t + 0xC5);

            this.DefaultSkinNumber = *(byteptr_t + 0xC6);
            this.IsSkinnable = (*(byteptr_t + 0xC7) == 0)
                ? eBoolean.False
                : eBoolean.True;
            this.Padding2 = *(int*)(byteptr_t + 0xC8);

            uint key = *(uint*)(byteptr_t + 0xCC);
            this.DefaultBasePaint = Map.Lookup(key, true) ?? BaseArguments.BPAINT;
        }
    }
}