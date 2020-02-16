namespace GlobalLib.Support.Shared.Class
{
	public partial class STRBlock
	{
		/// <summary>
		/// Disassembles labels block array into separate properties.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the label block array.</param>
		protected virtual unsafe void DisperseLabels(byte* byteptr_t, int length) { }
	}
}