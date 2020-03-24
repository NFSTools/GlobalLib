namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.MostWanted db)
        {
            this.Database = db;
            this.data = new byte[0x290];
            this.CollectionName = CName;
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(System.IntPtr byteptr_t, string CName, Database.MostWanted db)
        {
            this.Database = db;
            this.data = new byte[0x290];
            this.CollectionName = CName;
            this.Exists = true;
            this.Disassemble((byte*)byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}