namespace GlobalLib.Support.Underground2.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(byte* byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Disassemble(byteptr_t);
        }

        ~Material() { }
    }
}