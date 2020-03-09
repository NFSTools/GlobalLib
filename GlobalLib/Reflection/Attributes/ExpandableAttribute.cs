namespace GlobalLib.Reflection.Attributes
{
	class ExpandableAttribute : System.Attribute
	{
		public string Name { get; set; }

		public ExpandableAttribute(string Name)
		{
			this.Name = Name;
		}
	}
}