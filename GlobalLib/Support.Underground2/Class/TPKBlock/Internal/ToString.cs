﻿namespace GlobalLib.Support.Underground2.Class
{
	public partial class TPKBlock : Shared.Class.TPKBlock
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}