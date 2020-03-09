namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class SunInfo
	{
		/// <summary>
		/// Sets value at a field specified.
		/// </summary>
		/// <param name="PropertyName">Name of the field to be modified.</param>
		/// <param name="value">Value to be set at the field specified.</param>
		public override bool SetValue(string PropertyName, object value)
		{
			return base.SetValue(PropertyName, value);
		}

		/// <summary>
		/// Sets value at a field specified.
		/// </summary>
		/// <param name="PropertyName">Name of the field to be modified.</param>
		/// <param name="value">Value to be set at the field specified.</param>
		/// <param name="error">Error occured in case setting value fails.</param>
		public override bool SetValue(string PropertyName, object value, ref string error)
		{
			return base.SetValue(PropertyName, value, ref error);
		}
	}
}