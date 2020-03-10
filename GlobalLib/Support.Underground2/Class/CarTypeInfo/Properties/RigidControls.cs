namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private ushort[] _rigid_controls;
        private bool _is_suv = false;

        /// <summary>
        /// Defines whether the car is an SUV.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string IsSUV
        {
            get => this._is_suv ? Reflection.BaseArguments.TRUE : Reflection.BaseArguments.FALSE;
            set
            {
                if (value == Reflection.BaseArguments.TRUE)
                    this._is_suv = true;
                else if (value == Reflection.BaseArguments.FALSE)
                    this._is_suv = false;
                else
                    throw new System.InvalidCastException("Value passed is not of boolean type.");
            }
        }

        public override string CollisionInternalName { get => this._collection_name; }
    }
}