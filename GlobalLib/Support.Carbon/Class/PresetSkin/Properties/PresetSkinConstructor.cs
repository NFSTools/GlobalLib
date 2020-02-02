namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin, Reflection.Interface.ICastable<PresetSkin>
    {
        // Default constructor
        public PresetSkin() { }

        // Default constructor: create new skin
        public PresetSkin(string CName)
        {
            this.CollectionName = CName;
        }

        // Default constructor: disassemble skin
        public unsafe PresetSkin(byte* byteptr_t, string CName)
        {
            this.CollectionName = CName;
            this.Disassemble(byteptr_t);
        }

        // Default destructor
        ~PresetSkin() { }
    }
}