namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide
	{
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.CollectionName = CName;
            this.Initialize();
            this.data = new byte[0x338];
            this.MODEL = "SUPRA";
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(System.IntPtr byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this._collection_name = CName;
            this.Initialize();
            this.data = new byte[0x338];
            this.Exists = true;
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}