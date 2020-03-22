namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.Initialize();
            this.data = new byte[0x338];
            this.CollectionName = CName;
            this.MODEL = "SUPRA";
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(byte* byteptr_t, string CName, Database.Underground2 db)
        {
            this.Database = db;
            this.Initialize();
            this.data = new byte[0x338];
            this.CollectionName = CName;
            this.Exists = true;
            this.Disassemble(byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}