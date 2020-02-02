namespace GlobalLib.Support.Carbon.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        private short _offsetS = 0;
        private short _offsetT = 0x100;
        private short _scaleS = 0x100;
        private short _scaleT = 0;
    }
}