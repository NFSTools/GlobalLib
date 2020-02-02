namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName)
        {
            this.CollectionName = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(byte* byteptr_t, string CName)
        {
            this.CollectionName = CName;
            this.Disassemble(byteptr_t);
        }

        ~Material() { }
    }
}