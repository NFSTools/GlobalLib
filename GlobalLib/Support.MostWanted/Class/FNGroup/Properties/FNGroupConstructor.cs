namespace GlobalLib.Support.MostWanted.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        // Default constructor
        FNGroup() { }

        // Default constructor: disassemble frontend group
        public FNGroup(byte[] data)
        {
            this.Disassemble(data);
        }

        ~FNGroup() { }
    }
}