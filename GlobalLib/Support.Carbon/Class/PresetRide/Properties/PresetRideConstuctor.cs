namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string CName)
        {
            this.data = new byte[0x600];
            this.CollectionName = CName;
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            this.FRONTBUMPER = new Parts.PresetParts.Autosculpt();
            this.REARBUMPER = new Parts.PresetParts.Autosculpt();
            this.ROOFSCOOP = new Parts.PresetParts.Autosculpt();
            this.SPOILER = new Parts.PresetParts.Autosculpt();
            this.WHEELS = new Parts.PresetParts.Autosculpt();
            this.SKIRT = new Parts.PresetParts.Autosculpt();
            this.HOOD = new Parts.PresetParts.Autosculpt();
            this.Vinyls = new Parts.PresetParts.Vinyl[20];
            for (int i = 0; i < 20; ++i)
                this.Vinyls[i] = new Parts.PresetParts.Vinyl();
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(byte* byteptr_t, string CName)
        {
            this.data = new byte[0x600];
            this.CollectionName = CName;
            this.Exists = true;
            this.FRONTBUMPER = new Parts.PresetParts.Autosculpt();
            this.REARBUMPER = new Parts.PresetParts.Autosculpt();
            this.ROOFSCOOP = new Parts.PresetParts.Autosculpt();
            this.SPOILER = new Parts.PresetParts.Autosculpt();
            this.WHEELS = new Parts.PresetParts.Autosculpt();
            this.SKIRT = new Parts.PresetParts.Autosculpt();
            this.HOOD = new Parts.PresetParts.Autosculpt();
            this.Vinyls = new Parts.PresetParts.Vinyl[20];
            for (int i = 0; i < 20; ++i)
                this.Vinyls[i] = new Parts.PresetParts.Vinyl();
            this.Disassemble(byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}