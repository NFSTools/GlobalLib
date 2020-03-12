namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerInfo
	{
		public Database.Underground2 Database { get; set; }

		public GCareerInfo() { }

		public unsafe GCareerInfo(byte* byteptr_t, Database.Underground2 db)
		{
			this.Database = db;
			this.Diassemble(byteptr_t);
		}
	}
}