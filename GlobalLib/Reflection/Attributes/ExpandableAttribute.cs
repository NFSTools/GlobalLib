namespace GlobalLib.Reflection.Attributes
{
	/// <summary>
	/// Indicates that the property is an expandable class of a node.
	/// </summary>
	class ExpandableAttribute : System.Attribute
	{
		/// <summary>
		/// Parent of the property and/or node.
		/// </summary>
		public string Name { get; set; }

		public ExpandableAttribute(string Name)
		{
			this.Name = Name;
		}
	}
}