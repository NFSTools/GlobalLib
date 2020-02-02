namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        private byte _scroll_type = 0;
        private short _scroll_timestep = 0;
        private short _scroll_speedS = 0;
        private short _scroll_speedT = 0;
    }
}