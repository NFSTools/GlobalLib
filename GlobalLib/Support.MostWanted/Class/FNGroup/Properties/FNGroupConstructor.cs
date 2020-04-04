namespace GlobalLib.Support.MostWanted.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        public FNGroup() { }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data, Database.MostWanted db)
        {
            this.Database = db;
            this.Disassemble(data);
        }

        ~FNGroup() { }
    }
}