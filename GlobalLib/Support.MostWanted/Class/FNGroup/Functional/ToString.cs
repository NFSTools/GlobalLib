﻿namespace GlobalLib.Support.MostWanted.Class
{
	public partial class FNGroup
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}