using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private ushort[] _rigid_controls;
        private eBoolean _is_suv = eBoolean.False;

        /// <summary>
        /// Defines whether the car is an SUV.
        /// </summary>
        [AccessModifiable()]
        public eBoolean IsSUV
        {
            get => this._is_suv;
            set
            {
                if (Enum.IsDefined(typeof(eBoolean), value))
                    this._is_suv = value;
                else
                    throw new InvalidCastException("Value passed is not of boolean type.");
            }
        }

        public override string CollisionInternalName { get => this._collection_name; }
    }
}