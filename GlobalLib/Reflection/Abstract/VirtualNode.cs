using System.Collections.Generic;



namespace GlobalLib.Reflection.Abstract
{
	public class VirtualNode
	{
		public string NodeName { get; set; }
		public List<string> SubNodes { get; set; }

		public VirtualNode(string NodeName)
		{
			this.NodeName = NodeName;
			this.SubNodes = new List<string>();
		}
	}
}
