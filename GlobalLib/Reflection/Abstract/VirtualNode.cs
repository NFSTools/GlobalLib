using System.Collections.Generic;



namespace GlobalLib.Reflection.Abstract
{
	public class VirtualNode
	{
		public string NodeName { get; set; }
		public List<VirtualNode> SubNodes { get; set; }

		public VirtualNode(string NodeName)
		{
			this.NodeName = NodeName;
			this.SubNodes = new List<VirtualNode>();
		}

		public override string ToString()
		{
			return $"{this.NodeName}: {SubNodes.Count} nodes";
		}
	}
}
