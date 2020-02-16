namespace GlobalLib.Support.Shared.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Disassembles string block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the string block array.</param>
		protected virtual unsafe void Disassemble(byte* byteptr_t, int length) { }
	}
}