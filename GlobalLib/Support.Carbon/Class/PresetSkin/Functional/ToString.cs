﻿namespace GlobalLib.Support.Carbon.Class
{
	public partial class PresetSkin
	{
		public override string ToString()
		{
			return $"Collection Name: {this.CollectionName} | " +
				   $"BinKey: {this.BinKey.ToString("X8")} | Game: {this.GameSTR}";
		}
	}
}