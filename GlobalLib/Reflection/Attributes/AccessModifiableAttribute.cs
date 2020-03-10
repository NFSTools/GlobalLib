using System;



namespace GlobalLib.Reflection.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
	class AccessModifiableAttribute : Attribute
	{
	}
}