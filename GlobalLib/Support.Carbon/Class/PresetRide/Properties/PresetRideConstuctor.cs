namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.Carbon db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.data = new byte[0x600];
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            this.Initialize();
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(System.IntPtr byteptr_t, string CName, Database.Carbon db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.data = new byte[0x600];
            this.Exists = true;
            this.Initialize();
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}