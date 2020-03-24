namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin
    {
        // Default constructor
        public PresetSkin() { }

        // Default constructor: create new skin
        public PresetSkin(string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
        }

        // Default constructor: disassemble skin
        public unsafe PresetSkin(System.IntPtr byteptr_t, string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Disassemble((byte*)byteptr_t);
        }

        // Default destructor
        ~PresetSkin() { }
    }
}