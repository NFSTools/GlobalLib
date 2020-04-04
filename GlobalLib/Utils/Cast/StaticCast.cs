using System;



namespace GlobalLib.Utils
{
	public static partial class Cast
	{
		/// <summary>
		/// Casts any object to any type specified. Throws exception in case cast fails.
		/// </summary>
		/// <typeparam name="TypeID">Type to be converted to.</typeparam>
		/// <param name="value">Object passed to be casted.</param>
		/// <returns>Casted value of type specified. If casting fails, exception will be thrown.</returns>
		public static TypeID StaticCast<TypeID>(IConvertible value) where TypeID : IConvertible
		{
			return (TypeID)Convert.ChangeType(value, typeof(TypeID));
		}
	}
}
