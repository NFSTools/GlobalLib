using System;
using System.Reflection;



namespace GlobalLib.Reflection.Abstract
{
	public class CollectionAttrib
	{
		public PropertyInfo Attribute { get; set; }
		public object Parent { get; set; }
		public string FullPath { get; set; }
		public string Directory { get; set; }
		public string PropertyName { get => this.Attribute.Name; }
		public string Value { get => this.Attribute.GetValue(Parent).ToString(); }
		public Type PropertyType { get => this.Attribute.PropertyType; }
		public MethodInfo Set { get => this.Attribute.GetSetMethod(); }

		public CollectionAttrib() { }

		public CollectionAttrib(PropertyInfo property, object parent)
		{
			this.Parent = parent;
			this.Attribute = property;
		}

		public override string ToString()
		{
			return $"{FullPath} | {PropertyType.ToString()}";
		}
	}
}
