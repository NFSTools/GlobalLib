namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private ushort[] _rigid_controls;
        private Reflection.Enum.eBoolean _is_suv = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// Defines whether the car is an SUV.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsSUV
        {
            get => this._is_suv;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                    this._is_suv = value;
                else
                    throw new System.InvalidCastException("Value passed is not of boolean type.");
            }
        }

        public override string CollisionInternalName { get => this._collection_name; }
    }
}