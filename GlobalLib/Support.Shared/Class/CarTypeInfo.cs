using System;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Attributes;



namespace GlobalLib.Support.Shared.Class
{
    public class CarTypeInfo : Collectable
    {
        #region Private Fields

        private string _manufacturer_name;
        private string _collision_internal_name = BaseArguments.NULL;
        private int _index = -1;
        private eUsageType _usagetype = eUsageType.Racer;
        private eMemoryType _memorytype = eMemoryType.Racing;
        private eBoolean _is_skinnable = eBoolean.True;
        private string _defaultbasepaint = BaseArguments.BPAINT;

		#endregion

		#region Main Properties

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		public override string CollectionName { get; set; }

        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.None; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.None.ToString(); }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Provides info on whether this cartypeinfo was modified.
        /// </summary>
        public bool Modified { get; set; } = false;

        /// <summary>
        /// Original collection name of the cartypeinfo.
        /// </summary>
        public string OriginalName { get; protected set; }

        #endregion

        #region AccessModifiable Properties

        /// <summary>
        /// Represents manufacturer name of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        public string ManufacturerName
        {
            get => this._manufacturer_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                if (value.Length > 15)
                    throw new ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
                this._manufacturer_name = value;
            }
        }

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        public virtual string CollisionInternalName
        {
            get => this._collision_internal_name;
            set
            {
                if (value == BaseArguments.NULL || Map.CollisionMap.ContainsValue(value))
                    this._collision_internal_name = value;
                else
                    throw new MappingFailException();
            }
        }

        /// <summary>
        /// Represents index of the cartypeinfo in Global data.
        /// </summary>
        public int Index
        {
            get => this._index;
            set
            {
                if (value > byte.MaxValue || value < byte.MinValue)
                    throw new ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
                else
                    this._index = value;
            }
        }

        /// <summary>
        /// Represents usage type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        public eUsageType UsageType
        {
            get => this._usagetype;
            set
            {
                if (Enum.IsDefined(typeof(eUsageType), value))
                {
                    //if (!this.Deletable)
                    //    throw new Exception("Usage type of a core car cannot be changed.");
                    if (this._usagetype != value)
                        this.Modified = true;
                    this._usagetype = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        public virtual eMemoryType MemoryType
        {
            get => this._memorytype;
            set
            {
                if (Enum.IsDefined(typeof(eMemoryType), value))
                    this._memorytype = value;
                else
                    throw new ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents boolean as an int of whether cartypeinfo is skinnable.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eBoolean IsSkinnable
        {
            get => this._is_skinnable;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    this._is_skinnable = value;
                else
                    throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Represents paint type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public virtual string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (value == BaseArguments.NULL || Map.BinKeys.ContainsValue(value))
                    this._defaultbasepaint = value;
                else
                    throw new MappingFailException();
            }
        }

        [AccessModifiable()]
        [StaticModifiable()]
        public float HeadlightFOV { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte PadHighPerformance { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte NumAvailableSkinNumbers { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte WhatGame { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte ConvertibleFlag { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte WheelOuterRadius { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte WheelInnerRadiusMin { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte WheelInnerRadiusMax { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte Padding0 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float HeadlightPositionX { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float HeadlightPositionY { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float HeadlightPositionZ { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float HeadlightPositionW { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float DriverRenderingOffsetX { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float DriverRenderingOffsetY { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float DriverRenderingOffsetZ { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float DriverRenderingOffsetW { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float SteeringWheelRenderingX { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float SteeringWheelRenderingY { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float SteeringWheelRenderingZ { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float SteeringWheelRenderingW { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte MaxInstances1 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte MaxInstances2 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte MaxInstances3 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte MaxInstances4 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte MaxInstances5 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte KeepLoaded1 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte KeepLoaded2 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte KeepLoaded3 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte KeepLoaded4 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte KeepLoaded5 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public short Padding1 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float MinTimeBetweenUses1 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float MinTimeBetweenUses2 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float MinTimeBetweenUses3 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float MinTimeBetweenUses4 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public float MinTimeBetweenUses5 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers01 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers02 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers03 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers04 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers05 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers06 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers07 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers08 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers09 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte AvailableSkinNumbers10 { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public byte DefaultSkinNumber { get; set; } = 0;

        [AccessModifiable()]
        [StaticModifiable()]
        public int Padding2 { get; set; } = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles cartypeinfo array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the cartypeinfo array.</param>
        protected virtual unsafe void Disassemble(byte* byteptr_t) { }

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}