namespace GlobalLib.Support.Underground2.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        FNGroup() { }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data, Database.Underground2 db)
        {
            this.Database = db;
            this.Disassemble(data);
        }

        ~FNGroup() { }
    }
}