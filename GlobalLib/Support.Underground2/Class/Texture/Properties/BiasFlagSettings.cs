namespace GlobalLib.Support.Underground2.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        private byte _bias_level = 0;
        private byte _rendering_order = 5;
        private byte _used_flag = 0;
        private byte _flags = 0;
        private byte _padding = 1;
    }
}