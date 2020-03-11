using System;



namespace GlobalLib.Reflection.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	class AccessModifiableAttribute : Attribute
	{
	}
}