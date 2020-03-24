namespace GlobalLib.Support.Carbon.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        // Default constructor
        public Material() { }

        // Default constructor: create new material
        public Material(string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble material
        public unsafe Material(System.IntPtr byteptr_t, string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        ~Material() { }
    }
}