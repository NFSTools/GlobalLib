using System;



namespace GlobalLib.Database
{
	public partial class Underground1
	{
		/// <summary>
		/// Throws <see cref="NotImplementedException"/>.
		/// </summary>
		public override bool TryAddCollision(string CName, string filename, out string error)
		{
			error = $"Import of collisions is not supported";
			return false;
		}
	}
}