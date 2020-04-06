using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;
using System.IO;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <param name="index">Index of the cartypeinfo.</param>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public override unsafe byte[] Assemble()
        {
            byte[] result = new byte[0xD0];
            fixed (byte* byteptr_t = &result[0])
            {
                // Write CollectionName
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + a1) = (byte)this.CollectionName[a1];

                // Write BaseModelName
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + 0x10 + a1) = (byte)this.CollectionName[a1];

                // Write GeometryFileName
                string path = Path.Combine("CARS", this.CollectionName, "GEOMETRY.BIN");
                for (int a1 = 0; a1 < path.Length; ++a1)
                    *(byteptr_t + 0x20 + a1) = (byte)path[a1];

                // Write ManufacturerName
                for (int a1 = 0; a1 < this.ManufacturerName.Length; ++a1)
                    *(byteptr_t + 0x40 + a1) = (byte)this.ManufacturerName[a1];

                // Write all settings
                *(uint*)(byteptr_t + 0x50) = this.BinKey;
                *(float*)(byteptr_t + 0x54) = this.HeadlightFOV;
                *(byteptr_t + 0x58) = this.PadHighPerformance;
                *(byteptr_t + 0x59) = this.NumAvailableSkinNumbers;
                *(byteptr_t + 0x5A) = this.WhatGame;
                *(byteptr_t + 0x5B) = this.ConvertibleFlag;
                *(byteptr_t + 0x5C) = this.WheelOuterRadius;
                *(byteptr_t + 0x5D) = this.WheelOuterRadiusMin;
                *(byteptr_t + 0x5E) = this.WheelInnerRadiusMax;
                *(byteptr_t + 0x5F) = this.Padding0;
                *(float*)(byteptr_t + 0x60) = this.HeadlightPositionX;
                *(float*)(byteptr_t + 0x64) = this.HeadlightPositionY;
                *(float*)(byteptr_t + 0x68) = this.HeadlightPositionZ;
                *(float*)(byteptr_t + 0x6C) = this.HeadlightPositionW;
                *(float*)(byteptr_t + 0x70) = this.DriverRenderingOffsetX;
                *(float*)(byteptr_t + 0x74) = this.DriverRenderingOffsetY;
                *(float*)(byteptr_t + 0x78) = this.DriverRenderingOffsetZ;
                *(float*)(byteptr_t + 0x7C) = this.DriverRenderingOffsetW;
                *(float*)(byteptr_t + 0x80) = this.SteeringWheelRenderingX;
                *(float*)(byteptr_t + 0x84) = this.SteeringWheelRenderingY;
                *(float*)(byteptr_t + 0x88) = this.SteeringWheelRenderingZ;
                *(float*)(byteptr_t + 0x8C) = this.SteeringWheelRenderingW;

                *(int*)(byteptr_t + 0x90) = this.Index;
                *(int*)(byteptr_t + 0x94) = (int)this.UsageType;
                *(uint*)(byteptr_t + 0x98) = (uint)this.MemoryType;

                *(byteptr_t + 0x9C) = this.MaxInstances1;
                *(byteptr_t + 0x9D) = this.MaxInstances2;
                *(byteptr_t + 0x9E) = this.MaxInstances3;
                *(byteptr_t + 0x9F) = this.MaxInstances4;
                *(byteptr_t + 0xA0) = this.MaxInstances5;
                *(byteptr_t + 0xA1) = this.KeepLoaded1;
                *(byteptr_t + 0xA2) = this.KeepLoaded2;
                *(byteptr_t + 0xA3) = this.KeepLoaded3;
                *(byteptr_t + 0xA4) = this.KeepLoaded4;
                *(byteptr_t + 0xA5) = this.KeepLoaded5;
                *(short*)(byteptr_t + 0xA6) = this.Padding1;
                *(float*)(byteptr_t + 0xA8) = this.MinTimeBetweenUses1;
                *(float*)(byteptr_t + 0xAC) = this.MinTimeBetweenUses2;
                *(float*)(byteptr_t + 0xB0) = this.MinTimeBetweenUses3;
                *(float*)(byteptr_t + 0xB4) = this.MinTimeBetweenUses4;
                *(float*)(byteptr_t + 0xB8) = this.MinTimeBetweenUses5;
                *(byteptr_t + 0xBC) = this.AvailableSkinNumbers01;
                *(byteptr_t + 0xBD) = this.AvailableSkinNumbers02;
                *(byteptr_t + 0xBE) = this.AvailableSkinNumbers03;
                *(byteptr_t + 0xBF) = this.AvailableSkinNumbers04;
                *(byteptr_t + 0xC0) = this.AvailableSkinNumbers05;
                *(byteptr_t + 0xC1) = this.AvailableSkinNumbers06;
                *(byteptr_t + 0xC2) = this.AvailableSkinNumbers07;
                *(byteptr_t + 0xC3) = this.AvailableSkinNumbers08;
                *(byteptr_t + 0xC4) = this.AvailableSkinNumbers09;
                *(byteptr_t + 0xC5) = this.AvailableSkinNumbers10;

                *(byteptr_t + 0xC6) = this.DefaultSkinNumber;
                *(byteptr_t + 0xC7) = (this.IsSkinnable == eBoolean.True) ? (byte)1 : (byte)0;
                *(int*)(byteptr_t + 0xC8) = this.Padding2;
                *(uint*)(byteptr_t + 0xCC) = Bin.SmartHash(this.DefaultBasePaint);
            }
            return result;
        }
    }
}