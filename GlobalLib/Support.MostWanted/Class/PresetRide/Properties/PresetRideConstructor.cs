namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        // Default constructor
        public PresetRide() { }

        // Default constructor: create new preset
        public PresetRide(string v1)
        {
            this.data = new byte[0x290];
            this.CollectionName = v1;
            this.MODEL = "SUPRA";
            this.Frontend = "supra";
            this.Pvehicle = "supra";
            this.Modified = true;
        }

        // Default constructor: disassemble preset
        public unsafe PresetRide(byte* byteptr_t, string CName)
        {
            this.data = new byte[0x290];
            this.CollectionName = CName;
            this.Exists = true;
            this.Disassemble(byteptr_t);
            this.Modified = false;
        }

        // Default destructor
        ~PresetRide() { }
    }
}