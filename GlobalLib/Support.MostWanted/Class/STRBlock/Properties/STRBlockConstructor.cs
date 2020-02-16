namespace GlobalLib.Support.MostWanted.Class
{
	public partial class STRBlock : Shared.Class.STRBlock
	{
		// Default constructor
		public STRBlock() { }

		// Default constructor: disassemble string block
		public unsafe STRBlock(byte* byteptr_t, int length, Database.MostWanted db)
		{
			this.Database = db;
			this.Disassemble(byteptr_t, length);
		}

		~STRBlock() { }
	}
}