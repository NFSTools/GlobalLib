namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        [Reflection.Attributes.AccessModifiable()]
        public bool IsSUV { get; set; }

        private ushort[] _rigid_controls;
    }
}