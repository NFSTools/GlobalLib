namespace GlobalLib.Support.Shared.Class
{
    public class CarTypeInfo : Reflection.Abstract.Collectable
    {
        #region Private Fields

        private string _manufacturer_name;
        private string _collision_internal_name = Reflection.BaseArguments.NULL;
        private int _index = -1;
        private Reflection.Enum.eUsageType _usagetype = Reflection.Enum.eUsageType.Racer;
        private Reflection.Enum.eMemoryType _memorytype = Reflection.Enum.eMemoryType.Racing;
        private Reflection.Enum.eBoolean _is_skinnable = Reflection.Enum.eBoolean.True;
        private string _defaultbasepaint = Reflection.BaseArguments.BPAINT;

		#endregion

		#region Main Properties

		/// <summary>
		/// Collection name of the variable.
		/// </summary>
		public override string CollectionName { get; set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public virtual uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public virtual uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }

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
        [Reflection.Attributes.AccessModifiable()]
        public string ManufacturerName
        {
            get => this._manufacturer_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                if (value.Length > 15)
                    throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
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
                if (value == Reflection.BaseArguments.NULL || Core.Map.CollisionMap.ContainsValue(value))
                    this._collision_internal_name = value;
                else
                    throw new Reflection.Exception.MappingFailException();
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
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
                else
                    this._index = value;
            }
        }

        /// <summary>
        /// Represents usage type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eUsageType UsageType
        {
            get => this._usagetype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eUsageType), value))
                {
                    //if (!this.Deletable)
                    //    throw new System.Exception("Usage type of a core car cannot be changed.");
                    if (this._usagetype != value)
                        this.Modified = true;
                    this._usagetype = value;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents memory type of the cartypeinfo.
        /// </summary>
        public virtual Reflection.Enum.eMemoryType MemoryType
        {
            get => this._memorytype;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eMemoryType), value))
                    this._memorytype = value;
                else
                    throw new System.ArgumentOutOfRangeException("Value passed was outside of range of possible values.");
            }
        }

        /// <summary>
        /// Represents boolean as an int of whether cartypeinfo is skinnable.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsSkinnable
        {
            get => this._is_skinnable;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                    this._is_skinnable = value;
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// Represents paint type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public virtual string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (value == Reflection.BaseArguments.NULL || Core.Map.BinKeys.ContainsValue(value))
                    this._defaultbasepaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }

        [Reflection.Attributes.AccessModifiable()]
        public float HeadlightFOV { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte PadHighPerformance { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte NumAvailableSkinNumbers { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte WhatGame { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte ConvertibleFlag { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte WheelOuterRadius { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte WheelOuterRadiusMin { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte WheelInnerRadiusMax { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte Padding0 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float HeadlightPositionX { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float HeadlightPositionY { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float HeadlightPositionZ { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float HeadlightPositionW { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float DriverRenderingOffsetX { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float DriverRenderingOffsetY { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float DriverRenderingOffsetZ { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float DriverRenderingOffsetW { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float SteeringWheelRenderingX { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float SteeringWheelRenderingY { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float SteeringWheelRenderingZ { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float SteeringWheelRenderingW { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte MaxInstances1 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte MaxInstances2 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte MaxInstances3 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte MaxInstances4 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte MaxInstances5 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte KeepLoaded1 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte KeepLoaded2 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte KeepLoaded3 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte KeepLoaded4 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte KeepLoaded5 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public short Padding1 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float MinTimeBetweenUses1 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float MinTimeBetweenUses2 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float MinTimeBetweenUses3 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float MinTimeBetweenUses4 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public float MinTimeBetweenUses5 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers01 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers02 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers03 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers04 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers05 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers06 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers07 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers08 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers09 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte AvailableSkinNumbers10 { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public byte DefaultSkinNumber { get; set; } = 0;

        [Reflection.Attributes.AccessModifiable()]
        public int Padding2 { get; set; } = 0;

        #endregion

        #region Methods

        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <param name="index">Index of the cartypeinfo.</param>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public virtual unsafe byte[] Assemble(int index) { return null; }

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
        public override Reflection.Abstract.Collectable MemoryCast(string CName)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}