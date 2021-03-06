﻿using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class WorldShop
	{
		private string _shop_filename;

		[AccessModifiable()]
		public string ShopFilename
		{
			get => this._shop_filename;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value.Length > 0xF)
					throw new ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
				this._shop_filename = value;
			}
		}
	}
}