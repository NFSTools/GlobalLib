namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        public bool IsSUV { get; set; }
        private ushort[] _rigid_controls;
    }
}