namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private ushort[] _rigid_controls;
        private Reflection.Enum.eBoolean _is_suv = Reflection.Enum.eBoolean.False;
        private string _used_carparts_of = "SUPRA";

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

        [Reflection.Attributes.AccessModifiable()]
        public string UsesCarPartsOf
        {
            get => this._used_carparts_of;
            set
            {
                if (value != this._collection_name && !Core.Map.CarPartsMap.Contains(value))
                    throw new Reflection.Exception.MappingFailException("CarPart list of the car specified does not exist.");
                this._used_carparts_of = value;
            }
        }

        public override string CollisionInternalName { get => this._collection_name; }
    }
}